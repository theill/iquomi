using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for IRequestType.
	/// </summary>
	public interface IRequestType {
		string Service { get; }
		string OwnerIqid { get; }
	}
}
