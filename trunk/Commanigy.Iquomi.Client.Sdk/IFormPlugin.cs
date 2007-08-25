using System.Windows.Forms;

namespace Commanigy.Iquomi.Client.Sdk {
	/// <summary>
	/// Summary description for IFormPlugin.
	/// </summary>
	public interface IFormPlugin : IPlugin {
		Form UserInterface { get; }
	}
}
