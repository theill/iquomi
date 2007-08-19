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
	public partial class SubscriptionCreatePage : Commanigy.Iquomi.Web.WebPage {
		protected System.Web.UI.WebControls.Image Image1;
		
		private void Page_Load(object sender, System.EventArgs e) {
		
//			DbUtility db = new DbUtility();
//			db.Cmd("iqListProvisionedServices", CommandType.StoredProcedure);
//			db.In("@language_id", DbType.Int32, UiAccount.Get().LanguageId);

//			if (!Page.IsPostBack) {
//				List.DataSource = db.GetDataTable();
//				List.DataBind();
//			}
		}
		
	}
}