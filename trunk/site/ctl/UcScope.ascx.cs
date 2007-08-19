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

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcScope : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		protected Scope scope;

		public void SyncTo(Scope v) {
			v.Name = Name;
			v.Base = Base;
		}

		public void SyncFrom(Scope v) {
			Name = v.Name;
			Base = v.Base;

			scope = v;
		}

		public string Name {
			get {
				return this.TbName.Text;
			}

			set {
				this.TbName.Text = value;
			}
		}

		public string Base {
			get {
				return this.DdlBase.SelectedValue;
			}
			set {
				this.DdlBase.SelectedValue = value;
			}
		}

		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				DdlBase.Items.Add(new ListItem(ScopeBase.T.ToString(), ScopeBase.T.ToString()));
				DdlBase.Items.Add(new ListItem(ScopeBase.NIL.ToString(), ScopeBase.NIL.ToString()));

				DdlBase.SelectedValue = scope.Base.ToUpper();
			}
		}
	}
}