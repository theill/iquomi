#region Using directives

using System;
using System.Data;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "method_history" table.
	/// </summary>
	[DataObject()]
	public class DbMethodHistory : IDbObject<DbMethodHistory> {
		private int id;
		private int accountId;
		private Guid subscriptionId;
		private DateTime timestamp;
		private string method;
		private string userHostAddress;
		
		public int Id { get { return id; } set { id = value; } }
		public int AccountId { get { return accountId; } set { accountId = value; } }
		public Guid SubscriptionId { get { return subscriptionId; } set { subscriptionId = value; } }
		public DateTime Timestamp { get { return timestamp; } set { timestamp = value; } }
		public string Method { get { return method; } set { method = value; } }
		public string UserHostAddress { get { return userHostAddress; } set { userHostAddress = value; } }
		
		public DbMethodHistory() {

		}
		
		#region IDbObject<DbMethodHistory> Members

		public DbMethodHistory DbCreate() {
			using (DbUtility db = new DbUtility("iqMethodHistoryCreate")) {
				db.In("@account_id", this.AccountId);
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@method", this.Method);
				db.In("@user_host_address", this.UserHostAddress);
				this.Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbMethodHistory DbRead() {
			throw new NotImplementedException();
		}

		public DbMethodHistory DbUpdate() {
			throw new NotImplementedException();
		}

		public DbMethodHistory DbDelete() {
			throw new NotImplementedException();
		}

		#endregion

		public static DataTable DbFindAll(Int32 accountId, Int32 languageId) {
			using (DbUtility db = new DbUtility("iqMethodHistoryFindAll")) {
				db.In("@account_id", accountId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}

	}
}