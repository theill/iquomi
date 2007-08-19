#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;
using System.Xml;

using log4net;

using IqServicesRef;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServicesIqSmsPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private void Page_Load(object sender, System.EventArgs e) {
			
		}

		protected void Button1_Click(object sender, EventArgs e) {
			UiAccount account = UiAccount.Get();
			if (account == null) {
				return;
			}

			IqCoreSoap myService = new IqCoreSoap();
			myService.SoapAuthenticationTypeValue = new SoapAuthenticationType();
			myService.SoapAuthenticationTypeValue.Iqid = account.Iqid;
			myService.SoapAuthenticationTypeValue.Password = account.Password;
			myService.SoapRequestTypeValue = new SoapRequestType();
			myService.SoapRequestTypeValue.Value = new RequestType();
			myService.SoapRequestTypeValue.Value.Document = RequestTypeDocument.Content;
			myService.SoapRequestTypeValue.Value.GenResponse = RequestTypeGenResponse.Always;
			myService.SoapRequestTypeValue.Value.Service = "IqSms";
			RequestTypeKey rtk = new RequestTypeKey();
			rtk.Cluster = "";
			rtk.Instance = "";
			rtk.Puid = "petertheill";
			myService.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { rtk };

			XmlDocument document = new XmlDocument();
			document.LoadXml(string.Format("<m:ShortMessage><From><Address /><Name>{0}</Name></From><Body>{1}</Body></m:ShortMessage>", TbxFrom.Text, TbxBody.Text));

			InsertRequestType req = new InsertRequestType();
			req.Select = "/m:IqSms";
			req.Any = new XmlElement[] { document.DocumentElement };
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;
			req.MaxOccurs = 1;
			req.MaxOccursSpecified = true;
			req.UseClientIds = true;

			try {
				InsertResponseType res = myService.Insert(req);
				if (res.Status == ResponseStatus.Success) {
					Label1.Text = "ok";
				}
				else {
					Label1.Text = "Failed: " + res.Message;
				}
			}
			catch (Exception x) {
				Label1.Text = "Exception: " + x.Message;
			}
		}
	}
}