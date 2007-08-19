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
	public partial class SubscriptionShapeCreatePage : Commanigy.Iquomi.Web.WebPage {
		protected DbScope scope;
		protected DbShape shape;
		protected DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = new DbSubscription();
			subscription.Id = GetGuid("Subscription.Id");
			subscription.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			scope = new DbScope();
			scope.Id = GetInt32("Scope.Id");
			scope.DbRead();

			shape = new DbShape();
			shape.ScopeId = scope.Id;

			if (!Page.IsPostBack) {
				SubscriptionTab.Subscription = subscription;
				UcShape.SyncFrom(shape);
			}
		}

		protected void BtnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			UcShape.SyncTo(shape);
			DbShape v = (DbShape)shape.DbCreate();

			Notification.AssertSuccess(v.Id > 0);

			if (v.Id > 0) {
				this.Redirect("subscription.shape.update.aspx", new object[] { subscription.Id, v.Id });
			}
		}

	}
}