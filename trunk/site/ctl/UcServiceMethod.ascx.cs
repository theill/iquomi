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
using System.IO;
using System.Net;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	///	
	/// </summary>
	public partial class UcServiceMethod : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private DbServiceMethod dataItem;

		public DbServiceMethod DataItem {
			get {
				return dataItem;
			}
			set {
				dataItem = value;
			}
		}


		private void Page_Load(object sender, System.EventArgs e) {
			this.ObjectView.DefaultMode = DataItem != null ? FormViewMode.Edit : FormViewMode.Insert;
		}

		protected void ObjectSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e) {
			DbServiceMethod a = e.InputParameters[0] as DbServiceMethod;

			a.ServiceId = dataItem.ServiceId;
		}

		protected void ObjectSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e) {
			DbServiceMethod a = e.ReturnValue as DbServiceMethod;
			if (a != null && a.Id > 0) {
				(Page as WebPage).Success();
			}
		}

		protected void ObjectSource_Updating(object sender, ObjectDataSourceMethodEventArgs e) {
			DbServiceMethod a = e.InputParameters[0] as DbServiceMethod;

			a.Id = dataItem.Id;
			a.ServiceId = dataItem.ServiceId;
		}

		protected void ObjectSource_Updated(object sender, ObjectDataSourceStatusEventArgs e) {
			if (e.Exception == null) {
				(Page as WebPage).Success();
			}
		}

		protected void ObjectView_DataBound(object sender, EventArgs e) {
			DbServiceMethod a = this.ObjectView.DataItem as DbServiceMethod;

			if (a != null && string.IsNullOrEmpty(a.Script) && !string.IsNullOrEmpty(a.ScriptUrl)) {
				(this.ObjectView.FindControl("FldScript") as WebControl).CssClass = "txt Inactive";
				(this.ObjectView.FindControl("FldScriptUrl") as WebControl).CssClass = "txt";
			}
			else {
				(this.ObjectView.FindControl("FldScript") as WebControl).CssClass = "txt";
				(this.ObjectView.FindControl("FldScriptUrl") as WebControl).CssClass = "txt Inactive";
			}
		}

		protected void BtnReadScriptUrl_Click(object sender, EventArgs e) {
			string scriptUrl = (this.ObjectView.FindControl("FldScriptUrl") as TextBox).Text;

			try {
				XmlReader a = XmlReader.Create(scriptUrl);
				a.MoveToContent();
				(this.ObjectView.FindControl("FldScript") as TextBox).Text = a.ReadOuterXml();
			}
			catch (Exception) {
			}
		}

		protected void BtnTest_Click(object sender, EventArgs e) {
			string subscriptionName = "myChristmasList";
			string methodName = "AllItems"; // this.ObjectView.FindControl("FldScript")

			string a = readHtmlPage("http://services.iquomi.com/" + subscriptionName + "/" + methodName + ".rpc");
			(this.ObjectView.FindControl("TestResponse") as Literal).Text = a;
		}

		private String readHtmlPage(string url) {
			String result = "";
//			String strPost = "x=1&y=2&z=YouPostedOk";
			string strPost = "OwnerIqid=" + "petertheill" + "&Iqid=" + "petertheill" + "&Password=" + "g5zTb4oNXBR1VWyUqhNdcQ==";
			StreamWriter myWriter = null;

			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
			objRequest.Method = "POST";
			objRequest.ContentLength = strPost.Length;
			objRequest.ContentType = "application/x-www-form-urlencoded";

			try {
				myWriter = new StreamWriter(objRequest.GetRequestStream());
				myWriter.Write(strPost);
			}
			catch (Exception e) {
				return e.Message;
			}
			finally {
				myWriter.Close();
			}

			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			using (StreamReader sr = new StreamReader(objResponse.GetResponseStream())) {
				result = sr.ReadToEnd();

				// Close and clean up the StreamReader
				sr.Close();
			}

			return result;

		}   
	}
}