using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class QueryOptionsType {
		public SortType[] Sort;
		public RangeType[] Range;

		// [>] see p113 .NET My Services Spec
		//public ShapeType[] Shape;
	}
}