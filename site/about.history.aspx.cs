#region Using directives
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class AboutHistoryPage : Commanigy.Iquomi.Web.WebPage {
		
		private void Page_Load(object sender, System.EventArgs e) {
			try {
				lblHistory.Text = File.OpenText(Server.MapPath("~/history.txt")).ReadToEnd();
			}
			catch (FileNotFoundException) {
				lblHistory.Text = "File Not Found";
			}
		}
	}
}
