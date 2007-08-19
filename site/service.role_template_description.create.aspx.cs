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
	public partial class ServiceRoleTemplateDescriptionCreatePage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected UiService service;
		protected DbRoleTemplateDescription roleTemplateDescription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.AuthorId = UiAuthor.Get().Id;
			service.DbFindByAuthorId();

			roleTemplateDescription = new DbRoleTemplateDescription();
			roleTemplateDescription.RoleTemplateId = GetInt32("RoleTemplate.Id");
			roleTemplateDescription.LanguageId = UiAccount.Get().LanguageId;
			roleTemplateDescription.Description = "";
		}

		protected void Page_Load(object sender, System.EventArgs e) {

			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
				ServiceRoleTemplateDescription.SyncFrom(roleTemplateDescription);
			}
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}
			
			ServiceRoleTemplateDescription.SyncTo(roleTemplateDescription);

			bool success = (roleTemplateDescription.DbCreate() != null);
			Notification.AssertSuccess(success);
//			if (success) {
//				WorkFlow.GetInstance().GoNext("service.role_template.update", rtd.RoleTemplateId);
//			}
		}

	}
}