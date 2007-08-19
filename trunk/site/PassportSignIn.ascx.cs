#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Commanigy.Iquomi.Ui; 

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	///		Summary description for PassportSignIn.
	/// </summary>
	public partial class PassportSignIn : System.Web.UI.UserControl {

		public bool ConsentIsInDatabase(string hi, string low) {
			return true;
		}

		public void AddPUIDToConsentDatabase(string hi, string low) {
			;
		}

		private void Page_Load(object sender, System.EventArgs e) {

			if (Context.User.Identity.GetType() != typeof(PassportIdentity)) {
				lblPassport.Text = "No Passport Authentication";
				return;
			}
			
			PassportIdentity oMgr;
			oMgr = (PassportIdentity)Context.User.Identity;

			string thisURL, logoutURL; 
			bool isSignedIn = false;

			//The URL of this page.
			thisURL = "http://" + Request.ServerVariables.Get("SERVER_NAME") +
				":" + Request.ServerVariables.Get("SERVER_PORT") + 
				Request.ServerVariables.Get("SCRIPT_NAME");

			//The URL of the sign-out page
			logoutURL = "http://" + Request.ServerVariables.Get("SERVER_NAME") +
				":" + Request.ServerVariables.Get("SERVER_PORT") + 
				"/Default.aspx?action=signout";
			
			if (oMgr.GetFromNetworkServer) {
				// clears query string if ticket has just arrived
				Response.Redirect(thisURL); 
			}

			if (oMgr.GetIsAuthenticated(3600,false,false)) { //Ticket must be less than one
				//hour old (3600 seconds) or it 
				//will be considered stale.
				//This parameter is optional.

				//Determine user's PUID.
				string memberidhigh, memberidlow;
				memberidhigh = oMgr.GetProfileObject("MemberIDHigh").ToString();
				memberidlow = oMgr.GetProfileObject("MemberIDLow").ToString();

				// Check for this user's record
				// in your consent database
				if (ConsentIsInDatabase(memberidhigh,memberidlow)) { 
					// ConsentIsInDatabase call is provided
					// by your site and determines user's consent 
					// status on your site

					//If user has given consent,
					//set a variable to indicate the user
					//is signed in
					isSignedIn = true;

				}else{

					if (oMgr.TimeSinceSignIn < 10) {
						// The user clicked Sign In to enter your site,
						// providing implicit consent, so no consent page
						// is necessary.
						isSignedIn = true;

					}else{

						//If user has not given consent, show consent page.
						Response.Redirect("http://" + Request.ServerVariables.Get("SERVER_NAME") + ":" + Request.ServerVariables.Get("SERVER_PORT") + "/signup.aspx?returnTo=" + Server.UrlEncode(thisURL));

						//Gather_consent.asp will present the consent UI.
						//If consent is given, a database entry
						//will be made and redirect back to this 
						//page using the returnTo parameter 

					}
				}
			}else{

				oMgr.LoginUser(thisURL,3600,false,null,-1,null,-1,false,null);

				//If user is not authenticated,
				//set the variable to indicate the user
				//is not signed in
				isSignedIn = false;
			}

			// Now use the isSignedIn variable to 
			// determine which content to display.

			if (isSignedIn) {
				//The user is signed in, so	
				//call LogoTag2 with sign-out script
				//as return URL parameter
				lblPassport.Text = oMgr.LogoTag2(logoutURL,3600,false,null,-1,false,null,-1,false);
			}else{
				//The user is not signed in, so	
				//call LogoTag2 with this page
				//as return URL parameter
				lblPassport.Text = oMgr.LogoTag2(thisURL,3600,false,null,-1,false,null,-1,false);
			}

			//			lblPassport.Text += "[" + oMgr.HexPUID + "]";
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {

		}
		#endregion
	}
}