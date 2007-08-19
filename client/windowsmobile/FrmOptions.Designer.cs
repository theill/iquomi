namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	partial class FrmOptions {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.LblOptions = new System.Windows.Forms.Label();
			this.TpGeneral = new System.Windows.Forms.TabPage();
			this.LblPlugins = new System.Windows.Forms.Label();
			this.CbPlugins = new System.Windows.Forms.ComboBox();
			this.TcOptions = new System.Windows.Forms.TabControl();
			this.MmMenu = new System.Windows.Forms.MainMenu();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.TpGeneral.SuspendLayout();
			this.TcOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.LblOptions);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 32);
			// 
			// LblOptions
			// 
			this.LblOptions.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.LblOptions.ForeColor = System.Drawing.SystemColors.MenuText;
			this.LblOptions.Location = new System.Drawing.Point(3, 9);
			this.LblOptions.Name = "LblOptions";
			this.LblOptions.Size = new System.Drawing.Size(121, 20);
			this.LblOptions.Text = "Options";
			// 
			// TpGeneral
			// 
			this.TpGeneral.Controls.Add(this.LblPlugins);
			this.TpGeneral.Controls.Add(this.CbPlugins);
			this.TpGeneral.Location = new System.Drawing.Point(0, 0);
			this.TpGeneral.Name = "TpGeneral";
			this.TpGeneral.Size = new System.Drawing.Size(240, 213);
			this.TpGeneral.Text = "General";
			// 
			// LblPlugins
			// 
			this.LblPlugins.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.LblPlugins.Location = new System.Drawing.Point(8, 10);
			this.LblPlugins.Name = "LblPlugins";
			this.LblPlugins.Size = new System.Drawing.Size(100, 16);
			this.LblPlugins.Text = "Plugins:";
			// 
			// CbPlugins
			// 
			this.CbPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CbPlugins.Items.Add("\\Storage Card\\Iquomi Plugins");
			this.CbPlugins.Location = new System.Drawing.Point(8, 29);
			this.CbPlugins.Name = "CbPlugins";
			this.CbPlugins.Size = new System.Drawing.Size(224, 22);
			this.CbPlugins.TabIndex = 0;
			// 
			// TcOptions
			// 
			this.TcOptions.Controls.Add(this.TpGeneral);
			this.TcOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TcOptions.Location = new System.Drawing.Point(0, 32);
			this.TcOptions.Name = "TcOptions";
			this.TcOptions.SelectedIndex = 0;
			this.TcOptions.Size = new System.Drawing.Size(240, 236);
			this.TcOptions.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 31);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(240, 1);
			// 
			// FrmOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.TcOptions);
			this.Controls.Add(this.panel1);
			this.Menu = this.MmMenu;
			this.Name = "FrmOptions";
			this.Text = "Iquomi";
			this.panel1.ResumeLayout(false);
			this.TpGeneral.ResumeLayout(false);
			this.TcOptions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label LblOptions;
		private System.Windows.Forms.TabPage TpGeneral;
		private System.Windows.Forms.TabControl TcOptions;
		private System.Windows.Forms.MainMenu MmMenu;
		private System.Windows.Forms.ComboBox CbPlugins;
		private System.Windows.Forms.Label LblPlugins;
		private System.Windows.Forms.Panel panel2;
	}
}