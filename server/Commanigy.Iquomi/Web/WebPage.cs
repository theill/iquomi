#region Using directives

using System;
using System.Web;
using System.Resources;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	public delegate void PageSuccessHandler();

	/// <summary>
	/// 
	/// </summary>
	public class WebPage : System.Web.UI.Page, IPageNotification {
		protected static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		protected event PageSuccessHandler OnPageSuccess;

		protected object GetPageResourceObject(string s) {
			try {
//				return base.GetPageResourceObject(s) ?? (object)s;
				return s;
			}
			catch (MissingManifestResourceException) {
				return s;
			}
		}

		protected string _(string msg) {
			return (string)this.GetPageResourceObject(msg);
		}


		/// <summary>
		/// Redirects to url found from sitemap.
		/// </summary>
		/// <param name="siteMapUrl"></param>
		/// <param name="args"></param>
		protected void Redirect(string siteMapUrl, object[] args) {
			HttpContext.Current.Response.Redirect(Link(siteMapUrl, args), true);
		}

		#region Get* methods for request querystring parameters

		protected Int32 GetInt32(string key) {
			return Convert.ToInt32(HttpContext.Current.Request[key]);
		}

		protected string GetString(string key) {
			return HttpContext.Current.Request[key];
		}

		protected Guid GetGuid(string key) {
			return new Guid(HttpContext.Current.Request[key]);
		}

		#endregion
		
		public string Link(string siteMapUrl, object[] args) {
			SiteMapNode n = SiteMap.Provider.FindSiteMapNode("~/" + siteMapUrl);
			if (n == null) {
				log.Debug("Failed to look up node for " + siteMapUrl);
				throw new ArgumentException();
			}

			string qs = n["args"];

			return siteMapUrl + (!string.IsNullOrEmpty(qs) ? "?" + WorkFlow.Encrypt(string.Format(qs, args)) : "");
		}

		#region IPageNotification Members

		public virtual void Notify(Exception e) {
			throw new NotImplementedException();
		}

		public virtual void Notify(string message) {
			throw new NotImplementedException();
		}

		public void Success() {
			if (OnPageSuccess != null) {
				OnPageSuccess();
			}
		}

		#endregion
	}
}