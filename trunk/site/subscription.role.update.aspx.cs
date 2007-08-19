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
	public partial class SubscriptionRoleUpdatePage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");
		
		private DbSubscription subscription;
		private DbRole role;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = DbSubscription.DbRead(GetGuid("Subscription.Id"));

			role = new DbRole();
			role.Id = GetInt32("Role.Id");
			role.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				UcSubscriptionTab.Subscription = subscription;
				UcSubscriptionRole.Subscription = subscription;
				UcSubscriptionRole.SyncFrom(role);
			}

			UcSubscriptionRole.Updating = true;
		}

		protected void BtnUpdate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			UcSubscriptionRole.SyncTo(role);
			log.Debug("role = " + Commanigy.Utils.StringUtils.FieldsToString(role));

			try {
				role.DbUpdate();

				Notification.AssertSuccess(role.Id > 0);
			}
			catch (SystemException ex) {
				Notification.AssertSuccess(ex.Message.IndexOf("'IX_role'") == -1);
				Notification.Description = ex.Message;
			}
		}

	}
}