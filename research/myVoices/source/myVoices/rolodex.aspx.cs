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

using hsProxy.myContactsNs;
using System.Xml;

namespace myVoices
{
	/// <summary>
	/// Summary description for rolodex.
	/// </summary>
	public class rolodex : GlobalPage
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				hsProxy.hsProxy hsp = new hsProxy.hsProxy();
				int puid = GetPuid();
				myContacts myCon = (myContacts) hsp.GetMyService(typeof(myContacts), puid);

				//hack because cannot xpath by substring yet
				//so select all and then iterate through manually
				//possibly change to an {any} element with the search char
				string letter = Request["letter"]; //"c";
				//string queryStr = "/mc:myContacts/mc:contact[./mc:name/mp:surname='chesnut']";
				string queryStr = "/m:myContacts/m:contact";

				queryRequestType queryRequest = new queryRequestType();
				xpQueryType xpQuery = new xpQueryType();
				xpQuery.select=queryStr;
				queryRequest.xpQuery = new xpQueryType[]{xpQuery};

				queryResponseType queryResponse = myCon.query(queryRequest);

				queryResponseTypeXpQueryResponse xqr = queryResponse.xpQueryResponse[0];

				XmlDocument xd = new XmlDocument();
				XmlElement root = xd.CreateElement("root");
				xd.AppendChild(root);
				int dtmf = 1;
				
				foreach(contactType ct in xqr.Items)
				{
					XmlElement xe = xd.CreateElement("option");
					XmlAttribute xa1 = xd.CreateAttribute("dtmf");
					xa1.Value = dtmf.ToString();
					dtmf++; //iter for next element
					XmlAttribute xa2 = xd.CreateAttribute("value");
					string email = "email: " + ct.emailAddress[0].email;
					string phone = "phone: " + ct.telephoneNumber[0].nationalCode + ct.telephoneNumber[0].number;
					xa2.Value = email + " " + phone;
					xe.Attributes.Append(xa1);
					xe.Attributes.Append(xa2);
					//localizableString [] lsa = fwst.title;
					string firstName = ct.name[0].givenName.Value; 
					string lastName = ct.name[0].surname.Value;
					if(firstName.StartsWith(letter) | lastName.StartsWith(letter))
					{
						xe.InnerText = firstName + " " + lastName;
						root.AppendChild(xe);
					}
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
