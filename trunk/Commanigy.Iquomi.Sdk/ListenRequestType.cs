using System;
using System.Reflection;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class ListenRequestType : BaseRequestType {
		public string To;
	}
}