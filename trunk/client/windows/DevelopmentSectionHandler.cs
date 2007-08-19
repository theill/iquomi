using System;
using System.Configuration;

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// Summary description for DevelopmentSectionHandler.
	/// </summary>
	public class DevelopmentSectionHandler : IConfigurationSectionHandler {
		public DevelopmentSectionHandler() {
			;
		}

		#region IConfigurationSectionHandler Members

		public object Create(object parent, object configContext, System.Xml.XmlNode section) {
			// TODO:  Add DevelopmentSectionHandler.Create implementation
			return null;
		}

		#endregion
	}
}
