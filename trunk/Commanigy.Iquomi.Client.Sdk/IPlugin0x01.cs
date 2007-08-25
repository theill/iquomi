#region Using directives
using System;
using System.Collections.Generic;
using System.Text; 
#endregion

namespace Commanigy.Iquomi.Client.Sdk {
	interface IPlugin0x01 : IPlugin {
		void OnLoad();
		void OnUnload();

		void OnStart();
		void OnStop();
	}
}
