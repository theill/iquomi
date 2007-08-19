#region Using directives

using System;
using System.Data;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbSubscriptionScope : SubscriptionScope, IDbObject<DbSubscriptionScope> {
		public DbSubscriptionScope() {
			;
		}

		#region IDbObject<DbSubscriptionScope> Members

		public DbSubscriptionScope DbCreate() {
			using (DbUtility db = new DbUtility("iqSubscriptionScopeCreate")) {
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@scope_id", this.ScopeId);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbSubscriptionScope DbRead() {
			throw new NotImplementedException();
		}

		public DbSubscriptionScope DbUpdate() {
			throw new NotImplementedException();
		}

		public DbSubscriptionScope DbDelete() {
			using (DbUtility db = new DbUtility("iqSubscriptionScopeDelete")) {
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@scope_id", this.ScopeId);
				return (db.ExecuteNonQuery() > 0) ? this : null;
			}
		}

		#endregion

		public static DbScope[] DbFindAllScopesBySubscription(Guid subscriptionId) {
			using (DbUtility db = new DbUtility("iqSubscriptionScopeFindAllBySubscription")) {
				db.In("@subscription_id", DbType.Guid, subscriptionId);
				return (DbScope[])db.FillAll(typeof(DbScope));
			}
		}

		public static DataTable DbListAllScopesBySubscription(Guid subscriptionId, int languageId) {
			using (DbUtility db = new DbUtility("iqListAllScopesBySubscription")) {
				db.In("@subscription_id", DbType.Guid, subscriptionId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}
	}
}