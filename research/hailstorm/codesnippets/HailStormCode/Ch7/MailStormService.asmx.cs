using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace MailStorm
{
	[WebService(Namespace="http://ea.wrox.com/hailstorm/mailstorm/", Description="This Web Service provides email service to HailStorm myContacts.")]
	public class MailStormService : System.Web.Services.WebService
	{
		private string strSoapEncoding = 
			"http://schemas.xmlsoap.org/soap/encoding/";
		private string strMessageEncoding = "UTF-8";
		private string strSoapAction = 
			"http://schemas.microsoft.com/hs/2001/10/core#request";
		private string strSoapRPNamespace = "http://schemas.xmlsoap.org/rp/";
		private string strHSNamespace = 
			"http://schemas.microsoft.com/hs/2001/10/core" ;
		private string strSecNamespace = 
			"http://schemas.xmlsoap.org/soap/security/2000-12/";
		private string strMyContactsNamespace = 
			"http://schemas.microsoft.com/hs/2001/10/myContacts";
		private string strMyProfileNamespace = 
			"http://schemas.microsoft.com/hs/2001/10/myProfile";
		private string strService = "myContacts";
		private string strSmtpServer = "mailcluster";
		public MailStormService()
		{
		}
		public void BoilerplateSoapHeader(MSSOAPLib.SoapSerializer Serializer,
			string nUserId, string strTo,
			string strId, string strMethod) 
		{
			Serializer.startHeader(strSoapEncoding);
			Serializer.startHeaderElement("path", strSoapRPNamespace,1,"",
				"", "x");
			Serializer.startHeaderElement ("action", strSoapRPNamespace,
				1, "","", "x");
			Serializer.writeString(strSoapAction);
			Serializer.endHeaderElement();
			Serializer.startHeaderElement("rev", strSoapRPNamespace,
				1,"","","x");
			Serializer.startHeaderElement ("via", strSoapRPNamespace,
				1, "","", "x");
			Serializer.endElement();
			Serializer.endElement();
			Serializer.startHeaderElement ("to", strSoapRPNamespace,1,
				"","","x");
			Serializer.writeString(strTo);
			Serializer.endElement();
			Serializer.startHeaderElement ("id", strSoapRPNamespace, 1,
				"","","x");
			Serializer.writeString(strId);
			Serializer.endElement();
			Serializer.endElement();
			Serializer.startHeaderElement ("licenses", strSecNamespace,
				1, "","", "ss");
			Serializer.startHeaderElement ("identity", strHSNamespace, 1,
				"","", "h");

			Serializer.startHeaderElement ("kerberos", strHSNamespace,1, 
				"","", "h");

			Serializer.writeString(nUserId);
			Serializer.endElement();
			Serializer.endElement();
			Serializer.endElement();
			Serializer.startHeaderElement ("request", strHSNamespace,1, "",
				"", "h");

			Serializer.SoapAttribute ("service","",  strService,"");
			Serializer.SoapAttribute ("document", "","content","");

			Serializer.SoapAttribute ("method","", strMethod,"");
			Serializer.SoapAttribute ("genResponse", "","always","");
			Serializer.startHeaderElement("key", strHSNamespace,1, "","", "h");
			Serializer.SoapAttribute ("instance","", "0","");
			Serializer.SoapAttribute ("cluster", "","0","");
			Serializer.SoapAttribute ("puid","", nUserId,"");
			Serializer.endHeaderElement();
			Serializer.endHeaderElement();
			Serializer.endHeader();         
		}
		[WebMethod(Description="This method retrieves the list of contacts from myContacts using HailStorm ")]
		public string RetrieveMyContacts(string nUserId, string strServiceLocation)
		{
			string emailaddresslist="";
			strServiceLocation="http://" + strServiceLocation;
			string strEndPointURL     = strServiceLocation + "/" + strService;
			string strTo              = strServiceLocation;
			string strId              = "0c69dfd1-6694-11d5-a2bc-00b0d0e9071d";
			MSSOAPLib.HttpConnector Connector ;
			Connector=new MSSOAPLib.HttpConnector();
			Connector.set_Property("EndPointURL",strEndPointURL);
			Connector.Connect();
			Connector.set_Property("SoapAction",strSoapAction);
			Connector.BeginMessage();
			MSSOAPLib.SoapSerializer Serializer ;
			Serializer=new MSSOAPLib.SoapSerializer();
			Serializer.Init(Connector.InputStream);
			Serializer.startEnvelope("s", strSoapEncoding, strMessageEncoding);
			BoilerplateSoapHeader(Serializer, nUserId, strTo, strId, "query");
			Serializer.startBody(null) ;

			Serializer.startElement("queryRequest", strHSNamespace,null,"h");

			Serializer.startElement ("xpQuery", strHSNamespace,null,"h");

			Serializer.SoapAttribute("select", "","/m:myContacts","");
			Serializer.SoapAttribute("xmlns:m", "",strMyContactsNamespace,"");

			Serializer.endElement();
			Serializer.endElement();
			Serializer.endBody();
			Serializer.endEnvelope();
			Connector.EndMessage();

			MSSOAPLib.SoapReader Reader;
			Reader=new MSSOAPLib.SoapReader();
			Reader.Load(Connector.OutputStream,"");
			string u = Reader.Body.xml.ToString();
			System.Xml.XmlDocument doc;
			doc= new System.Xml.XmlDocument();
			doc.LoadXml(u);
			System.Xml.XmlElement root = doc.DocumentElement;
			System.Xml.XmlNameTable nt = new System.Xml.NameTable();
			System.Xml.XmlNamespaceManager nsmgr =
				new System.Xml.XmlNamespaceManager(nt);
			nsmgr.AddNamespace("mc", strMyContactsNamespace);
			nsmgr.AddNamespace("mp", strMyProfileNamespace);
			System.Xml.XmlNodeList elemList =
				root.SelectNodes("//mp:email", nsmgr);
			System.Collections.IEnumerator ienum = elemList.GetEnumerator();
			while (ienum.MoveNext())
			{   
				System.Xml.XmlNode address = (System.Xml.XmlNode) ienum.Current;
				emailaddresslist = emailaddresslist + address.InnerText + ";";
			}    
			return emailaddresslist;
		}
		[WebMethod(Description="This method is used to send mail to the contacts retrieved by the RetrieveMyContacts() Web Method")]
		public string SendMailToMyContacts(string nUserId,
			string strServiceLocation,
			string messageFrom,
			string messageSubject,
			string messageBody)
		{
			string emailaddresslist = RetrieveMyContacts(nUserId,
				strServiceLocation);
			System.Web.Mail.MailMessage msg = new System.Web.Mail.MailMessage();
			msg.To = emailaddresslist;
			msg.From = messageFrom;
			msg.Subject = messageSubject;
			msg.Body = messageBody;

			System.Web.Mail.SmtpMail.SmtpServer = strSmtpServer;

			System.Web.Mail.SmtpMail.Send(msg);

			return "Mail to "+ emailaddresslist + " sent successfully";
		}

		[WebMethod(Description="This method is used to populate myContacts using HailStorm")]
		public bool addContact(string nUserId, string strServiceLocation,
			string strFirstname,
			string strLastname,
			string strEmail)
		{
			strServiceLocation = "http://" + strServiceLocation;
         
			string strEndPointURL     = strServiceLocation + "/" + strService;
			string strTo              = strServiceLocation;
			string strId              = "0c69dfd1-6694-11d5-a2bc-00b0d0e9071d";
			MSSOAPLib.HttpConnector Connector;
			Connector=new MSSOAPLib.HttpConnector();
			Connector.set_Property("EndPointURL",strEndPointURL);
			Connector.Connect();
			Connector.set_Property("SoapAction",strSoapAction);
            
			Connector.BeginMessage();

			MSSOAPLib.SoapSerializer Serializer;
			Serializer=new MSSOAPLib.SoapSerializer();
			Serializer.Init(Connector.InputStream);
			Serializer.startEnvelope("s", strSoapEncoding, strMessageEncoding);
			BoilerplateSoapHeader(Serializer, nUserId, strTo, strId, "insert");
			Serializer.startBody(null);
			Serializer.startElement("insertRequest", strHSNamespace,null,"h");
			Serializer.SoapAttribute("select","","/mc:myContacts","");
			Serializer.SoapAttribute("xmlns:mc","",strMyContactsNamespace,"");
			Serializer.startElement("contact",strMyContactsNamespace,null,"mc");
			Serializer.SoapAttribute("synchronize", null, "no", null);
			Serializer.startElement ("name",strMyContactsNamespace,null,"mc");
			Serializer.startElement("givenName",strMyProfileNamespace,null,"mp");
			Serializer.SoapAttribute("xml:lang","","en","");
			Serializer.writeString(strFirstname);
			Serializer.endElement();
			Serializer.startElement("surname",strMyProfileNamespace,null,"mp");
			Serializer.SoapAttribute("xml:lang","","en","");
			Serializer.writeString(strLastname);
			Serializer.endElement();
			Serializer.endElement();
			Serializer.startElement("emailAddress",strMyContactsNamespace,
				null,"mc");
			Serializer.startElement("email",strMyProfileNamespace,null,"mp");
			Serializer.writeString(strEmail);
			Serializer.endElement();
			Serializer.endElement();
			Serializer.endElement();
			Serializer.endElement();

			Serializer.endBody();
			Serializer.endEnvelope();
			Connector.EndMessage();
			MSSOAPLib.SoapReader Reader ;
			Reader = new MSSOAPLib.SoapReader();
			Reader.Load(Connector.OutputStream,"");
			return Reader.Fault == null;
		}
	}
}