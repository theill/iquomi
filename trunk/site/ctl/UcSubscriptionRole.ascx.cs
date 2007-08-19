#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Schema;

using log4net;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;
//using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcSubscriptionRole : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			MethodBase.GetCurrentMethod().DeclaringType
			);

		public bool Updating = false;

		private DbSubscription subscription;
		private Role role;

		public DbSubscription Subscription {
			get {
				return this.subscription;
			}
			set {
				this.subscription = value;
			}
		}

		public void SyncTo(Role v) {
			DbAccount a = DbAccount.FindByIqid(this.TbxIqid.Text);
			v.AccountId = a.Id;
			v.RoleTemplateId = RoleTemplateId;
			v.ScopeId = ScopeId;
			v.ActiveFrom = ActiveFrom;
			v.ActiveTo = ActiveTo;
		}

		public void SyncFrom(Role v) {
			// Lookup account based on id to get unique Iquomi Id
			DbAccount a = DbAccount.DbRead(v.AccountId);
			this.TbxIqid.Text = a.Iqid;

			RoleTemplateId = v.RoleTemplateId;
			ScopeId = v.ScopeId;
			ActiveFrom = v.ActiveFrom;
			ActiveTo = v.ActiveTo;

			role = v;
		}

/*
		private RoleType role;

		public void SyncTo(RoleType v) {
			// Lookup id for account using unique Iquomi Id
			DbAccount a = DbAccount.FindByIqid(this.TbxIqid.Text);
//			v.AccountId = a.Id;
			
			v.RoleTemplateRef = RoleTemplateRef;
			v.ScopeRef = ScopeRef;
			//v.ActiveFrom = ActiveFrom;
			v.ExpiresAt = ActiveTo;
		}

		public void SyncFrom(RoleType v) {
			// Lookup account based on id to get unique Iquomi Id
			DbAccount a = DbAccount.DbRead(v.Creator);
			this.TbxIqid.Text = a.Iqid;
			
			RoleTemplateRef = v.RoleTemplateRef;
			ScopeRef = v.ScopeRef;
			//ActiveFrom = v.ActiveFrom;
			ActiveTo = v.ExpiresAt;

			role = v;
		}
*/
		public int RoleTemplateId {
			get {
				return Convert.ToInt32(this.DdlRoleTemplates.SelectedValue);
			}
			set {
				this.DdlRoleTemplates.SelectedValue = value.ToString();
			}
		}

		public int ScopeId {
			get {
				return Convert.ToInt32(this.DdlScopes.SelectedValue);
			}
			set {
				this.DdlScopes.SelectedValue = value.ToString();
			}
		}

		public DateTime ActiveFrom {
			get {
				return DbUiHelper.FromGeneralDateTime(this.TbxActiveFrom.Text);
			}
			set {
				this.TbxActiveFrom.Text = DbUiHelper.ToGeneralDateTime(value);
			}
		}

		public DateTime ActiveTo {
			get {
				return DbUiHelper.FromGeneralDateTime(this.TbxActiveTo.Text);
			}
			set {
				this.TbxActiveTo.Text = DbUiHelper.ToGeneralDateTime(value);
			}
		}

		private void Page_Load(object sender, System.EventArgs e) {
			if (!IsPostBack) {
				FillRoleTemplates();
				FillScopes();
			}

			TbxIqid.Enabled = !Updating;
		}

		private void FillRoleTemplates() {
			DbUtility db = new DbUtility("iqListAllRoleTemplatesByService");
			db.In("@service_id", subscription.ServiceId);
			db.In("@language_id", UiAccount.Get().LanguageId);

			// Include standard 'none selected' value
			DataTable dt = db.GetDataTable();

			DataRow dr = dt.NewRow();
			dr["RoleTemplateId"] = "0";
			dr["RoleTemplateName"] = "";
			dt.Rows.InsertAt(dr, 0);

			this.DdlRoleTemplates.DataSource = new DataView(dt);
			this.DdlRoleTemplates.DataValueField = "RoleTemplateId";
			this.DdlRoleTemplates.DataTextField = "RoleTemplateName";
			this.DdlRoleTemplates.DataBind();
		}

		private void FillScopes() {
			DbUtility db = new DbUtility("iqListAllScopesForSubscription");
			db.In("@subscription_id", DbType.Guid, subscription.Id);
			db.In("@language_id", UiAccount.Get().LanguageId);

			// Include standard 'none selected' value
			DataTable dt = db.GetDataTable();
			DataRow dr = dt.NewRow();
			dr["ScopeId"] = "0";
			dr["ScopeName"] = "";
			dt.Rows.InsertAt(dr, 0);

			this.DdlScopes.DataValueField = "ScopeId";
			this.DdlScopes.DataTextField = "ScopeName";
			this.DdlScopes.DataSource = dt;
			this.DdlScopes.DataBind();
		}

	}
}