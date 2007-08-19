using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace NotesService {
	/// <summary>
	/// Summary description for FrmCreate.
	/// </summary>
	public class FrmCreate : System.Windows.Forms.Form {
//		private AxSHDocVw.AxWebBrowser wb;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmCreate() {
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
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmCreate));
//			this.wb = new AxSHDocVw.AxWebBrowser();
//			((System.ComponentModel.ISupportInitialize)(this.wb)).BeginInit();
//			this.SuspendLayout();
//			// 
//			// wb
//			// 
//			this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
//			this.wb.Enabled = true;
//			this.wb.Location = new System.Drawing.Point(0, 0);
//			this.wb.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wb.OcxState")));
//			this.wb.Size = new System.Drawing.Size(292, 266);
//			this.wb.TabIndex = 4;
//			this.wb.Enter += new System.EventHandler(this.wb_Enter);
//			this.wb.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
			// 
			// FrmCreate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
//			this.Controls.Add(this.wb);
			this.Name = "FrmCreate";
			this.Text = "FrmCreate";
//			((System.ComponentModel.ISupportInitialize)(this.wb)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void LoadXml(string xml) {
//			try {
//				XslTransform xslt = new XslTransform();
//				xslt.Load("note.xslt");
//				xslt.Transform("note.xml", "note.html", null);
//				
//				object o = null;
//				FileInfo fi = new FileInfo("note.html");
//				FileInfo fi = new FileInfo("note.xml");
//				wb.Navigate("file://" + fi.FullName, ref o, ref o, ref o, ref o);
//			}
//			catch (Exception e) {
//				;
//			}
		}

		private void wb_Enter(object sender, System.EventArgs e) {
		
		}
	}
}