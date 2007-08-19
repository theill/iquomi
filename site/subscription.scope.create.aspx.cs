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
	public partial class SubscriptionScopeCreatePage : Commanigy.Iquomi.Web.WebPage {
		private DbScope scope;
		protected DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = new DbSubscription();
			subscription.Id = GetGuid("Subscription.Id");
			subscription.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			scope = new DbScope();
			scope.LanguageId = 1;
			scope.Base = DbScope.NIL;

			if (!Page.IsPostBack) {
				UcSubscriptionTab.Subscription = subscription;
			    UcScope.SyncFrom(scope);
			}
		}

		protected void BtnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			UcScope.SyncTo(scope);
			DbScope s = (DbScope)subscription.DbCreateScope(scope);

			if (Notification.AssertSuccess(s.Id > 0)) {
			    this.Redirect("subscription.scope.update.aspx", new object[] { subscription.Id, s.Id });
			}
		}

	}
}