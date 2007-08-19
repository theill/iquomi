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
	public partial class ServiceRoleTemplateUpdatePage : Commanigy.Iquomi.Web.WebPage {
		private static readonly ILog log = LogManager.GetLogger("WebSite");

		protected UiService service;
		private DbRoleTemplate roleTemplate;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.AuthorId = UiAuthor.Get().Id;
			service.DbFindByAuthorId();

			roleTemplate = new DbRoleTemplate();
			roleTemplate.Id = GetInt32("RoleTemplate.Id");
			roleTemplate.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
				ServiceRoleManage.SyncFrom(roleTemplate);
			}
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			ServiceRoleManage.SyncTo(roleTemplate);
			Notification.AssertSuccess(roleTemplate.DbUpdate() != null);
		}

		protected void btnAddMethod_Click(object sender, System.EventArgs e) {
			this.Redirect("service.role_template_method.create.aspx", new object[] { service.Id, roleTemplate.Id });
		}

		protected void btnDeleteMethod_Click(object sender, System.EventArgs e) {
			foreach (GridViewRow r in GridView1.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbRoleTemplateMethod v = new DbRoleTemplateMethod();
					v.RoleTemplateId = roleTemplate.Id;
					v.MethodTypeId = id;
					v.DbDelete();
				}
			}

			GridView1.DataBind();
		}

		protected void btnAddDescription_Click(object sender, System.EventArgs e) {
			this.Redirect("service.role_template_description.create.aspx", new object[] { service.Id, roleTemplate.Id });
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["roleTemplateId"] = roleTemplate.Id;
		}

	}
}