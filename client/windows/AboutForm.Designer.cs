namespace Commanigy.Iquomi.Client {
	partial class AboutForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblProgramName = new System.Windows.Forms.Label();
			this.gpnlHeader = new Commanigy.Controls.GradientPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.btnOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.gpnlHeader.SuspendLayout();
			this.SuspendLayout();
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
			// lblProgramName
			// 
			this.lblProgramName.BackColor = System.Drawing.Color.Transparent;
			this.lblProgramName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProgramName.ForeColor = System.Drawing.Color.White;
			this.lblProgramName.Location = new System.Drawing.Point(88, 16);
			this.lblProgramName.Name = "lblProgramName";
			this.lblProgramName.Size = new System.Drawing.Size(72, 23);
			this.lblProgramName.TabIndex = 0;
			this.lblProgramName.Text = "Iquomi";
			// 
			// gpnlHeader
			// 
			this.gpnlHeader.Controls.Add(this.pictureBox1);
			this.gpnlHeader.Controls.Add(this.lblProgramName);
			this.gpnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.gpnlHeader.Location = new System.Drawing.Point(0, 0);
			this.gpnlHeader.Name = "gpnlHeader";
			this.gpnlHeader.Size = new System.Drawing.Size(392, 80);
			this.gpnlHeader.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(52, 204);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Commanigy";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(52, 188);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Peter Theill";
			// 
			// linkLabel1
			// 
			this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(48, 26);
			this.linkLabel1.Location = new System.Drawing.Point(36, 148);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(344, 40);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "This product is licensed under the terms of the End-User License Agreement to:";
			this.linkLabel1.UseCompatibleTextRendering = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOk.Location = new System.Drawing.Point(304, 256);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "OK";
			// 
			// AboutForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOk;
			this.ClientSize = new System.Drawing.Size(392, 293);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.gpnlHeader);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Text = "About...";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.gpnlHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblProgramName;
		private Commanigy.Controls.GradientPanel gpnlHeader;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button btnOk;
	}
}