using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
//using Services=Commanigy.Iquomi.Api.Services;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for ServiceForm.
	/// </summary>
	public class ServiceForm : System.Windows.Forms.Form {
		
		private System.ComponentModel.Container components = null;
		
		public ServiceForm() {
			InitializeComponent();
		}
		
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			
			base.Dispose(disposing);
		}
		
//		public Services.Service GetService(string name) {
//			Services.Service myService = new Services.Service();
//			myService.AuthenticationTypeValue = new Services.AuthenticationType();
//			myService.AuthenticationTypeValue.Iqid = "petertheill";
//			myService.AuthenticationTypeValue.Password = "g5zTb4oNXBR1VWyUqhNdcQ==";
//			myService.RequestTypeValue = new Services.RequestType();
//			myService.RequestTypeValue.Service = name;
//			myService.RequestTypeValue.OwnerIqid = "petertheill";
//			
//			return myService;
//		}

		/// <summary>
		/// Retrieves a message from resource manager.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		protected string _(string name) {
			return name;
		}

		
		/*
		protected XmlDocument _request(string xpath) {
			
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.URI);
			request.Headers.Add("XPath", xpath);
			
//			request.Timeout = 3000;
			
			WebResponse	result = null;
			try {
				result = request.GetResponse();
				
				Stream stream = result.GetResponseStream();
				StreamReader sr	= new StreamReader(
					stream, 
					Encoding.UTF8
				);
				
				XmlDocument doc = new XmlDocument();
				doc.Load(sr);
				
				return doc;
			}
			catch (Exception ex) {
				Console.Write(ex);
			}
			finally {
				if (result != null) {
					result.Close();
				}
			}
			
			return null;
		}
		
		protected bool _post(XmlDocument xml, string xpath) {
			
			WebRequest request = WebRequest.Create(this.URI);
//			request.Headers.Add("XPath", xpath);
			request.Method = "POST";
			request.ContentType = "text/xml";
			
			byte[] buffer = Encoding.UTF8.GetBytes(xml.OuterXml);
			request.ContentLength = buffer.Length;
			
			Stream stream = request.GetRequestStream();
			try {
				stream.Write(buffer, 0, buffer.Length);
				stream.Flush();
			}
			catch (Exception ex) {
				// TODO: add error logging
				Console.Out.WriteLine("Error sending XML to server\n" + ex);
				return false;
			}
			finally {
				if (stream != null) {
					stream.Close();
				}
			}
			
			return true;
		}
		*/

		private void InitializeComponent() {
			// 
			// ServiceForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 453);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "ServiceForm";
			this.ShowInTaskbar = false;
			this.Text = "Iquomi Base Service Form";

		}
		
//		protected IServiceContainer ServiceContainer {
//			get {
//				return (IServiceContainer)this.ParentForm;
//			}
//		}
		
		/// <summary>
		/// Reads all bytes from stream and encodes these into an XmlDocument
		/// for further processing, e.g. if it should be send to the server
		/// where you'll need to call NotifyCreate, etc.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public XmlDocument XmlWrap(System.IO.Stream stream) {
			return null;
		}

	}
}