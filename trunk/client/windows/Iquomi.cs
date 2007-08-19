#region Using directives

using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Configuration;

using log4net.Config;

#endregion

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// The <b>Iquomi</b> Client Application is a Windows client capable of 
	/// loading Iquomi Services dynamically.
	/// </summary>
	class Iquomi {
		[STAThread]
		static void Main(string[] args) {

			// required to correct images in ImageList components
			Application.DoEvents();

			DOMConfigurator.ConfigureAndWatch(
				new FileInfo(ConfigurationManager.AppSettings["log4net-config-file"])
				);

			Application.EnableVisualStyles();
			Application.Run(new FrmIquomi());
		}
	}
}