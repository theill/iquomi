#region Using directives

using System;
using System.ComponentModel;
using System.Data;

using log4net;

using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "account" database table.
	/// </summary>
	[Serializable()]
	[DataObject()]
	public class DbAccount : Account, IDbObject<DbAccount> {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public DbAccount() {

		}

		#region IDbObject Members

		public DbAccount DbCreate() {
			using (DbUtility db = new DbUtility("iqAccountCreate")) {
				db.In("@owner_account_id", DbType.Int32, DbHelper.ToNullInt32(this.OwnerAccountId));
				db.In("@group_id", DbType.Int32, DbHelper.ToNullInt32(this.GroupId));
				db.In("@iqid", this.Iqid);
				db.In("@email", this.Email);
				db.In("@password", this.Password);
				this.Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbAccount DbRead() {
			using (DbUtility db = new DbUtility("iqAccountRead")) {
				db.In("@id", this.Id);
				return db.Fill<DbAccount>(this);
			}
		}

		public DbAccount DbUpdate() {
			using (DbUtility db = new DbUtility("iqAccountUpdate")) {
				db.In("@id", this.Id);
				db.In("@owner_account_id", DbType.Int32, DbHelper.ToNullInt32(this.OwnerAccountId));
				db.In("@group_id", DbType.Int32, DbHelper.ToNullInt32(this.GroupId));
				db.In("@iqid", this.Iqid);
				db.In("@email", this.Email);
				db.In("@password", this.Password);
				return db.Fill<DbAccount>(this);
			}
		}

		public DbAccount DbDelete() {
			using (DbUtility db = new DbUtility("iqAccountDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion

		public static Account DbLoad(Int32 id) {
			using (DbUtility db = new DbUtility("iqAccountRead")) {
				db.In("@id", id);
				return db.Fill<Account>(new Account());
			}
		}
		
		public static bool DbSave(Account v) {
			using (DbUtility db = new DbUtility("iqAccountUpdate")) {
				db.In("@id", v.Id);
				db.In("@owner_account_id", DbType.Int32, DbHelper.ToNullInt32(v.OwnerAccountId));
				db.In("@group_id", DbType.Int32, DbHelper.ToNullInt32(v.GroupId));
				db.In("@iqid", v.Iqid);
				db.In("@email", v.Email);
				db.In("@password", v.Password);
				return (db.ExecuteNonQuery() == 1);
			}
		}


		// ---


		public DbAccount DbFindByEmailAndPassword() {
			using (DbUtility db = new DbUtility("iqAccountFindByEmailPassword")) {
				db.In("@email", this.Email);
				db.In("@password", this.Password);
				return (DbAccount)db.Fill(this);
			}
		}
		
		public static DbAccount DbCreate(DbAccount v) {
			return (DbAccount)v.DbCreate();
		}

		public static DbAccount DbRead(DbAccount v) {
			using (DbUtility db = new DbUtility("iqAccountRead")) {
				db.In("@id", v.Id);
				return (DbAccount)db.Fill(new DbAccount());
			}
		}

		public static DbAccount DbRead(Int32 id) {
			using (DbUtility db = new DbUtility("iqAccountRead")) {
				db.In("@id", id);
				return (DbAccount)db.Fill(new DbAccount());
			}
		}

		public static DbAccount DbRead(byte[] creator) {
			using (DbUtility db = new DbUtility("iqAccountRead")) {
				db.In("@id", Convert.ToInt32(creator));
				return (DbAccount)db.Fill(new DbAccount());
			}
		}

		public static DbAccount DbUpdate(DbAccount v) {
			using (DbUtility db = new DbUtility("iqAccountUpdate")) {
				db.In("@id", DbType.Int32, v.Id);
				db.In("@owner_account_id", DbType.Int32, DbHelper.ToNullInt32(v.OwnerAccountId));
				db.In("@group_id", DbType.Int32, DbHelper.ToNullInt32(v.GroupId));
				db.In("@iqid", v.Iqid);
				db.In("@email", v.Email);
				db.In("@password", v.Password);
				return (DbAccount)db.Fill(v);
			}
		}

		public static DbAccount DbDelete(DbAccount v) {
			using (DbUtility db = new DbUtility("iqAccountDelete")) {
				db.In("@id", v.Id);
				return (db.ExecuteNonQuery() == 1) ? v : null;
			}
		}

		public static DbAccount DbLookup(string email, string password) {
			using (DbUtility db = new DbUtility("iqAccountFindByEmailPassword")) {
				db.In("@email", email);
				db.In("@password", password);
				return (DbAccount)db.Fill(new DbAccount());
			}
		}

		public static DbAccount FindById(int id) {
			DbAccount a = new DbAccount();
			a.Id = id;
			return DbAccount.DbRead(a);
		}

		public static DbAccount FindByIqid(string iqid) {
			using (DbUtility db = new DbUtility("iqAccountFindByIqid")) {
				db.In("@iqid", iqid);
				return (DbAccount)db.Fill(new DbAccount());
			}
		}

		public static DbAccount FindByToken(string token) {
			using (DbUtility db = new DbUtility("iqAccountFindByToken")) {
				db.In("@token", token);
				return (DbAccount)db.Fill(new DbAccount());
			}
		}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public static System.Collections.Generic.ICollection<DbAccount> GetAllAccounts() {
			throw new System.NotImplementedException();
		}
	}
}