using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.IO;

using log4net;

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// Base class for all pages with ability to retrieve secured request 
	/// parameters, use workflow to progress back/forward between pages,
	/// providing localized message or doing specialized Xslt transformation 
	/// before showing page for user.
	/// </summary>
	public partial class TemplatePage : Commanigy.Iquomi.Web.WebPage {
//		protected static readonly ILog log = LogManager.GetLogger(
//			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
//			);
		protected static readonly ILog log = LogManager.GetLogger("WebSite");
		
		protected WorkFlow WorkFlow {
			get {
				return null;
			}
		}
		
		private void Page_Load(object sender, System.EventArgs e) {
//			Response.Filter = new Commanigy.Iquomi.Web.TemplatePageFilter(Response.Filter);
//			Response.Filter = new Commanigy.Iquomi.Web.XhtmlFilter(Response.Filter);
		}

		private string GetControlOutput(string ucFileName) {
			StringBuilder sb = new StringBuilder();
			Control c = this.LoadControl(ucFileName);
			this.Controls.Add(c);
			c.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
			this.Controls.Remove(c);
			return sb.ToString();
		}

		protected override void Render(HtmlTextWriter writer) {
			XmlDocument document_ = new XmlDocument();
			XmlElement documentElement = document_.CreateElement("document");
			document_.AppendChild(documentElement);

			XmlDocument section = null;
			
			// import header document
			section = new XmlDocument();
			section.LoadXml(GetControlOutput("/UcHeader.ascx"));
			documentElement.AppendChild(document_.ImportNode(section.DocumentElement, true));

			// import menu document
			section = new XmlDocument();
			section.LoadXml(GetControlOutput("/UcMenu.ascx"));
			documentElement.AppendChild(document_.ImportNode(section.DocumentElement, true));

			// import footer document
			section = new XmlDocument();
			section.LoadXml(GetControlOutput("/UcFooter.ascx"));
			documentElement.AppendChild(document_.ImportNode(section.DocumentElement, true));
			
			StringBuilder sb = new StringBuilder();
			base.Render(new HtmlTextWriter(new StringWriter(sb)));

			// import content document
			section = new XmlDocument();
			section.LoadXml("<div id=\"Content\"><![CDATA[" + sb.ToString() + "]]></div>");
			
			// TODO It's currently not possible for the .NET framework to 
			// generate XHTML code properly thus it's impossible to parse 
			// page content directly into an Xml document without having to
			// override many render methods. With a future release it might
			// be possible and the line below should then be enabled 
			// instead to ensure we have a valid XHTML web site.
//			try {
//				section.LoadXml(sb.ToString());
//			}
//			catch (XmlException e) {
//				section.LoadXml("<div id=\"Content\" style=\"color: red\"><![CDATA[" + e.Message + "<br /><br />" + sb.ToString() + "]]></div>");
//			}
			
			documentElement.AppendChild(document_.ImportNode(section.DocumentElement, true));
			
			System.Xml.Xsl.XslTransform xslt = new System.Xml.Xsl.XslTransform();
			xslt.Load(Server.MapPath("template.xslt"));
			xslt.Transform(document_, null, writer, null);
		}
		
		protected string _(string msg) {
			return msg;
		}
		
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {    

		}
		#endregion
	}
}
