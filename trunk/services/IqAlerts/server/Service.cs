using System;
using System.Xml;
using System.Runtime.Remoting;
using System.Collections;

namespace Commanigy.Iquomi.Services.IqAlerts {
	class Service {
		static void Main() {
			RemotingConfiguration.Configure("Service.exe.config");
			Console.WriteLine("Host started.  Press ENTER to exit.");
			string x = Console.ReadLine();
			while (!"".Equals(x)) {

				AlertHandler c = AlertsSubscriptionManagement.GetInstance().GetChannel(x);
				if (c != null) {
					try {
						NotifyType at = new NotifyType();
						at.Content = new ViewType();
						at.Content.ContentType = "text/plain";
						at.Content.Value = "This is just a test";
						at.Content.Subject = "Test subject";
						at.Language = "en-US";
						at.Meta = new MetaType();
						at.Meta.BaseUrl = "adf";
						at.Meta.ActionUrl = "http://do.iquomi.com/";
						c(at);
					}
					catch (Exception e) {
						Console.WriteLine("Failed to fire event.");
						Console.WriteLine(e.Message);
						throw e;
					}
				}
				else {
					Console.WriteLine("User " + x + " wasn't found");
				}

				x = Console.ReadLine();
			}
		}
	}
}