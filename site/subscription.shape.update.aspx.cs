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
	public partial class SubscriptionShapeUpdatePage : Commanigy.Iquomi.Web.WebPage {
		private DbScope scope;
		private DbShape shape;
		protected DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = new DbSubscription();
			subscription.Id = GetGuid("Subscription.Id");
			subscription.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			shape = new DbShape();
			shape.Id = GetInt32("Shape.Id");
			shape.DbRead();

			scope = new DbScope();
			scope.Id = shape.ScopeId;
			scope.DbRead();

			if (!Page.IsPostBack) {
				SubscriptionTab.Subscription = subscription;
				UcShape.SyncFrom(shape);
			}
		}

		protected void BtnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			UcShape.SyncTo(shape);
			DbShape v = (DbShape)shape.DbUpdate();

			Notification.AssertSuccess(v.Id > 0);
		}
	}
}