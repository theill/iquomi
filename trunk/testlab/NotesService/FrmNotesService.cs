#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Xml;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Net.Sockets;

using Commanigy.Iquomi.Api;

#endregion

namespace NotesService {
	/// <summary>
	/// Summary description for FrmIquomiNotesService.
	/// </summary>
    public class FrmNotesService : System.Windows.Forms.Form {
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Data.DataTable dataTable1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mitAction;
		private System.Windows.Forms.MainMenu mmuNotes;
		private System.Windows.Forms.ContextMenu cmuNotes;
		private System.Data.DataSet dstNotes;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;
		private NotesListBox lbxNotes;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Data.DataColumn dataColumn3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ListView lvNotes;
		private System.Windows.Forms.ColumnHeader chTitle;
		private System.Windows.Forms.ColumnHeader chLastModified;
		private System.Windows.Forms.MenuItem mniActionOpen;
		private System.Windows.Forms.MenuItem mniActionNew;
		private System.Windows.Forms.MenuItem mniActionDelete;
		private System.Windows.Forms.MenuItem mniActionProperties;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public FrmNotesService() {
			InitializeComponent();
			SetupService();
			
			lbxNotes.DataSource = dstNotes;
			
			InitializeView();
		}
		
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
			this.lbxNotes = new NotesService.NotesListBox();
			this.cmuNotes = new System.Windows.Forms.ContextMenu();
			this.dstNotes = new System.Data.DataSet();
			this.dataTable1 = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.mmuNotes = new System.Windows.Forms.MainMenu();
			this.mitAction = new System.Windows.Forms.MenuItem();
			this.mniActionNew = new System.Windows.Forms.MenuItem();
			this.mniActionOpen = new System.Windows.Forms.MenuItem();
			this.mniActionDelete = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mniActionProperties = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.lvNotes = new System.Windows.Forms.ListView();
			this.chTitle = new System.Windows.Forms.ColumnHeader();
			this.chLastModified = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.dstNotes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			this.SuspendLayout();
			// 
			// lbxNotes
			// 
			this.lbxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbxNotes.ContextMenu = this.cmuNotes;
			this.lbxNotes.DisplayMember = "note.title";
			this.lbxNotes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lbxNotes.IntegralHeight = false;
			this.lbxNotes.Location = new System.Drawing.Point(8, 16);
			this.lbxNotes.Name = "lbxNotes";
			this.lbxNotes.Size = new System.Drawing.Size(200, 32);
			this.lbxNotes.TabIndex = 2;
			this.lbxNotes.ValueMember = "title";
			this.lbxNotes.Visible = false;
			this.lbxNotes.DoubleClick += new System.EventHandler(this.mitEditProperties_Click);
			this.lbxNotes.SelectedIndexChanged += new System.EventHandler(this.lbxNotes_SelectedIndexChanged);
			// 
			// cmuNotes
			// 
			this.cmuNotes.Popup += new System.EventHandler(this.cmuNotes_Popup);
			// 
			// dstNotes
			// 
			this.dstNotes.DataSetName = "notes";
			this.dstNotes.Locale = new System.Globalization.CultureInfo("en-US");
			this.dstNotes.Tables.AddRange(new System.Data.DataTable[] {
																		  this.dataTable1});
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn1,
																			  this.dataColumn2,
																			  this.dataColumn3});
			this.dataTable1.TableName = "note";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "title";
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "description";
			// 
			// dataColumn3
			// 
			this.dataColumn3.ColumnName = "type";
			// 
			// mmuNotes
			// 
			this.mmuNotes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mitAction});
			// 
			// mitAction
			// 
			this.mitAction.Index = 0;
			this.mitAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniActionNew,
																					  this.mniActionOpen,
																					  this.mniActionDelete,
																					  this.menuItem4,
																					  this.mniActionProperties,
																					  this.menuItem1,
																					  this.menuItem3,
																					  this.menuItem2,
																					  this.menuItem5,
																					  this.menuItem6});
			this.mitAction.Text = "&Action";
			this.mitAction.Click += new System.EventHandler(this.mitAction_Click);
			// 
			// mniActionNew
			// 
			this.mniActionNew.Index = 0;
			this.mniActionNew.Text = "&New Note...";
			this.mniActionNew.Click += new System.EventHandler(this.NewNote_Click);
			// 
			// mniActionOpen
			// 
			this.mniActionOpen.Index = 1;
			this.mniActionOpen.Text = "&Open";
			this.mniActionOpen.Click += new System.EventHandler(this.mniActionOpen_Click);
			// 
			// mniActionDelete
			// 
			this.mniActionDelete.Index = 2;
			this.mniActionDelete.Text = "&Delete";
			this.mniActionDelete.Click += new System.EventHandler(this.mitEditDelete_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// mniActionProperties
			// 
			this.mniActionProperties.DefaultItem = true;
			this.mniActionProperties.Index = 4;
			this.mniActionProperties.Text = "&Properties";
			this.mniActionProperties.Click += new System.EventHandler(this.mitEditProperties_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 5;
			this.menuItem1.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 6;
			this.menuItem3.Text = "&Synchronize";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 7;
			this.menuItem2.Text = "Load/Save";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 8;
			this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.F7;
			this.menuItem5.Text = "loaddoc";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 9;
			this.menuItem6.Text = "new_note";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// lvNotes
			// 
			this.lvNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.chTitle,
																					  this.chLastModified});
			this.lvNotes.ContextMenu = this.cmuNotes;
			this.lvNotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvNotes.FullRowSelect = true;
			this.lvNotes.Location = new System.Drawing.Point(0, 0);
			this.lvNotes.MultiSelect = false;
			this.lvNotes.Name = "lvNotes";
			this.lvNotes.Size = new System.Drawing.Size(216, 433);
			this.lvNotes.TabIndex = 5;
			this.lvNotes.View = System.Windows.Forms.View.Details;
			// 
			// chTitle
			// 
			this.chTitle.Text = "Title";
			this.chTitle.Width = 100;
			// 
			// chLastModified
			// 
			this.chLastModified.Text = "Last Modified";
			this.chLastModified.Width = 80;
			// 
			// FrmNotesService
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(216, 433);
			this.Controls.Add(this.lvNotes);
			this.Controls.Add(this.lbxNotes);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Menu = this.mmuNotes;
			this.Name = "FrmNotesService";
			this.Text = "My Notes";
			this.Load += new System.EventHandler(this.FrmIquomiNotesService_Load);
			((System.ComponentModel.ISupportInitialize)(this.dstNotes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// Perform additional setup for this service
		/// </summary>
		private void SetupService() {
//			URI += "notes";
		}
		
		/// <summary>
		/// Requests data from remote server and initializes notes listbox
		/// with loaded data.
		/// </summary>
		private void InitializeView() {

// [>]			XmlDocument doc = _request("/notes/");
			XmlDocument doc = new XmlDocument();
			
//			IquomiServices.NotesService ns = new IquomiServices.NotesService();
//			string xml = ns.ReadNote("//[@id=1]");
//			doc.LoadXml(xml);

			dstNotes.Clear();
			dstNotes.ReadXmlSchema("notes.xsd");
			
			dstNotes.ReadXml(new XmlNodeReader(doc));
			
			doc.Save("notes.xml");
			
			lbxNotes.DisplayMember = "note.title";
		}
		
		private void menuItem3_Click(object sender, System.EventArgs e) {
			
			// synchronize data with remote server
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(dstNotes.GetXml());
//			_post(xml, "/notes/");
			
			xml.Save("notes.xml");
		}
		
		private void mitEditNew_Click(object sender, System.EventArgs e) {
			
			FrmNoteProperties frmNote = new FrmNoteProperties(dstNotes.Tables["note"].NewRow());
			if (frmNote.ShowDialog(this) == DialogResult.OK) {
				lbxNotes.BeginUpdate();
				dstNotes.Tables["note"].Rows.Add(frmNote.GetDataRow());
				dstNotes.AcceptChanges();
				frmNote.Close();
				lbxNotes.EndUpdate();
			}
			
			frmNote.Dispose();

//          ServiceContainer.StatusBarText = "added note";
		}
		
		private void mitEditDelete_Click(object sender, System.EventArgs e) {
			if (lbxNotes.SelectedIndex == -1) {
				return;
			}
			
			lbxNotes.BeginUpdate();
			DataRow row = dstNotes.Tables["note"].Rows[lbxNotes.SelectedIndex];
			row.Delete();
			dstNotes.AcceptChanges();
			lbxNotes.EndUpdate();
			
//			ServiceContainer.StatusBarText = "deleted note";
		}
		
		private void mitEditProperties_Click(object sender, System.EventArgs e) {
			FrmNoteProperties frmNote = new FrmNoteProperties(dstNotes.Tables["note"].Rows[lbxNotes.SelectedIndex]);
			if (frmNote.ShowDialog(this) == DialogResult.OK) {
				lbxNotes.BeginUpdate();
				DataRow row = dstNotes.Tables["note"].Rows[lbxNotes.SelectedIndex];
				row = frmNote.GetDataRow();
				dstNotes.AcceptChanges();
				frmNote.Close();
				lbxNotes.EndUpdate();
			}
			
			frmNote.Dispose();
		}
		
		private void FrmIquomiNotesService_Load(object sender, System.EventArgs e) {
			// build context menu
			cmuNotes.MenuItems.Add(mniActionNew.CloneMenu());
			cmuNotes.MenuItems.Add(mniActionOpen.CloneMenu());
			cmuNotes.MenuItems.Add(mniActionDelete.CloneMenu());
			cmuNotes.MenuItems.Add(new MenuItem("-"));
			cmuNotes.MenuItems.Add(mniActionProperties.CloneMenu());

			IServiceContainer p = ServiceContainer;
			if (p != null) {
				p.SignedIn += new SignInEventHandler(OnSignIn);
				p.SignedOut += new SignOutEventHandler(OnSignOut);
			}

		}
		
		protected void OnSignIn(object sender, SignInEventArgs e) {
			Console.Out.WriteLine("Notes says: The user signed in");
		}

		protected void OnSignOut(object sender, SignOutEventArgs e) {
			Console.Out.WriteLine("Notes says: The user signed out!");
		}

		private void menuItem5_Click(object sender, System.EventArgs e) {
			XslTransform xslt = new XslTransform();
			xslt.Load("notes.xsl");
			xslt.Transform("notes.xml", "notes.html", null);

//			object o = null;
//			FileInfo fi = new FileInfo("notes.html");
//			axWebBrowser1.Navigate("file://" + fi.FullName, ref o, ref o, ref o, ref o);
		}

		private void lbxNotes_SelectedIndexChanged(object sender, System.EventArgs e) {
		
		}

		private void menuItem6_Click(object sender, System.EventArgs e) {
		}

//		private void axWebBrowser1_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e) {
//			string url = (string)e.uRL;
//			MessageBox.Show(url);
//			if (url.StartsWith("iquomi://")) {
//				MessageBox.Show("execute some code");
//				
//				e.cancel = true;
//			}
//		}

		private void menuItem2_Click(object sender, System.EventArgs e) {
		
		}

		private void axWebBrowser1_Enter(object sender, System.EventArgs e) {
		
		}

		private void mitAction_Click(object sender, System.EventArgs e) {
		
		}

		private void cmuNotes_Popup(object sender, System.EventArgs e) {

		}

		private void NewNote_Click(object sender, System.EventArgs e) {

//			FrmNote f = new FrmNote();
//			try {
//				IquomiNotesService.Note note = new IquomiNotesService.Note();
//				f.Note = note;
//				if (f.ShowDialog() == DialogResult.OK) {
//					IquomiNotesService.NotesService service = new IquomiNotesService.NotesService();
//					
////					note = service.create(note);
//					note.StoreId = "store id'et";
//					note.Text = "tekst";
//					note = (IquomiNotesService.Note)service.createX(note);
//
//					ServiceContainer.StatusBarText = "added note and got store id " + note.StoreId;
//				}
//			}
//			finally {
//				f.Dispose();
//			}
			
		}

		private void mniActionOpen_Click(object sender, System.EventArgs e) {
		
		}

	}

} // > namespace NotesService

// >> EOF