#region Using directives

using System;
using System.Xml;

#endregion

namespace Commanigy.Iquomi.Services.IqAlerts {
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class AlertEventShim : MarshalByRefObject {
		private AlertHandler target;

		private AlertEventShim(AlertHandler target) {
			this.target += target;
		}

		public void NotifyShim(NotifyType n) {
			target(n);
		}

		public static AlertHandler Create(AlertHandler target) {
			AlertEventShim shim = new AlertEventShim(target);
			return new AlertHandler(shim.NotifyShim);
		}

		public override object InitializeLifetimeService() {
			return null;
		}
	}
}