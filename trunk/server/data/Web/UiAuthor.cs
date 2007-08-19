#region Using directives

using System;
using System.Data;
using System.Web;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public class UiAuthor : DbAuthor {
		public UiAuthor() {
			;
		}
		
		public static UiAuthor Get() {
			UiAccount account = UiAccount.Get();
			if (account != null && account.Author != null && account.Author.Id > 0) {
				return account.Author;
			}

			//WorkFlow.Instance.GoNext(
			//    "account.author_setup", 
			//    HttpUtility.UrlEncode(HttpContext.Current.Request.Path)
			//    );

			return null;
		}

	}
}