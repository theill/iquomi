#region Using directives

using System;

#endregion

namespace Commanigy.Iquomi.Web {
	public interface IPageNotification {
		void Notify(Exception e);
		void Notify(string message);
		void Success();
	}
}
