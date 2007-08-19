using System;
using System.Web.Services.Protocols;

using Commanigy.Iquomi.Api;

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// 
	/// </summary>
	public class RequestType : SoapHeader, IRequestType {
		private string service;
		private string ownerIqid;
		private string method;
		private RequestTypeGenResponse genResponse;

		/// <summary>
		/// Unique name of service.
		/// </summary>
		/// <value></value>
		public string Service {
			get {
				return service;
			}

			set {
				service = value;
			}
		}

		/// <summary>
		/// Type of method such as Insert, Replace, etc or a service specific 
		/// method.
		/// </summary>
		public string Method {
			get {
				return method;
			}
			set {
				method = value;
			}
		}

		/// <summary>
		/// Unique owner id of service (identifies subscription).
		/// </summary>
		/// <value></value>
		public string OwnerIqid {
			get {
				return ownerIqid;
			}

			set {
				ownerIqid = value;
			}
		}

		/// <summary>
		/// Type of response being returned to client
		/// </summary>
		public RequestTypeGenResponse GenResponse {
			get {
				return genResponse;
			}
			set {
				genResponse = value;
			}
		}
	}
}