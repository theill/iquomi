using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class Shape {
		public int Id;
		public int ScopeId;
		public string Select;
		public string Type;

		public Shape() {
			;
		}
	}

	public enum ShapeType {
		Include,
		Exclude,
	}
}
