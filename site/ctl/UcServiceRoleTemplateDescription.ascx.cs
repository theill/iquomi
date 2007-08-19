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
using Commanigy.Iquomi.Api;
//using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcServiceRoleTemplateDescription : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public void SyncTo(RoleTemplateDescription rtd) {
			rtd.LanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
			rtd.Description = Description;
		}

		public void SyncFrom(RoleTemplateDescription rtd) {
			ddlLanguage.SelectedValue = rtd.LanguageId.ToString();
			Description = rtd.Description;
		}

/*
		public void SyncTo(RoleTemplateType rt) {
			LocalizableString a = new LocalizableString();
			a.lang = ddlLanguage.SelectedValue;
			a.Value = Description;
			rt.FullDescription = a;
//			rtd.LanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
//			rtd.FullDescription = Description;
		}

		public void SyncFrom(RoleTemplateType rt) {
			ddlLanguage.SelectedValue = rt.FullDescription.lang;
			Description = rt.FullDescription.Value;
//			ddlLanguage.SelectedValue = rtd.LanguageId.ToString();
//			Description = rtd.Description;
		}
*/
		/// <summary>
		/// 
		/// </summary>
		public string Description {
			get {
				return FldDescription.Text;
			}
			set {
				FldDescription.Text = value;
			}
		}


		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				DbUtility db = new DbUtility("iqListAllLanguages");
				ddlLanguage.DataSource = db.GetDataTable();
				ddlLanguage.DataBind();
			}
		}

	}
}