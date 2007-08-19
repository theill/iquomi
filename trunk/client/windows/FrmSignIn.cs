using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// Summary description for FrmSignIn.
	/// </summary>
	public class FrmSignIn : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbxEmail;
		private System.Windows.Forms.TextBox tbxPassword;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel lblSignUpAccount;

		/// <summary>
		/// Property Email (string)
		/// </summary>
		public string Email {
			get {
				return tbxEmail.Text;
			}
		}

		/// <summary>
		/// Property Password (string)
		/// </summary>
		public string Password {
			get {
				MD5 md5 = MD5.Create();
				md5.Initialize();

				string hashedPassword = Convert.ToBase64String(
					md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(tbxPassword.Text))
					);
				md5.Clear();

				return hashedPassword;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmSignIn() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSignIn));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbxEmail = new System.Windows.Forms.TextBox();
			this.tbxPassword = new System.Windows.Forms.TextBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblSignUpAccount = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Name = "btnOk";
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			// 
			// tbxEmail
			// 
			resources.ApplyResources(this.tbxEmail, "tbxEmail");
			this.tbxEmail.Name = "tbxEmail";
			// 
			// tbxPassword
			// 
			resources.ApplyResources(this.tbxPassword, "tbxPassword");
			this.tbxPassword.Name = "tbxPassword";
			// 
			// lblEmail
			// 
			resources.ApplyResources(this.lblEmail, "lblEmail");
			this.lblEmail.Name = "lblEmail";
			// 
			// lblPassword
			// 
			resources.ApplyResources(this.lblPassword, "lblPassword");
			this.lblPassword.Name = "lblPassword";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// pictureBox1
			// 
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			// 
			// lblSignUpAccount
			// 
			resources.ApplyResources(this.lblSignUpAccount, "lblSignUpAccount");
			this.lblSignUpAccount.Name = "lblSignUpAccount";
			this.lblSignUpAccount.TabStop = true;
			this.lblSignUpAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignUpAccount_LinkClicked);
			// 
			// FrmSignIn
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.lblSignUpAccount);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.tbxPassword);
			this.Controls.Add(this.tbxEmail);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSignIn";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void lblSignUpAccount_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			new FrmSignUp().ShowDialog();
		}
	}
}
