#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for PackageItemsPage.
	/// </summary>
	public partial class PackageItemsPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected DbPackage package;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			package = new DbPackage();
			package.Id = GetInt32("Package.Id");
			package.DbRead();
		}


		protected void Page_Load(object sender, System.EventArgs e) {
			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();

			UcPackageTab.Service = DbService.DbRead(package.ServiceId);
			UcPackageTab.Package = package;
		}

		protected void Add_Click(object sender, System.EventArgs e) {
			this.Redirect("package.item.create.aspx", new object[] { package.Id });
		}

		protected void Delete_Click(object sender, System.EventArgs e) {
			foreach (GridViewRow r in GridView1.Rows) {
				CheckBox a = (r.FindControl("RowChecked") as CheckBox);
				if (a.Checked) {
					string rowId = (r.FindControl("RowId") as Literal).Text;
					int id = Convert.ToInt32(rowId);

					DbPackageItem b = new DbPackageItem();
					b.Id = id;
					b.DbDelete();
				}
			}

			GridView1.DataBind();
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			e.InputParameters["packageId"] = package.Id;
		}

	}
}