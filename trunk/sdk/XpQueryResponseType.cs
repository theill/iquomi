using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class XpQueryResponseType : BaseResponseType {
		public System.Xml.XmlElement[] Any;
	}
}