using System.Windows.Forms;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for IFormPlugin.
	/// </summary>
	public interface IFormPlugin : IPlugin {
		Form UserInterface { get; }
	}
}
