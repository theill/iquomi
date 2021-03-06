namespace Commanigy.Iquomi.Services.IqContacts.Client {
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
			this.lblIqid = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.tbIqid = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.cbSync = new System.Windows.Forms.CheckBox();
			this.lblSynchronization = new Commanigy.Controls.LabelLine();
			this.lblAccounts = new Commanigy.Controls.LabelLine();
			this.llblForgotPassword = new System.Windows.Forms.LinkLabel();
			this.pbAccounts = new System.Windows.Forms.PictureBox();
			this.pbSynchronization = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSynchronization)).BeginInit();
			this.SuspendLayout();
			// 
			// lblIqid
			// 
			this.lblIqid.AutoSize = true;
			this.lblIqid.BackColor = System.Drawing.Color.Transparent;
			this.lblIqid.Location = new System.Drawing.Point(64, 34);
			this.lblIqid.Name = "lblIqid";
			this.lblIqid.Size = new System.Drawing.Size(23, 13);
			this.lblIqid.TabIndex = 1;
			this.lblIqid.Text = "Iqid:";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.BackColor = System.Drawing.Color.Transparent;
			this.lblPassword.Location = new System.Drawing.Point(64, 62);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(52, 13);
			this.lblPassword.TabIndex = 3;
			this.lblPassword.Text = "Password:";
			// 
			// tbIqid
			// 
			this.tbIqid.DataBindings.Add(new System.Windows.Forms.Binding("Text", Commanigy.Iquomi.Services.IqContacts.Client.Properties.Settings.Default, "Iqid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.tbIqid.Location = new System.Drawing.Point(138, 31);
			this.tbIqid.Name = "tbIqid";
			this.tbIqid.Size = new System.Drawing.Size(177, 20);
			this.tbIqid.TabIndex = 2;
			this.tbIqid.TextChanged += new System.EventHandler(this.tbIqid_TextChanged);
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(138, 59);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '●';
			this.tbPassword.Size = new System.Drawing.Size(177, 20);
			this.tbPassword.TabIndex = 4;
			this.tbPassword.UseSystemPasswordChar = true;
			this.tbPassword.TextChanged += new System.EventHandler(this.tbIqid_TextChanged);
			// 
			// cbSync
			// 
			this.cbSync.AutoSize = true;
			this.cbSync.BackColor = System.Drawing.Color.Transparent;
			this.cbSync.Checked = Commanigy.Iquomi.Services.IqContacts.Client.Properties.Settings.Default.SynchronizeFolder;
			this.cbSync.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSync.DataBindings.Add(new System.Windows.Forms.Binding("Checked", Commanigy.Iquomi.Services.IqContacts.Client.Properties.Settings.Default, "SynchronizeFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cbSync.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbSync.Location = new System.Drawing.Point(86, 142);
			this.cbSync.Name = "cbSync";
			this.cbSync.Size = new System.Drawing.Size(134, 18);
			this.cbSync.TabIndex = 7;
			this.cbSync.Text = "Synchronize this folder";
			this.cbSync.UseVisualStyleBackColor = false;
			this.cbSync.Click += new System.EventHandler(this.cbSync_Click);
			// 
			// lblSynchronization
			// 
			this.lblSynchronization.BackColor = System.Drawing.Color.Transparent;
			this.lblSynchronization.Location = new System.Drawing.Point(10, 116);
			this.lblSynchronization.Name = "lblSynchronization";
			this.lblSynchronization.Size = new System.Drawing.Size(390, 13);
			this.lblSynchronization.TabIndex = 6;
			this.lblSynchronization.Text = "Synchronization";
			this.lblSynchronization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAccounts
			// 
			this.lblAccounts.BackColor = System.Drawing.Color.Transparent;
			this.lblAccounts.Location = new System.Drawing.Point(10, 10);
			this.lblAccounts.Name = "lblAccounts";
			this.lblAccounts.Size = new System.Drawing.Size(390, 13);
			this.lblAccounts.TabIndex = 0;
			this.lblAccounts.Text = "Accounts";
			this.lblAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// llblForgotPassword
			// 
			this.llblForgotPassword.AutoSize = true;
			this.llblForgotPassword.Location = new System.Drawing.Point(137, 86);
			this.llblForgotPassword.Name = "llblForgotPassword";
			this.llblForgotPassword.Size = new System.Drawing.Size(87, 13);
			this.llblForgotPassword.TabIndex = 5;
			this.llblForgotPassword.TabStop = true;
			this.llblForgotPassword.Text = "Forgot password?";
			// 
			// pbAccounts
			// 
			this.pbAccounts.AutoSize = true;
			this.pbAccounts.BackColor = System.Drawing.Color.Transparent;
			this.pbAccounts.Image = Commanigy.Iquomi.Services.IqContacts.Client.Properties.Resources.woman;
			this.pbAccounts.Location = new System.Drawing.Point(16, 31);
			this.pbAccounts.Name = "pbAccounts";
			this.pbAccounts.Size = new System.Drawing.Size(32, 32);
			this.pbAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbAccounts.TabIndex = 2;
			this.pbAccounts.TabStop = false;
			// 
			// pbSynchronization
			// 
			this.pbSynchronization.AutoSize = true;
			this.pbSynchronization.BackColor = System.Drawing.Color.Transparent;
			this.pbSynchronization.Image = Commanigy.Iquomi.Services.IqContacts.Client.Properties.Resources.stream;
			this.pbSynchronization.Location = new System.Drawing.Point(16, 142);
			this.pbSynchronization.Name = "pbSynchronization";
			this.pbSynchronization.Size = new System.Drawing.Size(32, 32);
			this.pbSynchronization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbSynchronization.TabIndex = 8;
			this.pbSynchronization.TabStop = false;
			// 
			// IquomiPropertyPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.llblForgotPassword);
			this.Controls.Add(this.lblAccounts);
			this.Controls.Add(this.lblSynchronization);
			this.Controls.Add(this.cbSync);
			this.Controls.Add(this.pbAccounts);
			this.Controls.Add(this.pbSynchronization);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbIqid);
			this.Controls.Add(this.lblIqid);
			this.Controls.Add(this.lblPassword);
			this.Name = "IquomiPropertyPage";
			this.Size = new System.Drawing.Size(413, 390);
			this.Load += new System.EventHandler(this.IqContactsPropertyPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSynchronization)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblIqid;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox tbIqid;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.CheckBox cbSync;
		private Commanigy.Controls.LabelLine lblAccounts;
		private Commanigy.Controls.LabelLine lblSynchronization;
		private System.Windows.Forms.LinkLabel llblForgotPassword;
		private System.Windows.Forms.PictureBox pbAccounts;
		private System.Windows.Forms.PictureBox pbSynchronization;
	}
}
