#region Using directives

using System;
using System.Data;
using System.IO;
using System.Reflection;

using log4net;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Summary description for DbPackage.
	/// </summary>
	[DataObject()]
	public class DbPackage : Package, IDbObject<DbPackage> {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public DbPackage() {
			;
		}

//		public byte[] CreateAssembly() {
//			
//			// NOT WORKING!!!!
//			
//			PackageAssembly pa = new PackageAssembly(Items);
//			Assembly a = pa.CreateAssembly();
//			
//			FileStream fs = File.OpenRead(a.FullName);
//			byte[] bytes = new byte[fs.Length];
//			fs.Read(bytes, 0, bytes.Length);
//			fs.Close();
//
//			return bytes;
//		}
//
//		public byte[] CreateZip() {
//			PackageZip pz = new PackageZip(Items);
//			return pz.Zip();
//		}

		public byte[] CreateArchive() {
			return null;
		}

		#region ObjectDataSource methods

		public static DbPackage DbCreate(DbPackage v) {
			using (DbUtility db = new DbUtility("iqPackageCreate")) {
				db.In("@service_id", v.ServiceId);
				db.In("@platform_id", v.PlatformId);
				db.In("@version", v.Version);
				db.In("@release_date", v.ReleaseDate);
				db.In("@state", v.State);
				v.Id = (int)db.ExecuteScalar();
				return v;
			}
		}

		public static DbPackage DbRead(Int32 id, Int32 authorId, Int32 languageId) {
			using (DbUtility db = new DbUtility("iqPackageRead")) {
				db.In("@id", id);
				return db.Fill<DbPackage>(new DbPackage());
			}
		}

		public static DbPackage DbUpdate(DbPackage v) {
			using (DbUtility db = new DbUtility("iqPackageUpdate")) {
				db.In("@id", v.Id);
				db.In("@service_id", v.ServiceId);
				db.In("@platform_id", v.PlatformId);
				db.In("@version", v.Version);
				db.In("@release_date", v.ReleaseDate);
				db.In("@state", v.State);
				if (db.ExecuteNonQuery() == 1) {
					return v;
				}

				throw new DataException("Package not updated");
			}
		}

		#endregion

		public static DbPackage DbRead(Int32 id) {
			DbPackage a = new DbPackage();
			a.Id = id;
			return a.DbRead();
		}

		#region IDbObject<DbPackage> Members

		public DbPackage DbCreate() {
			using (DbUtility db = new DbUtility("iqPackageCreate")) {
				db.In("@service_id", this.ServiceId);
				db.In("@platform_id", this.PlatformId);
				db.In("@version", this.Version);
				db.In("@release_date", this.ReleaseDate);
				db.In("@state", this.State);
				Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbPackage DbRead() {
			using (DbUtility db = new DbUtility("iqPackageRead")) {
				db.In("@id", Id);
				return (DbPackage)db.Fill(this);
			}
		}

		public DbPackage DbUpdate() {
			using (DbUtility db = new DbUtility("iqPackageUpdate")) {
				db.In("@id", this.Id);
				db.In("@service_id", this.ServiceId);
				db.In("@platform_id", this.PlatformId);
				db.In("@version", this.Version);
				db.In("@release_date", this.ReleaseDate);
				db.In("@state", this.State);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbPackage DbDelete() {
			using (DbUtility db = new DbUtility("iqPackageDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion
		
		public static DataTable DbFindAllByAuthorId(int authorId, int languageId) {
			using (DbUtility db = new DbUtility("iqPackageFindAllByAuthor")) {
				db.In("@author_id", authorId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}
	}
}