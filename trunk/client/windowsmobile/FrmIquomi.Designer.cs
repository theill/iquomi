namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	partial class FrmIquomi {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu MmMenu;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIquomi));
			this.MmMenu = new System.Windows.Forms.MainMenu();
			this.MiSignInMenu = new System.Windows.Forms.MenuItem();
			this.MiMeu = new System.Windows.Forms.MenuItem();
			this.MiSignIn = new System.Windows.Forms.MenuItem();
			this.MiSignOut = new System.Windows.Forms.MenuItem();
			this.MiSep1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.MiOptions = new System.Windows.Forms.MenuItem();
			this.PbBackground = new System.Windows.Forms.PictureBox();
			this.LblSignIn = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// MmMenu
			// 
			this.MmMenu.MenuItems.Add(this.MiSignInMenu);
			this.MmMenu.MenuItems.Add(this.MiMeu);
			// 
			// MiSignInMenu
			// 
			this.MiSignInMenu.Text = "Sign In";
			this.MiSignInMenu.Click += new System.EventHandler(this.MiSignIn_Click);
			// 
			// MiMeu
			// 
			this.MiMeu.MenuItems.Add(this.MiSignIn);
			this.MiMeu.MenuItems.Add(this.MiSignOut);
			this.MiMeu.MenuItems.Add(this.MiSep1);
			this.MiMeu.MenuItems.Add(this.menuItem2);
			this.MiMeu.MenuItems.Add(this.menuItem3);
			this.MiMeu.MenuItems.Add(this.MiOptions);
			this.MiMeu.Text = "Menu";
			// 
			// MiSignIn
			// 
			this.MiSignIn.Text = "&Sign In...";
			this.MiSignIn.Click += new System.EventHandler(this.MiSignIn_Click);
			// 
			// MiSignOut
			// 
			this.MiSignOut.Enabled = false;
			this.MiSignOut.Text = "Sig&n Out";
			this.MiSignOut.Click += new System.EventHandler(this.MiSignOut_Click);
			// 
			// MiSep1
			// 
			this.MiSep1.Text = "-";
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "&My Status";
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "-";
			// 
			// MiOptions
			// 
			this.MiOptions.Text = "&Options...";
			this.MiOptions.Click += new System.EventHandler(this.MiOptions_Click);
			// 
			// PbBackground
			// 
			this.PbBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.PbBackground.Image = ((System.Drawing.Image)(resources.GetObject("PbBackground.Image")));
			this.PbBackground.Location = new System.Drawing.Point(120, 148);
			this.PbBackground.Name = "PbBackground";
			this.PbBackground.Size = new System.Drawing.Size(120, 120);
			this.PbBackground.Click += new System.EventHandler(this.MiSignIn_Click);
			// 
			// LblSignIn
			// 
			this.LblSignIn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.LblSignIn.Location = new System.Drawing.Point(24, 24);
			this.LblSignIn.Name = "LblSignIn";
			this.LblSignIn.Size = new System.Drawing.Size(149, 20);
			this.LblSignIn.Text = "Tab here to sign in...";
			// 
			// FrmIquomi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.LblSignIn);
			this.Controls.Add(this.PbBackground);
			this.Menu = this.MmMenu;
			this.Name = "FrmIquomi";
			this.Text = "Iquomi";
			this.Closed += new System.EventHandler(this.FrmIquomi_Closed);
			this.Click += new System.EventHandler(this.MiSignIn_Click);
			this.Load += new System.EventHandler(this.FrmIquomi_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuItem MiMeu;
		private System.Windows.Forms.MenuItem MiSignIn;
		private System.Windows.Forms.MenuItem MiSignOut;
		private System.Windows.Forms.MenuItem MiOptions;
		private System.Windows.Forms.MenuItem MiSep1;
		private System.Windows.Forms.PictureBox PbBackground;
		private System.Windows.Forms.MenuItem MiSignInMenu;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Label LblSignIn;
	}
}