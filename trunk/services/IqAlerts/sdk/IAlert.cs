#region Using directives

using System;
using System.Xml;

#endregion

namespace Commanigy.Iquomi.Services.IqAlerts {
	public delegate void AlertHandler(NotifyType notificationType);

	public interface IAlert {
		void Subscribe(string iqid, string password, AlertHandler handler);
		void Unsubscribe(string iqid, string password);
		
		event AlertHandler Notify;
	}
}