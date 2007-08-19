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
	public partial class ServiceRoleTemplateCreatePage : Commanigy.Iquomi.Web.WebPage {
		protected UiService service;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.AuthorId = UiAuthor.Get().Id;
			service.DbFindByAuthorId();
		}

		protected void Page_Load(object sender, System.EventArgs e) {

			if (!Page.IsPostBack) {
				ServiceTab.DataItem = service;
//				ServiceRoleManage.SyncFrom(new DbRoleTemplate());
			}
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			DbRoleTemplate rt = new DbRoleTemplate();
			ServiceRoleManage.SyncTo(rt);

			rt.ServiceId = service.Id;
			rt.DbCreate();

			Notification.AssertSuccess(rt.Id > 0);
		}

	}
}