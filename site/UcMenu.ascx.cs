#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

using log4net;

using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	///	
	/// </summary>
	public partial class UcMenu : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			XmlDocument doc = new XmlDocument();
			doc.Load(Server.MapPath("~/menu.xml"));
			
			try {
				InitializeMenu(doc);
			}
			catch (Exception ex) {
				log.Error("Failed to initialize menu", ex);
			}
		}

		protected void InitializeMenu(XmlDocument doc) {
			UiAccount account = UiAccount.Get();

			XmlElement n = null;
			n = (XmlElement)doc.SelectSingleNode("//menu[@id='admin']");
			n.SetAttribute("visible", (Request.UserHostAddress.Equals("80.63.233.183") || Request.UserHostAddress.Equals("127.0.0.1")).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menuItem[@id='signUp']");
			n.SetAttribute("visible", (account == null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menuItem[@id='logOn']");
			n.SetAttribute("visible", (account == null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menuItem[@id='logOff']");
			n.SetAttribute("visible", (account != null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menu[@id='myAccount']");
			n.SetAttribute("visible", (account != null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menu[@id='mySubscriptions']");
			n.SetAttribute("visible", (account != null).ToString().ToLower());
			if (account != null) {
				DataTable dt = DbSubscription.DbListAllByAccount(account.Id, account.LanguageId);
				foreach (DataRow dr in dt.Rows) {
					XmlElement mi = doc.CreateElement("menuItem");
					mi.SetAttribute("text", dr["SubscriptionName"].ToString());
					mi.SetAttribute("link", "subscription.read.aspx?Subscription.Id=" + dr["SubscriptionId"].ToString() + "&Service.Id=" + dr["ServiceId"].ToString());
					mi.SetAttribute("visible", "true");
					n.AppendChild(mi);
				}
			}
			
			n = (XmlElement)doc.SelectSingleNode("//menu[@id='myServices']");
			n.SetAttribute("visible", (account != null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menuItem[@id='servicesCreate']");
			n.SetAttribute("visible", (account != null && account.Author != null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menuItem[@id='servicesExtend']");
			n.SetAttribute("visible", (account != null && account.Author != null).ToString().ToLower());

			n = (XmlElement)doc.SelectSingleNode("//menu[@id='myPackages']");
			n.SetAttribute("visible", (account != null && account.Author != null).ToString().ToLower());

			XmlMenu.Document = doc;
			XmlMenu.DataBind();
		}
	}
}
