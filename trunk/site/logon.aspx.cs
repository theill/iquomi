#region using statements

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class LogOnPage : Commanigy.Iquomi.Web.WebPage {

		protected void Page_Load(object sender, System.EventArgs e) {
#if DEBUG
			if (Request["email"] != null && Request["password"] != null) {
				MD5 md5 = MD5.Create();
				md5.Initialize();

				UiAccount a = new UiAccount();
				a.Email = Request["email"];
				if (Request["NoHashing"] == null) {
					a.Password = Convert.ToBase64String(
						md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Request["password"]))
						);
				}
				else {
					a.Password = Request["password"];
				}
				md5.Clear();
				a.DbFindByEmailAndPassword();

				//a.MailAccountSetup();

				if (a.Id > 0) {
					a.Logon(true);
					this.Redirect("logon.success.aspx", null);
				}
			}
#endif
		}

		protected void btnLogOn_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			this.Redirect("logon.success.aspx", null);

			//(Page.Master.FindControl("XmlMenu") as Xml).Transform();
		}

		protected void CvLogOn_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args) {

			MD5 md5 = MD5.Create();
			md5.Initialize();

			UiAccount a = new UiAccount();
			a.Email = TxtEmail.Text;
			a.Password = Convert.ToBase64String(
				md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(TxtPassword.Text))
				);
			md5.Clear();
			a.DbFindByEmailAndPassword();

			if (a.Id > 0) {
				a.Logon(true);
			}

			args.IsValid = (a.Id > 0);
		}
	}
}