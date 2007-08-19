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
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for services.
	/// </summary>
	public partial class AccountPage : Commanigy.Iquomi.Web.WebPage {
		protected void Page_Load(object sender, EventArgs e) {
			ApplicationID.Text = UiAccount.Get().ApplicationID;
		}
	}
}