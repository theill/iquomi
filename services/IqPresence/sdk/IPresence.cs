#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using Commanigy.Iquomi.Services.IqAlerts;

#endregion

namespace Commanigy.Iquomi.Services.IqPresence.Sdk {
	public interface IPresence : IAlert {
		System.Guid SignIn(string iqid, string password, AlertHandler handler);
		void SignOut(System.Guid uid);
	}
}