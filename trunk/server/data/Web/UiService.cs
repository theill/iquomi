#region Using directives

using System;
using System.Data;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public class UiService : DbService {
		public UiService() {
			;
		}
		
		//[Obsolete]
		//public static UiService Get() {
		//    UiService s = (UiService)System.Web.HttpContext.Current.Session["service"];
		//    if (s == null) {
		//        WorkFlow.Instance.GoNext("logon");
		//        return null;
		//    }

		//    return s;
		//}

		//[Obsolete]
		//public static void Set(UiService v) {
		//    System.Web.HttpContext.Current.Session["service"] = v;
		//}

	}
}