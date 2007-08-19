using System;

using System.Web;
using System.Web.Services.Protocols;
using System.Xml;
using System.Reflection;
using Microsoft.Hs;
using Microsoft.Hs.ServiceLocator;

//had to add System.Windows.Forms library to get these to take?
//using hsProxyNs.dnMyServicesNs; //still does not work
using hsProxy.myAlertsNs;
using hsProxy.myApplicationSettingsNs;
using hsProxy.myCalendarNs;
using hsProxy.myCategoriesNs;
using hsProxy.myContactsNs;
using hsProxy.myDevicesNs;
using hsProxy.myFavoriteWebSitesNs;
using hsProxy.myListsNs;
using hsProxy.myLocationNs;
using hsProxy.myPresenceNs;
using hsProxy.myProfileNs;
using hsProxy.myServicesNs;
using hsProxy.myWalletNs;

namespace hsProxy
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class hsProxy
	{
		public hsProxy()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public SoapHttpClientProtocol GetMyService(Type service, int puid)
		{
			ServiceLocator serviceLocator = new ServiceLocator("http://localhost/myServices", "c:\\logfile.txt", true);
			return serviceLocator.GetService(service, puid);
		}

		//response
		public string sendXml(string user, Type service, string request)
		{
			string filePath = "c:\\log-" + service.Name + ".txt";
			ServiceLocator serviceLocator = new ServiceLocator("http://localhost/myServices", filePath, true);

			/*
			//attempt to inherit from SoapHttpClientProtocol, and extend with sendXml method
			GenericProxy mySrv = null;
			mySrv = (myFavoriteWebSites) serviceLocator.GetService(typeof(myFavoriteWebSites), user);
			*/

			//late binding
			MethodInfo m = service.GetMethod("sendXml");
			object o = Activator.CreateInstance(service);
			o = serviceLocator.GetService(service, user);

			//REQUEST
			XmlDocument xd = new XmlDocument();
			XmlElement xe = xd.CreateElement("request");
			xe.InnerXml = request;
			xe = (XmlElement) xe.FirstChild;

			//MESSAGE INVOCATION
			object[] args = new object[1];
			args[0] = xe;
			m.Invoke(o, args);

			//RESULT
			xe = (XmlElement) args[0];

			return xe.OuterXml;

			//could throw SoapException or Exception
		}
	}
}
