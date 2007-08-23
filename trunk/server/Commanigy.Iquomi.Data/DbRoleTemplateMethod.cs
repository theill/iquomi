#region Using directives

using System;
using System.Data;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "role_template_method" database table.
	/// </summary>
	[DataObject()]
	public class DbRoleTemplateMethod : RoleTemplateMethod, IDbObject<DbRoleTemplateMethod> {
		public DbRoleTemplateMethod() {
			;
		}
		
		#region IDbObject<DbRoleTemplateMethod> Members

		public DbRoleTemplateMethod DbCreate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateMethodCreate")) {
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@scope_id", this.ScopeId);
				try {
					return (db.ExecuteNonQuery() == 1) ? this : null;
				}
				catch (System.Data.Common.DbException dbe) {
					if (dbe.Message.StartsWith("Violation of PRIMARY KEY")) {
						return null;
					}

					throw;
				}
			}
		}

		public DbRoleTemplateMethod DbRead() {
			using (DbUtility db = new DbUtility("iqRoleTemplateMethodRead")) {
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@language_id", 1);
				return (DbRoleTemplateMethod)db.Fill(this);
			}
		}

		public DbRoleTemplateMethod DbUpdate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateMethodUpdate")) {
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@scope_id", this.ScopeId);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbRoleTemplateMethod DbDelete() {
			using (DbUtility db = new DbUtility("iqRoleTemplateMethodDelete")) {
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@method_type_id", this.MethodTypeId);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion
		
		public static DataTable DbListAll(int roleTemplateId, int languageId) {
			using (DbUtility db = new DbUtility("iqListAllRoleTemplateMethods")) {
				db.In("@role_template_id", roleTemplateId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}
	}
}