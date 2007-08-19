#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Sdk.WindowsMobile {
	public interface IPlugin {
		string Name { get; }
		string Version { get; }

		void OnLoad(IPluginContext context);
		void OnUnload(IPluginContext context);
	}
}
