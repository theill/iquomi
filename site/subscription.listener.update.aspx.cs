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
	public partial class SubscriptionListenerUpdatePage : Commanigy.Iquomi.Web.WebPage {
		private DbSubscription subscription;
		private DbSubscriptionListener subscriptionListener;

		protected void Page_Load(object sender, System.EventArgs e) {
			subscription = new DbSubscription();
			subscription.Id = GetGuid("Subscription.Id");
			subscription.DbRead();

			subscriptionListener = new DbSubscriptionListener();
			subscriptionListener.Id = GetInt32("SubscriptionListener.Id");
			subscriptionListener.DbRead();

			if (!Page.IsPostBack) {
				UcSubscriptionTab.Subscription = subscription;
				UcSubscriptionListener.SyncFrom(subscriptionListener);
			}
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			UcSubscriptionListener.SyncTo(subscriptionListener);

			subscriptionListener.DbUpdate();

			Notification.AssertSuccess(subscriptionListener.Id > 0);
		}
	}
}