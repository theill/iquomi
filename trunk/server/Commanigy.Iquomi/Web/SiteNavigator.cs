#region Using directives

using System;
using System.Xml.XPath;

using log4net;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for SiteNavigator.
	/// </summary>
	public class SiteNavigator {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private static SiteNavigator instance;

		private XPathNavigator xpathNavigator;
		private string page;

		private SiteNavigator(string configFile, string page) {
			xpathNavigator = new XPathDocument(configFile).CreateNavigator();
			this.page = page;
		}
		
		public static SiteNavigator GetInstance() {
//			if (instance == null) {
				instance = new SiteNavigator(
					System.Web.HttpContext.Current.Server.MapPath("~/website.flow.xml"),
					System.Web.HttpContext.Current.Request.Path
					);
//			}

			return instance;
		}

		/// <summary>
		/// Property Location (string)
		/// </summary>
		public string Location {
			get {
				XPathNodeIterator i = xpathNavigator.Select("//page[@file='" + page + "']/title");
				if (i.MoveNext()) {
					return i.Current.Value;
				}

				return page;
			}
		}
	}
}
