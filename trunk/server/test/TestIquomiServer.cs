using System;
using System.Data;
using System.IO;
using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;
//using Commanigy.Iquomi.Utility;

namespace ServerTester {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestIquomiServer {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			
			TestIquomiServer test = new TestIquomiServer();
//			test.TestPackageAssembly();
//			test.TestServiceFindAll();
//			test.TestWSAdminGetSubscriptionServices();
//			test.TestWSAdminDownloadLatestPackage();
//			test.TestServiceCreate();
//			test.TestCreate();
//			test.TestRead();
//			test.TestUpdate();
//			test.TestDelete();

			Console.WriteLine("\n\n\n<return> to quit");
			Console.ReadLine();
		}

		public bool TestServiceCreate() {
			DbService srv = new DbService();
			srv.AuthorId = 1;
			srv.Name = "test1";
			srv.Xsd = "<test:ok />";
			try {
				srv.DbCreate();
			}
			catch (Exception e) {
				Console.Out.Write(e.ToString());
			}

			return true;
		}

		public bool TestServiceFindAll() {
			try {
				DbService.DbFindAllByAuthor(1, 1);
			}
			catch (Exception e) {
				Console.Out.Write(e.ToString());
			}

			return true;
		}
/*
		public bool TestCreate() {
			Item item = new Item();
			item.StoreObject = "<note><title>new note created at " + DateTime.Now + "</title><description>fjdklsfjdskl</description></note>";
			item.StorePath = "//notes";

			DbService service = new DbService();
			service.Id = 1;
			DbAccount account = new DbAccount();
			account.Id = 1;
			account.IpAddress = "123.123.123.123";
			item = DataStore.GetInstance().Create(
				service,
				account,
				item
				);
			Console.WriteLine("new item created with id = " + item.StoreId);

			return true;
		}

		public bool TestRead() {
			Item item = new Item();
//			item.StorePath = "//notes";
			item.StoreId = "20229cb2-9276-4629-8c1f-976129a63fa9";

			DbService service = new DbService();
			service.Id = 1;
			DbAccount account = new DbAccount();
			account.Id = 1;
			account.IpAddress = "123.123.123.123";
			item = DataStore.GetInstance().Read(
				service,
				account,
				item
				);
			if (item != null) {
				Console.WriteLine("found item = " + item.StoreObject);
			} else {
				Console.WriteLine("no item found");
			}

			return true;
		}

		public bool TestUpdate() {
			Item item = new Item();
			item.StorePath = "//notes/note";
//			item.StoreId = "20229cb2-9276-4629-8c1f-976129a63fa9";
			item.StoreObject = "<note id=\"20229cb2-9276-4629-8c1f-976129a63fa9\"><title>updated note</title><description>this note has been updated at " + DateTime.Now + "</description></note>";

			DbService service = new DbService();
			service.Id = 1;
			DbAccount account = new DbAccount();
			account.Id = 1;
			account.IpAddress = "123.123.123.123";
			item = DataStore.GetInstance().Update(
				service,
				account,
				item
				);
			if (item != null) {
				Console.WriteLine("updated to = " + item.StoreObject);
			} else {
				Console.WriteLine("no update");
			}

			return true;
		}

		public bool TestDelete() {
			Item item = new Item();
			//			item.StorePath = "//notes";
			//item.StoreId = "20229cb2-9276-4629-8c1f-976129a63fa9";
			item.StoreId = "9e34c2fb-7327-4027-bf83-f0a849baa27d";

			DbService service = new DbService();
			service.Id = 1;
			DbAccount account = new DbAccount();
			account.Id = 1;
			account.IpAddress = "123.123.123.123";
			bool deleted = DataStore.GetInstance().Delete(
				service,
				account,
				item
				);
			if (deleted) {
				Console.WriteLine("deleted");
			} else {
				Console.WriteLine("nothing deleted");
			}

			return true;
		}
*/
/*
		public bool TestWSAdminGetSubscriptionServices() {
			DbUtility db = new DbUtility();
			db.Cmd("iqSubscriptionServices", CommandType.StoredProcedure);
			db.In("@account_id", DbType.Int32, 1);
			db.In("@language_id", DbType.Int32, 1);

//			object[] x = db.FillAll(typeof(Service));
//			Service[] y = new Service[x.Length];
//			System.Array.Copy(x, y, x.Length);
			return true;
		}
*/
		public bool TestWSAdminDownloadLatestPackage() {
			DbUtility db = new DbUtility();
			db.Cmd("iqFindLatestPackage", CommandType.StoredProcedure);
			db.In("@account_id", DbType.Int32, 1);
			db.In("@service_name", DbType.String, "BookmarkSync");
			db.In("@platform_id", DbType.Int32, DbPlatform.ToId("Any"));
			
			Package pkg = (Package)db.Fill(new Package());
			if (pkg == null) {
				return false;
			}
			
			DbPackageItem dbpkgi = new DbPackageItem();
			dbpkgi.PackageId = pkg.Id;
			DataTable dt = (DataTable)dbpkgi.DbFindAll(true);

			pkg.Items = new PackageItem[dt.Rows.Count];
			for (int i = 0; i < dt.Rows.Count; i++) {
				DataRow dr = dt.Rows[i];

				PackageItem pkgi = new PackageItem();
				pkgi.Id = (int)dr["PackageItemId"];
				pkgi.Name = (string)dr["PackageItemName"];
				pkgi.PackageId = pkg.Id;
				pkgi.Size = (int)dr["PackageItemSize"];
				pkgi.Data = (byte[])dr["PackageItemData"];

				pkg.Items[i] = pkgi;
			}

			return pkg != null;
		}

//		public bool TestPackageAssembly() {
//			FileStream fs = File.OpenRead(@"c:\svend.txt");
//			byte[] bytes = new byte[fs.Length];
//			fs.Read(bytes, 0, bytes.Length);
//			DbPackageItem[] x = new DbPackageItem[1];
//			x[0] = new DbPackageItem();
//			x[0].Data = bytes;
//
//			PackageAssembly pa = new PackageAssembly(x);
//			pa.CreateAssembly();
//			return true;
//		}

	}
}
