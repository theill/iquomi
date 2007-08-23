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
	public class DbServiceScope : ServiceScope, IDbObject<DbServiceScope> {
		public DbServiceScope() {
			;
		}

		#region IDbObject<DbServiceScope> Members

		public DbServiceScope DbCreate() {
			using (DbUtility db = new DbUtility("iqServiceScopeCreate")) {
				db.In("@service_id", DbType.Int32, ServiceId);
				db.In("@scope_id", DbType.Int32, ScopeId);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbServiceScope DbRead() {
			throw new NotImplementedException();
		}

		public DbServiceScope DbUpdate() {
			throw new NotImplementedException();
		}

		public DbServiceScope DbDelete() {
			using (DbUtility db = new DbUtility("iqServiceScopeDelete")) {
				db.In("@service_id", DbType.Int32, ServiceId);
				db.In("@scope_id", DbType.Int32, ScopeId);
				if (db.ExecuteNonQuery() > 0) {
					return this;
				}

				return null;
			}
		}

		#endregion

		public DataTable DbFindAllForService() {
			using (DbUtility db = new DbUtility("iqListServiceScopes")) {
				db.In("@service_id", this.ServiceId);
				db.In("@language_id", DbType.String, 1);
				return db.GetDataTable();
			}
		}

		public static DbScope[] DbFindAllScopesByService(int serviceId) {
			using (DbUtility db = new DbUtility("iqScopeFindAllByService")) {
				db.In("@service_id", serviceId);
				return (DbScope[])db.FillAll(typeof(DbScope));
			}
		}
		
		public static DataTable DbListAllScopesByService(int serviceId, int languageId) {
			using (DbUtility db = new DbUtility("iqListAllScopesByService")) {
				db.In("@service_id", serviceId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}
	}
}