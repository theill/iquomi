using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class Scope {
		public int Id;
		public int LanguageId;
		public string Name;
		public string Base;

		public Shape[] Shapes;

		public Scope() {
			;
		}
	}

	public enum ScopeBase {
		T,
		NIL,
	}
	
}
