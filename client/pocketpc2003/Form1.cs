using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commanigy.Iquomi.Client.SmartDevice {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if ((e.KeyCode == System.Windows.Forms.Keys.Up)) {
				// Rocker Up
				// Up
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Down)) {
				// Rocker Down
				// Down
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Left)) {
				// Left
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Right)) {
				// Right
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
				// Enter
			}

		}

		private void menuItem3_Click(object sender, EventArgs e) {

		}
	}
}