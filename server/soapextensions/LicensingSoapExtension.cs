using System;
using System.Web.Services.Protocols;

namespace Commanigy.Iquomi.Licensing {
	/// <summary>
	/// Summary description for LicensingSoapExtension.
	/// </summary>
	public class LicensingSoapExtension : SoapExtension {
		public LicensingSoapExtension() {
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

	}
}