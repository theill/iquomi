#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Commanigy.Iquomi {
	public class XmlSiteMapProviderEx : System.Web.XmlSiteMapProvider {
		public XmlSiteMapProviderEx() {

		}
		
		/// <summary>
		/// Explicitly sets "readonly" property to "false" so it's possible 
		/// to make changes to it (i.e. setting Title property, etc)
		/// </summary>
		/// <value></value>
		public override System.Web.SiteMapNode CurrentNode {
			get { 
				System.Web.SiteMapNode n = base.CurrentNode;
				if (n != null) {
					n.ReadOnly = false;
				}
				return n;
			}
		}

	}
}
