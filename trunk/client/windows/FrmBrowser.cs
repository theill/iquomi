using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Commanigy.Iquomi.Client {
	public class FrmBrowser : System.Windows.Forms.Form/*ServiceForm */{
		private AxSHDocVw.AxWebBrowser browser;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components = null;

		public FrmBrowser() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmBrowser));
			this.browser = new AxSHDocVw.AxWebBrowser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.browser)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// browser
			// 
			this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browser.Enabled = true;
			this.browser.Location = new System.Drawing.Point(0, 43);
			this.browser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("browser.OcxState")));
			this.browser.Size = new System.Drawing.Size(232, 410);
			this.browser.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(232, 43);
			this.panel1.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(8, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(176, 21);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "http://www.iquomi.com/client.aspx";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(192, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 24);
			this.button1.TabIndex = 3;
			this.button1.Text = "Go!";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrmBrowser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(232, 453);
			this.Controls.Add(this.browser);
			this.Controls.Add(this.panel1);
			this.Name = "FrmBrowser";
			this.Text = "Quick Browser";
			((System.ComponentModel.ISupportInitialize)(this.browser)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e) {
			System.Object nullObject = 0;
			string str = "";
			System.Object nullObjStr = str;
			Cursor.Current = Cursors.WaitCursor;
			browser.Navigate(textBox1.Text, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr);
			Cursor.Current = Cursors.Default;
		}

	}
}

