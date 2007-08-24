namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for IPlugin.
	/// </summary>
	public interface IPlugin {
		IPluginHost Host { get; set; }

		string Name { get; }
		string Version { get; }
//		string Description { get; }
//		string Author { get; }
		
		void OnLoad();
		void OnUnload();
	}
}