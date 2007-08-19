using System;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for Notification.
	/// </summary>
	[Serializable()]
	public class Listener {
		public Services.SubjectType Subject;
		public string Filter;
		public string NotifyTo; // iq:iqEvents, iq:iqContacts
		
		public Listener() {
			;
		}
	}
}