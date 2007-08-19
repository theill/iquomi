#region Using directives

using System;
using System.Data;
using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Summary description for DbRoleMap.
	/// </summary>
	[DataObject()]
	public class DbRoleMap : RoleMap, IDbObject<DbRoleMap> {
		public DbRoleMap() {
			;
		}

		#region IDbObject Members

		public DbRoleMap DbCreate() {
			using (DbUtility db = new DbUtility("iqRoleMapCreate")) {
				db.In("@service_id", DbType.Int32, ServiceId);
				db.In("@role_template_id", DbType.Int32, RoleTemplateId);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbRoleMap DbRead() {
			throw new NotImplementedException();
		}

		public DbRoleMap DbUpdate() {
			throw new NotImplementedException();
		}

		public DbRoleMap DbDelete() {
			throw new NotImplementedException();
		}

		#endregion
	}
}