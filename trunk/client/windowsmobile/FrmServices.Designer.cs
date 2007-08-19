namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	partial class FrmServices {
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.LvServices = new System.Windows.Forms.ListView();
			this.ChServiceName = new System.Windows.Forms.ColumnHeader();
			this.CmServices = new System.Windows.Forms.ContextMenu();
			this.MiActivate = new System.Windows.Forms.MenuItem();
			this.ChPath = new System.Windows.Forms.ColumnHeader();
			this.MiDeactivate = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// LvServices
			// 
			this.LvServices.Columns.Add(this.ChServiceName);
			this.LvServices.Columns.Add(this.ChPath);
			this.LvServices.ContextMenu = this.CmServices;
			this.LvServices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LvServices.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.LvServices.FullRowSelect = true;
			listViewItem1.Text = "IqSms";
			listViewItem1.SubItems.Add("\\Storage Card\\Iquomi Plugins\\IqSms");
			listViewItem2.Text = "IqAlerts";
			listViewItem2.SubItems.Add("\\Storage Card\\Iquomi Plugins\\IqAlerts");
			this.LvServices.Items.Add(listViewItem1);
			this.LvServices.Items.Add(listViewItem2);
			this.LvServices.Location = new System.Drawing.Point(0, 0);
			this.LvServices.Name = "LvServices";
			this.LvServices.Size = new System.Drawing.Size(240, 268);
			this.LvServices.TabIndex = 0;
			this.LvServices.View = System.Windows.Forms.View.Details;
			// 
			// ChServiceName
			// 
			this.ChServiceName.Text = "Service";
			this.ChServiceName.Width = 128;
			// 
			// CmServices
			// 
			this.CmServices.MenuItems.Add(this.MiActivate);
			this.CmServices.MenuItems.Add(this.MiDeactivate);
			// 
			// MiActivate
			// 
			this.MiActivate.Text = "&Activate";
			this.MiActivate.Click += new System.EventHandler(this.MiActivate_Click);
			// 
			// ChPath
			// 
			this.ChPath.Text = "Path";
			this.ChPath.Width = 96;
			// 
			// MiDeactivate
			// 
			this.MiDeactivate.Text = "&Deactivate";
			this.MiDeactivate.Click += new System.EventHandler(this.MiDeactivate_Click);
			// 
			// FrmServices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.LvServices);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.Menu = this.mainMenu1;
			this.Name = "FrmServices";
			this.Text = "Iquomi";
			this.Load += new System.EventHandler(this.FrmServices_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView LvServices;
		private System.Windows.Forms.ColumnHeader ChServiceName;
		private System.Windows.Forms.ContextMenu CmServices;
		private System.Windows.Forms.MenuItem MiActivate;
		private System.Windows.Forms.ColumnHeader ChPath;
		private System.Windows.Forms.MenuItem MiDeactivate;
	}
}