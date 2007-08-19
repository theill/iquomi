#region Using directives

using System;
using System.Xml;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;

using log4net;

using Commanigy.Iquomi.Store;
using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// 
	/// </summary>
	public class ServiceMethodHandler : System.Web.IHttpHandler {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public ServiceMethodHandler() {
			;
		}


		public bool IsReusable {
			get {
				return true;
			}
		}


		public void ProcessRequest(HttpContext context) {
			string token = context.Request["token"];
			if (string.IsNullOrEmpty(token)) {
				throw new HttpException(500, "Missing 'token' in request.");
			}

			string path = context.Request.AppRelativeCurrentExecutionFilePath.Trim();
			ServiceDetail a = new ServiceDetail(path);

			DbAccount account = GetAccountByToken(token);
			string iqid = account.Iqid;

			DbSubscription subscription = GetSubscription((iqid == a.OwnerIqid) ? account.Id : GetOwnerAccount(a.OwnerIqid).Id, a.SubscriptionName);

			DbService service = DbService.DbRead(subscription.ServiceId);
			DbServiceMethod sm = GetServiceMethod(a.MethodName, service);
			SubjectType subject = GetSubject(iqid);

			RequestType request = new RequestType();
			request.Key = new RequestTypeKey[] { new RequestTypeKey() };
			request.Key[0].Puid = a.OwnerIqid;
			request.Service = a.SubscriptionName;

			IXmlStore store = XmlStoreRepository.Instance.Find(request, null);

			QueryRequestType queryRequest = new QueryRequestType();
			queryRequest.XpQuery = new XpQueryType[] { new XpQueryType() };
			queryRequest.XpQuery[0].Select = sm.Select;
			queryRequest.XpQuery[0].MinOccurs = 1;
			queryRequest.XpQuery[0].MinOccursSpecified = true;

			QueryResponseType queryResponse = store.Query(subject, queryRequest);

			XmlElement root = null;

			if (queryResponse.XpQueryResponse[0].Status == ResponseStatus.Success) {
				DbMethodHistory mh = new DbMethodHistory();
				mh.Method = a.MethodName;
				mh.AccountId = account.Id;
				mh.SubscriptionId = subscription.Id;
				mh.UserHostAddress = context.Request.UserHostAddress;
				mh.DbCreate();

				if (queryResponse.XpQueryResponse[0].Any.Length == 1) {
					root = queryResponse.XpQueryResponse[0].Any[0];
				}
				else {
					XmlDocument wrappedDocument = new XmlDocument();
					wrappedDocument.LoadXml("<Response />");
					root = wrappedDocument.DocumentElement;
					foreach (XmlElement e in queryResponse.XpQueryResponse[0].Any) {
						root.AppendChild(wrappedDocument.ImportNode(e, true));
					}
				}
			}
			else {
				log.Debug("Query '" + queryRequest.XpQuery[0].Select + "' was unsuccessful");
				XmlDocument emptyDocument = new XmlDocument();
				emptyDocument.LoadXml("<empty />");
				root = emptyDocument.DocumentElement;
			}

			XslCompiledTransform xslt = new XslCompiledTransform();
			if (!string.IsNullOrEmpty(sm.Script)) {
				xslt.Load(new XmlTextReader(new StringReader(sm.Script)));
			}
			else {
				xslt.Load(sm.ScriptUrl);
			}

			switch (xslt.OutputSettings.OutputMethod) {
				case XmlOutputMethod.Html:
					context.Response.ContentType = "text/html";
					break;

				case XmlOutputMethod.Text:
					context.Response.ContentType = "text/plain";
					break;

				case XmlOutputMethod.Xml:
					context.Response.ContentType = "text/xml";
					break;
			}

			xslt.Transform(new XmlNodeReader(root), new XmlTextWriter(context.Response.Output));
		}

		protected DbService GetService(string serviceName) {
			DbService service = DbService.DbFindByName(serviceName);

			if (service.Id > 0) {
				return service;
			}

			throw new HttpException(500, "Failed to lookup service " + serviceName);
		}
				
		protected DbServiceMethod GetServiceMethod(string name, DbService b) {
			DbServiceMethod serviceMethod = new DbServiceMethod();
			serviceMethod.ServiceId = b.Id;
			serviceMethod.Name = name;
			serviceMethod.DbFindByName();

			if (serviceMethod.Id > 0) {
				return serviceMethod;
			}

			throw new HttpException(500, "Failed to lookup method " + name + " on service");
		}


		protected SubjectType GetSubject(string iqid) {
			SubjectType st = new SubjectType();
			st.UserId = iqid;
			st.AppAndPlatformId = "iquomi@windows";
			return st;
		}


		protected DbAccount GetOwnerAccount(string ownerIqid) {
			return DbAccount.FindByIqid(ownerIqid);
		}


		protected DbAccount GetAccountByToken(string token) {
			DbAccount account = DbAccount.FindByToken(token);
			if (account.Id > 0) {
				return account;
			}

			throw new HttpException(500, "Failed to lookup account " + token);
		}


		protected DbAccount GetAccount(string iqid, string password) {
			DbAccount account = DbAccount.FindByIqid(iqid);
			if (account.Id > 0 && account.Password == password) {
//				account.IpAddress = this.context.Request.UserHostAddress;
				return account;
			}

			throw new HttpException(500, "Failed to lookup account " + iqid);
		}

		/// <summary>
		/// Lookup subscription based on requested service name and owner.
		/// </summary>
		/// <returns></returns>
		protected DbSubscription GetSubscription(int accountId, string name) {
			DbSubscription subscription = new DbSubscription();
			subscription.AccountId = accountId;
			subscription.Name = name;
			subscription.DbFindByAccountIdName();

			if (subscription.IsValid()) {
				return subscription;
			}

			throw new HttpException(500, "Failed to lookup subscription for " + accountId);
		}

		public class ServiceDetail {
			public string SubscriptionName;
			public string MethodName;
			public string OwnerIqid;

			// example of full request: http://services.iquomi.com/get/theill/myContacts/asPhoneList.rpc?token=9e0a64d4e93eb744c5ad07f79472aedb375e4409
			// path is something like "~/get/theill/myContacts/asPhoneList.rpc?token=9e0a64d4e93eb744c5ad07f79472aedb375e4409"
			public ServiceDetail(string path) {
				string[] bits = path.Split(new char[] { '/' });
				if (!bits[1].Equals("get") || bits.Length < 5) {
					throw new HttpException(500, "Malformed request.");
				}

				OwnerIqid = bits[2];
				SubscriptionName = bits[3];
				MethodName = bits[4].Substring(0, bits[4].IndexOf('.'));
			}
		}
	}
}