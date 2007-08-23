#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion

namespace Commanigy.Iquomi {
	public class IqGridView : System.Web.UI.WebControls.GridView {

		public IqGridView() : base() {
			// FIX: whidbey bug
			this.Attributes["style"] = "border-collapse: inherited";
			this.CssClass = "List";
			this.AllowPaging = true;
			this.AllowSorting = true;
			this.AutoGenerateColumns = false;
			this.EnableViewState = false;
			this.GridLines = GridLines.None;
			this.PageSize = 15;
			this.PagerStyle.CssClass = "Pager";
//			try {
//				this.GridLines = (GridLines)Enum.Parse(typeof(GridLines), ConfigurationSettings.AppSettings["GridView.GridLines"].ToString());
//				this.PageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["GridView.PageSize"]);
//			}
//			catch (Exception) {
//				;
//			}
		}

	}
}
