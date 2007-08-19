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

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// </summary>
	public partial class AccountReportServicePage : Commanigy.Iquomi.Web.WebPage {
		protected UiService service;

		protected void Page_Load(object sender, System.EventArgs e) {
			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.DbRead();
//			UiService.Set(service);

			SiteMapNode n = SiteMap.CurrentNode;

			n.Title = service.Name ?? _("(unknown)");
			n.Url = this.Request.Url.ToString();

			ServiceTab.DataItem = service;
		}
	}
}
