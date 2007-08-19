using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public enum ResponseStatus {
		Success,
		Failure,
		Rollback,
		NotAttempted
	}
}