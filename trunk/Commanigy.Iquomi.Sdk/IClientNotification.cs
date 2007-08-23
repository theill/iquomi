using System;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Notifications received from the server (if client registered to get
	/// these notifications, that is).
	/// </summary>
	public interface IClientNotification {
		
/*
		event DataCreateEventHandler
		event DataReadEventHandler
		event DataUpdateEventHandler
		event DataDeleteEventHandler
		
		// should be implemented as implement as 'OnDataCreated', etc

// server part contains:
//		void NotifyCreate(string xpath, XmlDocument node);
//		void NotifyRead(string xpath, XmlDocument node); // i.e. undo
//		void NotifyUpdate(string xpath, XmlDocument node);
//		void NotifyDelete(string xpath, XmlDocument node);

*/
	}
}