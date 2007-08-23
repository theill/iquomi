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
	public class DbChargeUnit : IDbObject<DbChargeUnit> {
		
		public DbChargeUnit() {
			;
		}

		#region IDbObject Members

		public DbChargeUnit DbCreate() {
			throw new System.NotImplementedException();
		}

		public DbChargeUnit DbRead() {
			throw new System.NotImplementedException();
		}

		public DbChargeUnit DbUpdate() {
			throw new System.NotImplementedException();
		}

		public DbChargeUnit DbDelete() {
			throw new System.NotImplementedException();
		}

		#endregion

		public object DbFindAll() {
			using (DbUtility db = new DbUtility("iqChargeUnitFindAll")) {
				db.In("@language_id", DbType.Int32, 1);
				return db.GetDataTable();
			}
		}

	}
}