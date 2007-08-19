#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;

#endregion

namespace Commanigy.Iquomi.Sdk.WindowsMobile {
	public interface IPluginContext {
		SoapHttpClientProtocol GetService(Type serviceType, string iqid);

		IntPtr ContainerHandle { get; }

		/// <summary>
		/// Gets Iqid of currently signed in user.
		/// </summary>
		/// <value>Iqid of user; null if user not signed in</value>
		string Iqid { get; }
	}
}
