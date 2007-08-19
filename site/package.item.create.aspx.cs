#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class PackageItemCreatePage : Commanigy.Iquomi.Web.WebPage {
		private DbService service;
		private DbPackage package_;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			package_ = DbPackage.DbRead(GetInt32("Package.Id"), Profile.AuthorId, Profile.LanguageId);

			service = DbService.DbRead(package_.ServiceId, Profile.AuthorId, Profile.LanguageId);
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			UcPackageTab.Package = package_;
			UcPackageTab.Service = service;
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}
			
			DbPackageItem it = new DbPackageItem();
			it.PackageId = package_.Id;
			
			if (PackageItem.Upload.PostedFile != null) {
				log.Debug("File was posted with a size of " + PackageItem.Upload.PostedFile.ContentLength);
				it.Name = System.IO.Path.GetFileName(PackageItem.Upload.PostedFile.FileName);
				it.Size = PackageItem.Upload.PostedFile.ContentLength;
				it.Type = PackageItem.Upload.PostedFile.ContentType;

				byte[] file = new byte[PackageItem.Upload.PostedFile.ContentLength];
				PackageItem.Upload.PostedFile.InputStream.Read(file, 0, file.Length);
				it.Data = file;
			} else {
				it.Name = PackageItem.Name;
				it.Size = PackageItem.Size;
				it.Type = PackageItem.Type;
				using (System.IO.MemoryStream ms = new System.IO.MemoryStream()) {
					System.IO.StreamWriter sw = new System.IO.StreamWriter(ms);
					sw.Write(PackageItem.Data);
					sw.Close();
					it.Data = ms.ToArray();
				}
			}

			log.Debug("Creating package_item with package_id: " + it.PackageId);
			it.DbCreate();
			
			if (it.Id > 0) {
				this.Redirect("package.items.aspx", new object[] { package_.Id });
			}
		}
		
	}
}