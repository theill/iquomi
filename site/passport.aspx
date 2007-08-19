<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security"%>
<%
PassportIdentity oMgr;
oMgr = (PassportIdentity)Context.User.Identity;

string thisURL, logoutURL; 
bool isSignedIn = false;

//The URL of this page.
thisURL = "http://" + Request.ServerVariables.Get("SERVER_NAME") +
   Request.ServerVariables.Get("SCRIPT_NAME");

//The URL of the sign-out page
logoutURL = "http://" + Request.ServerVariables.Get("SERVER_NAME") +
   "/logoutuser.htm";


if (oMgr.GetFromNetworkServer) {
   Response.Redirect(thisURL); //Clears query string if ticket has
                              //just arrived.
}

if (oMgr.GetIsAuthenticated(3600,false,false)) { //Ticket must be less than one
                                   //hour old (3600 seconds) or it 
                                   //will be considered stale.
                                   //This parameter is optional.

   //Determine user's PUID.
   string nickname, memberidhigh, memberidlow;
   memberidhigh = oMgr.GetProfileObject("MemberIDHigh").ToString();
   memberidlow = oMgr.GetProfileObject("MemberIDLow").ToString();

      if (oMgr.TimeSinceSignIn < 10) {
         // The user clicked Sign In to enter your site,
         // providing implicit consent, so no consent page
         // is necessary.
         isSignedIn = true;

      }else{

         //If user has not given consent, show consent page.

         Response.Redirect("http://" + Request.ServerVariables.Get("SERVER_NAME") +
         "gather_consent.asp?returnTo=" + Server.UrlEncode(thisURL));

         //Gather_consent.asp will present the consent UI.
         //If consent is given, a database entry
         //will be made and redirect back to this 
         //page using the returnTo parameter 

      }

}else{

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
   Response.Write(oMgr.LogoTag2(logoutURL,3600,false,null,-1,false,null,-1,false));
   Response.Write("<HR>");

   //And display customized content
   Response.Write("You are signed in to .NET Passport.");

}else{

   //The user is not signed in, so	
   //call LogoTag2 with this page
   //as return URL parameter
   Response.Write(oMgr.LogoTag2(thisURL,3600,false,null,-1,false,null,-1,false));
   Response.Write("<HR>");

   //And display customized content
   Response.Write("You are not a .NET Passport user.");

}

Response.Write("This content is seen by all users");

%>