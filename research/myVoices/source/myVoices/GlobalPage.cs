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

namespace myVoices
{
	/// <summary>
	/// Summary description for GlobalPage.
	/// </summary>
	public class GlobalPage : System.Web.UI.Page
	{
		public GlobalPage()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string result = "";
		public string GetResult()
		{
			return result;
		}

		public string GetPuidApp()
		{
			return Session["puid"].ToString();
			//return Request["puid"];
		}

		public int GetPuid()
		{
			if(Session["puid"] == null)
			{
				//Administrator = 13971
				Session["puid"] = "3819"; //TODO strip this out, put in for testing
			}
			return Int32.Parse(Session["puid"].ToString());
		}


	}
}
