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
	public partial class ServiceMethodCreatePage : Commanigy.Iquomi.Web.WebPage {
		private DbService service;

		protected void Page_Load(object sender, System.EventArgs e) {
			service = new DbService();
			service.Id = GetInt32("Service.Id");
			service.DbRead();
			
			ServiceTab.DataItem = service;

			this.OnPageSuccess += new PageSuccessHandler(ServiceMethodCreatePage_OnPageSuccess);
		}

		void ServiceMethodCreatePage_OnPageSuccess() {
			//Notification.AssertSuccess(true);
			this.Redirect("service.methods.aspx", new object[] { service.Id });
		}

		public override void Notify(Exception e) {
			if (e != null) {
				Notification.Failed(e.Message);
				if (e.InnerException != null) {
					Notification.Description = e.InnerException.Message;
				}
			}
			else {
				Notification.AssertSuccess(true);
			}
		}
	}
}