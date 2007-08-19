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

using IqServicesRef;

using log4net;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceBookmarkSyncPage : Commanigy.Iquomi.Web.WebPage {
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
			myService.SoapRequestTypeValue.Value.Service = "bookmarksync";
			RequestTypeKey rtk = new RequestTypeKey();
			rtk.Cluster = "";
			rtk.Instance = "";
			rtk.Puid = "petertheill";
			myService.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { rtk };

			QueryRequestType q = new QueryRequestType();
			XpQueryType qt = new XpQueryType();
			qt.Select = "/xbel/folder | /xbel/bookmark";
			q.XpQuery = new XpQueryType[] { qt };
			try {
				QueryResponseType response = myService.Query(q);
				if (response != null && response.XpQueryResponse != null) {
//					string xml = (string)response.XpQueryResponses[0].Any;
//					
//					notes.DocumentContent = "<response>" + xml + "</response>";
//					
//					log.Debug("Got back:\n " + xml);
//					
//					XslTransform trans = new XslTransform();
//					trans.Load(Server.MapPath("bookmarksync.xslt"));
//					
//					notes.Transform = trans;
				}
			}
			catch (Exception ex) {
				log.Error("Failed to perform operation for notes", ex);
			}
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {    

		}
		#endregion
	}
}