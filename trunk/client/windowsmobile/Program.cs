#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static void Main() {
			Application.Run(new FrmIquomi());
		}
	}
}