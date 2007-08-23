using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class BaseRequestType {
		public string Select;
		public MinOccursType MinOccurs;
		public MaxOccursType MaxOccurs;
	}
}