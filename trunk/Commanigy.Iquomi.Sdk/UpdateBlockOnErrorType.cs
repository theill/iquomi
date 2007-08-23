using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public enum UpdateBlockOnErrorType {
		RollbackBlockAndFail,
		RollbackBlockAndContinue,
		Ignore
	}
}