using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for IAuthenticationType.
	/// </summary>
	public interface IAuthenticationType {
		string Iqid { get; }
		string Password { get; }
	}
}
