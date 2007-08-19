#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using Commanigy.Iquomi.Services;
using System.Threading;
using System.Security.Principal;
using System.Runtime.Remoting.Messaging;

#endregion

namespace Commanigy.Iquomi.Services.IqAlerts {
	[Serializable]
	public class Alert : MarshalByRefObject, IAlert {
		#region IAlert Members

		/// <summary>
		/// TODO: provide authentication based on soap headers instead of using
		/// explicitly passed credentials
		/// </summary>
		/// <param name="iqid"></param>
		/// <param name="password"></param>
		/// <param name="mn"></param>
		public void Subscribe(string iqid, string password, AlertHandler mn) {
			AlertsSubscriptionManagement.Instance.Subscribe(iqid, password, mn);
		}

		public void Unsubscribe(string iqid, string password) {
			AlertsSubscriptionManagement.Instance.Unsubscribe(iqid, password);
		}

//		public string AppDomainName {
//			get { return (AppDomain.CurrentDomain.FriendlyName); }
//		}

		public event AlertHandler Notify;

		#endregion
	}
}