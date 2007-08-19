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

using IqCoreRef;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServicesIqRssPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected void Page_Load(object sender, System.EventArgs e) {

			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqCore myService = (IqCore)serviceLocator.GetService(
				typeof(IqCore),
				UiAccount.Get().Iqid
				);
			myService.SoapRequestTypeValue.Value.Service = "IqRss";

			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[1];
			q.XpQuery[0] = new XpQueryType();
			q.XpQuery[0].Select = "/rss/channel[title='The Theill Web Site']";
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MinOccursSpecified = true;
			q.XpQuery[0].MaxOccurs = 1;
			q.XpQuery[0].MaxOccursSpecified = true;

			try {
				QueryResponseType response = myService.Query(q);
				if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
					Notification.Success("Data read");

					XmlView.DocumentContent = response.XpQueryResponse[0].Any[0].OuterXml;

					XslTransform trans = new XslTransform();
					trans.Load(Server.MapPath("~/iqrss.xslt"));

					XmlView.Transform = trans;
				}
				else {
					Notification.Failed("Unable to read data.");
				}
			}
			catch (System.Net.WebException x) {
				Notification.Failed(x.Message);
			}
		}


	}
}