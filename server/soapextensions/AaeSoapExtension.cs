#region Using directives

using System;
using System.Security.Principal;
using System.Xml;
using System.Web;
using System.Web.Security;
using System.Web.Services.Protocols;

#endregion

namespace Commanigy.Iquomi.Aae {
	/// <summary>
	/// Summary description for AAESoapExtension.
	/// </summary>
	public class AaeSoapExtension : SoapExtension {
		public AaeSoapExtension() {
			;
		}
		
		public override object GetInitializer(Type serviceType) {
			return null;
		}
		
		public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) {
			return null;
		}
		
		public override void Initialize(object initializer) {
			;
		}
		
		public override void ProcessMessage(SoapMessage message) {
			if (message is SoapServerMessage) {
				switch (message.Stage) {
					case SoapMessageStage.BeforeDeserialize:
						break;

					case SoapMessageStage.AfterDeserialize:
						break;

					case SoapMessageStage.BeforeSerialize:
						break;

					case SoapMessageStage.AfterSerialize:
						break;
				}
			}
		}

		private bool AuthenticateRequest(SoapServerMessage message) {
			string soapHeaderTicket = null;
			System.Xml.XmlNode node = null;
			System.Collections.IEnumerator enumerator = null;

			try {
				// Loop through the collection of SoapHeaders
				foreach (SoapUnknownHeader header in message.Headers) {
					// Inspect the KrakSoapHeader
					if ((header.Element.Name == "IquomiHeader") && (header.Element.NamespaceURI == "http://webservice.krak.dk/")) {
						enumerator = header.Element.ChildNodes.GetEnumerator();
						while (enumerator.MoveNext()) {
							node = (System.Xml.XmlNode)enumerator.Current;
						}
					}
				}

				FormsAuthenticationTicket ticket = null;
				try {
					ticket = FormsAuthentication.Decrypt(soapHeaderTicket);
				}
				catch {
					;
				}

				string userData = ticket.UserData;
				
				if (ticket.Expired) {
					;
				}
				
				HttpContext.Current.User = new GenericPrincipal(
					new FormsIdentity(ticket), 
					new string[] {""}
					);
				
				return true;
			}
			catch(ApplicationException) {
				return false;
			}
		}

	}
}
