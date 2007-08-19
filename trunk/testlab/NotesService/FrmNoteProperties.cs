using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace NotesService
{
	/// <summary>
	/// Summary description for FrmNoteProperties.
	/// </summary>
	public class FrmNoteProperties : System.Windows.Forms.Form
	{
		
		private DataRow note_;
		private System.Windows.Forms.ComboBox cbxType;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.TextBox tbxDescription;
		private System.Windows.Forms.TextBox tbxTitle;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.TabControl tbcNotes;
		private System.Windows.Forms.TabPage tbpNoteProperties;
		private System.Windows.Forms.Button btnOk;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public FrmNoteProperties(DataRow note) {
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			note_ = note;
			
			InitializeNote();
		}
		
		public DataRow GetDataRow() {
			note_["title"] = tbxTitle.Text;
			note_["description"] = tbxDescription.Text;
			return note_;
		}
		
		protected void InitializeNote() {
			tbxTitle.Text = note_.IsNull("title") ? "" : (string)note_["title"];
			tbxDescription.Text = note_.IsNull("description") ? "" : (string)note_["description"];
			cbxType.SelectedIndex = -1;
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			
			base.Dispose(disposing);
		}
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbcNotes = new System.Windows.Forms.TabControl();
			this.tbpNoteProperties = new System.Windows.Forms.TabPage();
			this.cbxType = new System.Windows.Forms.ComboBox();
			this.lblType = new System.Windows.Forms.Label();
			this.tbxDescription = new System.Windows.Forms.TextBox();
			this.tbxTitle = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.tbcNotes.SuspendLayout();
			this.tbpNoteProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcNotes
			// 
			this.tbcNotes.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbcNotes.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.tbpNoteProperties});
			this.tbcNotes.Location = new System.Drawing.Point(8, 8);
			this.tbcNotes.Name = "tbcNotes";
			this.tbcNotes.SelectedIndex = 0;
			this.tbcNotes.Size = new System.Drawing.Size(296, 248);
			this.tbcNotes.TabIndex = 7;
			// 
			// tbpNoteProperties
			// 
			this.tbpNoteProperties.Controls.AddRange(new System.Windows.Forms.Control[] {
																							this.cbxType,
																							this.lblType,
																							this.tbxDescription,
																							this.tbxTitle,
																							this.lblDescription,
																							this.lblTitle});
			this.tbpNoteProperties.Location = new System.Drawing.Point(4, 22);
			this.tbpNoteProperties.Name = "tbpNoteProperties";
			this.tbpNoteProperties.Size = new System.Drawing.Size(288, 222);
			this.tbpNoteProperties.TabIndex = 0;
			this.tbpNoteProperties.Text = "Note Properties";
			// 
			// cbxType
			// 
			this.cbxType.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.cbxType.Items.AddRange(new object[] {
														 "Key Codes"});
			this.cbxType.Location = new System.Drawing.Point(8, 192);
			this.cbxType.Name = "cbxType";
			this.cbxType.Size = new System.Drawing.Size(272, 21);
			this.cbxType.TabIndex = 11;
			this.cbxType.Text = "comboBox1";
			// 
			// lblType
			// 
			this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblType.Location = new System.Drawing.Point(8, 176);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(272, 23);
			this.lblType.TabIndex = 10;
			this.lblType.Text = "&Category:";
			// 
			// tbxDescription
			// 
			this.tbxDescription.AcceptsReturn = true;
			this.tbxDescription.AcceptsTab = true;
			this.tbxDescription.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbxDescription.Location = new System.Drawing.Point(8, 72);
			this.tbxDescription.Multiline = true;
			this.tbxDescription.Name = "tbxDescription";
			this.tbxDescription.Size = new System.Drawing.Size(272, 96);
			this.tbxDescription.TabIndex = 9;
			this.tbxDescription.Text = "textBox2";
			// 
			// tbxTitle
			// 
			this.tbxTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbxTitle.Location = new System.Drawing.Point(8, 24);
			this.tbxTitle.Name = "tbxTitle";
			this.tbxTitle.Size = new System.Drawing.Size(272, 20);
			this.tbxTitle.TabIndex = 7;
			this.tbxTitle.Text = "textBox1";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblDescription.Location = new System.Drawing.Point(8, 56);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(272, 23);
			this.lblDescription.TabIndex = 8;
			this.lblDescription.Text = "&Description:";
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblTitle.Location = new System.Drawing.Point(8, 8);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(272, 23);
			this.lblTitle.TabIndex = 6;
			this.lblTitle.Text = "&Title:";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(240, 264);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(64, 23);
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "Close";
			// 
			// FrmNoteProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnOk,
																		  this.tbcNotes});
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.KeyPreview = true;
			this.Name = "FrmNoteProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Propeties";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmNoteProperties_KeyPress);
			this.Load += new System.EventHandler(this.FrmNoteProperties_Load);
			this.tbcNotes.ResumeLayout(false);
			this.tbpNoteProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e) {
		
		}

		private void FrmNoteProperties_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
			if (e.KeyChar == 27) {
				Close();
			}
		}

		private void FrmNoteProperties_Load(object sender, System.EventArgs e) {
			
		}

	}
}
