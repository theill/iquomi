#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commanigy.Iquomi.Sdk.WindowsMobile;
using System.Web.Services.Protocols;
using Commanigy.Iquomi.Client.SmartDevice.WindowsMobile.IqServicesRef;

#endregion

namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	public partial class FrmIquomi : Form, IPluginContext {
		private string iqid = "petertheill", password = "g5zTb4oNXBR1VWyUqhNdcQ==";

		private PluginManager pluginManager = PluginManager.Instance;

		private ServiceLocator serviceLocator;
		protected ServiceLocator ServiceLocator {
			get {
				if (serviceLocator == null || serviceLocator.Iqid != this.iqid || serviceLocator.Password != this.password) {
					serviceLocator = new ServiceLocator("http://services.iquomi.com/", this.iqid, this.password);
				}

				return serviceLocator;
			}
		}

		#region IPluginContext Members

		public SoapHttpClientProtocol GetService(Type serviceType, string iqid) {
			//IqServicesRef.IqCoreSoap myService = new IqServicesRef.IqCoreSoap();
			//myService.Url = "http://services.iquomi.com/IqCore.asmx";
			//myService.SoapAuthenticationTypeValue = new SoapAuthenticationType();
			//myService.SoapAuthenticationTypeValue.Iqid = this.iqid;
			//myService.SoapAuthenticationTypeValue.Password = this.password;
			//myService.SoapRequestTypeValue = new SoapRequestType();
			//myService.SoapRequestTypeValue.Value = new RequestType();
			//myService.SoapRequestTypeValue.Value.Document = RequestTypeDocument.Content;
			//myService.SoapRequestTypeValue.Value.GenResponse = RequestTypeGenResponse.Always;
			//myService.SoapRequestTypeValue.Value.Service = serviceType.Name;
			//myService.SoapRequestTypeValue.Value.Method = RequestTypeMethod.Insert;
			//myService.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { new RequestTypeKey() };
			//myService.SoapRequestTypeValue.Value.Key[0].Puid = iqid;
			//myService.SoapRequestTypeValue.Value.Key[0].Cluster = "";
			//myService.SoapRequestTypeValue.Value.Key[0].Instance = "";
			//return myService;
			return ServiceLocator.GetService(serviceType, iqid);
		}

		public IntPtr ContainerHandle {
			get { 
				return this.Handle; 
			}
		}

		public string Iqid {
			get { 
				return iqid;
			}
		}

		#endregion

		public FrmIquomi() {
			InitializeComponent();
		}

		#region Menuitem event handlers

		private void MiSignIn_Click(object sender, EventArgs e) {
			using (FrmSignIn f = new FrmSignIn()) {
				if (f.ShowDialog() == DialogResult.OK) {
					SignIn(f.Iqid, f.Password);
				}
			}
		}

		private void MiSignOut_Click(object sender, EventArgs e) {
			// TODO: sign out
		}

		private void MiOptions_Click(object sender, EventArgs e) {
			using (FrmOptions f = new FrmOptions()) {
				f.ShowDialog();
			}
		}

		#endregion

		private void SignIn(string iqid, string password) {
			// TODO: sign in user using 'iqPresence' service
			this.iqid = iqid;
			this.password = password;

			using (FrmServices f = new FrmServices()) {
				f.Owner = this;
				f.ShowDialog();
			}
		}

		private void FrmIquomi_Load(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(this.iqid) && !string.IsNullOrEmpty(this.password)) {
				pluginManager.Load(this);
			}
		}

		private void FrmIquomi_Closed(object sender, EventArgs e) {
			// unload all plugins
			pluginManager.Unload(this);
		}

	}
}