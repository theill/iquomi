#region Using directives
using System;
using System.Data;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;
using System.ComponentModel;
#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Summary description for DbRoleTemplate.
	/// </summary>
	[DataObject()]
	public class DbRoleTemplate : RoleTemplate, IDbObject<DbRoleTemplate> {
		public DbRoleTemplate() {
			;
		}

		#region IDbObject Members

		public DbRoleTemplate DbCreate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateCreate")) {
				db.In("@service_id", this.ServiceId);
				db.In("@name", this.Name);
				db.In("@priority", this.Priority);
				Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbRoleTemplate DbRead() {
			using (DbUtility db = new DbUtility("iqRoleTemplateRead")) {
				db.In("@id", this.Id);
				return (DbRoleTemplate)db.Fill(this);
			}
		}

		public DbRoleTemplate DbUpdate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateUpdate")) {
				db.In("@id", Id);
				db.In("@name", Name);
				db.In("@priority", Priority);
				return (DbRoleTemplate)db.Fill(this);
			}
		}

		public DbRoleTemplate DbDelete() {
			using (DbUtility db = new DbUtility("iqRoleTemplateDelete")) {
				db.In("@id", Id);
				if (db.ExecuteNonQuery() > 0) {
					this.Id = 0;
				}

				return this;
			}
		}

		#endregion

		public bool DbInsertDescription(int languageId, string description) {
			using (DbUtility db = new DbUtility("iqRoleTemplateDescriptionCreate")) {
				db.In("@role_template_id", this.Id);
				db.In("@language_id", languageId);
				db.In("@description", description);
				return (db.ExecuteNonQuery() == 1);
			}
		}

		public bool DbUpdateDescription(int languageId, string description) {
			using (DbUtility db = new DbUtility("iqRoleTemplateDescriptionUpdate")) {
				db.In("@role_template_id", this.Id);
				db.In("@language_id", languageId);
				db.In("@description", description);
				return (db.ExecuteNonQuery() == 1);
			}
		}

		public DbScope DbFindScopeByMethodTypeId(int methodTypeId) {
			using (DbUtility db = new DbUtility("iqScopeLookupByMethodType")) {
				db.In("@role_template_id", this.Id);
				db.In("@method_type_id", methodTypeId);
				DbScope scope = (DbScope)db.Fill(new DbScope());
				scope.DbFindAllShapes();
				return scope;
			}
		}

		public static DbRoleTemplate[] DbFindAllByService(int serviceId) {
			using (DbUtility db = new DbUtility("iqRoleTemplateFindAllByService")) {
				db.In("@service_id", serviceId);
				return (DbRoleTemplate[])db.FillAll(typeof(DbRoleTemplate));
			}
		}

		public DbRoleTemplateMethod[] DbFindAllRoleTemplateMethodsByRoleTemplate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateMethodFindAllByRoleTemplate")) {
				db.In("@role_template_id", this.Id);
				return (DbRoleTemplateMethod[])db.FillAll(typeof(DbRoleTemplateMethod));
			}
		}

		public static DataTable DbListAllRoleTemplatesByService(int serviceId, int languageId) {
			using (DbUtility db = new DbUtility("iqListAllRoleTemplatesByService")) {
				db.In("@service_id", serviceId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}
	}
}