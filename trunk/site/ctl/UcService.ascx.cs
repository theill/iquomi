#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Schema;
using System.Collections;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Utils;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcService : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		#region Properties

		private DbService dataItem;

		public DbService DataItem {
			get {
				return dataItem;
			}

			set {
				dataItem = value;
			}
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e) {
			form.DefaultMode = (dataItem != null && dataItem.Id != 0) ? FormViewMode.Edit : FormViewMode.Insert;
		}

		protected void BtnValidate_Click(object sender, EventArgs e) {
			try {
				Api.Service.Validate(dataItem, null);

				(this.Page as IPageNotification).Notify(null as Exception);
			}
			catch (XmlSchemaException ese) {
				log.Debug("Unable to validate schema: " + ese.Message + "(" + ese.SourceUri + ", " + ese.LineNumber + ", " + ese.LinePosition + ")");

				foreach (DictionaryEntry de in ese.Data) {
					log.Debug(de.Key + ": " + de.Value);
				}

				(this.Page as IPageNotification).Notify(ese);
			}
			catch (XmlException ex) {
				log.Debug("Unable to validate: " + ex.Message);
				(this.Page as IPageNotification).Notify(ex);
			}
		}

		protected void ObjectSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			if (this.dataItem != null) {
				e.InputParameters["Id"] = this.dataItem.Id;
			}
		}
		protected void ObjectSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e) {
			DbService service = e.InputParameters[0] as DbService;
			service.AuthorId = UiAccount.Get().Author.Id;
			service.State = Ui.State.DESIGN;
		}
		
		protected void ObjectSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e) {
			dataItem = (DbService)e.ReturnValue;
			//log.Debug("dataItem: " + Utils.ObjectUtils.Dump(dataItem));
			if (dataItem != null && dataItem.Id > 0) {
				XmlDocument d = new XmlDocument();
				d.Load(Server.MapPath("~/xml/StandardRoleTemplates.xml"));
				dataItem.InsertStandardRoleTemplates(d.DocumentElement);

				(Page as IPageNotification).Success();
			}
			else {
				e.ExceptionHandled = true;
				(Page as IPageNotification).Notify(e.Exception);
			}
		}

		protected void ObjectSource_Updating(object sender, ObjectDataSourceMethodEventArgs e) {
			DbService service = e.InputParameters[0] as DbService;
			service.Id = dataItem.Id;
			service.AuthorId = dataItem.AuthorId;
			service.State = dataItem.State;
		}

		protected void ObjectSource_Updated(object sender, ObjectDataSourceStatusEventArgs e) {
			e.ExceptionHandled = true;
			(Page as IPageNotification).Notify(e.Exception);
		}
	}
}