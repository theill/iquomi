using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class ChangeQueryType : BaseRequestType {
		public QueryOptionsType[] Options;
		public int BaseChangeNumber;
	}
}