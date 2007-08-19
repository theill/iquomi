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

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceChargeCreatePage : Commanigy.Iquomi.Web.WebPage {
		private DbService service;

		protected void Page_Load(object sender, System.EventArgs e) {
			service = new DbService();
			service.Id = GetInt32("Service.Id");
			service.DbRead();
			
			ServiceTab.DataItem = service;

			if (!Page.IsPostBack) {
				ServiceCharge.Service = service;
			}
		}

		protected void btnCreate_Click(object sender, System.EventArgs e) {
			if (!this.IsValid) {
				return;
			}

			DbServiceCharge a = new DbServiceCharge();
			a.ServiceId = service.Id;
			a.SchemaType = ServiceCharge.SchemaType;
			a.Script = ServiceCharge.Script;
			a.MethodTypeId = ServiceCharge.MethodTypeId;
			a.Price = ServiceCharge.Price;
			a.ChargeUnitId = ServiceCharge.ChargeUnitId;
			a.DbCreate();

			Notification.AssertSuccess(a.Id > 0);
		}
		
	}
}