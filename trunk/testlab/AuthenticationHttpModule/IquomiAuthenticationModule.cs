using System;
using System.Web;

namespace Commanigy.Iquomi.Auth {
	/// <summary>
	/// Provides authentication for incoming SOAP requests by checking 
	/// header for identification tokens.
	/// </summary>
	public class IquomiAuthenticationModule : IHttpModule {
		
		public void Init(HttpApplication ha) {
			ha.PreRequestHandlerExecute += new EventHandler(
				this.onPreRequestHandlerExecute
				);
			
			ha.PostRequestHandlerExecute += new EventHandler(
				this.onPostRequestHandlerExecute
				);
		}
		
		public void Dispose() {
			;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="o"></param>
		/// <param name="ea"></param>
		public void onPreRequestHandlerExecute(object o, EventArgs ea) {
			HttpApplication ha = (HttpApplication)o;
			Type t = (ha.Context.Handler).GetType();
		return;

			if ((ha.Context.Request.ServerVariables["HTTP_SOAPACTION"] == null) && (t.Namespace.ToString() != "System.Web.Services.Protocols")) {
				return;
			}
			ha.Context.Cache.Add("accountId", 1, null, System.DateTime.Now.AddDays(1), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
			
			Uri url = (Uri)ha.Request.Url;
//			WSPF.Monitor m = new WSPF.Monitor(url.AbsoluteUri, httpApp.Request.UserHostAddress);
//			if (m.ServiceID > 0) {
//
//				if (m.Valid) {
//					m.BeginTime = System.DateTime.Now;
//					httpApp.Context.Cache.Add(String.Concat("monitor_esynaps_ws_", httpApp.Context.Request.GetHashCode().ToString()), m, null, System.DateTime.Now.AddDays(1), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
//				} else {
//					SoapException se = new SoapException(m.ErrorMessage.ToString(), SoapException.ServerFaultCode,httpApp.Context.Request.Url.AbsoluteUri);
//					httpApp.CompleteRequest();
//					throw se;
//
//				}
//			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="o"></param>
		/// <param name="ea"></param>
		public void onPostRequestHandlerExecute(object o, EventArgs ea) {
			HttpApplication ha = (HttpApplication)o;
			Type t = (ha.Context.Handler).GetType();
			if ((ha.Context.Request.ServerVariables["HTTP_SOAPACTION"] == null) && (t.Namespace.ToString() != "System.Web.Services.Protocols")) {
				return;
			}
			
			ha.Context.Cache.Remove("accountId");
			
//			if (httpApp.Context.Cache.Get(String.Concat("monitor_esynaps_ws_", httpApp.Context.Request.GetHashCode().ToString())) == null) {
//			}
//			else {
//				WSPF.Monitor m = (WSPF.Monitor) httpApp.Context.Cache.Get(String.Concat("monitor_esynaps_ws_", httpApp.Context.Request.GetHashCode().ToString()));
//				if(m.Valid) {
//					m.EndTime = System.DateTime.Now;
//					m.Save();
//					httpApp.Context.Cache.Remove(String.Concat("monitor_esynaps_ws_", httpApp.Context.Request.GetHashCode().ToString()));
//				}
//				else {
//					httpApp.Context.Cache.Remove(String.Concat("monitor_esynaps_ws_", httpApp.Context.Request.GetHashCode().ToString()));
//				}
//			}
		}
	}
}