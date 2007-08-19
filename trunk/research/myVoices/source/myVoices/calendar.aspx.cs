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

using hsProxy.myCalendarNs;
using System.Xml;

namespace myVoices
{
	/// <summary>
	/// Summary description for calendar.
	/// </summary>
	public class calendar : GlobalPage
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				hsProxy.hsProxy hsp = new hsProxy.hsProxy();
				int puid = GetPuid();
				myCalendar myCal = (myCalendar) hsp.GetMyService(typeof(myCalendar), puid);

				getCalendarDaysRequest daysRequest = new getCalendarDaysRequest();
				//hardcoded
				daysRequest.startTime = new DateTime(2002, 1, 15, 0,0,0);
				daysRequest.endTime = new DateTime(2002, 1, 21, 0, 0, 0);


				getCalendarDaysResponse daysResponse = myCal.getCalendarDays(daysRequest);

				XmlDocument xd = new XmlDocument();
				XmlElement root = xd.CreateElement("root");
				xd.AppendChild(root);

				foreach(getCalendarDaysResponseEvent dre in daysResponse.@event)
				{
					XmlElement xe = xd.CreateElement("prompt");
					xe.InnerText = dre.body.title.Value + " on " + dre.body.startTime.ToShortDateString();
					root.AppendChild(xe);
				}

				result = root.InnerXml;

			}
			catch(System.Web.Services.Protocols.SoapException sex)
			{
				result = sex.ToString();
			}
			catch(Exception ex)
			{
				result = ex.ToString();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
