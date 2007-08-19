#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// The <b>NotifyListDocument</b> contains notification listeners setup 
	/// by users to listen on a given scope of data. When these data are 
	/// changed the subscriber is notified. The "To" parameter is used
	/// to determine how the subscriber is notified.
	/// </summary>
	public class NotifyListDocument : IqDocument {
		private NotifyListType notifyList;

		public static NotifyListDocument Create(Api.Subscription s) {
			XmlDocument d = new XmlDocument();
			if (s.NotifyList != null) {
				d.LoadXml(s.NotifyList);
			}

			return new NotifyListDocument(d, s.GetNotifyList());
		}

		private NotifyListDocument(XmlDocument d, NotifyListType notifyList) : base(d) {
			this.notifyList = notifyList ?? new NotifyListType();
		}

		public ListenerType[] GetListeners() {
			return notifyList.Listener ?? new ListenerType[0];
		}

	}
}