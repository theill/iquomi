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

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcServiceRoleTemplate : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public void SyncTo(DbRoleTemplate rt) {
			rt.Name = Name;
			rt.Priority = Priority;
		}

		public void SyncFrom(DbRoleTemplate rt) {
			Name = rt.Name;
			Priority = rt.Priority;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name {
			get {
				return FldName.Text;
			}
			set {
				FldName.Text = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Priority {
			get {
				return Convert.ToInt32(FldPriority.Text);
			}

			set {
				FldPriority.Text = Convert.ToString(value);
			}
		}

	}
}
