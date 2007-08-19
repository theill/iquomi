#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

using log4net;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[Serializable(), DataObject()]
	public class DbService : Service, IDbObject<DbService> {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public DbService() {

		}
		
		public static DbService DbCreate(DbService v) {
			using (DbUtility db = new DbUtility("iqServiceCreate")) {
				db.In("@author_id", v.AuthorId);
				db.In("@name", v.Name);
				db.In("@version", v.Version);
				db.In("@xsd", v.Xsd);
				db.In("@url_xsd", v.UrlXsd);
				db.In("@url_icon", v.UrlIcon);
				db.In("@url_homepage", v.UrlHomepage);
				db.In("@state", v.State);
				db.In("@role_map", v.RoleMap);
				v.Id = (int)db.ExecuteScalar();
				return v;
			}
		}

		public static DbService DbRead(Int32 id, Int32 authorId, Int32 languageId) {
			using (DbUtility db = new DbUtility("iqServiceFindByAuthor")) {
				db.In("@id", id);
				db.In("@author_id", authorId);
				db.In("@language_id", languageId);
				return (DbService)db.Fill(new DbService());
			}
		}

		public static DbService DbRead(Int32 id) {
			DbService a = new DbService();
			a.Id = id;
			return a.DbRead();			
		}
		
		public static DbService DbUpdate(DbService v) {
			using (DbUtility db = new DbUtility("iqServiceUpdate")) {
				db.In("@id", v.Id);
				db.In("@author_id", v.AuthorId);
				db.In("@name", v.Name);
				db.In("@version", v.Version);
				db.In("@xsd", v.Xsd);
				db.In("@url_xsd", v.UrlXsd);
				db.In("@url_icon", v.UrlIcon);
				db.In("@url_homepage", v.UrlHomepage);
				db.In("@state", v.State);
				db.In("@role_map", v.RoleMap);
				return (db.ExecuteNonQuery() == 1) ? v : null;
			}
		}

		public static DbService DbDelete(DbService v) {
			using (DbUtility db = new DbUtility("iqServiceDelete")) {
				db.In("@id", v.Id);
				return (db.ExecuteNonQuery() == 1) ? v : null;
			}
		}

		// ---

		#region IDbObject<DbService> Members

		/// <summary>
		/// Creates new Service.
		/// </summary>
		/// <returns></returns>
		public DbService DbCreate() {
			using (DbUtility db = new DbUtility("iqServiceCreate")) {
				db.In("@author_id", this.AuthorId);
				db.In("@name", this.Name);
				db.In("@version", this.Version);
				db.In("@xsd", this.Xsd);
				db.In("@url_xsd", this.UrlXsd);
				db.In("@url_icon", this.UrlIcon);
				db.In("@url_homepage", this.UrlHomepage);
				db.In("@state", this.State);
				db.In("@role_map", this.RoleMap);
				Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbService DbRead() {
			using (DbUtility db = new DbUtility("iqServiceRead")) {
				db.In("@id", this.Id);
				db.In("@language_id", 1);
				return (DbService)db.Fill(this);
			}
		}

		public DbService DbUpdate() {
			using (DbUtility db = new DbUtility("iqServiceUpdate")) {
				db.In("@id", DbType.Int32, Id);
				db.In("@author_id", DbType.Int32, AuthorId);
				db.In("@name", DbType.String, Name);
				db.In("@version", DbType.String, Version);
				db.In("@xsd", DbType.String, Xsd);
				db.In("@url_xsd", DbType.String, UrlXsd);
				db.In("@url_icon", DbType.String, UrlIcon);
				db.In("@url_homepage", DbType.String, UrlHomepage);
				db.In("@state", DbType.String, State);
				db.In("@role_map", DbType.String, this.RoleMap);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbService DbDelete() {
			using (DbUtility db = new DbUtility("iqServiceDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion

		public DbService DbFindByName() {
			using (DbUtility db = new DbUtility("iqServiceFindByName")) {
				db.In("@name", this.Name);
				db.In("@language_id", 1);
				return (DbService)db.Fill(this);
			}
		}

		public static DbService DbFindByName(string name) {
			DbService service = new DbService();
			service.Name = name;
			return service.DbFindByName();
		}

		public static DbService[] DbFindAllByAuthor(int authorId, int languageId) {
			using (DbUtility db = new DbUtility("iqServiceFindAllByAuthor")) {
				db.In("@author_id", authorId);
				db.In("@language_id", languageId);
				return (DbService[])db.FillAll(typeof(DbService));
			}
		}

		public DbService DbFindByAuthorId() {
			using (DbUtility db = new DbUtility("iqServiceFindByAuthor")) {
				db.In("@id", this.Id);
				db.In("@author_id", this.AuthorId);
				db.In("@language_id", 1);
				return (DbService)db.Fill(this);
			}
		}

		public static DataTable DbListAllByAuthor(int authorId, int languageId) {
			using (DbUtility db = new DbUtility("iqListAllServicesByAuthorId")) {
				db.In("@author_id", authorId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}

		public DbScope DbCreateScope(DbScope v) {
			using (DbUtility db = new DbUtility("iqScopeCreateByService")) {
				db.In("@service_id", this.Id);
				db.In("@language_id", v.LanguageId);
				db.In("@name", v.Name);
				db.In("@base", v.Base);
				v.Id = (int)db.ExecuteScalar();
				return (DbScope)v;
			}
		}

		/// <summary>
		/// Attach standard role template to this new service. These
		/// templates are read from an Xml document and is currently
		/// the same for all created services. In the future it might
		/// be possible to specify a specific role-set upon service
		/// creation
		/// </summary>
		/// <param name="standardRoleTemplates"></param>
		/// <returns></returns>
		public bool InsertStandardRoleTemplates(XmlNode standardRoleTemplates) {
			Hashtable ht = new Hashtable();
			foreach (XmlElement scope in standardRoleTemplates.SelectNodes("//Scope")) {
				DbScope s = new DbScope();
				s.Name = scope.GetAttribute("Name");
				s.Base = scope.GetAttribute("Base");
				s.DbCreate();
				ht.Add(s.Name, s);

				foreach (XmlElement shape in scope.SelectNodes("Shape")) {
					DbShape shp = new DbShape();
					shp.ScopeId = s.Id;
					shp.Select = shape.GetAttribute("Select");
					shp.Type = shape.GetAttribute("Type");
					shp.DbCreate();
				}

				DbServiceScope ss = new DbServiceScope();
				ss.ServiceId = this.Id;
				ss.ScopeId = s.Id;
				ss.DbCreate();
			}

			foreach (XmlElement roleTemplate in standardRoleTemplates.SelectNodes("//RoleTemplate")) {
				DbRoleTemplate rt = new DbRoleTemplate();
				rt.ServiceId = this.Id;
				rt.Name = roleTemplate.GetAttribute("Name");
				rt.Priority = roleTemplate.HasAttribute("Priority") ? Convert.ToInt32(roleTemplate.GetAttribute("Priority")) : 0;
				rt.DbCreate();
				foreach (XmlElement method in roleTemplate.SelectNodes("Method")) {
					DbRoleTemplateMethod rtm = new DbRoleTemplateMethod();
					rtm.RoleTemplateId = rt.Id;
					rtm.MethodTypeId = DbMethodType.GetIdForName(method.GetAttribute("Name"));
					rtm.ScopeId = ((DbScope)ht[method.GetAttribute("ScopeRef")]).Id;
					rtm.DbCreate();
				}
			}

			return true;
		}
  







		// Write out the example of the XSD usage
		public string GetXmlTemplate() {
			log.Debug("Getting XmlTemplate");
			MemoryStream mem = new MemoryStream();
			XmlTextWriter myXmlTextWriter = new XmlTextWriter(mem, System.Text.Encoding.UTF8);
			myXmlTextWriter.Formatting = Formatting.Indented;
			myXmlTextWriter.Indentation = 2;
			XmlSchema xsd = this.GetXmlSchema();
			xsd.Compile(null);
			foreach (XmlSchemaElement element in xsd.Elements.Values) {
				WriteExampleElement(myXmlTextWriter, element);
			}
			myXmlTextWriter.Flush();
			mem.Position = 0;
			StreamReader sr = new StreamReader(mem);
			string xml = sr.ReadToEnd();
			log.Debug("Returning sample xml as:\n" + xml);
			return xml;
		}

		// Write some example elements
		void WriteExampleElement(XmlTextWriter myXmlTextWriter, XmlSchemaElement element) {
			myXmlTextWriter.WriteStartElement(element.QualifiedName.Name, element.QualifiedName.Namespace);
			if (element.ElementType is XmlSchemaComplexType) {
				XmlSchemaComplexType type = (XmlSchemaComplexType)element.ElementType;
				if (type.ContentModel != null) {
					Console.WriteLine("Not Implemented for this ContentModel");
				}
				WriteExampleAttributes(myXmlTextWriter, type.Attributes);
				WriteExampleParticle(myXmlTextWriter, type.Particle);
			}
			else {
				WriteExampleValue(myXmlTextWriter, element.ElementType);
			}

			myXmlTextWriter.WriteEndElement();
		}

		// Write some example attributes
		void WriteExampleAttributes(XmlTextWriter myXmlTextWriter, XmlSchemaObjectCollection attributes) {
			foreach (object o in attributes) {
				if (o is XmlSchemaAttribute) {
					WriteExampleAttribute(myXmlTextWriter, (XmlSchemaAttribute)o);
				}
				else {
					XmlSchemaAttributeGroup group = (XmlSchemaAttributeGroup)this.GetXmlSchema().Groups[((XmlSchemaAttributeGroupRef)o).RefName];
					WriteExampleAttributes(myXmlTextWriter, group.Attributes);
				}
			}
		}

		// Write a single example attribute
		void WriteExampleAttribute(XmlTextWriter myXmlTextWriter, XmlSchemaAttribute attribute) {
			myXmlTextWriter.WriteStartAttribute(attribute.QualifiedName.Name, attribute.QualifiedName.Namespace);
			// The examples value
			WriteExampleValue(myXmlTextWriter, attribute.AttributeType);
			myXmlTextWriter.WriteEndAttribute();
		}

		// Write example particles
		void WriteExampleParticle(XmlTextWriter myXmlTextWriter, XmlSchemaParticle particle) {
			Decimal max;

			if (particle.MaxOccurs == -1 || particle.MaxOccurs > 10000)
				max = 5;
			else
				max = particle.MaxOccurs;

			for (int i = 0; i < max; i++) {
				if (particle is XmlSchemaElement)
					WriteExampleElement(myXmlTextWriter, (XmlSchemaElement)particle);
				else if (particle is XmlSchemaSequence) {
					foreach (XmlSchemaParticle particle1 in ((XmlSchemaSequence)particle).Items)
						WriteExampleParticle(myXmlTextWriter, particle1);
				}
				else
					Console.WriteLine("Not Implemented for this type: {0}", particle.ToString());
			}
		}

		// Write the examples text values
		void WriteExampleValue(XmlTextWriter myXmlTextWriter, object schemaType) {
			XmlSchemaDatatype datatype = (schemaType is XmlSchemaSimpleType) ? ((XmlSchemaSimpleType)schemaType).Datatype : (XmlSchemaDatatype)schemaType;

			// Consult the XSD to CLR conversion table for the correct type mappings
			Type type = datatype.ValueType;
			if (type == typeof(bool))
				myXmlTextWriter.WriteString("true");
			else if (type == typeof(int) || type == typeof(long))
				myXmlTextWriter.WriteString("100");
			else if (type == typeof(float) || type == typeof(decimal))
				myXmlTextWriter.WriteString("279.42");
			else if (type == typeof(System.Xml.XmlQualifiedName))
				myXmlTextWriter.WriteString("qualified_name");
			else if (type == typeof(DateTime))
				myXmlTextWriter.WriteString("12-12-2001");
			else if (type == typeof(string))
				myXmlTextWriter.WriteString("ExampleString");
			// Handle the 'xsd:positiveInteger' XSD type in the SOMsample.xsd
			else if (type == typeof(System.UInt64))
				//positiveInteger
				myXmlTextWriter.WriteString("42789");
			else
				myXmlTextWriter.WriteString("Not Implemented for this datatype: " + datatype.ToString());
		}

	}
}