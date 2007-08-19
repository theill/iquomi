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
	public partial class UcSubscriptionTab : System.Web.UI.UserControl {
		protected DbService service;
		protected DbSubscription subscription;

		public DbService Service {
			get {
				return service;
			}

			set {
				service = value;
			}
		}
		
		public DbSubscription Subscription {
			get {
				return subscription;
			}

			set {
				subscription = value;
			}
		}

		protected override void OnLoad(EventArgs e) {
			Setup();
		}

		private void Setup() {
			if (service == null && subscription != null) {
				service = DbService.DbRead(subscription.ServiceId);
			}

			if (service == null) {
				return;
			}

			UrlIcon.ImageUrl = !string.IsNullOrEmpty(service.UrlIcon) ? service.UrlIcon : UrlIcon.ImageUrl;
			Description.Text = "Short description of service.";

			LnkServiceName.Text = string.Format("{0} based on {1} v{2}", subscription.Name, service.Name, service.Version);

			LnkServiceName.NavigateUrl = "~/" + (this.Page as WebPage).Link("account.report.service.aspx", new object[] { service.Id });
		}
	}
}