using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class MinOccursType {
		public int Value;

		public MinOccursType() {
			;
		}

		public MinOccursType(int minOccurs) {
			this.Value = minOccurs;
		}
	}
}