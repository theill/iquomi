#region Using directives

using System;
using System.ComponentModel;
using System.Data;

using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "method_type" database table.
	/// </summary>
	[DataObject()]
	public class DbMethodType : MethodType, IDbObject<DbMethodType> {

		// Default ids for methods created in database
		public enum DbIdentifier {
			Insert	= 0x01,
			Replace	= 0x02,
			Delete	= 0x03,
			Update	= 0x04,
			Query	= 0x05,
			Listen	= 0x06
		}

		public DbMethodType() {
			;
		}

		#region IDbObject<DbMethodType> Members

		public DbMethodType DbCreate() {
			throw new NotImplementedException();
		}

		public DbMethodType DbRead() {
			using (DbUtility db = new DbUtility("iqMethodTypeRead")) {
				db.In("@id", this.Id);
				return (DbMethodType)db.Fill(this);
			}
		}

		public DbMethodType DbUpdate() {
			throw new NotImplementedException();
		}

		public DbMethodType DbDelete() {
			throw new NotImplementedException();
		}

		#endregion

		public static Array DbFindAll() {
			using (DbUtility db = new DbUtility("iqMethodTypeFindAll")) {
				return db.FillAll(typeof(DbMethodType));
			}
		}
		
		public static DataTable DbFindAllAsTable() {
			using (DbUtility db = new DbUtility("iqMethodTypeFindAll")) {
				return db.GetDataTable();
			}
		}

		public static int GetIdForName(string name) {
			switch (name.ToLower()) {
				case MethodType.Insert:
					return (int)DbIdentifier.Insert;
				case MethodType.Replace:
					return (int)DbIdentifier.Replace;
				case MethodType.Delete:
					return (int)DbIdentifier.Delete;
				case MethodType.Update:
					return (int)DbIdentifier.Update;
				case MethodType.Query:
					return (int)DbIdentifier.Query;
				case MethodType.Listen:
					return (int)DbIdentifier.Listen;
			}

			return 0;
		}

		public static string GetNameForId(int id) {
			switch (id) {
				case (int)DbIdentifier.Insert:
					return Enum.GetName(typeof(DbIdentifier), DbIdentifier.Insert);
				case (int)DbIdentifier.Replace:
					return Enum.GetName(typeof(DbIdentifier), DbIdentifier.Replace);
				case (int)DbIdentifier.Delete:
					return Enum.GetName(typeof(DbIdentifier), DbIdentifier.Delete);
				case (int)DbIdentifier.Update:
					return Enum.GetName(typeof(DbIdentifier), DbIdentifier.Update);
				case (int)DbIdentifier.Query:
					return Enum.GetName(typeof(DbIdentifier), DbIdentifier.Query);
				case (int)DbIdentifier.Listen:
					return Enum.GetName(typeof(DbIdentifier), DbIdentifier.Listen);
			}

			return "Custom" + id.ToString();
		}

//		public static int GetIdForType(BaseRequestType request) {
//			if (typeof(InsertRequestType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Insert;
//			} else if (typeof(ReplaceRequestType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Replace;
//			} else if (typeof(DeleteRequestType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Delete;
//			} else if (typeof(UpdateRequestType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Update;
//			} else if (typeof(XpQueryType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Query;
//			} else if (typeof(ChangeQueryType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Query;
//			} else if (typeof(QueryRequestType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Query;
//			} else if (typeof(ListenRequestType).IsInstanceOfType(request)) {
//				return (int)DbMethodType.DbIdentifier.Listen;
//			}
//
//			return 0;
//		}

	}
}