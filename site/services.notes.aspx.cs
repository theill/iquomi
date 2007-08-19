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
	public partial class ServiceNotesPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private void Page_Load(object sender, System.EventArgs e) {
			
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
			myService.SoapRequestTypeValue.Value.Service = "OutlookNotes";
			RequestTypeKey rtk = new RequestTypeKey();
			rtk.Cluster = "";
			rtk.Instance = "";
			rtk.Puid = "petertheill";
			myService.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { rtk };

			QueryRequestType q = new QueryRequestType();
			XpQueryType qt = new XpQueryType();
			qt.Select = "/notes/note";
			q.XpQuery = new XpQueryType[] { qt };
			try {
				QueryResponseType response = myService.Query(q);
				if (response.XpQueryResponse != null) {
					string xml = string.Empty;
					foreach (XmlElement note in response.XpQueryResponse[0].Any) {
						xml += note.OuterXml;
					}
					notes.DocumentContent = "<response>" + xml + "</response>";

					log.Debug("Got back:\n " + xml);

					XslTransform trans = new XslTransform();
					trans.Load(Server.MapPath("notes.xslt"));

					notes.Transform = trans;
				}
			}
			catch (Exception ex) {
				log.Error("Failed to perform operation for notes", ex);
				Notification.Failed(ex.Message);
			}
		}
	}
}