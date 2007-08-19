namespace Commanigy.Iquomi.Client.SmartDevice {
	partial class Form1 {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.ctmServices = new System.Windows.Forms.ContextMenu();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.lvServices = new System.Windows.Forms.ListView();
			this.mnmApp = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// ctmServices
			// 
			this.ctmServices.MenuItems.Add(this.menuItem6);
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "Refresh";
			// 
			// lvServices
			// 
			this.lvServices.ContextMenu = this.ctmServices;
			this.lvServices.FullRowSelect = true;
			this.lvServices.Location = new System.Drawing.Point(12, 47);
			this.lvServices.Name = "lvServices";
			this.lvServices.Size = new System.Drawing.Size(216, 200);
			this.lvServices.TabIndex = 1;
			this.lvServices.View = System.Windows.Forms.View.List;
			// 
			// mnmApp
			// 
			this.mnmApp.MenuItems.Add(this.menuItem1);
			this.mnmApp.MenuItems.Add(this.menuItem2);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "";
			// 
			// menuItem2
			// 
			this.menuItem2.MenuItems.Add(this.menuItem3);
			this.menuItem2.MenuItems.Add(this.menuItem7);
			this.menuItem2.MenuItems.Add(this.menuItem8);
			this.menuItem2.MenuItems.Add(this.menuItem9);
			this.menuItem2.Text = "Tools";
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Sign In...";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Text = "Sign Out";
			// 
			// menuItem8
			// 
			this.menuItem8.Text = "-";
			// 
			// menuItem9
			// 
			this.menuItem9.Text = "Preferences...";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.lvServices);
			this.KeyPreview = true;
			this.Menu = this.mnmApp;
			this.Name = "Form1";
			this.Text = "Form1";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenu ctmServices;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ListView lvServices;
		private System.Windows.Forms.MainMenu mnmApp;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
	}
}