using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class QueryResponseType {
		public XpQueryResponseType[] XpQueryResponses;
		public ChangeQueryResponseType[] ChangeQueryResponses;
	}
}