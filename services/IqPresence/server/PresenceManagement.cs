#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Commanigy.Iquomi.Services.IqAlerts;

#endregion

namespace Commanigy.Iquomi.Services.IqPresence {
	public class PresenceManagement {
		private static readonly PresenceManagement instance = new PresenceManagement(new Hashtable());

		private Hashtable endpoints;

		private PresenceManagement(Hashtable endpoints) {
			this.endpoints = endpoints;
		}

		public static PresenceManagement Instance {
			get {
				return instance;
			}
		}

		public Guid SignIn(AlertHandler cb) {
			Guid id = new Guid();
			endpoints.Add(id, cb);
			return id;
		}

		public void SignOut(Guid id) {
			endpoints.Remove(id);
		}

		public AlertHandler GetEndpoint(string id) {
			return (AlertHandler)endpoints[new Guid(id)];
		}
	}
}
