#region Using directives

using System;
using System.IO;
using System.Xml;

#endregion

namespace Commanigy.Utils {
	/// <summary>
	/// Summary description for XmlUtils.
	/// </summary>
	public class XmlUtils {
		public XmlUtils() {

		}

		public static string FormatXml(string xml) {
			MemoryStream mem = new MemoryStream();
			XmlTextReader reader = null;
			XmlTextWriter writer = null;

			try {
				reader = new XmlTextReader(xml, XmlNodeType.Document, null);
				reader.WhitespaceHandling = WhitespaceHandling.None;
				
				writer = new XmlTextWriter(mem, System.Text.Encoding.UTF8);
				writer.Formatting = Formatting.Indented;
				writer.Indentation = 2;
				writer.WriteNode(reader, false);
				writer.Flush();

				mem.Position = 0;
				using (StreamReader sr = new StreamReader(mem)) {
					return sr.ReadToEnd();
				}
			}
			finally {
				if (writer != null) {
					writer.Close();
				}

				if (reader != null) {
					reader.Close();
				}

				if (mem != null) {
					mem.Close();
				}
			}
		}

	}
}