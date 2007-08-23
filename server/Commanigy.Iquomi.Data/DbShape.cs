#region Using directives

using System;
using System.Data;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbShape : Shape, IDbObject<DbShape> {
		// Default base targets for scope
		public static string INCLUDE = "I";
		public static string EXCLUDE = "E";

		public DbShape() {
			;
		}

		#region IDbObject Members

		public DbShape DbCreate() {
			using (DbUtility db = new DbUtility("iqShapeCreate")) {
				db.In("@scope_id", this.ScopeId);
				db.In("@select", this.Select);
				db.In("@type", this.Type);
				Id = (int)db.ExecuteScalar();
				return (Id > 0) ? this : null;
			}
		}

		public DbShape DbRead() {
			using (DbUtility db = new DbUtility("iqShapeRead")) {
				db.In("@id", this.Id);
				return (DbShape)db.Fill(this);
			}
		}

		public DbShape DbUpdate() {
			using (DbUtility db = new DbUtility("iqShapeUpdate")) {
				db.In("@id", this.Id);
				db.In("@scope_id", this.ScopeId);
				db.In("@select", this.Select);
				db.In("@type", this.Type);
				return (DbShape)db.Fill(this);
			}
		}

		public DbShape DbDelete() {
			using (DbUtility db = new DbUtility("iqShapeDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion

		public DbShape[] DbFindAll() {
			using (DbUtility db = new DbUtility("iqShapeFindAllByScope")) {
				db.In("@scope_id", this.ScopeId);
				return (DbShape[])db.FillAll(typeof(DbShape));
			}
		}
	}
}