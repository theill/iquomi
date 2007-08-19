#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;
using System.Windows.Forms;

using Microsoft.WindowsMobile.PocketOutlook.MessageInterception;
using Microsoft.WindowsMobile.PocketOutlook;

using Commanigy.Iquomi.Services.IqSms.IqCoreRef;
using Commanigy.Iquomi.Sdk.WindowsMobile;

#endregion

namespace Commanigy.Iquomi.Services.IqSms {
	/// <summary>
	/// 
	/// </summary>
	public class IqSmsPlugin : IPlugin {
		private static XmlSerializer iqSmsSerializer = new XmlSerializer(typeof(IqSmsType));

		private IPluginContext pluginContext;
		private MessageInterceptor interceptor;

		#region IPlugin Members

		public string Name {
			get { 
				return "IqSms"; 
			}
		}

		public string Version {
			get {
				return "1.0.0.0";
			}
		}

		public void OnLoad(IPluginContext pluginContext) {
			//iqSms = new IqCore();
			//iqSms.Timeout = System.Threading.Timeout.Infinite;
			//iqSms.SoapAuthenticationTypeValue = new SoapAuthenticationType();
			//iqSms.SoapAuthenticationTypeValue.Iqid = "petertheill";
			//iqSms.SoapAuthenticationTypeValue.Password = "g5zTb4oNXBR1VWyUqhNdcQ==";
			//iqSms.SoapRequestTypeValue = new SoapRequestType();
			//iqSms.SoapRequestTypeValue.Value = new RequestType();
			//iqSms.SoapRequestTypeValue.Value.Document = RequestTypeDocument.Content;
			//iqSms.SoapRequestTypeValue.Value.GenResponse = RequestTypeGenResponse.Always;
			//iqSms.SoapRequestTypeValue.Value.Service = "iqSms";
			//iqSms.SoapRequestTypeValue.Value.Method = RequestTypeMethod.Insert;
			//iqSms.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { new RequestTypeKey() };
			//iqSms.SoapRequestTypeValue.Value.Key[0].Puid = "petertheill";
			//iqSms.SoapRequestTypeValue.Value.Key[0].Cluster = "";
			//iqSms.SoapRequestTypeValue.Value.Key[0].Instance = "";

			this.pluginContext = pluginContext;

			interceptor = new MessageInterceptor();
			interceptor.InterceptionAction = InterceptionAction.Notify;
			interceptor.MessageReceived += new MessageInterceptorEventHandler(OnMessageReceived);

			//// test
			//ShortMessageType sm = new ShortMessageType();
			//sm.Body = "testing";
			//sm.From = new RecipientType();
			//sm.From.Address = "asd";
			//sm.From.Name = "peter";
			//sm.To = new RecipientType[] { new RecipientType() };
			//sm.To[0].Address = "asdf";
			//sm.To[0].Name = "theill";
			//ForwardSms(sm);
		}

		public void OnUnload(IPluginContext pluginContext) {
			interceptor.Dispose();
		}

		#endregion

		void OnMessageReceived(object sender, MessageInterceptorEventArgs e) {
			try {
				ForwardSms(ToShortMessage((SmsMessage)e.Message));
			}
			catch (Exception x) {
				throw x;
			}
		}

		private ShortMessageType ToShortMessage(SmsMessage msg) {
			ShortMessageType message = new ShortMessageType();

			message.Body = msg.Body;
			if (msg.From != null) {
				message.From = new RecipientType();
				message.From.Address = msg.From.Address;
				message.From.Name = msg.From.Name;
			}

			if (msg.To != null) {
				int i = 0;

				message.To = new RecipientType[msg.To.Count];
				foreach (Recipient r in msg.To) {
					RecipientType rt = new RecipientType();
					rt.Address = r.Address;
					rt.Name = r.Name;
					message.To[i++] = rt;
				}
			}

			message.Received = msg.Received;
			message.ReceivedSpecified = msg.Received != DateTime.MinValue;

			message.LastModified = msg.LastModified;
			message.LastModifiedSpecified = (msg.LastModified != DateTime.MinValue);

			message.Read = msg.Read;

			return message;
		}

		void ForwardSms(ShortMessageType message) {
			XmlDocument document = new XmlDocument();

			IqSmsType sms = new IqSmsType();
			sms.ShortMessage = new ShortMessageType[] { message };

			StringBuilder buffer = new StringBuilder();
			using (XmlWriter w = XmlWriter.Create(buffer)) {
				iqSmsSerializer.Serialize(w, sms);
			}
			document.LoadXml(buffer.ToString());

			InsertRequestType req = new InsertRequestType();
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;
			req.MaxOccurs = 1;
			req.MaxOccursSpecified = true;
			req.Select = "/m:IqSms";
			req.Any = new XmlElement[] { document.DocumentElement.ChildNodes[0] as XmlElement };

			IqCore iqSms = (IqCore)this.pluginContext.GetService(
				typeof(IqCore),
				this.pluginContext.Iqid
				);

			iqSms = FixNETCEFrameworkBug(iqSms);
			iqSms.SoapRequestTypeValue.Value.Service = "iqSms";

			iqSms.Timeout = System.Threading.Timeout.Infinite;

			iqSms.BeginInsert(req, new AsyncCallback(OnSmsInsertResponse), iqSms);
		}

		private IqCore FixNETCEFrameworkBug(IqCore myService) {
			myService.Url = "http://services.iquomi.com/IqCore.asmx";
			myService.SoapAuthenticationTypeValue = new SoapAuthenticationType();
			myService.SoapAuthenticationTypeValue.Iqid = this.pluginContext.Iqid;
			myService.SoapAuthenticationTypeValue.Password = "g5zTb4oNXBR1VWyUqhNdcQ==";
			myService.SoapRequestTypeValue = new SoapRequestType();
			myService.SoapRequestTypeValue.Value = new RequestType();
			myService.SoapRequestTypeValue.Value.Document = RequestTypeDocument.Content;
			myService.SoapRequestTypeValue.Value.GenResponse = RequestTypeGenResponse.Always;
			//myService.SoapRequestTypeValue.Value.Service = serviceType.Name;
			myService.SoapRequestTypeValue.Value.Method = RequestTypeMethod.Insert;
			myService.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { new RequestTypeKey() };
			myService.SoapRequestTypeValue.Value.Key[0].Puid = this.pluginContext.Iqid;
			myService.SoapRequestTypeValue.Value.Key[0].Cluster = "";
			myService.SoapRequestTypeValue.Value.Key[0].Instance = "";
			return myService;
		}

		private void OnSmsInsertResponse(IAsyncResult result) {
			IqCore iqSms = (IqCore)result.AsyncState;

			try {
				InsertResponseType res = iqSms.EndInsert(result);
				if (res.Status == ResponseStatus.Success) {

				}
			}
			catch (SoapException x) {
				throw x;
			}
		}
	}
}