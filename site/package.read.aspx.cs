#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for PackagePage.
	/// </summary>
	public partial class PackagePage : Commanigy.Iquomi.Web.WebPage {
		protected DbPackage package;

		protected void Page_Load(object sender, System.EventArgs e) {
			package = new DbPackage();
			package.Id = GetInt32("Package.Id");
			package.DbRead();

			if (!Page.IsPostBack) {
				DbService service = new DbService();
				service.Id = package.ServiceId;
				service.DbRead();

				SiteMapNode n = SiteMap.CurrentNode;
				n.Title = service.Name ?? _("(unknown)");
				n.Url = this.Request.Url.ToString();

				UcPackageTab.Service = service;
				UcPackageTab.Package = package;

				// only possible to delete new packages
				BtnDelete.Enabled = (package.State == DbPackage.StateNew);
			}
		}

		protected void BtnFiles_Click(object sender, System.EventArgs e) {
			this.Redirect("package.items.aspx", new object[] { package.Id });
		}

		protected void BtnDelete_Click(object sender, EventArgs e) {
			if (package.DbDelete() != null) {
				this.Redirect("packages.aspx", new object[0]);
			}
		}

		protected void BtnRetire_Click(object sender, EventArgs e) {
			// retire package
			package.State = DbPackage.StateRetired;
			package.DbUpdate();
		}

		protected void BtnManage_Click(object sender, EventArgs e) {
			this.Redirect("package.update.aspx", new object[] { package.Id });
		}
}
}