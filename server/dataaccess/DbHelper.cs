#region Using directives

using System;
using System.Data;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Converts simple type values into objects and thus enable a NULL 
	/// reference required when executing SQL statements.
	/// </summary>
	public class DbHelper {
		
		public static object ToNullDateTime(DateTime v) {
			return (v != DateTime.MinValue) ? v : (object)null;
		}

		public static object ToNullInt32(Int32 v) {
			return (v != 0) ? v : (object)null;
		}

		public static object ToNullString(string v) {
			return (v != null && !v.Equals("")) ? v : null;
		}
	}

}