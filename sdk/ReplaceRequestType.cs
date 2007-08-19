using System;
using System.Reflection;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for ReplaceRequestType.
	/// </summary>
	[Serializable()]
	public class ReplaceRequestType : BaseRequestType {
		public UseClientIdsType UseClientIds;
		
		public AttributeType[] Attributes;
		public XmlElement[] Any;
	}
}