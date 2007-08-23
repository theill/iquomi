using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class BaseResponseType {
		public int SelectedNodeCount;
		public ResponseStatus Status;
	}
}