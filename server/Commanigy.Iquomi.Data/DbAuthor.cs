#region Using directives

using System;
using System.ComponentModel;
using System.Data;

using log4net;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "author" database table.
	/// </summary>
	[DataObject()]
	public class DbAuthor : IDbObject<DbAuthor> {
		public int Id;
		public int AccountId;
		public string Name;
		
		public DbAuthor() {
			;
		}
	
		#region IDbObject Members

		public DbAuthor DbCreate() {
			using (DbUtility db = new DbUtility("iqAuthorCreate")) {
				db.In("@account_id", this.AccountId);
				db.In("@name", this.Name);
				this.Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbAuthor DbRead() {
			using (DbUtility db = new DbUtility("iqAuthorRead")) {
				db.In("@id", this.Id);
				return (DbAuthor)db.Fill(this);
			}
		}

		public DbAuthor DbUpdate() {
			throw new NotImplementedException();
		}

		public DbAuthor DbDelete() {
			using (DbUtility db = new DbUtility("iqAuthorDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}
		
		#endregion

		public object DbLookup() {
			using (DbUtility db = new DbUtility("iqAuthorLookup")) {
				db.In("@account_id", this.AccountId);
				return db.Fill(this);
			}
		}
		
		public DataTable DbFindAllPackages() {
			using (DbUtility db = new DbUtility("iqAuthorFindAllPackages")) {
				db.In("@author_id", this.Id);
				return db.GetDataTable();
			}
		}
		
	}
}