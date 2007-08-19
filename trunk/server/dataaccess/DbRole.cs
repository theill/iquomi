#region Using directives

using System;
using System.ComponentModel;
using System.Data;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbRole : Role, IDbObject<DbRole> {
		public DbRole() {
			;
		}

		#region IDbObject Members

		public DbRole DbCreate() {
			using (DbUtility db = new DbUtility("iqRoleCreate")) {
				db.In("@subscription_id", this.SubscriptionId);
				db.In("@account_id", this.AccountId);
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@scope_id", DbType.Int32, DbHelper.ToNullInt32(this.ScopeId));
				db.In("@active_from", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveFrom));
				db.In("@active_to", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveTo));
				this.Id = (Int32)db.ExecuteScalar();
				return this;
			}
		}

		public DbRole DbRead() {
			using (DbUtility db = new DbUtility("iqRoleRead")) {
				db.In("@id", this.Id);
				return (DbRole)db.Fill(this);
			}
		}

		public DbRole DbUpdate() {
			using (DbUtility db = new DbUtility("iqRoleUpdate")) {
				db.In("@id", DbType.Int32, this.Id);
				db.In("@account_id", this.AccountId);
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@scope_id", DbType.Int32, DbHelper.ToNullInt32(this.ScopeId));
				db.In("@active_from", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveFrom));
				db.In("@active_to", DbType.DateTime, DbHelper.ToNullDateTime(this.ActiveTo));
				return (DbRole)db.Fill(this);
			}
		}

		public DbRole DbDelete() {
			using (DbUtility db = new DbUtility("iqRoleDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}
		
		#endregion

		public DbRoleTemplate DbLookupRoleTemplate() {
			DbRoleTemplate roleTemplate = new DbRoleTemplate();
			roleTemplate.Id = this.RoleTemplateId;
			return (DbRoleTemplate)roleTemplate.DbRead();
		}

		public DbScope DbLookupScope() {
			// Not necessarily any scopes attached to role
			if (this.ScopeId == 0) {
				return null;
			}

			DbScope scope = new DbScope();
			scope.Id = this.ScopeId;
			if (scope.DbRead() == null) {
				return null;
			}

			DbShape shape = new DbShape();
			shape.ScopeId = scope.Id;
			scope.Shapes = (DbShape[])shape.DbFindAll();
			return scope;
		}

		public static DbRole DbLookup(int accountId, Guid subscriptionId) {
			using (DbUtility db = new DbUtility("iqRoleLookup")) {
				db.In("@account_id", accountId);
				db.In("@subscription_id", subscriptionId);
				return (DbRole)db.Fill(new DbRole());
			}
		}

        public static DbRole[] DbFindAllBySubscriptionId(Guid subscriptionId) {
			using (DbUtility db = new DbUtility("iqRoleFindAllBySubscription")) {
				db.In("@subscription_id", subscriptionId);
				return (DbRole[])db.FillAll(typeof(DbRole));
			}
        }

    }
}