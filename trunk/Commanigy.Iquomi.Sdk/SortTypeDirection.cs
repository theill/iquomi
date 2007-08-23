using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
	public enum SortTypeDirection {
		Ascending,
		Descending
	}
}