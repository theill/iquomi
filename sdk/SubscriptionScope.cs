using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class SubscriptionScope {
		public Guid SubscriptionId;
		public int ScopeId;

		public SubscriptionScope() {
			;
		}
	}
}
