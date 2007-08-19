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
	public partial class SubscriptionRoleCreatePage : Commanigy.Iquomi.Web.WebPage {
		private DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = DbSubscription.DbRead(GetGuid("Subscription.Id"));
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				UcSubscriptionTab.Subscription = subscription;
				UcSubscriptionRole.Subscription = subscription;
			}
		}

		protected void BtnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			DbRole v = new DbRole();
			UcSubscriptionRole.SyncTo(v);
			v.SubscriptionId = subscription.Id;

			if (v.AccountId == 0) {
				Notification.Failed("No account matched entered Iqid");
				return;
			}

			try {
				v.DbCreate();

				if (Notification.AssertSuccess(v.Id > 0)) {
					this.Redirect("subscription.role.update.aspx", new object[] { subscription.Id, v.Id });
				}
			}
			catch (SystemException ex) {
				Notification.AssertSuccess(ex.Message.IndexOf("'IX_role'") == -1);
				Notification.Description = ex.Message;
			}
		}

	}
}