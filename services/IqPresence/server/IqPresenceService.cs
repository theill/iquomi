#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Reflection;

using log4net;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Services.IqPresence {
	/// <summary>
	/// Core IqPresence service.
	/// 
	/// This service contains the electronic presence information for 
	/// endpoints, who control access to this information themselves.
	/// </summary>
//	[System.Web.Services.Configuration.XmlFormatExtension("IqPresence", "http://schemas.iquomi.com/2004/01/iqPresence", typeof(System.Web.Services.Description.Types))]
	public class IqPresenceService : IqCoreService {
		protected static readonly ILog log = LogManager.GetLogger(
			MethodBase.GetCurrentMethod().DeclaringType
			);

		private MessengerManagement messengerManagement = MessengerManagement.Instance;

		public MessengerArgotType messengerArgotType;

		public IqPresenceService() {
			log.Debug("Service \"IqPresence\" initialized");

		}

		public override System.Reflection.Module ServiceModule {
			get {
				return typeof(IqPresenceType).Module;
			}
		}

		/// <summary>
		/// Sends a notification to a specified endpoint.
		/// </summary>
		/// <param name="req"></param>
		[WebMethod]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public void NotifyEndpoint(NotifyEndpointRequest req) {
			log.Debug("Notifying endpoint for user " + this.Request.Value.Key[0].Puid + "...");
			IqAlerts.AlertHandler endPoint = PresenceManagement.Instance.GetEndpoint(req.EndpointId);
		}

		[WebMethod]
		public IqPresenceType Void() {
			return new IqPresenceType();
		}

		[WebMethod(Description="Sends a message to specified user")]
		public void SendMessage(string puid, string message) {
			log.Debug("Starting to send " + message + " to " + puid);

			MessengerManagement.Instance.SendTextMessage(puid, message);
		}
	}
}