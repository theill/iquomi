#region Using directives

using System;
using System.Xml;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Reflection;

using log4net;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Services.IqAlerts {
	/// <summary>
	/// Summary description for IqAlertsService.
	/// </summary>
	public class IqAlertsService : IqCoreService {
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		//static IqAlertsService() {
		//    bool alreadyRegistered = false;
		//    foreach (WellKnownServiceTypeEntry e in RemotingConfiguration.GetRegisteredWellKnownServiceTypes()) {
		//        if (e.ObjectType == typeof(Alert)) {
		//            alreadyRegistered = true;
		//            break;
		//        }
		//    }

		//    if (!alreadyRegistered) {
		//        log.Debug("Going to register using " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
		//    }
		//    else {
		//        log.Debug("Already registered");
		//        log.Debug(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
		//    }

		//    ChannelServices.RegisterChannel(new TcpChannel(4083));

		//    RemotingConfiguration.RegisterWellKnownServiceType(
		//        typeof(Alert),
		//        "alerts.soap",
		//        WellKnownObjectMode.Singleton
		//        );

		//    log.Debug(".NET Remoting objects for IqAlerts successfully registered");
		//log.Debug("Alert service type registered as .NET Remoting object");
		//			RemotingConfiguration.Configure(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".config");
		//}

		public IqAlertsService() {
			log.Debug("Service \"IqAlerts\" initialized");

			// .NET Remoting configuration is currently handled in "global.asax"
		}


		public override Module ServiceModule {
			get {
				return typeof(IqAlertsType).Module;
			}
		}

		[WebMethod]
		public void Void(IqAlertsType a) {

		}


		///// <summary>
		///// Sends one or more notifications to the targeted receiver.
		///// </summary>
		///// <param name="notification"></param>
		///// <returns></returns>
		//[WebMethod]
		//[SoapHeader("Authentication")]
		//[SoapHeader("Request")]
		//public NotifyResponseType Notify(NotifyRequestType notify) {
		//    NotifyResponseType response = new NotifyResponseType();
		//    if (notify.Notification.Length == 0) {
		//        response.Status = ResponseStatusType.Success;
		//        return response;
		//    }

		//    // TODO store notification into service and have external thread
		//    // actually dispatch these notifications

		//    foreach (NotificationType notification in notify.Notification) {

		//    }

		//    return response;
		//}

		[WebMethod]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public NotifyResponseType Notify(NotifyType notification) {
			string iqid = this.Request.Value.Key[0].Puid;
			log.Debug(string.Format("Iqid \"{0}\" requests channel for \"{1}\"...", this.Authentication.Iqid, iqid));

			// TODO: use internal 'Query' request to get channel for user. 
			// This ensures the requester (Authentication.Iqid) is allowed
			// to get a channel for requested user (Request...Puid)

			// Query: /m:IqAlerts/m:Connection[m:ArgotQuery='HumanReadable']
			QueryRequestType request = new QueryRequestType();
			request.XpQuery = new XpQueryType[] { new XpQueryType() };
//			request.XpQuery[0].Select = "/m:IqAlerts/m:Connection[m:Argot/@ArgotURI='http://schemas.iquomi.com/2004/01/iqAlerts/HumanReadableArgot.xsd']";
			request.XpQuery[0].Select = string.Format("/m:IqAlerts/m:Connection[m:Argot/@ArgotURI='{0}']", notification.Content.ContentType);
			request.XpQuery[0].MinOccurs = 1;
			request.XpQuery[0].MinOccursSpecified = true;

			NotifyResponseType response = new NotifyResponseType();

			QueryResponseType query = this.Query(request);
			if (query.XpQueryResponse[0].Status == ResponseStatus.Success) {
				ConnectionType connection = (ConnectionType)query.XpQueryResponse[0].Items[0];

				log.Debug("Looking up channel \"" + connection.Id + "\"");

				AlertHandler handler = AlertsSubscriptionManagement.Instance.GetChannel(connection.Id);
				if (handler != null) {
					log.Debug("Notifying client " + iqid + " about " + notification.Content.Subject);
					try {
						handler(notification);
						response.Status = ResponseStatusType.Success;
					}
					catch (Exception e) {
						log.Error("Failed to notify client " + iqid, e);
						response.Status = ResponseStatusType.Failure;
						//					throw e;
					}
				}
				else {
					log.Debug("No channel found for user");

					// unable to find user where notification should be delivered
					response.Status = ResponseStatusType.Failure;
				}
			}
			else {
				log.Debug("Failed to find channel");

				// unable to find channel for user
				response.Status = ResponseStatusType.Failure;
			}

			return response;
		}

        [WebMethod]
        public string[] DebugListUsers() {
			return AlertsSubscriptionManagement.Instance.RegisteredUsers();
        }
    }
}