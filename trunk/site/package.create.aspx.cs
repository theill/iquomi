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

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class PackageCreatePage : Commanigy.Iquomi.Web.WebPage {

		protected void Page_Load(object sender, System.EventArgs e) {
			this.OnPageSuccess += new PageSuccessHandler(PackageCreatePage_OnPageSuccess);
		}

		void PackageCreatePage_OnPageSuccess() {
			this.Redirect("packages.aspx", new object[0]);
			//this.Redirect("package.read.aspx", new object[] { package.Id });
		}

		public override void Notify(Exception e) {
			if (e != null) {
				Notification.Failed(e.Message);
				if (e.InnerException != null) {
					Notification.Description = e.InnerException.Message;
				}
			}
			else {
				Notification.AssertSuccess(true);
			}
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			//if (!this.IsValid) {
			//    return;
			//}
			
			//DbPackage it = new DbPackage();
			//it.ServiceId = Int32.Parse(Services.SelectedValue);
			//it.PlatformId = Int32.Parse(Platforms.SelectedValue);
			//it.Version = Version.Text;
			//it.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
			//it.State = DbPackage.StateNew;
			//it.DbCreate();
			
			//if (it.Id > 0) {
			//    this.Redirect("package.read.aspx", new object[] { it.Id });
			//}
		}
	}
}