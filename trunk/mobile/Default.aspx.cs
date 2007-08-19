#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Api;

using IqPresenceRef;
using System.Web.Services.Protocols;

#endregion

namespace Commanigy.Iquomi.Web.Mobile {
	/// <summary>
	/// Summary description for DefaultPage.
	/// </summary>
	public partial class DefaultPage : System.Web.UI.MobileControls.MobilePage {
		protected static readonly ILog log = LogManager.GetLogger("Mobile");
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, System.EventArgs e) {
			log.Debug("Page_Load");

			if (HttpContext.Current.User == null) {
//				Response.Redirect("/logon.aspx");
			}
			
//			StatusPanel.Visible = true;
//			LblStatus.Text += "IsMobile: " + this.Request.Browser.IsMobileDevice + "<br />";
//			LblStatus.Text += "UserAgent: " + this.Request.UserAgent;
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CmdSignIn_Click(object sender, System.EventArgs e) {
			if (!IsValid) {
				return;
			}

			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				TbxUsername.Text,
				TbxPassword.Text
				);

			IqPresence myPresence = (IqPresence)serviceLocator.GetService(
				typeof(IqPresence),
				TbxUsername.Text
				);

			// Update Mobile Endpoint
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "/m:IqPresence/m:Endpoint/m:Argot/*[local-name(.)='MessengerArgot']/@status";
			req.MinOccurs = 1;

			RedAttributeType ra = new RedAttributeType();
			ra.Name = "status";
			ra.Value = "online";
			req.Attributes = new RedAttributeType[] { ra };

			try {
				ReplaceResponseType res = myPresence.Replace(req);
				if (res.Status == ResponseStatus.Success) {
					this.Profile.AccountId = 1;
					this.Profile.LanguageId = 1;
					Response.Redirect("subscriptions.aspx");
				}
				else {
					LblStatus.Text = "Failed to log on: " + res.Message;
					StatusPanel.Visible = true;
				}
			}
			catch (SoapException x) {
				LblStatus.Text = x.Message;
				StatusPanel.Visible = true;
			}
		}

		protected void Command1_Click(object sender, EventArgs e) {
			Response.Redirect("profile.aspx");
		}
}
}