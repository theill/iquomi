#region Using directives

using System;
using System.Data;
using System.ComponentModel;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbRoleTemplateDescription : RoleTemplateDescription, IDbObject<DbRoleTemplateDescription> {
		public DbRoleTemplateDescription() {
			;
		}
		
		#region IDbObject Members

		public DbRoleTemplateDescription DbCreate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateDescriptionCreate")) {
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@language_id", this.LanguageId);
				db.In("@description", this.Description);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbRoleTemplateDescription DbRead() {
			throw new NotImplementedException();
		}

		public DbRoleTemplateDescription DbUpdate() {
			using (DbUtility db = new DbUtility("iqRoleTemplateDescriptionUpdate")) {
				db.In("@role_template_id", this.RoleTemplateId);
				db.In("@language_id", this.LanguageId);
				db.In("@description", this.Description);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbRoleTemplateDescription DbDelete() {
			throw new NotImplementedException();
		}

		#endregion
	}
}