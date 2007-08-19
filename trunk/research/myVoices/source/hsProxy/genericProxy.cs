using System;

using System.Xml;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace hsProxyNs
{
	/// <summary>
	/// Summary description for genericProxy.
	/// </summary>
	[System.Web.Services.WebServiceBindingAttribute(Name="genericProxy", Namespace="http://www.brains-N-brawn.com")]
	public class GenericProxy : SoapHttpClientProtocol
	{
		public GenericProxy()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void sendXml(ref XmlElement any)
		{
			return;
		}
	}
}
