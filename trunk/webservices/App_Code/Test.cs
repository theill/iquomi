using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;

using Commanigy.Iquomi.Services;

namespace Commanigy.Iquomi.WebServices {
	[WebService(Namespace = "http://schemas.iquomi.com/2004/01/core")]
	public class Test : System.Web.Services.WebService {
		[WebMethod]
		[XmlInclude(typeof(Person)), XmlInclude(typeof(Company))]
		public bool Update(ObjectType myObject) {
			return (myObject.Any != null && myObject.Any.GetType() == typeof(Person));
		}
	}

	[Serializable]
	[XmlTypeAttribute(Namespace = "http://schemas.iquomi.com/2004/01/core")]
	public class ObjectType {
		public string Type;
		[XmlChoiceIdentifier("EnumType")]
		[XmlElement("Person", typeof(Person)), XmlElement("Company", typeof(Company))]
		public object Any;

		[XmlIgnore]
		public PersonCompanyChoiceType EnumType;
	}

	[Serializable]
	[XmlTypeAttribute(Namespace = "http://schemas.iquomi.com/2004/01/core")]
	public class Person {
		public string Firstname;
		public string Surname;
	}

	[Serializable]
	[XmlTypeAttribute(Namespace = "http://schemas.iquomi.com/2004/01/core")]
	public class Company {
		public string Name;
	}

	[XmlType(IncludeInSchema = false)]
	public enum PersonCompanyChoiceType {
		Person,
		Company
	}
}