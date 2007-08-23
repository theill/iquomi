using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public enum ChangeQueryResponseStatus {
		Success,
		Failure,
		Refresh
	}
}