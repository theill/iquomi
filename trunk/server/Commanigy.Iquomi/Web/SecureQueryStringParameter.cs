#region Using directives

using System;
using System.Text;
using System.Web;
using System.Web.UI;

#endregion

namespace Commanigy.Iquomi.Web {
	public class SecureQueryStringParameter : System.Web.UI.WebControls.QueryStringParameter {
		protected override object Evaluate(HttpContext context, Control control) {
			if ((context != null) && (context.Request != null)) {
				// TODO: decrypt value before it's returned
				return context.Request.QueryString[this.QueryStringField];
			}
			return null;
		}
	}
}
