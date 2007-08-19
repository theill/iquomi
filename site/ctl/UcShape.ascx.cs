#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Schema;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Services;

using log4net;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcShape : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public void SyncTo(DbShape v) {
			v.Select = Select;
			v.Type = Type;
		}

		public void SyncFrom(DbShape v) {
			Select = v.Select;
			Type = v.Type;
		}

		public string Select {
			get {
				return this.TbSelect.Text;
			}
			set {
				this.TbSelect.Text = value;
			}
		}

		public string Type {
			get {
				return this.DdlType.SelectedValue;
			}
			set {
				this.DdlType.SelectedValue = value;
			}
		}

		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				DdlType.Items.Add(new ListItem("Include", DbShape.INCLUDE));
				DdlType.Items.Add(new ListItem("Exclude", DbShape.EXCLUDE));
			}
		}

	}
}