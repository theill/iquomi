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

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for AccountUpdatePage.
	/// </summary>
	public partial class AccountUpdatePage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");
		
		private void Page_Load(object sender, System.EventArgs e) {

		}

		public override void Notify(string message) {
			this.Notification.Show(message, "");
		}
	}
}