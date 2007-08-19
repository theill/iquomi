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
using System.Text;
using System.Xml.Xsl;
using System.Xml;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class SubscriptionListenersPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected UiService service;
		protected DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = DbSubscription.DbRead(GetGuid("Subscription.Id"));

			service = new UiService();
			service.Id = subscription.ServiceId;
			service.DbRead();

			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				UcSubscriptionTab.Service = service;
				UcSubscriptionTab.Subscription = subscription;
			}
		}

		protected void BtnAddItem_Click(object sender, System.EventArgs e) {
			this.Redirect("subscription.listener.create.aspx", new object[] { subscription.Id });
		}

		/// <summary>
		/// Deletes selected listeners.
		/// </summary>	
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void BtnRemoveItem_Click(object sender, EventArgs e) {
			foreach (GridViewRow r in View.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbSubscriptionListener b = DbSubscriptionListener.DbRead(id);
					b.DbDelete();
				}
			}

			View.DataBind();
		}

		/// <summary>
		/// Suspends listeners so no notifications are sent. This feature is 
		/// useful when additional checks are needed for that resource.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void BtnSuspendListener_Click(object sender, EventArgs e) {
			foreach (GridViewRow r in View.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbSubscriptionListener b = DbSubscriptionListener.DbRead(id);
					b.ToggleState();
					b.DbUpdate();
				}
			}

			View.DataBind();

			this.UcNotification.Success(_("State updated on selected listeners"));
		}

		protected void List_RowDataBound(object sender, GridViewRowEventArgs e) {
			if (e.Row.RowType == DataControlRowType.DataRow) {
				string state = (string)((DataRowView)e.Row.DataItem)["State"];
				if (DbSubscriptionListener.StateSuspended.Equals(state)) {
					e.Row.CssClass = "inactive";
				}
			}
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["subscriptionId"] = subscription.Id;
		}
	}
}