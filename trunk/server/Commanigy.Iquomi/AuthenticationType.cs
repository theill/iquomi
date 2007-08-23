using System.Web.Services.Protocols;
using System.Xml.Serialization;

using Commanigy.Iquomi.Api;

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// 
	/// </summary>
	public class AuthenticationType : SoapHeader, IAuthenticationType {
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