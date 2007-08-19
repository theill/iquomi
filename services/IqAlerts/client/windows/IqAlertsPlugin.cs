#region Using directives

using System;
using System.IO;
using System.Runtime.Remoting;
using System.Configuration;
using System.Reflection;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

//using Commanigy.Iquomi.Api;

using Commanigy.Iquomi.Services.IqAlerts.IqAlertsRef;

#endregion

namespace Commanigy.Iquomi.Services.IqAlerts {
	/// <summary>
	/// Summary description for IqAlertsPlugin.
	/// </summary>
	public class IqAlertsPlugin : Api.IPlugin {
		private Api.IPluginHost pluginHost;
		private IAlert alert;
		private AlertHandler OnAlerts;

		public IqAlertsPlugin() {

		}

		public Api.IPluginHost Host {
			get {
				return pluginHost;
			}

			set {
				pluginHost = value;
			}
		}

		public string Name {
			get {
				return "IqAlerts";
			}
		}

		public string Version {
			get {
				return "1.0.0.0";
			}
		}

		public void OnLoad() {
			IqAlertsRef.IqAlerts myAlerts = (IqAlertsRef.IqAlerts)this.Host.GetService(
				typeof(IqAlertsRef.IqAlerts),
				this.Host.Iqid
				);

			InsertRequestType req = new InsertRequestType();
			req.Select = "/m:IqAlerts";
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;

			HumanReadable argot = new HumanReadable();
			argot.ActionUrl = "";
			argot.BaseUrl = "";
			argot.Language = new HumanReadableLanguage[] { new HumanReadableLanguage() };
			argot.Language[0].IconUrl = "";
			argot.Language[0].lang = "en-US";
			argot.Language[0].Text = "asdf";

			ConnectionType connection = new ConnectionType();
			connection.Creator = new byte[] { 0x00, 0x01, 0x02, 0x03};
			connection.ChangeNumber = "";
			connection.Id = "";
			connection.Argot = new ArgotType[] { new ArgotType() };
			connection.Argot[0].ArgotURI = "http://schemas.iquomi.com/2004/01/iqAlerts/HumanReadableArgot.xsd";
			connection.Argot[0].Any = new XmlElement[] { this.Host.SetObject(argot, "HumanReadable") };
			connection.ArgotQuery = NotificationQueryType.Item;
			connection.Class = ConnectionClassType.Push_http;
			connection.Characteristics = ConnectionCharacteristicsType.Reliable;
			connection.Status = ConnectionStatusType.Active;
			connection.Expiration = DateTime.Now.AddMinutes(30);

//			req.Items = new object[] { connection };
			req.Any = new XmlElement[] { this.Host.SetObject(connection, "Connection") };

			//QueryRequestType request = new QueryRequestType();
			//request.XpQuery = new XpQueryType[] { new XpQueryType() };
			//request.XpQuery[0].Select = "/m:IqAlerts/m:Connection/m:Argot[@ArgotURI='http://schemas.iquomi.com/2004/01/iqAlerts/HumanReadableArgot.xsd']";
			//request.XpQuery[0].MinOccurs = 1;
			//request.XpQuery[0].MinOccursSpecified = true;

			//QueryResponseType response = myAlerts.Query(request);
			//if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
			//    // update connection
			//}
			//else {
			//    // insert connection
			//}

			InsertResponseType res = myAlerts.Insert(req);
			if (res.Status == ResponseStatus.Success) {
				if (res.NewBlueId == null || res.NewBlueId.Length == 0) {
					Console.WriteLine("Failed to properly insert connection");
					return;
				}

				string id = res.NewBlueId[0].Id;

				ConfigureInfrastructure();

				Console.Write("Subscribing " + this.Host.Iqid + " using " + id);
				alert.Subscribe(id, "", OnAlerts);
			}
		}

		private void ConfigureInfrastructure() {
			try {
				string configFilename = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + System.IO.Path.DirectorySeparatorChar + Assembly.GetExecutingAssembly().GetName().Name + ".dll.config";
				Console.WriteLine("Configuring using " + configFilename);
				RemotingConfiguration.Configure(configFilename);
			}
			catch (Exception e) {
				Console.WriteLine("Failed to configure .NET remoting - already configured? " + e.Message);
			}

			string url = ConfigurationManager.AppSettings["alertsUrl"];

			Console.WriteLine("Connecting to " + url);
			alert = (IAlert)RemotingServices.Connect(typeof(IAlert), url);

			OnAlerts = AlertEventShim.Create(new AlertHandler(this.OnMyNotification));
			alert.Notify += OnAlerts;
		}

		public void OnUnload() {
			try {
				alert.Unsubscribe(this.Host.Iqid, "");
				alert.Notify -= OnAlerts;
			}
			catch (WebException we) {
				Console.WriteLine("Unable to unregister handler - server might be closed?\n" + we.Message);
			}
		}

		void OnMyNotification(NotifyType n) {
			Console.WriteLine("Got (Meta: {0} {1} {2}) back!", n.Meta.ActionUrl, n.Content.Subject, n.Content.Value);

			this.Host.StatusBarText = n.Content.Value;
		}

	}
}