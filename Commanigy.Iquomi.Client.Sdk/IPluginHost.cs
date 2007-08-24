#region Using directives

using System;
using System.Web.Services.Protocols;
using System.Xml;

#endregion

namespace Commanigy.Iquomi.Api {
	public delegate void AppShuttingdownEventHandler(object sender, AppShuttingdownEventArgs e);
	public delegate void SignInEventHandler(object sender, SignInEventArgs e);
	public delegate void SignOutEventHandler(object sender, SignOutEventArgs e);
	
	/// <summary>
	/// Summary description for IPluginHost.
	/// </summary>
	public interface IPluginHost {
		event AppShuttingdownEventHandler AppShuttingdown;
		event SignInEventHandler SignedIn;
		event SignOutEventHandler SignedOut;
		
		//// Gets service for specified user (takes care of credentials, request 
		//// headers, etc)
		//Services.Service GetService(string name, string iqid);

		SoapHttpClientProtocol GetService(Type serviceType, string iqid);

		object GetObject(Type type, XmlElement e);
		object GetObject(Type type, XmlElement[] e);
		XmlElement SetObject(object o, string elementName);

		IntPtr ContainerHandle { get; }
		
		/// <summary>
		/// Sets statusbar text in host environment.
		/// </summary>
		string StatusBarText { set; }

		/// <remarks>
		/// Gets version of plugin.
		/// </remarks>
		/// <value>Version of plugin</value>
		string Version { get; }
		
		/// <summary>
		/// Gets Iqid of currently signed in user.
		/// TODO: is this a security issue?
		/// </summary>
		/// <value>Iqid of user; null if user not signed in</value>
		string Iqid { get; }
	}
}