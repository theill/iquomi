#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Commanigy.Iquomi.Data;
using Commanigy.Utils;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for SearchPage.
	/// </summary>
	public partial class SearchPage : Commanigy.Iquomi.Web.WebPage {
		private string query;
		public string Query {
			get {
				return (query != null) ? query : this.Request["q"];
			}
			set {
				query = value;
			}
		}
		
		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				TbxQuery.Text = Query;
			}
		}

		protected void DsSubscriptions_Selected(object sender, ObjectDataSourceStatusEventArgs e) {
			if (e.Exception != null) {
				LblQuery.Text = e.Exception.InnerException.Message;
				e.ExceptionHandled = true;
				return;
			}

			int rowCount = (e.ReturnValue as DataTable).Rows.Count;

			if (rowCount > 1) {
				LblQuery.Text = string.Format(_("Your query on <b class=\"Query\">{0}</b> resulted in {1} results."), Query, rowCount);
			}
			else if (rowCount == 1) {
				LblQuery.Text = string.Format(_("Your query on <b class=\"Query\">{0}</b> resulted in 1 result."), Query);
			}
			else {
				LblQuery.Text = string.Format(_("No documents were found matching your query on <b class=\"Query\">{0}</b>."), Query);
			}
		}

		protected void DsQuerySubscriptions_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.Cancel = string.IsNullOrEmpty(Query);
		}

		protected void BtnSearch_Click(object sender, EventArgs e) {
			Query = TbxQuery.Text;
			SearchView.DataBind();
		}
	}
}