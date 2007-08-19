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
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceRoleTemplateMethodCreatePage : Commanigy.Iquomi.Web.WebPage {
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
			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
				DbRoleTemplateMethod v = new DbRoleTemplateMethod();
				v.MethodTypeId = (int)DbMethodType.DbIdentifier.Insert;
				ServiceRoleTemplateMethodManage.SyncFrom(v);
			}
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			DbRoleTemplateMethod v = new DbRoleTemplateMethod();
			ServiceRoleTemplateMethodManage.SyncTo(v);
			v.RoleTemplateId = roleTemplate.Id;

			bool success = (v.DbCreate() != null);
			Notification.AssertSuccess(success);
			if (success) {
				this.Redirect("service.role_template.update.aspx", new object[] { service.Id, roleTemplate.Id });
			}
		}

	}
}