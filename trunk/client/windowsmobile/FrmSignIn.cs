#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	public partial class FrmSignIn : Form {
		#region Properties
		
		public string Iqid {
			get {
				return CbUsername.SelectedItem as string;
			}
		}

		public string Password {
			get {
				// TODO: to MD5
				return TbxPassword.Text;
			}
		}

		#endregion

		public FrmSignIn() {
			InitializeComponent();
		}

		private void MiOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void MiCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

	}
}