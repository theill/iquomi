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
	public partial class ServiceScopeUpdatePage : Commanigy.Iquomi.Web.WebPage {
		protected DbScope scope;
		protected UiService service;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);
			
			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.DbRead();

			scope = new DbScope();
			scope.Id = GetInt32("Scope.Id");
			scope.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {

			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
				UcScope.SyncFrom(scope);
			}
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			UcScope.SyncTo(scope);
			Notification.AssertSuccess(scope.DbUpdate() != null);
		}

		protected void BtnAddItem_Click(object sender, System.EventArgs e) {
			this.Redirect("service.shape.create.aspx", new object[] { service.Id, scope.Id });
		}

		protected void BtnDeleteItem_Click(object sender, System.EventArgs e) {
			foreach (GridViewRow r in GridView1.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbShape v = new DbShape();
					v.Id = id;
					v.DbDelete();
				}
			}

			GridView1.DataBind();
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["scopeId"] = scope.Id;
		}

	}
}