#region Using directives

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net.Mail;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public class UiAccount : DbAccount {
		private UiAuthor author;
		
		/// <summary>
		/// Property Author (Author)
		/// </summary>
		public UiAuthor Author {
			get {
				return this.author;
			}
			set {
				this.author = value;
			}
		}

		public int LanguageId {
			get {
				return 1;
			}
		}

		public UiAccount() {
			;
		}
		
		public UiAccount(DbAccount a) {
			this.Id = a.Id;
			this.OwnerAccountId = a.OwnerAccountId;
			this.GroupId = a.GroupId;
			this.Iqid = a.Iqid;
			this.Email = a.Email;
			this.Password = a.Password;
		}
		
		public static UiAccount Get() {
			UiAccount a = (UiAccount)HttpContext.Current.Session["account"];
			
			#region DEBUG
			/// TODO: Remove logon (debug) fallback
			//if (a == null || a.Id == 0) {
			//    a = new UiAccount(DbAccount.DbLookup(
			//        ConfigurationSettings.AppSettings["Debug.Username"].ToString(),
			//        ConfigurationSettings.AppSettings["Debug.Password"].ToString()
			//        ));

			//    if (a.Id > 0) {
			//        a.Logon();
			//    }
			//}
			#endregion

			if (a == null || a.Id == 0) {
				// read logon information from cookie if available
				HttpCookie cookie = HttpContext.Current.Request.Cookies["Iquomi"];
				if (cookie != null) {
					a = new UiAccount(DbAccount.DbLookup(cookie["LogonEmail"], cookie["LogonPassword"]));
					if (a.Id > 0) {
						a.Logon(true);
					}
				}
			}

//			if (a == null || a.Id == 0) {
//				// we do not have a valid account in session so we have to
//				// redirect user to our log on page
//				WorkFlow.GetInstance().GoNext("logon");
//				return null;
//			}
			
			return a;
		}

		public void Logon(bool storeCookie) {
			HttpContext ctx = HttpContext.Current;
			ctx.Profile["AccountId"] = this.Id;
			ctx.Profile["LanguageId"] = this.LanguageId;

			// lookup author if one is connected to this account
			UiAuthor author = new UiAuthor();
			author.AccountId = this.Id;
			if (author.DbLookup() != null && author.Id > 0) {
				this.Author = author;

				ctx.Profile["AuthorId"] = author.Id;
			}

			if (storeCookie) {
				// store cookie with logon information
				HttpCookie cookie = new HttpCookie("Iquomi");
				cookie.Values.Add("LogonEmail", this.Email);
				cookie.Values.Add("LogonPassword", this.Password);
				cookie.Expires = DateTime.Now.AddDays(14);
				ctx.Response.Cookies.Add(cookie);
			}

			ctx.Session["account"] = this;
		}

		public void Logoff(bool clearCookie) {
			HttpContext ctx = HttpContext.Current;
			ctx.Session.Abandon();

			if (clearCookie) {
				HttpCookie c = ctx.Request.Cookies["Iquomi"];
				if (c != null) {
					c.Expires = DateTime.Now;
					ctx.Response.Cookies.Set(c);
				}
			}

			ctx.Session["account"] = null;
		}

		public void MailAccountSetup() {
			SmtpClient smtp = new SmtpClient();
			smtp.Send("info@iquomi.com", this.Email, "Account setup", "Thanks for setting up your account");
		}
	}
}