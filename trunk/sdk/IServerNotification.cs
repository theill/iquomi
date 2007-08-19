using System;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Server notifications are called when a client service wants to tell
	/// the server that it doesn't contain the latest information since the
	/// client did some changes. It's up to the class implementing this
	/// interface (i.e. "ServiceForm" or a custom-made) to check the online
	/// status and eventually upload the changed data if possible. The 
	/// implementator should be able to buffer notifications as well since
	/// a client service might want to do several notifications at once. It
	/// _could_ as well be an assignment for the implementator to filter out
	/// redundant notify reads e.g. if two NotifyUpdate methods are executed
	/// having the same xpath there's no need to fire off the first one if
	/// you haven't done so already.
	/// </summary>
	interface IServerNotification {
		void NotifyCreate(string xpath, XmlDocument node);
		void NotifyRead(string xpath, XmlDocument node); // i.e. undo
		void NotifyUpdate(string xpath, XmlDocument node);
		void NotifyDelete(string xpath, XmlDocument node);
	}
}