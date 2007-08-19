<%@ WebHandler Language="C#" Class="XmlRpc" %>

#region Using directives

using System;
using System.Web;
using System.Xml;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

public class XmlRpc : IHttpHandler {
	ILog log = LogManager.GetLogger("WebServices");
    
    public void ProcessRequest(HttpContext context) {
		XmlDocument d = new XmlDocument();
		d.Load(context.Request.InputStream);

		string methodName = d.SelectSingleNode("/methodCall/methodName/text()").Value;
		log.Debug("methodName: " + methodName);

		switch (methodName) {
			case "weblogUpdates.extendedPing":
				XmlNodeList values = d.SelectNodes("//param/value/string/text()");
				if (values.Count != 3) {
					throw new InvalidOperationException("Method " + methodName + " understood but some parameters were unexpected");
				}
				
				string urlXml = values[2].Value;
				
				XmlDocument updatedDocument = new XmlDocument();
				updatedDocument.Load(urlXml);
				
				DbSubscription[] subscriptions = DbSubscription.DbFindAllByUrl(urlXml);
				foreach (DbSubscription s in subscriptions) {
					s.Xml = updatedDocument.OuterXml;
					s.DbUpdate();
					log.Debug("Updated subscription " + s.Id + " based on XML-RPC ping request");

					DbMethodHistory mh = new DbMethodHistory();
					mh.Method = DbMethodType.Replace;
					mh.AccountId = s.AccountId;
					mh.SubscriptionId = s.Id;
					mh.UserHostAddress = context.Request.UserHostAddress;
					mh.DbCreate();
				}
				break;
				
			default:
				break;
		}
		
		context.Response.ContentType = "text/xml";
		context.Response.Write(@"<methodResponse>
  <params>
    <param>
      <value>
        <struct>
  <member><name>flerror</name><value><boolean>0</boolean></value></member>
  <member><name>message</name><value><string>Ping received</string></value></member>
</struct>
      </value>
    </param>
  </params>
</methodResponse>");
    }

	/*
	 example:

POST / HTTP/1.1
User-Agent: The Incutio XML-RPC PHP Library -- WordPress/1.5.2
Content-Type: text/xml
Host: rpc.pingomatic.com
Content-Length: 366

<?xml version="1.0"?>
<methodCall>
<methodName>weblogUpdates.extendedPing</methodName>
<params>
<param><value><string>The Theill Weblog</string></value></param>
<param><value><string>http://peter.rapanden.dk/wordpress/</string></value></param>
<param><value><string>http://peter.rapanden.dk/wordpress/feed/</string></value></param>
</params></methodCall>




HTTP/1.1 200 OK
Connection: close
Content-Length: 354
Content-type: text/xml;charset=UTF-8
Server: lighttpd/1.3.16

<?xml version="1.0"?>
<methodResponse>
  <params>
	<param>
	  <value>
		<struct>
  <member><name>flerror</name><value><boolean>0</boolean></value></member>
  <member><name>message</name><value><string>Pings being forwarded to 15 services!</string></value></member>
</struct>
	  </value>
	</param>
  </params>
</methodResponse>

	 */

	public bool IsReusable {
        get {
            return true;
        }
    }

}