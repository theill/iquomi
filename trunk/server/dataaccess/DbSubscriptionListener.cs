#region Using directives

using System;
using System.Data;
using System.Xml.Schema;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "subscription_listener" database table.
	/// </summary>
	[DataObject()]
	public class DbSubscriptionListener : SubscriptionListener, IDbObject<DbSubscriptionListener> {
		public static readonly string StateRunning		= "R";
		public static readonly string StateSuspended	= "S";

		public DbSubscriptionListener() {
			;
		}
		
		public void ToggleState() {
			this.State = StateSuspended.Equals(this.State) ? StateRunning : StateSuspended;
		}

		#region IDbObject Members

		public DbSubscriptionListener DbCreate() {
			using (DbUtility db = new DbUtility("iqSubscriptionListenerCreate")) {
				db.In("@account_id", this.AccountId);
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@filter", this.Filter);
				db.In("@context", this.Context);
				db.In("@context_uri", this.ContextUri);
				db.In("@to", this.To);
				db.In("@active_from", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveFrom));
				db.In("@active_to", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveTo));
				db.In("@state", this.State);
				this.Id = (int)db.ExecuteScalar();
				return this;
			}
		}
		
		public DbSubscriptionListener DbRead() {
			using (DbUtility db = new DbUtility("iqSubscriptionListenerRead")) {
				db.In("@id", this.Id);
				return (DbSubscriptionListener)db.Fill(this);
			}
		}
		
		public DbSubscriptionListener DbUpdate() {
			using (DbUtility db = new DbUtility("iqSubscriptionListenerUpdate")) {
				db.In("@id", this.Id);
				db.In("@account_id", this.AccountId);
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@filter", this.Filter);
				db.In("@context", this.Context);
				db.In("@context_uri", this.ContextUri);
				db.In("@to", this.To);
				db.In("@active_from", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveFrom));
				db.In("@active_to", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveTo));
				db.In("@state", this.State);
				return (DbSubscriptionListener)db.Fill(this);
			}
		}
		
		public DbSubscriptionListener DbDelete() {
			using (DbUtility db = new DbUtility("iqSubscriptionListenerDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? null : this;
			}
		}

		#endregion

		public static DbSubscriptionListener DbRead(int id) {
			DbSubscriptionListener a = new DbSubscriptionListener();
			a.Id = id;
			return a.DbRead();
		}

		public static DbSubscriptionListener[] DbFindAllBySubscriptionId(Guid subscriptionId) {
			using (DbUtility db = new DbUtility("iqSubscriptionListenerFindAllBySubscription")) {
				db.In("@subscription_id", subscriptionId);
				return (DbSubscriptionListener[])db.FillAll(typeof(DbSubscriptionListener));
			}
		}

		public static DataTable DbListListenersBySubscription(Guid subscriptionId, Int32 languageId) {
			using (DbUtility db = new DbUtility("iqListListenersBySubscription")) {
				db.In("@subscription_id", subscriptionId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}
	}
}