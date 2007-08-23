using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class QueryRequestType {
		public XpQueryType[] XpQueries;
		public ChangeQueryType[] ChangeQueries;
	}
}