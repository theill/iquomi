using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class UseClientIdsType {
		public bool Value;

		public UseClientIdsType() {
			;
		}

		public UseClientIdsType(bool useClientIds) {
			this.Value = useClientIds;
		}
	}
}