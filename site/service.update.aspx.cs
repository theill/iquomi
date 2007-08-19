#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceUpdatePage : WebPage {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private void Page_Load(object sender, System.EventArgs e) {
			DbService service = DbService.DbRead(GetInt32("Service.Id"), Profile.AuthorId, Profile.LanguageId);

			ServiceTab.DataItem = service;
			Service.DataItem = service;

			SiteMapNode n = SiteMap.CurrentNode;
			n.Url = this.Request.Url.ToString();
		}

		public override void Notify(Exception e) {
			if (e != null) {
				Notification.Failed(e.Message);
				if (e.InnerException != null) {
					Notification.Description = e.InnerException.Message;
				}
			} else {
				Notification.AssertSuccess(true);
			}
		}
	}
}