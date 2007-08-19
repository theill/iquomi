#region Using directives

using System;
using System.Xml;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Xml.Schema;
using System.IO;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// Builds WSDL/DISCO file based on Service definition.
	/// </summary>
	public class ServiceLocatorHandler : System.Web.IHttpHandler {

		public ServiceLocatorHandler() {
			;
		}

		public bool IsReusable {
			get {
				return true;
			}
		}

		public void ProcessRequest(HttpContext context) {
			string output = "";
			
			string path = context.Request.Path.Trim();
			string serviceName = path.Substring(1, path.Length-".service".Length-1);
			if (serviceName != null && serviceName.Length > 0) {
				if (context.Request.QueryString.ToString().ToLower().StartsWith("wsdl")) {
					output = GetWsdl(serviceName);
					context.Response.ContentType = "text/xml";
				} else if (context.Request.QueryString.ToString().ToLower().StartsWith("disco")) {
					output = GetDisco(serviceName);
					context.Response.ContentType = "text/xml";
				} else {
					output = @"
						<html>
						<head>
							<link type='text/xml' rel='alternate' href='" + path + @"?disco'/>
						</head>
						<body>
						<h1>Iquomi Web Service Generator</h1>
						Service: <b>" + serviceName + @"</b>
						</body>
						</html>

					";
				}
			}

			// [~] why is it using utf16? this can't be displayed by browsers!
			output = output.Replace("utf-16", "utf-8");

			if (context.Request["debug"] != null) {
				context.Response.ContentType = "text/html";
				context.Response.Write(@"<html><head><link type='text/xml' rel='alternate' href='" + serviceName + ".service?disco'/></HEAD><body>");

				context.Response.Write("<h1>Iquomi Dynamic WSDL Generator</h1>");
				
				context.Response.Write("Requesting service: <b>" + serviceName + "</b>");
				context.Response.Write("<pre style='font-size: 11px; background-color: #f3fff3; border: 1px solid #c3ffc3'>");
				context.Response.Write(HttpUtility.HtmlEncode(output));
				context.Response.Write("</pre>");
			} else {
				context.Response.Write(output);
			}
		}

		protected DbService LookupService(string serviceName) {
			DbService service = new DbService();
			service.Name = serviceName;
			return (DbService)service.DbFindByName();
		}
		
		public void handler(object o, System.Xml.Schema.ValidationEventArgs args) {
			throw new Exception("uha, en fejl ved parsing af xsd");
		}

		public string GetDisco(string serviceName) {
			DiscoveryDocument dd = new DiscoveryDocument();

			// Get a ContractReference.
			ContractReference myContractReference = new ContractReference();

			// Set the URL to the referenced service description.
			myContractReference.Ref = "http://services.iquomi.com/" + serviceName + ".service?wsdl";

			// Set the URL for an XML Web service implementing the service
			// description.
			myContractReference.DocRef = "http://services.iquomi.com/" + serviceName + ".service";
			System.Web.Services.Discovery.SoapBinding myBinding = new System.Web.Services.Discovery.SoapBinding();
			myBinding.Binding = new XmlQualifiedName(serviceName + "Soap", "http://tempuri.org/");
			myBinding.Address = "http://services.iquomi.com/" + serviceName + ".service";
			
			// Add myContractReference to the list of references contained 
			// in the discovery document.
			dd.References.Add(myContractReference); 
			
			// Add Binding to the references collection.
			dd.References.Add(myBinding);
			
			System.IO.StringWriter writer = new System.IO.StringWriter();
			dd.Write(writer);
			writer.Flush();
			return writer.GetStringBuilder().ToString();
		}

		public string GetWsdl(string serviceName) {
			DbService service = LookupService(serviceName);
			if (service == null || service.Xsd == null) {
				return "No xsd found";
			}

			ServiceDescription sd = new ServiceDescription();
			sd.TargetNamespace = "http://schemas.iquomi.com/2004/01/" + serviceName;

			string realPath = HttpContext.Current.Server.MapPath("~/2004/01/core/iqcommon.xsd");
			System.IO.StreamReader sr = new System.IO.StreamReader(realPath, System.Text.Encoding.UTF8);
			XmlSchema core = System.Xml.Schema.XmlSchema.Read(sr ,null);
			core.Compile(null);
			//sd.Types.Schemas.Add(core);

			System.Xml.Schema.XmlSchema x = service.GetXmlSchema();
			x.TargetNamespace = sd.TargetNamespace;
			System.Xml.Schema.XmlSchemaElement xso = new System.Xml.Schema.XmlSchemaElement();
			xso.Name = "Create";
			System.Xml.Schema.XmlSchemaComplexType xsoct = new System.Xml.Schema.XmlSchemaComplexType();
			xso.SchemaType = xsoct;
			x.Items.Add(xso);
			sd.Types.Schemas.Add(x);

			Message m = new Message();
			m.Name = "InsertRequest";
			MessagePart mp = new MessagePart();
			mp.Name = "parameters";
			mp.Element = new XmlQualifiedName("Insert", sd.TargetNamespace);
			m.Parts.Add(mp);
			sd.Messages.Add(m);

			m = new Message();
			m.Name = "InsertResponse";
			mp = new MessagePart();
			mp.Name = "parameters";
			mp.Element = new XmlQualifiedName("Insert", sd.TargetNamespace);
			m.Parts.Add(mp);
			sd.Messages.Add(m);
			
			System.Web.Services.Description.PortType pt = new PortType();
			pt.Name = serviceName + "Soap";
			
			System.Web.Services.Description.Operation o = CreateOperation(
				"Insert", "InsertRequest", "InsertResponse", sd.TargetNamespace
				);
			pt.Operations.Add(o);
			sd.PortTypes.Add(pt);
			
			Binding b = new Binding();
			b.Name = serviceName + "Soap";
			b.Type = new System.Xml.XmlQualifiedName(pt.Name, sd.TargetNamespace);
			
			System.Web.Services.Description.SoapBinding mySoapBinding = new System.Web.Services.Description.SoapBinding();
			mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
			mySoapBinding.Style = SoapBindingStyle.Document;
			b.Extensions.Add(mySoapBinding);

			OperationBinding ob = new OperationBinding();
			ob.Name = "Insert";

			SoapOperationBinding soapo = new SoapOperationBinding();
			soapo.SoapAction = "http://services.iquomi.com/Insert";
			soapo.Style = SoapBindingStyle.Document;
			ob.Extensions.Add(soapo);

			SoapBodyBinding soapb = new SoapBodyBinding();
			soapb.Use = SoapBindingUse.Literal;
			
			InputBinding ib = new InputBinding();
			ib.Extensions.Add(soapb);
			ob.Input = ib;

			OutputBinding outb = new OutputBinding();
			outb.Extensions.Add(soapb);
			ob.Output = outb;

			b.Operations.Add(ob);
			sd.Bindings.Add(b);

			System.Web.Services.Description.Service s = new System.Web.Services.Description.Service();
			s.Name = serviceName;
			
			Port p = new Port();
			p.Name = serviceName + "Soap";
			p.Binding = b.Type;

			SoapAddressBinding soapab = new SoapAddressBinding();
			soapab.Location = "http://services.iquomi.com/Service.asmx";
			p.Extensions.Add(soapab);
			s.Ports.Add(p);
			sd.Services.Add(s);

			
			System.IO.StringWriter writer = new System.IO.StringWriter();
			sd.Write(writer);
			writer.Flush();
			return writer.GetStringBuilder().ToString();
		}
			
		public static Operation CreateOperation(string operationName, 
			string inputMessage, string outputMessage, string targetNamespace) {
			Operation myOperation = new Operation();
			myOperation.Name = operationName;
			OperationMessage input = (OperationMessage) new OperationInput();
			input.Message = new XmlQualifiedName(inputMessage, targetNamespace);
			OperationMessage output = (OperationMessage) new OperationOutput();
			output.Message = new XmlQualifiedName(outputMessage, targetNamespace);
			myOperation.Messages.Add(input);
			myOperation.Messages.Add(output);
			return myOperation;
		}

	}
}