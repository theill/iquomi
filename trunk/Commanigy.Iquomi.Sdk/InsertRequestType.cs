using System;
using System.Reflection;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class InsertRequestType : BaseRequestType {
		public UseClientIdsType UseClientIds;
		
		public AttributeType[] Attributes;
		public XmlElement[] Any;
	}
}