#region Using directives

using System.Data;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbServiceMethod : ServiceMethod, IDbObject<DbServiceMethod> {

		public DbServiceMethod() {
			;
		}

		#region IDbObject<DbServiceMethod> Members

		public DbServiceMethod DbCreate() {
			using (DbUtility db = new DbUtility("iqServiceMethodCreate")) {
				db.In("@service_id", this.ServiceId);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@name", this.Name);
				db.In("@select", this.Select);
				db.In("@script", DbType.String, DbHelper.ToNullString(this.Script));
				db.In("@script_url", this.ScriptUrl);
				Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbServiceMethod DbRead() {
			using (DbUtility db = new DbUtility("iqServiceMethodRead")) {
				db.In("@id", this.Id);
				return (DbServiceMethod)db.Fill(this);
			}
		}

		public DbServiceMethod DbUpdate() {
			using (DbUtility db = new DbUtility("iqServiceMethodUpdate")) {
				db.In("@id", this.Id);
				db.In("@service_id", this.ServiceId);
				db.In("@name", this.Name);
				db.In("@select", this.Select);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@script", DbType.String, DbHelper.ToNullString(this.Script));
				db.In("@script_url", this.ScriptUrl);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbServiceMethod DbDelete() {
			using (DbUtility db = new DbUtility("iqServiceMethodDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion

		#region ObjectDataSource methods

		public static DbServiceMethod DbCreate(DbServiceMethod v) {
			return v.DbCreate();
		}

		public static DbServiceMethod DbRead(int id) {
			DbServiceMethod a = new DbServiceMethod();
			a.Id = id;
			return a.DbRead();
		}

		public static DbServiceMethod DbUpdate(DbServiceMethod v) {
			return v.DbUpdate();
		}

		#endregion


		public static DataTable DbFindAllByService(int serviceId) {
			using (DbUtility db = new DbUtility("iqListAllServiceMethodsByService")) {
				db.In("@service_id", serviceId);
				return db.GetDataTable();
			}
		}

		public DbServiceMethod DbFindByName() {
			using (DbUtility db = new DbUtility("iqServiceMethodFindByName")) {
				db.In("@service_id", this.ServiceId);
				db.In("@name", this.Name);
				return (DbServiceMethod)db.Fill(this);
			}
		}

	}
}