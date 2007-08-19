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
	public partial class ServiceSubscribePage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");
		
		protected DbService service;

		protected void Page_Load(object sender, System.EventArgs e) {
			service = new DbService();
			service.Id = GetInt32("Service.Id");
			service.DbRead();

			ServiceUC.DataItem = service;

			if (!Page.IsPostBack) {
				FldName.Text = service.Name;
			}
		}

		protected void SubscribeService_Click(object sender, System.EventArgs e) {
			DbSubscription subscription = new DbSubscription();
			subscription.AccountId = UiAccount.Get().Id;
			subscription.ServiceId = service.Id;
			subscription.Name = FldName.Text;

			try {
				subscription.DbCreateDocument();

				this.Redirect("subscription.read.aspx", new object[] { subscription.Id, subscription.ServiceId });
			}
			catch (System.Data.Common.DbException x) {
				if (x.Message.Contains("Violation of UNIQUE KEY constraint 'IX_subscription'.")) {
					Notify(_("A subscription with this name already exists."));
				}
				else {
					Notify(x);
				}
			}
		}

		public override void Notify(string message) {
			Notification.Failed(message);
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