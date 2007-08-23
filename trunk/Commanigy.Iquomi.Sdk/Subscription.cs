#region Using statements

using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class Subscription : ICloneable {
		private Guid id;
		private int accountId;
		private int serviceId;
		private string name;
		private string xml;
		private string urlXml;
		private RoleListType roleList;
		private NotifyListType notifyList;

		[NonSerialized()]
		private XmlSerializer serializer = new XmlSerializer(typeof(RoleListType));
		
		[NonSerialized()]
		private XmlSerializer serializer2 = new XmlSerializer(typeof(NotifyListType));

		public Guid Id { get { return id; } set { id = value; } }
		public int AccountId { get { return accountId; } set { accountId = value; } }
		public int ServiceId { get { return serviceId; } set { serviceId = value; } }
		public string Name { get { return name; } set { name = value; } }
		public string Xml { get { return xml; } set { xml = value; } }
		public string UrlXml { get { return urlXml; } set { urlXml = value; } }
		public string RoleList {
			get {
				if (roleList != null) {
					StringWriter buffer = new StringWriter();
					serializer.Serialize(buffer, roleList);
					return buffer.ToString();
				}
				else {
					return null;
				}
			}

			set {
				if (!string.IsNullOrEmpty(value)) {
					StringReader buffer = new StringReader(value);
					try {
						Trace.WriteLine("Deserializing rolelist: " + roleList);
						roleList = (RoleListType)serializer.Deserialize(buffer);
					}
					catch (Exception e) {
						Trace.WriteLine("Failed to deserialize: " + e.Message);
						roleList = new RoleListType();
					}
				}
				else {
					roleList = null;
				}
			}
		}

		public string NotifyList {
			get {
				if (notifyList != null) {
					StringWriter buffer = new StringWriter();
					serializer2.Serialize(buffer, notifyList);
					return buffer.ToString();
				}
				else {
					return null;
				}
			}

			set {
				if (!string.IsNullOrEmpty(value)) {
					StringReader buffer = new StringReader(value);
					try {
						Trace.WriteLine("Deserializing notifyList: " + notifyList);
						notifyList = (NotifyListType)serializer2.Deserialize(buffer);
					}
					catch (Exception e) {
						Trace.WriteLine("Failed to deserialize: " + e.Message);
						notifyList = new NotifyListType();
					}
				}
				else {
					notifyList = null;
				}
			}
		}

		public XmlDocument GetXmlDocument() {
			if (Xml == null) {
				return null;
			}

			XmlDocument d = new XmlDocument();
			d.LoadXml(Xml);
			return d;
		}

		public RoleListType GetRoleList() {
			return roleList;
		}

		public void SetRoleList(RoleListType v) {
			roleList = v;
		}

		public NotifyListType GetNotifyList() {
			return notifyList;
		}

		public void SetNotifyList(NotifyListType v) {
			notifyList = v;
		}

		/// <summary>
		/// Validates Xml document based on XmlSchema.
		/// </summary>
		/// <param name="xsd"></param>
		/// <returns></returns>
		public void ValidateXmlDocument(XmlSchema xsd, ValidationEventHandler veh) {
//			// Create the XmlNamespaceManager that is used to look up 
//			// namespace information.
//			NameTable nt = new NameTable();
//			XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
//			nsmgr.AddNamespace("iq", "http://schemas.iquomi.com/2004/01/core");
//
//			// Create the XmlParserContext.
//				XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
			XmlParserContext context = new XmlParserContext(null, null, "http://www.w3.org/XML/1998/namespace", XmlSpace.None);

//			XmlReader.Create(null).Read()
			// Implement the reader. 
			XmlValidatingReader rdr = new XmlValidatingReader(this.xml, XmlNodeType.Element, context);

			rdr.ValidationType = ValidationType.Schema;
			rdr.Schemas.Add(xsd);
			rdr.ValidationEventHandler += veh;
			while (rdr.Read()) {
				;
			}
		}

		public void SetXmlDocument(XmlDocument d) {
			if (d == null) {
				return;
			}

			Xml = d.OuterXml;
		}

		public bool IsValid() {
			return !Guid.Empty.Equals(this.Id) && (AccountId > 0) && (ServiceId > 0);
		}

		public object Clone() {
			Subscription c = new Subscription();
			c.Id = this.Id;
			c.AccountId = this.AccountId;
			c.ServiceId = this.ServiceId;
			c.Name = this.Name;
			c.Xml = this.Xml;
			c.UrlXml = this.UrlXml;
			c.RoleList = this.RoleList;
			c.NotifyList = this.NotifyList;
			return c;
		}
	}
}