using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// A scope defines a base of either true or nil with an associated list
	/// of shapes filtering base e.g. base T with an exclude shape of 
	/// //*[@Level='Private'] will include everything except any nodes 
	/// with a level attribute of 'Private'.
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
