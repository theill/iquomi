#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Commanigy.Iquomi.Sdk.WindowsMobile;
using System.Reflection;

#endregion

namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	/// <summary>
	/// 
	/// </summary>
	public class PluginManager {
		private static readonly PluginManager instance = new PluginManager(new Dictionary<string, IPlugin>());
		private Dictionary<string, IPlugin> plugins;

		private PluginManager(Dictionary<string, IPlugin> plugins) {
			this.plugins = plugins;
		}

		public static PluginManager Instance {
			get {
				return instance;
			}
		}

		public IPlugin LoadPlugin(string name, string assemblyFile, IPluginContext pluginContext) {
			if (plugins.ContainsKey(assemblyFile)) {
				return plugins[assemblyFile];
			}

			Assembly a = Assembly.LoadFrom(assemblyFile);
			if (a == null) {
				throw new ArgumentException("Unable to load assembly " + assemblyFile);
			}

			name = string.Format("Commanigy.Iquomi.Services.{0}.{0}Plugin", name);

			IPlugin plugin = a.CreateInstance(name) as IPlugin;
			if (plugin == null) {
				throw new ArgumentException("Unable to instantiate " + name);
			}

			plugin.OnLoad(pluginContext);

			plugins.Add(assemblyFile, plugin);

			return plugin;
		}

		public void UnloadPlugin(string assemblyFile, IPluginContext pluginContext) {
			if (!plugins.ContainsKey(assemblyFile)) {
				return;
			}

			plugins[assemblyFile].OnUnload(pluginContext);
			plugins.Remove(assemblyFile);
		}

		internal void Load(IPluginContext pluginContext) {
			// TODO read configuration file with default plugins
			LoadPlugin("IqSms", string.Format(@"{0}\Commanigy.Iquomi.Services.{1}.Client.WindowsMobile.dll", @"\Storage Card\Iquomi Plugins\IqSms", "IqSms"), pluginContext);
		}

		internal void Unload(IPluginContext pluginContext) {
			foreach (IPlugin p in plugins.Values) {
				p.OnUnload(pluginContext);
			}

			plugins.Clear();
		}

		internal bool IsLoaded(string assemblyFile) {
			return plugins.ContainsKey(assemblyFile);
		}
	}
}
