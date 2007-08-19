#region Using directives
using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Commanigy.Iquomi.Data;
#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Summary description for MyServicesPage.
	/// </summary>
	public partial class MyServicesPage : Commanigy.Iquomi.Web.WebPage {
		protected void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				if (UiAccount.Get().Author != null) {
//					// load author services if available for account
//					DbService service = new DbService();
//					service.AuthorId = UiAccount.Get().Author.Id;
//					MyServices.DataSource = service.DbFindAllByAuthorId();
//					MyServices.DataBind();
				}
				else {
					// no "author" setup for this account. ask user for info
					// so it's possible to create an author entry and allow
					// ability to setup new services themselves
					this.Redirect("account.provider.setup.aspx", new object[] { HttpContext.Current.Request.RawUrl });
				}
			}
		}
	}
}