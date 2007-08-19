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
using System.Xml;
using System.Xml.Xsl;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceCreatePage : Commanigy.Iquomi.Web.WebPage {

		private void Page_Load(object sender, System.EventArgs e) {
			this.OnPageSuccess += new PageSuccessHandler(ServiceCreatePage_OnPageSuccess);
		}

		void ServiceCreatePage_OnPageSuccess() {
			this.Redirect("services.aspx", new object[0]);
		}

		public override void Notify(Exception e) {
			if (e != null) {
				Notification.Failed(e.Message);
				if (e.InnerException != null) {
					Notification.Description = e.InnerException.Message;
				}
			} else {
				Notification.AssertSuccess(true);
			}
		}

	}
}