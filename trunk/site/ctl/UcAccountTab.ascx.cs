#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui; 

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcAccountTab : System.Web.UI.UserControl {
	
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			UiAccount a = UiAccount.Get();
			if (a != null) {
				this.FullName.Text = a.Iqid + "/" + a.Password + " (" + this.Context.Profile.UserName + ")";
			}
		}
	}
}