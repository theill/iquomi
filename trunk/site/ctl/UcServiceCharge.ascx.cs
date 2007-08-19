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
	public partial class UcServiceCharge : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private DbServiceCharge item;

		public DbServiceCharge Item {
			get {
				item.MethodTypeId = this.MethodTypeId;
				item.SchemaType = this.SchemaType;
				item.Script = this.Script;
				item.Price = this.Price;
				item.ChargeUnitId = this.ChargeUnitId;
				return item;
			}

			set {
				item = value;
				this.MethodTypeId = item.MethodTypeId;
				this.SchemaType = item.SchemaType;
				this.Script = item.Script;
				this.Price = item.Price;
				this.ChargeUnitId = item.ChargeUnitId;
			}
		}

		private DbService service;

		public DbService Service {
			get {
				return this.service;
			}

			set {
				this.service = value;

				XmlSchema schema = null;
				try {
					schema = service.GetXmlSchema();

//					log.Debug("Enumerating elements for schema = " + schema);
					if (!schema.IsCompiled) {
						XmlSchemaSet xss = new XmlSchemaSet();
						xss.Add(schema);
						xss.Compile();

//						log.Debug("Global Elements");
						foreach (XmlQualifiedName o in xss.GlobalElements.Names) {
//							log.Debug("Namespace: " + o.Namespace + ". Name: " + o.Name);
							if (schema.TargetNamespace != null && schema.TargetNamespace.Equals(o.Namespace)) {
								this.FldSchemaType.Items.Add(o.Name);
							}
						}

//						log.Debug("Global Types");
						foreach (XmlQualifiedName o in xss.GlobalTypes.Names) {
//							log.Debug("Namespace: " + o.Namespace + ". Name: " + o.Name);
							if (schema.TargetNamespace != null && schema.TargetNamespace.Equals(o.Namespace)) {
								this.FldSchemaType.Items.Add(o.Name);
							}
						}

//						log.Debug("Global Attributes");
//						foreach (XmlQualifiedName o in xss.GlobalAttributes.Names) {
//							log.Debug("Namespace: " + o.Namespace + ". Name: " + o.Name);
//							if (schema.TargetNamespace.Equals(o.Namespace)) {
//								log.Debug(o.Name);
//							}
//						}
					}
				}
				catch (XmlSchemaException xse) {
					log.Warn("Service \"" + service.Name + "\" contains invalid Xml Schema", xse);
				}
				catch (XmlException xe) {
					log.Warn("Cannot read schema for service \"" + service.Name + "\"", xe);
				}
				
//				if (schema != null) {
//					foreach (XmlQualifiedName o in schema.SchemaTypes.Names) {
//						log.Debug(o.Namespace + ": " + o.Name);
//						if (schema.TargetNamespace.Equals(o.Namespace)) {
//							this.FldSchemaType.Items.Add(o.Name);
//						}
//					}
//				}
			}
		}

		#region Properties
		/// <summary>
		/// Property SchemaType (string)
		/// </summary>
		public string SchemaType {
			get {
				return FldSchemaType.SelectedValue;
			}
			set {
				FldSchemaType.SelectedValue = value;
			}
		}

		/// <summary>
		/// Property Type (int)
		/// </summary>
		public int MethodTypeId {
			get {
				return Convert.ToInt32(FldMethodTypeId.SelectedValue);
			}
			set {
				FldMethodTypeId.SelectedValue = Convert.ToString(value);
			}
		}

		/// <summary>
		/// Property Script (string)
		/// </summary>
		public string Script {
			get {
				return FldScript.Text;
			}
			set {
				FldScript.Text = value;
			}
		}

		/// <summary>
		/// Property ChargeUnitId (int)
		/// </summary>
		public int ChargeUnitId {
			get {
				return Convert.ToInt32(FldChargeUnitId.SelectedValue);
			}
			set {
				FldChargeUnitId.SelectedValue = Convert.ToString(value);
			}
		}

		/// <summary>
		/// Property Price (float)
		/// </summary>
		public float Price {
			get {
				try {
					return Convert.ToSingle(FldPrice.Text);
				}
				catch (FormatException) {
					return 0.0f;
				}
			}
			set {
				FldPrice.Text = Convert.ToString(value);
			}
		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				FldSchemaType.Enabled = (FldSchemaType.Items.Count > 0);

				DbMethodType[] y = (DbMethodType[])DbMethodType.DbFindAll();
				foreach (DbMethodType a in y) {
					FldMethodTypeId.Items.Add(new ListItem(a.Name, Convert.ToString(a.Id)));
				}
				FldMethodTypeId.Items.Insert(0, new ListItem("", ""));

				DbChargeUnit chargeUnit = new DbChargeUnit();
				DataTable dt = (DataTable)chargeUnit.DbFindAll();
				foreach (DataRow dr in dt.Rows) {
					ListItem li = new ListItem(
						String.Format("{0}: {1}",
							dr["ChargeUnitCommonName"].ToString(),
							dr["ChargeUnitDescriptionName"].ToString() 
						),
						dr["ChargeUnitId"].ToString()
						);
					FldChargeUnitId.Items.Add(li);
				}

				FldMethodTypeId.DataBind();
				FldChargeUnitId.DataBind();
			}
		}
	}
}