#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;
using Commanigy.Utils;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServicesIqAlertsPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private void Page_Load(object sender, System.EventArgs e) {
			
		}

		/*
		ReadRDF("http://www.xsltblog.com/index.rdf");
		private void ReadRDF(string s) {
			XmlTextReader r = new XmlTextReader(s);
			XmlDocument d = new XmlDocument();
			d.Load(r);
			XmlNamespaceManager ns = new XmlNamespaceManager(d.NameTable);
			ns.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
			XmlNodeList nl = d.SelectNodes("//rdf:RDF", ns);
			log.Debug("Got: " + nl.Count + " node(s)");
		}
		*/

		protected void BtnSubmitAlert_Click(object sender, EventArgs e) {
			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqAlertsRef.IqAlerts myService = (IqAlertsRef.IqAlerts)serviceLocator.GetService(
				typeof(IqAlertsRef.IqAlerts),
				TbxUserId.Text
				);

			IqAlertsRef.NotifyType notify = new IqAlertsRef.NotifyType();
			notify.Content = new IqAlertsRef.ViewType();
			notify.Content.ContentType = DdlContentType.SelectedValue;
			notify.Content.Subject = "Alert from web site";
			notify.Content.Value = TbxMessage.Text;
			notify.Meta = new IqAlertsRef.MetaType();
			notify.Meta.Subject = "Meta subject";

			try {
				IqAlertsRef.NotifyResponseType response = myService.Notify(notify);
				if (response.Status == IqAlertsRef.ResponseStatusType.Success) {
					Notification.Success("Alert has been dispatched to user");
				}
				else {
					Notification.Failed("Unable to dispatch alert. User might not have been found.");
				}
			}
			catch (System.Net.WebException x) {
				Notification.Failed(x.Message);
			}
		}

	}
}