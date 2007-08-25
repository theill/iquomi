#region Using directives

using System;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Net;
using System.IO;

using Commanigy.Iquomi.Client.Sdk;

#endregion

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// A IquomiService instance contains information about a service 
	/// conforming to the Iquomi Services SDK.
	/// </summary>
	public class IquomiService {
		private string fileName;
		private Assembly assembly;

		public IquomiService(string fileName) {
			this.fileName = fileName;

			// Create separate AppDomain for service
			CreateAppDomain();

			// Load service into newly created AppDomain
			LoadServiceAssembly();
		}

		public IPlugin Instantiate(IPluginHost host) {
			foreach (Type pluginType in assembly.GetTypes()) {
				if (!pluginType.IsPublic) {
					continue;
				}

				if (pluginType.IsAbstract) {
					continue;
				}

				// Gets a type object of the interface we need the plugins to match
				Type typeInterface = pluginType.GetInterface(typeof(IFormPlugin).ToString(), false);

				// Make sure the interface we want to use actually exists
				if (typeInterface == null) {
					typeInterface = pluginType.GetInterface(typeof(IPlugin).ToString(), false);
					if (typeInterface == null) {
						continue;
					}
				}

				IPlugin plugin = (IPlugin)Activator.CreateInstance(
					assembly.GetType(pluginType.ToString())
					);

				// Set the Plugin's host to this class which inherit IPluginHost
				plugin.Host = host;

				// Call the initialization sub of the plugin
				plugin.OnLoad();

				return plugin;
			}

			return null;
		}

		public bool IsValid {
			get {
				// TODO: figure out what to look for in the assembly
				Console.Out.WriteLine("Validating {0}", assembly.GetName());
				return assembly.GetName().Name.IndexOf("Service") > 0;
			}
		}

		protected void CreateAppDomain() {
//			AppDomain ad = AppDomain.CreateDomain("Test");
//			AppDomain.CurrentDomain.SetupInformation.PrivateBinPath += ";" + new FileInfo(fileName).DirectoryName;
		}

		protected Assembly LoadServiceAssembly() {
			assembly = Assembly.LoadFrom(fileName);
			return assembly;
		}

	}
}