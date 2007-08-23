using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class MaxOccursType {
		public int Value;
		
		public MaxOccursType() {
			;
		}

		public MaxOccursType(int maxOccurs) {
			this.Value = maxOccurs;
		}
	}
}