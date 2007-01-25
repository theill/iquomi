using System;
using System.Collections.Generic;
using System.Text;

namespace Commanigy.Iquomi.Api {
	interface IPlugin0x01 : IPlugin {
		void OnLoad();
		void OnUnload();

		void OnStart();
		void OnStop();
	}
}
