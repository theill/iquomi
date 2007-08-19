#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls; 
#endregion

public partial class Default_aspx : Commanigy.Iquomi.Web.WebPage {

	protected void Page_Load(object sender, System.EventArgs e) {
		if (this.Request.Browser.IsMobileDevice) {
			Response.Redirect("http://mobile.iquomi.com/", true);
		}
	}
}
