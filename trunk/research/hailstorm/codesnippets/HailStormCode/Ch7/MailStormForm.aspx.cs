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

//namespace MailStormService{}
namespace MailStormClient
{
	/// <summary>
	/// Summary description for MailStormForm.
	/// </summary>
	public class MailStormForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.TextBox txtServer;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtFrom;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnList;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.TextBox txtStatus;
		protected System.Web.UI.WebControls.Button btnSend;
		public localhost.MailStormService mailstorm;
	
		public MailStormForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			mailstorm = new localhost.MailStormService();
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnList.Click += new System.EventHandler(this.btnList_Click);
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			txtStatus.Text = mailstorm.SendMailToMyContacts(
				txtId.Text, txtServer.Text, txtFrom.Text,
				txtSubject.Text, txtBody.Text);
		}

		private void btnList_Click(object sender, System.EventArgs e)
		{
			txtStatus.Text = mailstorm.RetrieveMyContacts(txtId.Text,
				txtServer.Text);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			bool success = mailstorm.addContact(txtId.Text, txtServer.Text,
				txtFirstName.Text, txtLastName.Text,
				txtEMail.Text);
			if (success)
			{
				txtStatus.Text = "Successfully added contact " + txtFirstName + " " + txtLastName;
			}
			else
			{
				txtStatus.Text = "Error adding contact";
			}
		}
	}
}