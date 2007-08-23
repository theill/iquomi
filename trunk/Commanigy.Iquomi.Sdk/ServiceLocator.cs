#region Using directives

using System;
using System.Web.Services.Protocols;
using System.Reflection;

#endregion

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for ServiceLocator.
	/// </summary>
	public class ServiceLocator {
		#region Properties
		private string url;
		public string Url {
			get { return url; }
			set { url = value; }
		}

		private string iqid;
		public string Iqid {
			get { return iqid; }
			set { iqid = value; }
		}

		private string password;
		public string Password {
			get { return password; }
			set { password = value; }
		}
		#endregion
		
		public ServiceLocator(string url, string iqid, string password) {
			if (url == null) {
				throw new ArgumentNullException();
			}

			this.url = url.EndsWith("/") ? url.TrimEnd(new char[] { '/' }) : url;
			this.iqid = iqid;
			this.password = password;
		}
		
		public SoapHttpClientProtocol GetService(Type serviceType, string iqid) {
			// TODO: add cache layer for looking up same service

			if (serviceType == null || iqid == null) {
				throw new ArgumentNullException();
			}

			if (serviceType.BaseType.Name != "SoapHttpClientProtocol") {
				throw new Exception("You must initialize a proxy class that inherits from SoapHttpClientProtocol");
			}

			// create instance of service using default constructor
			SoapHttpClientProtocol service = serviceType.GetConstructor(Type.EmptyTypes).Invoke(null) as SoapHttpClientProtocol;

			// use default credentials in order to use local web services
			service.UseDefaultCredentials = true;

			// build url for web service dynamically
			service.Url = url + "/" + serviceType.Name + ".asmx";

			Type aType = serviceType.Assembly.GetType(serviceType.Namespace + ".SoapAuthenticationType");
			object soapAuthentication = aType.GetConstructor(Type.EmptyTypes).Invoke(null);
			aType.InvokeMember("Iqid", BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.SetField, null, soapAuthentication, new object[] { this.Iqid });
			aType.InvokeMember("Password", BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.SetField, null, soapAuthentication, new object[] { this.Password });

			Type rType = serviceType.Assembly.GetType(serviceType.Namespace + ".SoapRequestType");
			object soapRequest = rType.GetConstructor(Type.EmptyTypes).Invoke(null);
			
			Type rtType = serviceType.Assembly.GetType(serviceType.Namespace + ".RequestType");
			object requestType = rtType.GetConstructor(Type.EmptyTypes).Invoke(null);
			rtType.InvokeMember("Service", BindingFlags.SetProperty | BindingFlags.SetField, null, requestType, new object[] { serviceType.Name });

			Type rtkType = serviceType.Assembly.GetType(serviceType.Namespace + ".RequestTypeKey");
			object requestTypeKey = rtkType.GetConstructor(Type.EmptyTypes).Invoke(null);
			rtkType.InvokeMember("Cluster", BindingFlags.SetProperty | BindingFlags.SetField, null, requestTypeKey, new object[] { "" });
			rtkType.InvokeMember("Instance", BindingFlags.SetProperty | BindingFlags.SetField, null, requestTypeKey, new object[] { "" });
			rtkType.InvokeMember("Puid", BindingFlags.SetProperty | BindingFlags.SetField, null, requestTypeKey, new object[] { iqid });

			Array rtkTypeArray = System.Array.CreateInstance(rtkType, 1);
			rtkTypeArray.SetValue(requestTypeKey, 0);
			rtType.InvokeMember("Key", BindingFlags.SetProperty | BindingFlags.SetField, null, requestType, new object[] { rtkTypeArray });

			rType.InvokeMember("Value", BindingFlags.SetProperty | BindingFlags.SetField, null, soapRequest, new object[] { requestType });

			serviceType.InvokeMember("SoapAuthenticationTypeValue", BindingFlags.SetProperty | BindingFlags.SetField, null, service, new object[] { soapAuthentication });
			serviceType.InvokeMember("SoapRequestTypeValue", BindingFlags.SetProperty | BindingFlags.SetField, null, service, new object[] { soapRequest });

			return service;
		}

	}
}