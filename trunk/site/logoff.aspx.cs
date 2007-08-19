#region Using directives
using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;

using Commanigy.Iquomi.Ui;
#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for LogOffPage.
	/// </summary>
	public partial class LogOffPage : Commanigy.Iquomi.Web.WebPage {
		
		private void Page_Load(object sender, System.EventArgs e) {
			new UiAccount().Logoff(true);

			this.Redirect("logoff.success.aspx", null);
		}
		
	}
}
