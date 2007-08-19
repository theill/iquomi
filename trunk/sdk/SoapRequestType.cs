#region Using directives

using System;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Services {
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://services.iquomi.com/2004/01/core", IsNullable = false)]
	public class SoapRequestType : SoapHeader {
		public RequestType Value;
	}
}