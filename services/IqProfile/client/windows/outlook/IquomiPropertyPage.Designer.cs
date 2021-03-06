namespace Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook {
	partial class IquomiPropertyPage {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.llblForgotPassword = new System.Windows.Forms.LinkLabel();
			this.pbAccounts = new System.Windows.Forms.PictureBox();
			this.lblIqid = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbIqid = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).BeginInit();
			this.SuspendLayout();
			// 
			// llblForgotPassword
			// 
			this.llblForgotPassword.AutoSize = true;
			this.llblForgotPassword.Location = new System.Drawing.Point(144, 88);
			this.llblForgotPassword.Name = "llblForgotPassword";
			this.llblForgotPassword.Size = new System.Drawing.Size(93, 13);
			this.llblForgotPassword.TabIndex = 11;
			this.llblForgotPassword.TabStop = true;
			this.llblForgotPassword.Text = "Forgot password?";
			// 
			// pbAccounts
			// 
			this.pbAccounts.BackColor = System.Drawing.Color.Transparent;
			this.pbAccounts.Location = new System.Drawing.Point(23, 33);
			this.pbAccounts.Name = "pbAccounts";
			this.pbAccounts.Size = new System.Drawing.Size(32, 32);
			this.pbAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbAccounts.TabIndex = 8;
			this.pbAccounts.TabStop = false;
			// 
			// lblIqid
			// 
			this.lblIqid.AutoSize = true;
			this.lblIqid.BackColor = System.Drawing.Color.Transparent;
			this.lblIqid.Location = new System.Drawing.Point(71, 36);
			this.lblIqid.Name = "lblIqid";
			this.lblIqid.Size = new System.Drawing.Size(29, 13);
			this.lblIqid.TabIndex = 6;
			this.lblIqid.Text = "Iqid:";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.BackColor = System.Drawing.Color.Transparent;
			this.lblPassword.Location = new System.Drawing.Point(71, 64);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(57, 13);
			this.lblPassword.TabIndex = 9;
			this.lblPassword.Text = "Password:";
			// 
			// tbPassword
			// 
			this.tbPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.tbPassword.Location = new System.Drawing.Point(145, 61);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '●';
			this.tbPassword.Size = new System.Drawing.Size(177, 20);
			this.tbPassword.TabIndex = 10;
			this.tbPassword.Text = global::Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook.Properties.Settings.Default.Password;
			this.tbPassword.UseSystemPasswordChar = true;
			// 
			// tbIqid
			// 
			this.tbIqid.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook.Properties.Settings.Default, "Iqid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.tbIqid.Location = new System.Drawing.Point(145, 33);
			this.tbIqid.Name = "tbIqid";
			this.tbIqid.Size = new System.Drawing.Size(177, 20);
			this.tbIqid.TabIndex = 7;
			this.tbIqid.Text = global::Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook.Properties.Settings.Default.Iqid;
			// 
			// IquomiPropertyPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.llblForgotPassword);
			this.Controls.Add(this.pbAccounts);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbIqid);
			this.Controls.Add(this.lblIqid);
			this.Controls.Add(this.lblPassword);
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.Name = "IquomiPropertyPage";
			this.Size = new System.Drawing.Size(368, 413);
			this.Load += new System.EventHandler(this.IquomiPropertyPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel llblForgotPassword;
		private System.Windows.Forms.PictureBox pbAccounts;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.TextBox tbIqid;
		private System.Windows.Forms.Label lblIqid;
		private System.Windows.Forms.Label lblPassword;
	}
}
