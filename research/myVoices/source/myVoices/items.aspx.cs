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

using hsProxy.myListsNs;
using System.Xml;

namespace myVoices
{
	/// <summary>
	/// Summary description for items.
	/// </summary>
	public class items : GlobalPage
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				hsProxy.hsProxy hsp = new hsProxy.hsProxy();
				int puid = GetPuid();
				myLists myLis = (myLists) hsp.GetMyService(typeof(myLists), puid);

				string listId = Request["list"];
				string queryStr = "/m:myLists/m:item[./m:listRef/@ref='" + listId + "']";

				queryRequestType queryRequest = new queryRequestType();
				xpQueryType xpQuery = new xpQueryType();
				xpQuery.select=queryStr;
				queryRequest.xpQuery = new xpQueryType[]{xpQuery};

				queryResponseType queryResponse = myLis.query(queryRequest);

				queryResponseTypeXpQueryResponse xqr = queryResponse.xpQueryResponse[0];

				XmlDocument xd = new XmlDocument();
				XmlElement root = xd.CreateElement("root");
				xd.AppendChild(root);

				foreach(itemType it in xqr.Items)
				{
					XmlElement xe = xd.CreateElement("prompt");
					xe.InnerText = it.title[0].Value;
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
