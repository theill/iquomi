using System;
using System.Data;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbScope : Scope, IDbObject<DbScope> {

		// Default base targets for scope
		public static string T		= "T";
		public static string NIL	= "NIL";
		
		// Default ids for scopes created in database
		public static int ID_T		= 0x01;
		public static int ID_NIL	= 0x02;

		public DbScope() {
			;
		}

		#region IDbObject<DbScope> Members

		public DbScope DbCreate() {
			using (DbUtility db = new DbUtility("iqScopeCreate")) {
				db.In("@language_id", this.LanguageId);
				db.In("@name", this.Name);
				db.In("@base", this.Base);
				Id = (int)db.ExecuteScalar();
				return (Id > 0) ? this : null;
			}
		}

		public DbScope DbRead() {
			using (DbUtility db = new DbUtility("iqScopeRead")) {
				db.In("@id", this.Id);
				return (DbScope)db.Fill(this);
			}
		}

		public DbScope DbUpdate() {
			using (DbUtility db = new DbUtility("iqScopeUpdate")) {
				db.In("@id", this.Id);
				db.In("@language_id", this.LanguageId);
				db.In("@name", this.Name);
				db.In("@base", this.Base);
				return (DbScope)db.Fill(this);
			}
		}

		public DbScope DbDelete() {
			using (DbUtility db = new DbUtility("iqScopeDelete")) {
				db.In("@id", DbType.Int32, Id);
				if (db.ExecuteNonQuery() == 1) {
					Id = 0;
					return this;
				}

				return null;
			}
		}

		#endregion

		public DbShape[] DbFindAllShapes() {
			DbShape shape = new DbShape();
			shape.ScopeId = this.Id;
			this.Shapes = (DbShape[])shape.DbFindAll();
			return (DbShape[])this.Shapes;
		}

		public static DataTable DbListAllShapesByScope(int scopeId) {
			using (DbUtility db = new DbUtility("iqShapeFindAllByScope")) {
				db.In("@scope_id", scopeId);
				return db.GetDataTable();
			}
		}

	}
}