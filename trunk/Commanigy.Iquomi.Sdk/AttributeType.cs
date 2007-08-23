#region Using directives

using System;
using System.Runtime.Serialization;

#endregion

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for AttributeType.
	/// </summary>
	[Serializable()]
	public class AttributeType {
		public string Name;
		public string Value;
	}
}