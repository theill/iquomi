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

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// </summary>
	public partial class AccountProviderSetupPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected void Page_Load(object sender, System.EventArgs e) {
			// Put user code to initialize the page here
			log.Debug("Referrer: " + Request["referrer"]);
		}

	}
}