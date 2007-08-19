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
	/// Summary description for lists.
	/// </summary>
	public class lists : GlobalPage
	{

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				hsProxy.hsProxy hsp = new hsProxy.hsProxy();
				int puid = GetPuid();
				myLists myLis = (myLists) hsp.GetMyService(typeof(myLists), puid);
				
				queryRequestType queryRequest = new queryRequestType();
				xpQueryType xpQuery = new xpQueryType();
				xpQuery.select="/m:myLists/m:list";
				queryRequest.xpQuery = new xpQueryType[]{xpQuery};

				queryResponseType queryResponse = myLis.query(queryRequest);

				queryResponseTypeXpQueryResponse xqr = queryResponse.xpQueryResponse[0];

				XmlDocument xd = new XmlDocument();
				XmlElement root = xd.CreateElement("root");
				xd.AppendChild(root);
				int dtmf = 1;
				foreach(listType lt in xqr.Items)
				{
					XmlElement xe = xd.CreateElement("option");
					XmlAttribute xa1 = xd.CreateAttribute("dtmf");
					xa1.Value = dtmf.ToString();
					dtmf++; //iter for next element
					XmlAttribute xa2 = xd.CreateAttribute("value");
					xa2.Value = lt.id;
					xe.Attributes.Append(xa1);
					xe.Attributes.Append(xa2);
					//localizableString [] lsa = fwst.title;
					xe.InnerText = lt.title[0].Value;
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
