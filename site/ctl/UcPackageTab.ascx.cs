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
	public partial class UcPackageTab : System.Web.UI.UserControl {

		protected DbService service;
		protected DbPackage package;

		public DbService Service {
			get {
				return service;
			}

			set {
				service = value;
			}
		}

		public DbPackage Package {
			get {
				return package;
			}

			set {
				package = value;
			}
		}

		private void Page_Load(object sender, System.EventArgs e) {
			;
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);
			Setup();
		}

		private void Setup() {
			if (service == null || package == null) {
				LblPackageDescription.Text = "Unknown package";
				LblServiceDescription.Text = string.Empty;
				return;
			}

			LblPackageDescription.Text = string.Format("Package v{0} based on <b>{1}</b> v{2}",
				package.Version,
				service.Name,
				service.Version
				);

			ImgServiceUrlIcon.ImageUrl = service.UrlIcon;
			LblServiceState.Text = string.Format("Service is currently in state <b>{0}</b>", Commanigy.Iquomi.Ui.DbUiHelper.ToServiceState(service.State));
			LblServiceDescription.Text = "The description for this service is currently unknown.";
		}

	}
}