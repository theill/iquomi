#region Using directives

using System;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Services {
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://services.iquomi.com/2004/01/core", IsNullable=false)]
	public class SoapAuthenticationType : SoapHeader {
		private string iqid;
		private string password;

		// Unique identifier for user performing request
		public string Iqid {
			get {
				return iqid;
			}

			set {
				iqid = value;
			}
		}

		// MD5 encrypted password for requesting user
		public string Password {
			get {
				return password;
			}

			set {
				password = value;
			}
		}
	}
}
