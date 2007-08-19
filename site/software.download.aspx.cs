#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for SoftwareDownloadPage.
	/// </summary>
	/// <author>pt</author>
	public partial class SoftwareDownloadPage : Commanigy.Iquomi.Web.WebPage {

		private void Page_Load(object sender, System.EventArgs e) {
			DataTable dt = new DataTable();
			dt.Columns.Add("Name");
			dt.Columns.Add("Platform");
			dt.Columns.Add("Size");
			dt.Columns.Add("LastWriteTimeUtc");

			DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/files"));
			FileInfo[] files = di.GetFiles();
			foreach (FileInfo f in files) {
				if (f.Extension != ".msi") {
					continue;
				}

				DataRow dr = dt.NewRow();
				dr["Name"] = f.Name;
				dr["Platform"] = "Windows";
				dr["Size"] = Commanigy.Iquomi.Ui.DbUiHelper.ToFileSize(f.Length);
				dr["LastWriteTimeUtc"] = f.LastWriteTimeUtc;
				dt.Rows.Add(dr);
			}

			GridView1.DataSource = dt;
			GridView1.DataBind();
		}
	}
}