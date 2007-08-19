#region Using directives

using System;
using System.ComponentModel;
using System.Data;

using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "delete_log" database table.
	/// </summary>
	[DataObject()]
	public class DbDeleteLog : DeleteLog, IDbObject<DbDeleteLog> {
		
		public DbDeleteLog() {
			;
		}
		
		#region IDbObject<DbDeleteLog> Members

		public DbDeleteLog DbCreate() {
			using (DbUtility db = new DbUtility("iqDeleteLogCreate")) {
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@change_number", DbType.String, this.ChangeNumber);
				db.In("@uuid", this.Uuid);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbDeleteLog DbRead() {
			throw new System.NotImplementedException();
		}

		public DbDeleteLog DbUpdate() {
			throw new System.NotImplementedException();
		}

		public DbDeleteLog DbDelete() {
			using (DbUtility db = new DbUtility("iqDeleteLogDelete")) {
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@change_number", DbType.String, this.ChangeNumber);
				db.In("@uuid", this.Uuid);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion

		public DbDeleteLog[] DbFindAll() {
			using (DbUtility db = new DbUtility("iqDeleteLogFindAll")) {
				db.In("@subscription_id", this.SubscriptionId);
				return (DbDeleteLog[])db.FillAll(typeof(DbDeleteLog));
			}
		}

	}
}