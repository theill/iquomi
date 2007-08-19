using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// Summary description for FrmAbout.
	/// </summary>
	public class FrmAbout : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnOk;
		private Commanigy.Controls.GradientPanel gpnlHeader;
		private System.Windows.Forms.Label lblProgramName;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAbout() {
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmAbout));
			this.btnOk = new System.Windows.Forms.Button();
			this.gpnlHeader = new Commanigy.Controls.GradientPanel();
			this.lblProgramName = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gpnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOk.Location = new System.Drawing.Point(308, 260);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			// 
			// gpnlHeader
			// 
			this.gpnlHeader.Controls.Add(this.pictureBox1);
			this.gpnlHeader.Controls.Add(this.lblProgramName);
			this.gpnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.gpnlHeader.Location = new System.Drawing.Point(0, 0);
			this.gpnlHeader.Name = "gpnlHeader";
			this.gpnlHeader.Size = new System.Drawing.Size(392, 80);
			this.gpnlHeader.TabIndex = 2;
			// 
			// lblProgramName
			// 
			this.lblProgramName.BackColor = System.Drawing.Color.Transparent;
			this.lblProgramName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblProgramName.ForeColor = System.Drawing.Color.White;
			this.lblProgramName.Location = new System.Drawing.Point(88, 16);
			this.lblProgramName.Name = "lblProgramName";
			this.lblProgramName.Size = new System.Drawing.Size(72, 23);
			this.lblProgramName.TabIndex = 0;
			this.lblProgramName.Text = "Iquomi";
			// 
			// linkLabel1
			// 
			this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(48, 26);
			this.linkLabel1.Location = new System.Drawing.Point(40, 152);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(344, 40);
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "This product is licensed under the terms of the End-User License Agreement to:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 192);
			this.label1.Name = "label1";
			this.label1.TabIndex = 4;
			this.label1.Text = "Peter Theill";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(56, 208);
			this.label2.Name = "label2";
			this.label2.TabIndex = 5;
			this.label2.Text = "Commanigy";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// FrmAbout
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnOk;
			this.ClientSize = new System.Drawing.Size(392, 293);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.gpnlHeader);
			this.Controls.Add(this.btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAbout";
			this.Text = "About...";
			this.gpnlHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	}
}
