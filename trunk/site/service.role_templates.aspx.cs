#region Using directives

using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceRoleTemplatesPage : Commanigy.Iquomi.Web.WebPage {
		private static readonly ILog log = LogManager.GetLogger("WebSite");
		protected UiService service;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.AuthorId = UiAuthor.Get().Id;
			service.DbFindByAuthorId();
		}

		protected void Page_Load(object sender, System.EventArgs e) {

			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
			}
		}

		protected void AddRoleButton_Click(object sender, System.EventArgs e) {
			this.Redirect("service.role_template.create.aspx", new object[] { service.Id });
		}

		protected void DeleteRoleButton_Click(object sender, System.EventArgs e) {
			foreach (GridViewRow r in GridView1.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbRoleTemplate d = new DbRoleTemplate();
					d.Id = id;
					d.DbDelete();
				}
			}

			GridView1.DataBind();
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["serviceId"] = GetInt32("Service.Id");
		}

	}
}