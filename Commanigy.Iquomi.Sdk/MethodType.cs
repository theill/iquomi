using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class MethodType {
		public const string Insert = "insert";
		public const string Replace = "replace";
		public const string Delete = "delete";
		public const string Update = "update";
		public const string Query = "query";
		public const string Listen = "listen";
		
		private int id;
		private string name;
		
		public int Id { get { return id; } set { id = value; } }
		public string Name { get { return name; } set { name = value; } }
	}
}