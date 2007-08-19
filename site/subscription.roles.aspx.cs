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

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class SubscriptionRolesPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected UiService service;
		private DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			subscription = new DbSubscription();
			subscription.Id = GetGuid("Subscription.Id");
			subscription.DbRead();

			service = new UiService();
			service.Id = subscription.ServiceId;
			service.DbRead();
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			if (!Page.IsPostBack) {
				UcSubscriptionTab.Service = service;
				UcSubscriptionTab.Subscription = subscription;
			}
		}

		protected void BtnAddItem_Click(object sender, System.EventArgs e) {
			this.Redirect("subscription.role.create.aspx", new object[] { subscription.Id });
		}

		protected void BtnDeleteItem_Click(object sender, System.EventArgs e) {
			foreach (GridViewRow r in GridView1.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbRole v = new DbRole();
					v.Id = id;
					v.DbDelete();
				}
			}

			GridView1.DataBind();
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["subscriptionId"] = subscription.Id;
//			e.InputParameters["languageId"] = UiAccount.Get().LanguageId;
		}

		protected void GridView1_Sorted(object sender, EventArgs e) {
			// current user must always be shown in the top of the list
		}

		protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e) {
			DataTable dt = (DataTable)e.ReturnValue;
			if (dt.Rows.Count > 0) {
				DataRow[] top = dt.Select("Iqid='" + UiAccount.Get().Iqid + "'");
				if (top.Length == 1) {
					DataRow mx = dt.NewRow();
					mx.ItemArray = top[0].ItemArray;
					dt.Rows.Remove(top[0]);
					// FIX: Bug in whidbey - inserts in bottom but ought to insert in
					// top; no workaround for this one afaik
					dt.Rows.InsertAt(mx, 0);
				}
			}
		}

		protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e) {
			if (e.Row.RowIndex == 0) {
				e.Row.CssClass = "hl";
				(e.Row.FindControl("RowChecked") as CheckBox).Enabled = false;
			}
			else if (e.Row.RowIndex % 2 == 1) {
//				e.Row.CssClass = "l";
			}
			else {
//				e.Row.CssClass = "d";
			}
		}

	}
}