namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	partial class FrmSignIn {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.MiOK = new System.Windows.Forms.MenuItem();
			this.MiCancel = new System.Windows.Forms.MenuItem();
			this.TbxPassword = new System.Windows.Forms.TextBox();
			this.LblPassword = new System.Windows.Forms.Label();
			this.LblUsername = new System.Windows.Forms.Label();
			this.CbSavePassword = new System.Windows.Forms.CheckBox();
			this.CbUsername = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.MiOK);
			this.mainMenu1.MenuItems.Add(this.MiCancel);
			// 
			// MiOK
			// 
			this.MiOK.Text = "OK";
			this.MiOK.Click += new System.EventHandler(this.MiOK_Click);
			// 
			// MiCancel
			// 
			this.MiCancel.Text = "Cancel";
			this.MiCancel.Click += new System.EventHandler(this.MiCancel_Click);
			// 
			// TbxPassword
			// 
			this.TbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TbxPassword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.TbxPassword.Location = new System.Drawing.Point(8, 84);
			this.TbxPassword.Name = "TbxPassword";
			this.TbxPassword.PasswordChar = '*';
			this.TbxPassword.Size = new System.Drawing.Size(224, 19);
			this.TbxPassword.TabIndex = 2;
			this.TbxPassword.Text = "g5zTb4oNXBR1VWyUqhNdcQ==";
			// 
			// LblPassword
			// 
			this.LblPassword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.LblPassword.Location = new System.Drawing.Point(8, 65);
			this.LblPassword.Name = "LblPassword";
			this.LblPassword.Size = new System.Drawing.Size(100, 16);
			this.LblPassword.Text = "Password:";
			// 
			// LblUsername
			// 
			this.LblUsername.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.LblUsername.Location = new System.Drawing.Point(8, 14);
			this.LblUsername.Name = "LblUsername";
			this.LblUsername.Size = new System.Drawing.Size(100, 16);
			this.LblUsername.Text = "Username:";
			// 
			// CbSavePassword
			// 
			this.CbSavePassword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.CbSavePassword.Location = new System.Drawing.Point(8, 109);
			this.CbSavePassword.Name = "CbSavePassword";
			this.CbSavePassword.Size = new System.Drawing.Size(100, 20);
			this.CbSavePassword.TabIndex = 3;
			this.CbSavePassword.Text = "Save password";
			// 
			// CbUsername
			// 
			this.CbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CbUsername.DisplayMember = "petertheill";
			this.CbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.CbUsername.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.CbUsername.Items.Add("petertheill");
			this.CbUsername.Location = new System.Drawing.Point(8, 33);
			this.CbUsername.Name = "CbUsername";
			this.CbUsername.Size = new System.Drawing.Size(224, 20);
			this.CbUsername.TabIndex = 5;
			this.CbUsername.Text = "petertheill";
			// 
			// FrmSignIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.CbUsername);
			this.Controls.Add(this.CbSavePassword);
			this.Controls.Add(this.TbxPassword);
			this.Controls.Add(this.LblPassword);
			this.Controls.Add(this.LblUsername);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FrmSignIn";
			this.Text = "Iquomi - Sign In";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox TbxPassword;
		private System.Windows.Forms.Label LblPassword;
		private System.Windows.Forms.Label LblUsername;
		private System.Windows.Forms.CheckBox CbSavePassword;
		private System.Windows.Forms.ComboBox CbUsername;
		private System.Windows.Forms.MenuItem MiOK;
		private System.Windows.Forms.MenuItem MiCancel;
	}
}