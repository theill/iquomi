using System;
using System.Xml;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for SubscriptionListener.
	/// </summary>
	[Serializable()]
	public class SubscriptionListener {
		private int id;

		public int Id {
			get { return id; }
			set { id = value; }
		}

		private Guid subscriptionId;

		public Guid SubscriptionId {
			get { return subscriptionId; }
			set { subscriptionId = value; }
		}

		private int accountId;

		public int AccountId {
			get { return accountId; }
			set { accountId = value; }
		}

		private string filter;

		public string Filter {
			get { return filter; }
			set { filter = value; }
		}

		private string context;

		public string Context {
			get { return context; }
			set { context = value; }
		}

		private string contextUri;

		public string ContextUri {
			get { return contextUri; }
			set { contextUri = value; }
		}

		private DateTime activeFrom;

		public DateTime ActiveFrom {
			get { return activeFrom; }
			set { activeFrom = value; }
		}

		private DateTime activeTo;

		public DateTime ActiveTo {
			get { return activeTo; }
			set { activeTo = value; }
		}

		// "iq:iqEvents" | ".NET Alerts" | <event sink>
		private string to;

		public string To {
			get { return to; }
			set { to = value; }
		}

		// R = Running, S = Suspended
		private string state;

		public string State {
			get { return state; }
			set { state = value; }
		}

		public SubscriptionListener() {
			;
		}
	}
}