#region Using directives

using System;
using System.Web;
using System.Xml;

using log4net;
#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for WorkFlow.
	/// </summary>
	public class WorkFlow {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private XmlDocument document;

		private string nextStep;
		private object[] arguments;
		
		public WorkFlow(string config) {
			Load(config);
		}
		
		private void Load(string config) {
			document = new XmlDocument();
			document.Load(config);
		}

		public string Next {
			get {
				return nextStep;
			}

			set {
				nextStep = value;
			}
		}

		public object[] Arguments {
			get {
				return arguments;
			}

			set {
				arguments = value;
			}
		}
		
		public string PageTitle {
			get {
				XmlElement e = (XmlElement)document.SelectSingleNode("//page[@id='" + Next + "']");
				return (e != null) ? e.GetAttribute("title") : null;
			}
		}
		
		public void Go() {
			XmlElement e = (XmlElement)document.DocumentElement.SelectSingleNode("//page[@id='" + Next + "']");
			if (e == null) {
				log.Debug("Unable to find page \"" + Next + "\" in flow");
				System.Web.HttpContext.Current.Response.StatusCode = 404;
				System.Web.HttpContext.Current.Response.End();
			}

			string filename;
			if (e.HasAttribute("file")) {
				filename = e.GetAttribute("file");
			} else {
				filename = "~/" + e.GetAttribute("id") + ".aspx";
			}

			if (Arguments != null && Arguments.Length > 0) {
				filename = String.Format(filename, Arguments);
			}

			System.Web.HttpContext.Current.Response.Redirect(
				filename,
				true
				);
		}

		public void GoNext(string nextStep) {
			Next = nextStep;
			Go();
		}

		public void GoNext(string nextStep, object[] arguments) {
			Arguments = arguments;
			GoNext(nextStep);
		}

		public void GoNext(string nextStep, object arg0) {
			GoNext(nextStep, new object[] { arg0 });
		}

		public void GoNext(string nextStep, object arg0, object arg1) {
			GoNext(nextStep, new object[] { arg0, arg1 });
		}

		#region Get* methods for request querystring parameters
		public Int32 GetInt32(string key) {
			return Convert.ToInt32(HttpContext.Current.Request[key]);
		}

		public Int32? GetInt32Q(string key) {
			string v = HttpContext.Current.Request[key];
			return !string.IsNullOrEmpty(v) ? Convert.ToInt32(v) as Int32? : null;
		}

		public string GetString(string key) {
			return HttpContext.Current.Request[key];
		}
		
		public Guid GetGuid(string key) {
			return new Guid(HttpContext.Current.Request[key]);
		}
		#endregion

		public static string Encrypt(string qs) {
			// TODO implement method for encrypting an *entire* url e.g. the
			// input could be id=1&type_id=582. The returned value could be
			// someting like 0x02097FA92 and must be appended to an url to 
			// give /service.aspx?q=0x02097FA92
			//byte[] encrypted = System.Security.Cryptography.ProtectedData.Protect(
			//    new System.Text.UTF8Encoding().GetBytes(qs), 
			//    new byte[] { 9, 8, 7, 6, 5 }, 
			//    System.Security.Cryptography.DataProtectionScope.LocalMachine
			//    );
			//return System.Convert.ToBase64String(encrypted);
			return qs;
		}

		public static string Decrypt(string key) {
			//byte[] unencrypted = System.Security.Cryptography.ProtectedData.Unprotect(
			//    System.Convert.FromBase64String(key),
			//    new byte[] { 9, 8, 7, 6, 5 },
			//    System.Security.Cryptography.DataProtectionScope.LocalMachine
			//    );
			//return new System.Text.UTF8Encoding().GetString(unencrypted);
			return key;
		}

		//public static WorkFlow Instance {
		//    get {
		//        return WorkFlow.GetInstance();
		//    }
		//}

		private static WorkFlow GetInstance() {
			WorkFlow wf = (WorkFlow)System.Web.HttpContext.Current.Session["workflow"];
			if (wf == null) {
				wf = new WorkFlow(System.Web.HttpContext.Current.Server.MapPath("~/website.flow.xml"));
				System.Web.HttpContext.Current.Session["workflow"] = wf;
			}

			#if DEBUG
			wf.Load(System.Web.HttpContext.Current.Server.MapPath("~/website.flow.xml"));
			#endif

			return wf;
		}
	}
}