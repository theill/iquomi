#region Using directives

using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class SubscriptionScopesPage : Commanigy.Iquomi.Web.WebPage {
		private DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = DbSubscription.DbRead(GetGuid("Subscription.Id"));
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			if (!Page.IsPostBack) {
				UcSubscriptionTab.Subscription = subscription;
			}
		}

		protected void BtnAddScope_Click(object sender, System.EventArgs e) {
			this.Redirect("subscription.scope.create.aspx", new object[] { subscription.Id });
		}

		protected void BtnDeleteScope_Click(object sender, System.EventArgs e) {
			foreach (GridViewRow r in GridView1.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					// delete subscription specific scope and relation to 
					// subscription (cascading)
					try {
						DbScope v = new DbScope();
						v.Id = id;
						v.DbDelete();
					}
					catch (System.Data.Common.DbException x) {
						Notification.Failed(_("Failed to delete one or more scopes"));
						Notification.Description = "";
						if (x.Message.IndexOf("FK_role_scope") > 0) {
							Notification.AddMessage(string.Format(_("You cannot delete scope {0} since it's associated with a role."), id));
						}
					}

					Notification.Display();
				}
			}

			GridView1.DataBind();
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["subscriptionId"] = subscription.Id;
		}

	}
}