using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class NewBlueIdType {
		public string Id;
		
		public NewBlueIdType() {
			;
		}

		public NewBlueIdType(string id) {
			this.Id = id;
		}
	}
}