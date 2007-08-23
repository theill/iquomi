using System;
using System.Data;
using System.Web.Services;
using System.Web.Services.Protocols;

using log4net;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// 
	/// </summary>
	[WebService(Namespace="http://services.iquomi.com/")]
	public class WSAdmin : System.Web.Services.WebService {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);
		
		public SoapAuthenticationType Authentication;
		public SoapRequestType Request;
		
		public WSAdmin() {
			;
		}
		
		[WebMethod]
		[SoapHeader("Authentication")]
		public Service[] GetSubscriptionServices() {
			DbUtility db = new DbUtility();
			db.Cmd("iqSubscriptionServices", CommandType.StoredProcedure);
			db.In("@account_id", DbType.Int32, GetAccount().Id);
			db.In("@language_id", DbType.Int32, 1);
			
			log.Debug("Getting subscriptions for account " + GetAccount().Id);
			return (Service[])db.FillAll(typeof(Service));
		}
		
		[WebMethod]
		[SoapHeader("Authentication")]
		public Package DownloadLatestPackage(string serviceName, string platform) {
			DbUtility db = new DbUtility();
			db.Cmd("iqFindLatestPackage", CommandType.StoredProcedure);
			db.In("@account_id", DbType.Int32, GetAccount().Id);
			db.In("@service_name", DbType.String, serviceName);
			db.In("@platform_id", DbType.Int32, DbPlatform.ToId(platform));
			
			log.Debug("Fetching latest package for " + serviceName + ", platform = " + DbPlatform.ToId(platform));
			Package pkg = (Package)db.Fill(new Package());
			if (pkg == null) {
				return null;
			}
			
			log.Debug("Preparing to download package version " + pkg.Version);
			
			DbPackageItem dbpkgi = new DbPackageItem();
			dbpkgi.PackageId = pkg.Id;
			DataTable dt = (DataTable)dbpkgi.DbFindAll(true);

			pkg.Items = new PackageItem[dt.Rows.Count];
			for (int i = 0; i < dt.Rows.Count; i++) {
				DataRow dr = dt.Rows[i];
				log.Debug("Reading entry " + dr["PackageItemName"]);

				PackageItem pkgi = new PackageItem();
				pkgi.Id = (int)dr["PackageItemId"];
				pkgi.Name = (string)dr["PackageItemName"];
				pkgi.PackageId = pkg.Id;
				pkgi.Type = (string)dr["PackageItemType"];
				pkgi.Size = (int)dr["PackageItemSize"];
				pkgi.Data = (byte[])dr["PackageItemData"];

				pkg.Items[i] = pkgi;
			}

			return pkg;
		}
		
		protected DbAccount GetAccount() {
			DbAccount account = DbAccount.FindByIqid(this.Authentication.Iqid);
			if (account.Id > 0 && account.Password.Equals(this.Authentication.Password)) {
				account.IpAddress = this.Context.Request.UserHostAddress;
				return account;
			}

			throw new SoapException("Access denied for user " + this.Authentication.Iqid, SoapException.ClientFaultCode);
		}
		
	}

}