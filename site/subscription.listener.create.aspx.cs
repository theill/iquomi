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
	public partial class SubscriptionListenerCreatePage : Commanigy.Iquomi.Web.WebPage {
		private DbSubscription subscription;

		protected void Page_Load(object sender, System.EventArgs e) {
			subscription = new DbSubscription();
			subscription.Id = GetGuid("Subscription.Id");
			subscription.DbRead();

			if (!Page.IsPostBack) {
				UcSubscriptionTab.Subscription = subscription;
			}
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			DbSubscriptionListener v = new DbSubscriptionListener();
			UcSubscriptionListener.SyncTo(v);
			v.SubscriptionId = subscription.Id;
			v.State = DbSubscriptionListener.StateRunning;

			v.DbCreate();

			if (Notification.AssertSuccess(v.Id > 0)) {
				this.Redirect("subscription.listener.update.aspx", new object[] { subscription.Id, v.Id });
			}
		}
	}
}