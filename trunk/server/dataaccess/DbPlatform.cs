#region Using directives

using System;
using System.ComponentModel;
using System.Data;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbPlatform {
		public DbPlatform() {
			;
		}

		public static DataTable DbFindAll(int languageId) {
			using (DbUtility db = new DbUtility("iqPlatformFindAll")) {
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}

		public static int ToId(string platformName) {
			switch (platformName.ToLower()) {
				case "windows":
					return 2;
				case "linux":
					return 3;
				case "pda":
					return 4;
				case "palm":
					return 5;
				default: // "any"
					return 1;
			}
		}

	}
}
