#region Using directives

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

using Commanigy.Iquomi.Sdk.WindowsMobile;

#endregion

namespace Commanigy.Iquomi.Client.SmartDevice.WindowsMobile {
	public partial class FrmServices : Form {
		private const string PLUGIN_ASSEMBLY_FILENAME = @"{0}\Commanigy.Iquomi.Services.{1}.Client.WindowsMobile.dll";

		public FrmServices() {
			InitializeComponent();
		}

		private void FrmServices_Load(object sender, EventArgs e) {
			// TODO: load subscriptions and look for installed plugins

			LvServices.Items.Clear();
			foreach (string p in Directory.GetDirectories(@"\Storage Card\Iquomi Plugins")) {
				ListViewItem li = new ListViewItem(new string[] { Path.GetFileName(p), p });

				if (PluginManager.Instance.IsLoaded(string.Format(PLUGIN_ASSEMBLY_FILENAME, p, Path.GetFileName(p)))) {
					li.ForeColor = SystemColors.Highlight;
				}
				
				LvServices.Items.Add(li);
			}
		}

		private void MiActivate_Click(object sender, EventArgs e) {
			foreach (int index in LvServices.SelectedIndices) {
				string serviceName = LvServices.Items[index].Text;
				string assemblyFile = string.Format(PLUGIN_ASSEMBLY_FILENAME, LvServices.Items[index].SubItems[1].Text, serviceName);

				IPlugin plugin = PluginManager.Instance.LoadPlugin(serviceName, assemblyFile, this.Owner as IPluginContext);
				if (plugin != null) {
					LvServices.Items[index].ForeColor = SystemColors.Highlight;
				}
			}
		}

		private void MiDeactivate_Click(object sender, EventArgs e) {
			foreach (int index in LvServices.SelectedIndices) {
				string serviceName = LvServices.Items[index].Text;
				string assemblyFile = string.Format(PLUGIN_ASSEMBLY_FILENAME, LvServices.Items[index].SubItems[1].Text, serviceName);

				PluginManager.Instance.UnloadPlugin(assemblyFile, this.Owner as IPluginContext);
				LvServices.Items[index].ForeColor = SystemColors.WindowText;
			}
		}
	}
}