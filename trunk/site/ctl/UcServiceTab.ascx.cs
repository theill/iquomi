#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcServiceTab : System.Web.UI.UserControl {
		protected DbService service;

		public DbService DataItem {
			get {
				return service;
			}

			set {
				service = value;
				Setup();
			}
		}

		private void Setup() {
			if (service == null) {
				return;
			}

			UrlIcon.ImageUrl = !string.IsNullOrEmpty(service.UrlIcon) ? service.UrlIcon : UrlIcon.ImageUrl;
			State.Text = new Commanigy.Iquomi.Ui.State(service.State).ToString();
			Description.Text = "Short description of service.";

			LnkServiceName.Text = string.Format("{0} v{1}", service.Name, service.Version);

			UiAuthor author = UiAccount.Get().Author;
			if (author != null && service.AuthorId == author.Id) {
				// the author of this service is allowed to edit the fields
				// so we should allow a direct link to an 'edit service' 
				// page.
				LnkServiceName.NavigateUrl = "~/" + (this.Page as WebPage).Link("service.update.aspx", new object[] { service.Id });
//				this.LnkManageService.NavigateUrl = "~/" + (this.Page as WebPage).Link("service.update.aspx", new object[] { service.Id });
//				this.Authoring.Visible = true;
			}
			else {
				LnkServiceName.NavigateUrl = "~/" + (this.Page as WebPage).Link("account.report.service.aspx", new object[] { service.Id });
			}
		}
	}
}