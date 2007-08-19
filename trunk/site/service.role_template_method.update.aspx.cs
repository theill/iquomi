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
	public partial class ServiceRoleTemplateMethodUpdatePage : Commanigy.Iquomi.Web.WebPage {
		private static readonly ILog log = LogManager.GetLogger("WebSite");
		
		protected UiService service;
		private DbRoleTemplateMethod roleTemplateMethod;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.AuthorId = UiAuthor.Get().Id;
			service.DbFindByAuthorId();

			roleTemplateMethod = new DbRoleTemplateMethod();
			roleTemplateMethod.RoleTemplateId = GetInt32("RoleTemplate.Id");
			roleTemplateMethod.MethodTypeId = GetInt32("MethodType.Id");
			roleTemplateMethod.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			ServiceRoleTemplateMethodManage.Updating = true;

			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
				ServiceRoleTemplateMethodManage.SyncFrom(roleTemplateMethod);
			}
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}
			
			ServiceRoleTemplateMethodManage.SyncTo(roleTemplateMethod);
			Notification.AssertSuccess(roleTemplateMethod.DbUpdate() != null);
		}
		
	}
}