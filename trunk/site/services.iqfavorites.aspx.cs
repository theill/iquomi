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
using IqServicesRef;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceIqFavoritesPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private void Page_Load(object sender, System.EventArgs e) {
			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqCoreSoap myService = (IqCoreSoap)serviceLocator.GetService(
				typeof(IqCoreSoap),
				UiAccount.Get().Iqid
				);

			myService.SoapRequestTypeValue.Value.Service = "iqFavorites";

			XpQueryType query = new XpQueryType();
			query.Select = "/m:IqFavorites/m:Favorite";
			QueryRequestType req = new QueryRequestType();
			req.XpQuery = new XpQueryType[] { query };
			QueryResponseType res = myService.Query(req);
			if (res.XpQueryResponse[0].Status == ResponseStatus.Success) {
				StringBuilder xml = new StringBuilder();
				foreach (XmlElement n in res.XpQueryResponse[0].Any) {
					xml.Append(n.OuterXml);
				}

				notes.DocumentContent = "<response>" + xml.ToString() + "</response>";

				XslTransform trans = new XslTransform();
				trans.Load(Server.MapPath("~/iqfavorites.xslt"));

				notes.Transform = trans;
			} else {
				;
			}
		}
	}
}