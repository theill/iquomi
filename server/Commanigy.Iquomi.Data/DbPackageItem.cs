#region Using directives

using System.Data;
using System.ComponentModel;

using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbPackageItem : PackageItem, IDbObject<DbPackageItem> {
		
		public DbPackageItem() {
			;
		}

		#region IDbObject<DbPackageItem> Members

		public DbPackageItem DbCreate() {
			using (DbUtility db = new DbUtility("iqPackageItemCreate")) {
				db.In("@package_id", this.PackageId);
				db.In("@name", this.Name);
				db.In("@type", this.Type);
				db.In("@size", this.Size);
				db.In("@data", DbType.Binary, this.Data);
				this.Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbPackageItem DbRead() {
			throw new System.NotImplementedException();
		}

		public DbPackageItem DbUpdate() {
			using (DbUtility db = new DbUtility("iqPackageItemUpdate")) {
				db.In("@id", this.Id);
				db.In("@package_id", this.PackageId);
				db.In("@name", this.Name);
				db.In("@type", this.Type);
				db.In("@size", this.Size);
				db.In("@data", DbType.Binary, this.Data);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbPackageItem DbDelete() {
			using (DbUtility db = new DbUtility("iqPackageItemDelete")) {
				db.In("@id", this.Id);
				if (db.ExecuteNonQuery() > 0) {
					this.Id = 0;
				}

				return this;
			}
		}

		#endregion

		public object DbRead(int authorId) {
			using (DbUtility db = new DbUtility("iqPackageItemRead")) {
				db.In("@id", this.Id);
				db.In("@author_id", authorId);
				return db.Fill(this);
			}
		}
		
		public object DbFindAll() {
			return this.DbFindAll(false);
		}

		public DataTable DbFindAll(bool includeBinary) {
			using (DbUtility db = new DbUtility(!includeBinary ? "iqPackageItemFindAllPartial" : "iqPackageItemFindAll")) {
				db.In("@package_id", this.PackageId);
				return db.GetDataTable();
			}
		}

		public static DataTable DbFindAllByPackage(int packageId) {
			using (DbUtility db = new DbUtility("iqPackageItemFindAllPartial")) {
				db.In("@package_id", packageId);
				return db.GetDataTable();
			}
		}

		public static DataTable DbFindAllSupportedTypes() {
			DataTable dt = new DataTable();
			dt.Columns.Add("Id");
			dt.Columns.Add("Type");
			dt.Rows.Add(new object[] { "text/xml", "Configuration File"});
			dt.Rows.Add(new object[] { "text/xsd", "Structure File"});
			dt.Rows.Add(new object[] { "text/xsl", "Transformation File"});
			dt.Rows.Add(new object[] { "text/plain", "Plain Text File"});
			dt.Rows.Add(new object[] { "application/octet-stream", "Binary File"});
			dt.Rows.Add(new object[] { "application/dll", "Binary File"});
			dt.Rows.Add(new object[] { "image/gif", "GIF Graphics File"});
			dt.Rows.Add(new object[] { "image/jpg", "JPG Graphics File"});
			dt.Rows.Add(new object[] { "image/x-png", "PNG Graphics File"});
			dt.Rows.Add(new object[] { "application/x-zip-compressed", "ZIP Compressed File"});
//			dt.Rows.Add(new object[] { "pdf", "PDF"});
			return dt;
		}
		
	}

}