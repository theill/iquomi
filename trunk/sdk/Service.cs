#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Runtime.Serialization;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class Service {
		private int id;
		private int authorId;
		private string name;
		private string version;
		private string xsd;
		private string urlXsd;
		private string urlIcon;
		private string urlHomepage;
		private string state;
		private RoleMapType roleMap;

		[NonSerialized()]
		private XmlSerializer serializer = new XmlSerializer(typeof(RoleMapType));

		public int Id { get { return id; } set { id = value; } }
		public int AuthorId { get { return authorId; } set { authorId = value; } }
		public string Name { get { return name; } set { name = value; } }
		public string Version { get { return version; } set { version = value; } }
		public string Xsd { get { return xsd; } set { xsd = value; } }
		public string UrlXsd { get { return urlXsd; } set { urlXsd = value; } }
		public string UrlIcon { get { return (urlIcon != null) ? urlIcon : "/gfx/ico.generic.gif"; } set { urlIcon = value; } }
		public string UrlHomepage { get { return urlHomepage; } set { urlHomepage = value; } }
		public string State { get { return state; } set { state = value; } }
		public string RoleMap {
			get {
				if (roleMap != null) {
					StringWriter buffer = new StringWriter();
					serializer.Serialize(buffer, roleMap);
					return buffer.ToString();
				}
				else {
					return null;
				}
			}

			set {
				if (!string.IsNullOrEmpty(value)) {
					StringReader buffer = new StringReader(value);
					roleMap = (RoleMapType)serializer.Deserialize(buffer);
				}
				else {
					roleMap = null;
				}
			}
		}

		public static void Validate(Service v, ValidationEventHandler validationEvents) {
			XmlSchemaSet xsdset = new XmlSchemaSet();
			xsdset.XmlResolver = new XmlUrlResolver();
			xsdset.Add(v.GetXmlSchema());
			//xsdset.Add("http://www.w3.org/XML/1998/namespace", "http://www.w3.org/2001/03/xml.xsd");
			//xsdset.Add("http://schemas.iquomi.com/2004/01/core", "http://schemas.iquomi.com/2004/01/core/iqcommon.xsd");
			if (validationEvents != null) {
				xsdset.ValidationEventHandler += validationEvents;
			}
			xsdset.Compile();
		}

		/// <summary>
		/// Returns *uncompiled* schema.
		/// </summary>
		/// <returns></returns>
		public XmlSchema GetXmlSchema() {
			if (Xsd == null && UrlXsd == null) {
				return null;
			}

			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ValidationType = ValidationType.Schema;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ProcessInlineSchema | XmlSchemaValidationFlags.ProcessIdentityConstraints | XmlSchemaValidationFlags.ReportValidationWarnings;
			//settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema | XmlSchemaValidationFlags.ProcessIdentityConstraints | XmlSchemaValidationFlags.ReportValidationWarnings;

			if (Xsd != null) {
				using (StringReader reader = new StringReader(Xsd)) {
					return XmlSchema.Read(
						XmlReader.Create(reader, settings),
						null
						);
				}
			}
			else {
				return XmlSchema.Read(
					XmlReader.Create(UrlXsd, settings),
					null
					);
			}
		}

		public RoleMapType GetRoleMap() {
			return roleMap;
		}

		public void SetRoleMap(RoleMapType v) {
			roleMap = v;
		}
	}
}