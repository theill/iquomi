#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using log4net;

#endregion

namespace Commanigy.Iquomi.Services.IqAlerts {
	/// <summary>
	/// 
	/// </summary>
	public class AlertsSubscriptionManagement {
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private static readonly AlertsSubscriptionManagement instance = new AlertsSubscriptionManagement(new Dictionary<string, AlertHandler>());
		private Dictionary<string, AlertHandler> users;

		private AlertsSubscriptionManagement(Dictionary<string, AlertHandler> users) {
			this.users = users;
		}

		public static AlertsSubscriptionManagement Instance {
			get {
				return instance;
			}
		}

		public void Subscribe(string iqid, string password, AlertHandler cb) {
			// remove any previous handlers
			if (users.ContainsKey(iqid)) {
				users.Remove(iqid);
			}

			users.Add(iqid, cb);
			log.Debug(string.Format("Iqid \"{0}\" subscribed", iqid));
		}

		public void Unsubscribe(string iqid, string password) {
			users.Remove(iqid);
			log.Debug(string.Format("Iqid \"{0}\" unsubscribed", iqid));
		}

		public AlertHandler GetChannel(string iqid) {
			return users.ContainsKey(iqid) ? users[iqid] : null;
		}

        public string[] RegisteredUsers() {
            if (users == null) {
                return new string[0];
            }

            string[] a = new string[users.Keys.Count];
            users.Keys.CopyTo(a, 0);
            return a;
        }
    }
}