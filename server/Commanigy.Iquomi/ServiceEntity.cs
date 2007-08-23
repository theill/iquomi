#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

using Commanigy.Iquomi;

#endregion

namespace Commanigy.Iquomi.Data {
	public class ServiceEntity : DataAccess.ServiceEntityRow {
		public ServiceEntity() : base(null) {
			
		}

		/// <summary>
		/// Returns *uncompiled* schema.
		/// </summary>
		/// <returns></returns>
		public XmlSchema GetXmlSchema() {
			if (Xsd == null && UrlXsd == null) {
				return null;
			}

			if (Xsd != null) {
				StringReader reader = new StringReader(Xsd);
				return XmlSchema.Read(
					reader,
					null
					);
			}
			else {
				XmlTextReader reader = new System.Xml.XmlTextReader(UrlXsd);
				return XmlSchema.Read(
					reader,
					null
					);
			}
		}

	}
}