#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class PackageItemUpdatePage : Commanigy.Iquomi.Web.WebPage {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private DbPackageItem packageItem;
		private DbService service;
		private DbPackage package;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			// get requested package (taking into account it's only 
			// possible to read package if it's owned by author)
			packageItem = new DbPackageItem();
			packageItem.Id = GetInt32("PackageItem.Id");
			packageItem.DbRead(Profile.AuthorId);

			package = new DbPackage();
			package.Id = packageItem.PackageId;
			package.DbRead();

			service = new DbService();
			service.Id = package.ServiceId;
			service.AuthorId = Profile.AuthorId; // UiAuthor.Get().Id;
			service.DbFindByAuthorId();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			PackageTab.Package = package;
			PackageTab.Service = service;

			PackageItem.DbItem = packageItem;
		}

		protected void BtnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			DbPackageItem it = PackageItem.ToDb();

			if (it.DbUpdate() != null) {
				this.Redirect("package.items.aspx", new object[] { package.Id });
			}
		}
	}
}