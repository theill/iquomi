#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcNotification : System.Web.UI.UserControl {
		public enum NotificationState {
			Success,
			Failed
			};

		private XmlDocument messages;

		public void ClearMessages() {
			messages = new XmlDocument();
			messages.LoadXml("<messages />");
		}

		public void AddMessage(string v) {
			XmlElement e = messages.CreateElement("message");
			e.InnerText = v;
			messages.DocumentElement.AppendChild(e);
		}

		public string Title {
			get {
				return TitleControl.Text;
			}

			set {
				TitleControl.Text = value;
			}
		}

		public string Description {
			get {
				return DescriptionControl.Text;
			}
			set {
				DescriptionControl.Text = value;
			}
		}

		private NotificationState state;
		public NotificationState State {
			get {
				return state;
			}

			set {
				state = value;
				switch (state) {
					case NotificationState.Success:
						Title = "Success";
						Description = "Your command executed successfully.";
						ImageControl.ImageUrl = "~/gfx/ico.success.gif";
						break;

					case NotificationState.Failed:
						Title = "Failed!";
						Description = "Your command failed.";
						ImageControl.ImageUrl = "~/gfx/ico.failed.gif";
						break;
				}
			}
		}

		private void Page_Load(object sender, System.EventArgs e) {
			ClearMessages();

			this.Visible = false;
			this.EnableViewState = false;
		}

		public bool AssertSuccess(bool success) {
			State = success ? NotificationState.Success : NotificationState.Failed;
			this.Visible = true;
			//this.Page.ClientScript.RegisterStartupScript(this.GetType(), "NotificationDisplay", "HideNotification('InformationSummary', 2500);", true);
			return success;
		}

		public void Show(string title, string description) {
			this.Title = title;
			this.Description = description;
			this.Visible = true;
			//this.Page.ClientScript.RegisterStartupScript(this.GetType(), "NotificationDisplay", "HideNotification('InformationSummary', 2500);", true);
		}

		public void Success(string title) {
			this.State = NotificationState.Success;
			this.Title = title;
			this.Visible = true;
			//this.Page.ClientScript.RegisterStartupScript(this.GetType(), "NotificationDisplay", "HideNotification('InformationSummary', 2500);", true);
		}

		public void Failed(string title) {
			this.State = NotificationState.Failed;
			this.Title = title;
			this.Visible = true;
			//this.Page.ClientScript.RegisterStartupScript(this.GetType(), "NotificationDisplay", "HideNotification('InformationSummary', 2500);", true);
		}

		public void Display() {
			XmlView.DocumentContent = messages.OuterXml;
			XmlView.TransformSource = "~/xslt/notification.xslt";
			//this.Page.ClientScript.RegisterStartupScript(this.GetType(), "NotificationDisplay", "HideNotification('InformationSummary', 2500);", true);
		}

	}
}