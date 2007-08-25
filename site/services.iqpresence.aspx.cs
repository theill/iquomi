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

using Commanigy.Iquomi.Api;

using IqPresenceRef;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServicesIqPresencePage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private void Page_Load(object sender, System.EventArgs e) {
			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqPresence myService = (IqPresence)serviceLocator.GetService(
				typeof(IqPresence),
				UiAccount.Get().Iqid
				);

			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[] { new XpQueryType(), new XpQueryType() };
			q.XpQuery[0].Select = "/m:IqPresence/m:Endpoint[@Name='Home Computer']/m:Argot[@Name='Iquomi Messenger']";
			q.XpQuery[0].MinOccursSpecified = true;
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MaxOccursSpecified = true;
			q.XpQuery[0].MaxOccurs = 1;
			q.XpQuery[1].Select = "/m:IqPresence/m:Endpoint[@Name='Work Computer']/m:Argot[@Name='Iquomi Messenger']";
			q.XpQuery[1].MinOccursSpecified = true;
			q.XpQuery[1].MinOccurs = 0;
			q.XpQuery[1].MaxOccursSpecified = true;
			q.XpQuery[1].MaxOccurs = 1;

			try {
				QueryResponseType response = myService.Query(q);
				if (response.XpQueryResponse[0].Status == ResponseStatus.Success && response.XpQueryResponse[0].Items.Length > 0) {
					ArgotType1 a = response.XpQueryResponse[0].Items[0] as ArgotType1;
					PresenceInfo.Text += "Home: " + a.Any[0].OuterXml;
				}

				if (response.XpQueryResponse[1].Status == ResponseStatus.Success && response.XpQueryResponse[1].Items != null && response.XpQueryResponse[1].Items.Length > 0) {
					ArgotType1 a = response.XpQueryResponse[1].Items[0] as ArgotType1;
					PresenceInfo.Text += "Work: " + a.Any[0].OuterXml;
				}
			}
			catch (Exception x) {
				log.Error("Failed to receive presence", x);
			}
		}
	}
}