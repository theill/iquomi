using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NotesService {
	/// <summary>
	/// Summary description for FrmNote.
	/// </summary>
	public class FrmNote : System.Windows.Forms.Form {
		private System.Windows.Forms.TabControl tbcNotes;
		private System.Windows.Forms.TabPage tbpNoteProperties;
		private System.Windows.Forms.TextBox tbxDescription;
		private System.Windows.Forms.TextBox tbxTitle;
		private System.Windows.Forms.Label lblText;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnOk;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmNote() {
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
			this.tbcNotes = new System.Windows.Forms.TabControl();
			this.tbpNoteProperties = new System.Windows.Forms.TabPage();
			this.tbxDescription = new System.Windows.Forms.TextBox();
			this.tbxTitle = new System.Windows.Forms.TextBox();
			this.lblText = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.tbcNotes.SuspendLayout();
			this.tbpNoteProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcNotes
			// 
			this.tbcNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbcNotes.Controls.Add(this.tbpNoteProperties);
			this.tbcNotes.Location = new System.Drawing.Point(8, 8);
			this.tbcNotes.Name = "tbcNotes";
			this.tbcNotes.SelectedIndex = 0;
			this.tbcNotes.Size = new System.Drawing.Size(344, 296);
			this.tbcNotes.TabIndex = 9;
			// 
			// tbpNoteProperties
			// 
			this.tbpNoteProperties.Controls.Add(this.tbxDescription);
			this.tbpNoteProperties.Controls.Add(this.tbxTitle);
			this.tbpNoteProperties.Controls.Add(this.lblText);
			this.tbpNoteProperties.Controls.Add(this.lblTitle);
			this.tbpNoteProperties.Location = new System.Drawing.Point(4, 22);
			this.tbpNoteProperties.Name = "tbpNoteProperties";
			this.tbpNoteProperties.Size = new System.Drawing.Size(336, 270);
			this.tbpNoteProperties.TabIndex = 0;
			this.tbpNoteProperties.Text = "Properties";
			// 
			// tbxDescription
			// 
			this.tbxDescription.AcceptsReturn = true;
			this.tbxDescription.AcceptsTab = true;
			this.tbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxDescription.Location = new System.Drawing.Point(8, 72);
			this.tbxDescription.Multiline = true;
			this.tbxDescription.Name = "tbxDescription";
			this.tbxDescription.Size = new System.Drawing.Size(320, 192);
			this.tbxDescription.TabIndex = 9;
			this.tbxDescription.Text = "";
			// 
			// tbxTitle
			// 
			this.tbxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxTitle.Location = new System.Drawing.Point(8, 24);
			this.tbxTitle.Name = "tbxTitle";
			this.tbxTitle.Size = new System.Drawing.Size(320, 20);
			this.tbxTitle.TabIndex = 7;
			this.tbxTitle.Text = "";
			// 
			// lblText
			// 
			this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblText.Location = new System.Drawing.Point(8, 56);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(320, 23);
			this.lblText.TabIndex = 8;
			this.lblText.Text = "Text:";
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.Location = new System.Drawing.Point(8, 8);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(320, 23);
			this.lblTitle.TabIndex = 6;
			this.lblTitle.Text = "Title:";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(288, 312);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(64, 23);
			this.btnOk.TabIndex = 10;
			this.btnOk.Text = "Close";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// FrmNote
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 341);
			this.Controls.Add(this.tbcNotes);
			this.Controls.Add(this.btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.Name = "FrmNote";
			this.Text = "FrmNote";
			this.tbcNotes.ResumeLayout(false);
			this.tbpNoteProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e) {
			;
		}
	}
}
