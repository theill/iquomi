using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
	public class SortType {
    
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(SortTypeDirection.Ascending)]
		public SortTypeDirection Direction = SortTypeDirection.Ascending;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Key;
	}
}