#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;

using Commanigy.Iquomi.Data;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	///	
	/// </summary>
	public partial class UcPackageItem : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private DbPackageItem dbItem;

		public DbPackageItem DbItem {
			get {
				return dbItem;
			}
			set {
				dbItem = value;
			}
		}


		public string Name {
			get {
				return FldName.Text;
			}
		}

		public long Size {
			get {
				return (FldSize.Text.Length > 0) ? Convert.ToInt64(FldSize.Text) : 0;
			}
		}

		public string Type {
			get {
				return FldType.SelectedValue;
			}
		}

		public string Data {
			get {
				return FldData.Text;
			}
		}

		public HtmlInputFile Upload {
			get {
				return FldUpload;
			}
		}

		private void Page_Load(object sender, System.EventArgs e) {
			FldType.DataTextField = "Type";
			FldType.DataValueField = "Id";
			FldType.DataSource = (DataTable)DbPackageItem.DbFindAllSupportedTypes();
			FldType.DataBind();

			if (!Page.IsPostBack) {
				if (this.dbItem != null) {
					this.FromDb(this.dbItem);
				}
			}
		}

		public void FromDb(DbPackageItem v) {
			this.FldName.Text = v.Name;
			ListItem a = this.FldType.Items.FindByValue(v.Type);
			if (a == null) {
				a = new ListItem(v.Type, v.Type);
				//a.Attributes["style"] = "color: #ccc";
				this.FldType.Items.Insert(0, a);
			}
			a.Selected = true;
			FldSize.Text = v.Size.ToString();

			// TODO add 'mimetype' on 'DbFindAllSupportedTypes'
			if (v.Type.StartsWith("text/")) {
				FldData.Text = Encoding.UTF8.GetString(v.Data as byte[]);
			}
			else if (v.Type.StartsWith("image/")) {
				FldData.Text = "(binary image)";
			}
			else {
				FldData.Text = "(binary)";
			}

			FldSize.ReadOnly = true;
			FldData.ReadOnly = true;
		}

		public DbPackageItem ToDb() {
			DbPackageItem v = new DbPackageItem();
			v.Id = dbItem.Id;
			v.PackageId = dbItem.PackageId;
			v.Name = Name;
			v.Type = Type;
			v.Size = Size;
			v.Data = dbItem.Data;
			return v;
		}
	}
}