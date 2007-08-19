#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Utils;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class SubscriptionReadPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");
		
		protected UiService service;
		protected DbSubscription subscription;

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);

			service = new UiService();
			service.Id = GetInt32("Service.Id");
			service.DbRead();

			subscription = DbSubscription.DbRead(GetGuid("Subscription.Id"));
		}

		protected void Page_Load(object sender, System.EventArgs e) {
			if (subscription.AccountId != UiAccount.Get().Id) {
				throw new UnauthorizedAccessException("Subscription not found");
			}

			SiteMapNode n = SiteMap.CurrentNode;
			
			// set node title to show currently selected service name
			n.Title = subscription.Name ?? _("(unknown)");
			n.Url = this.Request.Url.ToString();

			SubscriptionUC.Service = service;
			SubscriptionUC.Subscription = subscription;

			if (!Page.IsPostBack) {
				FldName.Text = subscription.Name;
				Xml.Text = subscription.Xml;
				try {
					Xml.Text = XmlUtils.FormatXml(Xml.Text);
				}
				catch (XmlException) {
					// not valid xml
				}
				UrlXml.Text = subscription.UrlXml;
			}

			Xml.Focus();

//			if (Request["o"] == "xml") {
//				this.Response.Clear();
//				this.Response.ClearHeaders();
//				this.Response.ContentType = "text/xml";
//				this.Response.Write(Xml.Text);
//				this.Response.End();
//			}
		}

		protected void Update_Click(object sender, System.EventArgs e) {
			log.Debug("Updating subscription " + subscription.Id);

			subscription.Name = FldName.Text;
			subscription.Xml = Xml.Text;
			subscription.UrlXml = UrlXml.Text;

			try {
				Notification.AssertSuccess(subscription.DbUpdate() != null);
			}
			catch (System.Data.Common.DbException x) {
				if (x.Message.Contains("Violation of UNIQUE KEY constraint 'IX_subscription'.")) {
					Notify(_("A subscription with this name already exists."));
				}
				else {
					Notify(x);
				}
			}
			
			try {
				Xml.Text = XmlUtils.FormatXml(Xml.Text);
			}
			catch (XmlException) {
				;
			}
		}

		protected void Unsubscribe_Click(object sender, System.EventArgs e) {
			DbSubscription deletedSubscription = (DbSubscription)subscription.DbDelete();
			if (Guid.Empty.Equals(deletedSubscription.Id)) {
				this.Redirect("subscriptions.aspx", null);
			} else {
				Notification.State = UcNotification.NotificationState.Failed;
				Notification.Visible = true;
			}
		}

		protected void BtnRoleLists_Click(object sender, System.EventArgs e) {
			this.Redirect("subscription.roles.aspx", new object[] { subscription.Id });
		}

		protected void BtnScopes_Click(object sender, System.EventArgs e) {
			this.Redirect("subscription.scopes.aspx", new object[] { subscription.Id });
		}

		protected void BtnListeners_Click(object sender, System.EventArgs e) {
			this.Redirect("subscription.listeners.aspx", new object[] { subscription.Id });
		}

		protected void BtnValidate_Click(object sender, System.EventArgs e) {
			
			XmlSchema xsd = null;
			try {
				xsd = service.GetXmlSchema();
			}
			catch (SystemException ex) {
				log.Debug("Cannot validate document");
				Notification.Title = _("Can't load XSD for service");
				Notification.Description = string.Format(_("Failed to properly load XSD attached to service: {0}"), ex.Message);
				Notification.Visible = true;
				return;
			}

			Notification.Success(_("Validated correctly"));

			// Update Xml in subscription before doing validation
			subscription.Xml = this.Xml.Text;

			try {
				XmlTextReader tr = new XmlTextReader(new StringReader(subscription.Xml));

				XmlReaderSettings xrs = new XmlReaderSettings();
				//xrs.XsdValidate = true;
				xrs.ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ProcessInlineSchema | XmlSchemaValidationFlags.ProcessIdentityConstraints | XmlSchemaValidationFlags.ReportValidationWarnings;
				xrs.ProhibitDtd = false;
				xrs.Schemas.Add(xsd);

//				Uri fileUrl = new Uri("http://schemas.iquomi.com/2004/01/iqProfile/iqProfile.xsd");
//				System.Net.HttpWebRequest myFileWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(fileUrl);
//				System.Net.HttpWebResponse myFileWebResponse = (System.Net.HttpWebResponse)myFileWebRequest.GetResponse();
//				Stream receiveStream = myFileWebResponse.GetResponseStream();

//				xsd = XmlSchema.Read(receiveStream, new ValidationEventHandler(this.ValidationCallBack));
//				xsd.Namespaces.Add("mp", "http://schemas.iquomi.com/2004/01/iqProfile");
				//xrs.Schemas.Add(xsd);
//				xrs.Schemas.Compile();
//				xrs.Schemas.Add("http://schemas.iquomi.com/2004/01/iqProfile", "http://schemas.iquomi.com/2004/01/iqProfile/iqProfile.xsd");

				xrs.Schemas.ValidationEventHandler += new ValidationEventHandler(this.ValidationCallBack);
				xrs.ValidationEventHandler += new ValidationEventHandler(this.ValidationCallBack);
				xrs.ValidationType = ValidationType.Schema;

				XmlReader r = XmlReader.Create(tr, xrs);
				while (r.Read()) {
					;
				}

//				subscription.ValidateXmlDocument(
//					xsd, 
//					new ValidationEventHandler(this.ValidationCallBack)
//					);
			}
			catch (SystemException xse) {
				log.Debug("Can't validate subscription data");
				Notification.Title = _("Xml Schema cannot be validated");
				Notification.Description = "Failed to properly validate subscription data based on XSD attached to service: " + xse.Message;
				Notification.Visible = true;
				return;
			}

			Notification.Display();
		}

		protected void ValidationCallBack(object sender, ValidationEventArgs e) {
			Notification.Title = _("Validation failed");
			Notification.Description = "";
			Notification.AddMessage("Line: " + e.Exception.LineNumber + ", Pos: " + e.Exception.LinePosition + " (" + e.Exception.SourceUri + "): " + e.Message + " (" + e.Severity + ")");
			log.Debug("Validation Error: " + e.Exception);
		}

		protected void BtnRefresh_Click(object sender, EventArgs e) {
			Response.Expires = 0;
			Response.Redirect(Page.Request.Url.AbsoluteUri);
		}

		protected void BtnFilter_Click(object sender, EventArgs e) {
			if (TbxFilter.Text == string.Empty) {
				return;
			}

			try {
				XmlDocument d = new XmlDocument();
				d.LoadXml(Xml.Text);

				XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
				nsmgr.AddNamespace("m", d.DocumentElement.NamespaceURI);
				nsmgr.AddNamespace("iq", "http://schemas.iquomi.com/2004/01/core");

				XmlNodeList nodes = d.SelectNodes(TbxFilter.Text, nsmgr);
				string s = "<Filter XPath=\"" + TbxFilter.Text + "\">";
				foreach (XmlNode n in nodes) {
					s += n.OuterXml;
				}
				s += "</Filter>";

				LblFilterResult.Text = Server.HtmlEncode(XmlUtils.FormatXml(s));
			}
			catch (Exception x) {
				Notification.Title = _("Failed to perform filtering");
				Notification.Description = x.Message;
				Notification.Visible = true;
			}

			TbxFilter.Focus();
		}

		public override void Notify(string message) {
			Notification.Failed(message);
		}

		public override void Notify(Exception e) {
			if (e != null) {
				Notification.Failed(e.Message);
				if (e.InnerException != null) {
					Notification.Description = e.InnerException.Message;
				}
			}
			else {
				Notification.AssertSuccess(true);
			}
		}
	}
}