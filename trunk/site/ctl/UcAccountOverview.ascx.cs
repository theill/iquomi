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

using Commanigy.Iquomi.Web;

#endregion

public partial class UcAccountOverview_ascx : System.Web.UI.UserControl {

	protected override void OnLoad(EventArgs e) {
        UiAccount a = UiAccount.Get();
        if (a != null) {
            this.Balance.Text = "295.23 USD";
            this.Details.Text = "You have a total of 93 contacts registered.";
            this.Devices.Text = "Iqid: " + a.Iqid + "; Password: " + a.Password;
//		    this.Devices.Text = "2 Windows Clients, 1 Pocket PC Client, 1 Linux Client.";
        }

        this.Visible = (a != null);
    }

}