#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Commanigy.Iquomi.Client.IqProfileRef;

#endregion

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// Summary description for FrmProfileName.
	/// </summary>
	public class FrmProfileName : System.Windows.Forms.Form {
		private System.Windows.Forms.ComboBox cbSuffix;
		private System.Windows.Forms.ComboBox cbTitle;
		private System.Windows.Forms.TextBox tbSurName;
		private System.Windows.Forms.TextBox tbGivenName;
		private System.Windows.Forms.Label lblFirstName;
		private System.Windows.Forms.GroupBox gbNameDetails;
		private System.Windows.Forms.TextBox tbMiddleName;
		private System.Windows.Forms.Label lblMiddleName;
		private System.Windows.Forms.Label lblSuffix;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSurName;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;

		private NameType profileName;
		
		/// <summary>
		/// Property ProfileName (nameType)
		/// </summary>
		public NameType ProfileName {
			get {
				if (profileName.Title == null) {
					profileName.Title = new LocalizableString();
				}

				if (profileName.GivenName == null) {
					profileName.GivenName = new LocalizableString();
				}

				if (profileName.MiddleName == null) {
					profileName.MiddleName = new LocalizableString();
				}

				if (profileName.SurName == null) {
					profileName.SurName = new LocalizableString();
				}

				if (profileName.Suffix == null) {
					profileName.Suffix = new LocalizableString();
				}

				profileName.Title.Value = cbTitle.SelectedValue as string;
				profileName.GivenName.Value = tbGivenName.Text as string;
				profileName.MiddleName.Value = tbMiddleName.Text as string;
				profileName.SurName.Value = tbSurName.Text as string;
				profileName.Suffix.Value = cbSuffix.SelectedValue as string;
				return this.profileName;
			}

			set {
				this.profileName = value;
				this.cbTitle.SelectedText = (profileName.Title != null && profileName.Title.Value != null) ? profileName.Title.Value : "";
				this.tbGivenName.Text = (profileName.GivenName != null) ? profileName.GivenName.Value : "";
				this.tbMiddleName.Text = (profileName.MiddleName != null) ? profileName.MiddleName.Value : "";
				this.tbSurName.Text = (profileName.SurName != null) ? profileName.SurName.Value : "";
				this.cbSuffix.SelectedText = (profileName.Suffix != null && profileName.Suffix.Value != null) ? profileName.Suffix.Value : "";
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmProfileName() {
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
			this.gbNameDetails = new System.Windows.Forms.GroupBox();
			this.tbMiddleName = new System.Windows.Forms.TextBox();
			this.lblMiddleName = new System.Windows.Forms.Label();
			this.cbSuffix = new System.Windows.Forms.ComboBox();
			this.lblSuffix = new System.Windows.Forms.Label();
			this.cbTitle = new System.Windows.Forms.ComboBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.tbSurName = new System.Windows.Forms.TextBox();
			this.lblSurName = new System.Windows.Forms.Label();
			this.tbGivenName = new System.Windows.Forms.TextBox();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbNameDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbNameDetails
			// 
			this.gbNameDetails.Controls.Add(this.tbMiddleName);
			this.gbNameDetails.Controls.Add(this.lblMiddleName);
			this.gbNameDetails.Controls.Add(this.cbSuffix);
			this.gbNameDetails.Controls.Add(this.lblSuffix);
			this.gbNameDetails.Controls.Add(this.cbTitle);
			this.gbNameDetails.Controls.Add(this.lblTitle);
			this.gbNameDetails.Controls.Add(this.tbSurName);
			this.gbNameDetails.Controls.Add(this.lblSurName);
			this.gbNameDetails.Controls.Add(this.tbGivenName);
			this.gbNameDetails.Controls.Add(this.lblFirstName);
			this.gbNameDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbNameDetails.Location = new System.Drawing.Point(8, 8);
			this.gbNameDetails.Name = "gbNameDetails";
			this.gbNameDetails.Size = new System.Drawing.Size(248, 160);
			this.gbNameDetails.TabIndex = 0;
			this.gbNameDetails.TabStop = false;
			this.gbNameDetails.Text = "Name details";
			// 
			// tbMiddleName
			// 
			this.tbMiddleName.Location = new System.Drawing.Point(88, 72);
			this.tbMiddleName.Name = "tbMiddleName";
			this.tbMiddleName.Size = new System.Drawing.Size(144, 20);
			this.tbMiddleName.TabIndex = 5;
			this.tbMiddleName.Text = "";
			// 
			// lblMiddleName
			// 
			this.lblMiddleName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblMiddleName.Location = new System.Drawing.Point(16, 72);
			this.lblMiddleName.Name = "lblMiddleName";
			this.lblMiddleName.Size = new System.Drawing.Size(64, 23);
			this.lblMiddleName.TabIndex = 4;
			this.lblMiddleName.Text = "Middle:";
			this.lblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbSuffix
			// 
			this.cbSuffix.ItemHeight = 13;
			this.cbSuffix.Items.AddRange(new object[] {
														  "I",
														  "II",
														  "III",
														  "Jr.",
														  "Sr."});
			this.cbSuffix.Location = new System.Drawing.Point(88, 120);
			this.cbSuffix.Name = "cbSuffix";
			this.cbSuffix.Size = new System.Drawing.Size(144, 21);
			this.cbSuffix.TabIndex = 9;
			// 
			// lblSuffix
			// 
			this.lblSuffix.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblSuffix.Location = new System.Drawing.Point(16, 120);
			this.lblSuffix.Name = "lblSuffix";
			this.lblSuffix.Size = new System.Drawing.Size(64, 23);
			this.lblSuffix.TabIndex = 8;
			this.lblSuffix.Text = "Suffix:";
			this.lblSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbTitle
			// 
			this.cbTitle.ItemHeight = 13;
			this.cbTitle.Items.AddRange(new object[] {
														 "Dr.",
														 "Miss",
														 "Mr.",
														 "Mrs.",
														 "Ms.",
														 "Prof."});
			this.cbTitle.Location = new System.Drawing.Point(88, 24);
			this.cbTitle.Name = "cbTitle";
			this.cbTitle.Size = new System.Drawing.Size(144, 21);
			this.cbTitle.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblTitle.Location = new System.Drawing.Point(16, 24);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(64, 23);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title:";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSurName
			// 
			this.tbSurName.Location = new System.Drawing.Point(88, 96);
			this.tbSurName.Name = "tbSurName";
			this.tbSurName.Size = new System.Drawing.Size(144, 20);
			this.tbSurName.TabIndex = 7;
			this.tbSurName.Text = "";
			// 
			// lblSurName
			// 
			this.lblSurName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblSurName.Location = new System.Drawing.Point(16, 96);
			this.lblSurName.Name = "lblSurName";
			this.lblSurName.Size = new System.Drawing.Size(64, 23);
			this.lblSurName.TabIndex = 6;
			this.lblSurName.Text = "Last:";
			this.lblSurName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbGivenName
			// 
			this.tbGivenName.Location = new System.Drawing.Point(88, 48);
			this.tbGivenName.Name = "tbGivenName";
			this.tbGivenName.Size = new System.Drawing.Size(144, 20);
			this.tbGivenName.TabIndex = 3;
			this.tbGivenName.Text = "";
			// 
			// lblFirstName
			// 
			this.lblFirstName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblFirstName.Location = new System.Drawing.Point(16, 48);
			this.lblFirstName.Name = "lblFirstName";
			this.lblFirstName.Size = new System.Drawing.Size(64, 23);
			this.lblFirstName.TabIndex = 2;
			this.lblFirstName.Text = "First:";
			this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(264, 16);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(264, 44);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// FrmProfileName
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 176);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.gbNameDetails);
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmProfileName";
			this.ShowInTaskbar = false;
			this.Text = "Full Name";
			this.gbNameDetails.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
