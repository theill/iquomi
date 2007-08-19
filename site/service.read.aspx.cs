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

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceReadPage : Commanigy.Iquomi.Web.WebPage {
		protected UiService service;
		
		protected void Page_Load(object sender, System.EventArgs e) {
			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.AuthorId = Profile.AuthorId;
			service.DbFindByAuthorId();
			
			ProvisionService.Enabled = (service.State == Ui.State.DESIGN);
			RetireButton.Enabled = (service.State == Ui.State.PROVISIONED);
			DeleteButton.Enabled = (service.State == Ui.State.DESIGN);

			SiteMapNode n = SiteMap.CurrentNode;

			n.Title = service.Name ?? _("(unknown)");
			n.Url = this.Request.Url.ToString();

			ServiceTab.DataItem = service;
		}

		protected void ProvisionService_Click(object sender, System.EventArgs e) {
			service.State = Ui.State.PROVISIONED;
			service.DbUpdate();
			ServiceTab.DataItem = service;
		}

		protected void RetireButton_Click(object sender, System.EventArgs e) {
			service.State = Ui.State.RETIRED;
			service.DbUpdate();
			ServiceTab.DataItem = service;
		}

		protected void DeleteButton_Click(object sender, EventArgs e) {
			service.DbDelete();
			this.Redirect("services.aspx", new object[0]);
		}

		protected void ManageButton_Click(object sender, System.EventArgs e) {
			this.Redirect("service.update.aspx", new object[] { service.Id });
		}

		protected void ChargesButton_Click(object sender, System.EventArgs e) {
			this.Redirect("service.charges.aspx", new object[] { service.Id });
		}

		protected void RolesButton_Click(object sender, System.EventArgs e) {
			this.Redirect("service.role_templates.aspx", new object[] { service.Id });
		}

		protected void btnScopes_Click(object sender, System.EventArgs e) {
			this.Redirect("service.scopes.aspx", new object[] { service.Id });
		}

		protected void BtnUpgrade_Click(object sender, EventArgs e) {
			this.Redirect("service.upgrade.aspx", new object[] { service.Id });
		}
		protected void MethodsButton_Click(object sender, EventArgs e) {
			this.Redirect("service.methods.aspx", new object[] { service.Id });
		}
}
}