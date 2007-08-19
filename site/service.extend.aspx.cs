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
using System.Xml;
using System.Xml.Xsl;

using Commanigy.Iquomi.Data;

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceExtendPage : Commanigy.Iquomi.Web.WebPage {
		
		private void Page_Load(object sender, System.EventArgs e) {
			;
		}
		
		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}
		
//			DbService service = new DbService();
//			service.AuthorId = UiAccount.Get().Author.Id;
//			service.Name = Service.Name;
//			service.Version = Service.Version;
//			service.Xsd = Service.Xsd;
//			service.State = Ui.State.DESIGN;
//			service.DbCreate();
//
//			if (service.Id > 0) {
//				XmlDocument d = new XmlDocument();
//				d.Load(Server.MapPath("xml/standardRoleTemplates.xml"));
//				service.InsertStandardRoleTemplates(d.DocumentElement);
//
//				WorkFlow.GetInstance().GoNext("service.create.success");
//			}
		}
	}
}