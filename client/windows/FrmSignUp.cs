using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Commanigy.Iquomi.Client {
	public class FrmSignUp : Commanigy.Controls.FrmWizard {
		private System.ComponentModel.IContainer components = null;

		public FrmSignUp() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			// 
			// pnlHeader
			// 
			this.pnlHeader.Name = "pnlHeader";
			// 
			// btnBack
			// 
			this.btnBack.Name = "btnBack";
			// 
			// btnNext
			// 
			this.btnNext.Name = "btnNext";
			// 
			// btnDone
			// 
			this.btnDone.Name = "btnDone";
			// 
			// pbIcon
			// 
			this.pbIcon.Name = "pbIcon";
			// 
			// lblDescription
			// 
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Text = "By registering for an Iquomi account you will be able to use this account wheneve" +
				"r you need to access an Iquomi service.";
			// 
			// lblTitle
			// 
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Text = "Sign up for a new Iquomi account";
			// 
			// FrmSignUp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(482, 375);
			this.Name = "FrmSignUp";

		}
		#endregion
	}
}