#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Schema;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcServiceRoleTemplateMethod : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		// is component creating or updating?
		public bool Updating = false;

		public void SyncTo(DbRoleTemplateMethod v) {
			v.MethodTypeId = MethodTypeId;
			v.ScopeId = ScopeId;
		}

		public void SyncFrom(DbRoleTemplateMethod v) {
			MethodTypeId = v.MethodTypeId;
			ScopeId = v.ScopeId;
		}

//		public void SyncTo(RoleTemplateTypeMethod v) {
//			v.Name = Name;
//			v.ScopeRef = ScopeRef;
//		}
//
//		public void SyncFrom(RoleTemplateTypeMethod v) {
//			Name = v.Name;
//			ScopeRef = v.ScopeRef;
//		}

		public int MethodTypeId {
			get {
				return Convert.ToInt32(this.DdlMethodTypes.SelectedValue);
			}
			set {
				this.DdlMethodTypes.SelectedValue = Convert.ToString(value);
			}
		}

		public int ScopeId {
			get {
				return Convert.ToInt32(this.DdlScopes.SelectedValue);
			}
			set {
				this.DdlScopes.SelectedValue = Convert.ToString(value);
			}
		}
		
//		/// <summary>
//		/// 
//		/// </summary>
//		public string Name {
//			get {
//				return this.DdlMethodTypes.SelectedValue;
//			}
//			set {
//				this.DdlMethodTypes.SelectedValue = value;
//			}
//		}
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string ScopeRef {
//			get {
//				return this.DdlScopes.SelectedValue;
//			}
//			set {
//				this.DdlScopes.SelectedValue = value;
//			}
//		}
		
		
		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				DataTable dt = DbMethodType.DbFindAllAsTable();
				DdlMethodTypes.DataTextField = "Name";
				DdlMethodTypes.DataValueField = "Id";
				DdlMethodTypes.DataSource = dt;
				DdlMethodTypes.DataBind();
				
				// enable only on creation
				DdlMethodTypes.Enabled = !Updating;

				DbServiceScope ss = new DbServiceScope();
				ss.ServiceId = UiService.Get().Id;
				dt = ss.DbFindAllForService();

				// insert empty element since it's possible no scopes will
				// be selected upon creation
				DataRow row = dt.NewRow();
				row["Name"] = "";
				row["Id"] = "0";
				dt.Rows.InsertAt(row, 0);
				
				DdlScopes.DataTextField = "Name";
				DdlScopes.DataValueField = "Id";
				DdlScopes.DataSource = dt;
				DdlScopes.DataBind();
			}
		}
	}
}