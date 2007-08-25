#region Using directives
using System;

using Commanigy.Iquomi.Client.Sdk;
#endregion

namespace Commanigy.Iquomi.Services.IqFavorites {
	/// <summary>
	/// Summary description for IqFavoritesPlugin.
	/// </summary>
	public class IqFavoritesPlugin : IFormPlugin	{
		private IPluginHost pluginHost;
		private FrmIqFavoritesService userInterface;

		public IqFavoritesPlugin() {

		}

		public IPluginHost Host {
			get {
				return pluginHost;
			}

			set {
				pluginHost = value;
				
				if (userInterface != null) {
					userInterface.PluginHost = pluginHost;
				}
			}
		}

		public System.Windows.Forms.Form UserInterface {
			get {
				return userInterface;
			}
		}

		public string Name {
			get {
				return "IqFavorites";
			}
		}

		public string Version {
			get {
				return "1.0.0.0";
			}
		}

		public void OnLoad() {
			userInterface = new FrmIqFavoritesService();
			userInterface.PluginHost = pluginHost;
			userInterface.Initialize();
		}

		public void OnUnload() {
			;
		}
	}
}