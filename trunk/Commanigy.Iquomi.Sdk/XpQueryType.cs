using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class XpQueryType : BaseRequestType {
		public QueryOptionsType[] Options;
	}
}