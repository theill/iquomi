#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
	public partial class AccountReportsMonthlyPage : Commanigy.Iquomi.Web.WebPage {

		protected void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				DbUtility db = new DbUtility();
				db.Cmd("iqFindAllMethodHistories", CommandType.StoredProcedure);
				db.In("@account_id", UiAccount.Get().Id);
				db.In("@language_id", UiAccount.Get().LanguageId);

				ItemsList.DataSource = db.GetDataTable();
				ItemsList.DataBind();
			}
		}

	}
}