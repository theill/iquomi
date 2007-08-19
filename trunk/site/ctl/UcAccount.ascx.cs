#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Utils;
using Commanigy.Iquomi.Api;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcAccount : System.Web.UI.UserControl {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		protected Api.Account dataEntity;

		public FormView GetView() {
			return this.form;
		}

		private void Page_Load(object sender, System.EventArgs e) {
			if (Page.IsPostBack) {
				dataEntity = (Api.Account)ViewState["dataEntity"];
			}
		}

		protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e) {
			dataEntity = (Api.Account)e.ReturnValue;
			
			ViewState["dataEntity"] = dataEntity;
			
			log.Debug("Loaded " + dataEntity + " (email=" + dataEntity.Email + ") into view state");
		}

		protected void ObjectSource_Updating(object sender, ObjectDataSourceMethodEventArgs e) {
			log.Debug("ObjectSource_Updating " + dataEntity + "...");

			Account a = e.InputParameters[0] as Account;
			a.Id = dataEntity.Id;
			a.OwnerAccountId = dataEntity.OwnerAccountId;
			a.GroupId = dataEntity.GroupId;

			MD5 md5 = MD5.Create();
			md5.Initialize();

			a.Password = Convert.ToBase64String(
				md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(a.Password))
				);
			md5.Clear();
		}

		protected void ObjectSource_Updated(object sender, ObjectDataSourceStatusEventArgs e) {
			log.Debug("ObjectSource_Updated");

			if ((bool)e.ReturnValue) {
				(this.Page as IPageNotification).Notify("Success");
			}
			else {
				(this.Page as IPageNotification).Notify("Account not updated. " + e.Exception);
			}
		}

		protected void RfvOldPassword2_ServerValidate(object source, ServerValidateEventArgs args) {
			MD5 md5 = MD5.Create();
			md5.Initialize();

			string hashedPassword = Convert.ToBase64String(
				md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(args.Value))
				);
			md5.Clear();

			args.IsValid = hashedPassword.Equals(UiAccount.Get().Password);
		}
	}
}