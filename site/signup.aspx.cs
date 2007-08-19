#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class SignUpPage : Commanigy.Iquomi.Web.WebPage {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		protected void btnSubmit_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

#if DEBUG
			if (Request.UserHostAddress != "80.63.233.183" && Request.UserHostAddress != "127.0.0.1") {
				Notification.Failed("You are not allowed to sign up for an account");
				return;
			}
#endif

			MD5 md5 = MD5.Create();
			md5.Initialize();
			
			// create new account in system
			UiAccount a = new UiAccount();
			a.Iqid = Email.Text;
			a.Email = Email.Text;
			a.Password = Convert.ToBase64String(
				md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Password.Text))
				);

			md5.Clear();

			try {
				a.DbCreate();
			}
			catch (System.Data.Common.DbException x) {
				log.Debug("Cannot create account", x);

				if (x.Message.StartsWith("Violation of UNIQUE KEY constraint 'IX_account'")) {
					log.Debug("Account " + a.Iqid + " already exists");
					Notification.Failed(_("You cannot create a new account with the entered information"));
				}
			}

			if (a.Id > 0) {
				a.Logon(true);
				Redirect("signup.success.aspx", null);
			}
		}
	}
}