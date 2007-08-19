using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// Displays window showing available Iquomi services.
	/// </summary>
	public class FrmToolbox : System.Windows.Forms.Form {
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.Panel pnlToolbarCaption;
		private System.Windows.Forms.Label lblToolbarCaption;
		private System.Windows.Forms.Label lblToolbarCaptionDescription;
		private System.Windows.Forms.MenuItem mniFileExit;
		private System.Windows.Forms.MenuItem mniHelpAbout;
		private System.Windows.Forms.ListView ltvServices;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.IContainer components;

		public FrmToolbox() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			ltvServices.Clear();
			/*
						ServicesListViewItem item = null;

						item = new ServicesListViewItem();
						item.Name = "Notes";
						item.URI = "http://localhost:89/iquomi/notes";
						item.Form = @"D:\Documents and Settings\Administrator\My Documents\Visual Studio Projects\RequestSOAPServer\NotesService\bin\Debug\NotesService.dll";
						item.Text = item.Name;
						item.ImageIndex = 0;
						ltvServices.Items.Add(item);
			
						item = new ServicesListViewItem();
						item.Name = "Contacts";
						item.URI = "http://localhost:89/iquomi/contacts";
						item.Form = "FrmContactsServices";
						item.Text = item.Name;
						item.ImageIndex = 1;
						ltvServices.Items.Add(item);
			*/			
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmToolbox));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Notes", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, 0);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Contacts", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, 1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "CD-ROM Collection", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, 2);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Passwords", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, 1);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Favorites", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, 0);
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mniFileExit = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mniHelpAbout = new System.Windows.Forms.MenuItem();
			this.pnlToolbarCaption = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblToolbarCaptionDescription = new System.Windows.Forms.Label();
			this.lblToolbarCaption = new System.Windows.Forms.Label();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.ltvServices = new System.Windows.Forms.ListView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.pnlToolbarCaption.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuFile,
																					 this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mniFileExit});
			this.mnuFile.Text = "&File";
			// 
			// mniFileExit
			// 
			this.mniFileExit.Index = 0;
			this.mniFileExit.Text = "E&xit";
			this.mniFileExit.Click += new System.EventHandler(this.mniFileExit_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 1;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mniHelpAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mniHelpAbout
			// 
			this.mniHelpAbout.Index = 0;
			this.mniHelpAbout.Text = "&About...";
			// 
			// pnlToolbarCaption
			// 
			this.pnlToolbarCaption.BackColor = System.Drawing.SystemColors.Desktop;
			this.pnlToolbarCaption.Controls.AddRange(new System.Windows.Forms.Control[] {
																							this.textBox1,
																							this.lblToolbarCaptionDescription,
																							this.lblToolbarCaption});
			this.pnlToolbarCaption.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlToolbarCaption.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.pnlToolbarCaption.Name = "pnlToolbarCaption";
			this.pnlToolbarCaption.Size = new System.Drawing.Size(416, 48);
			this.pnlToolbarCaption.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(272, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(136, 21);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "/notes/";
			// 
			// lblToolbarCaptionDescription
			// 
			this.lblToolbarCaptionDescription.BackColor = System.Drawing.Color.Transparent;
			this.lblToolbarCaptionDescription.Location = new System.Drawing.Point(8, 24);
			this.lblToolbarCaptionDescription.Name = "lblToolbarCaptionDescription";
			this.lblToolbarCaptionDescription.Size = new System.Drawing.Size(456, 23);
			this.lblToolbarCaptionDescription.TabIndex = 1;
			this.lblToolbarCaptionDescription.Text = "Pick a service below to start working on your managed data.";
			// 
			// lblToolbarCaption
			// 
			this.lblToolbarCaption.AutoSize = true;
			this.lblToolbarCaption.BackColor = System.Drawing.Color.Transparent;
			this.lblToolbarCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblToolbarCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblToolbarCaption.Location = new System.Drawing.Point(8, 8);
			this.lblToolbarCaption.Name = "lblToolbarCaption";
			this.lblToolbarCaption.Size = new System.Drawing.Size(150, 14);
			this.lblToolbarCaption.TabIndex = 0;
			this.lblToolbarCaption.Text = "Available Iquomi services";
			this.lblToolbarCaption.UseMnemonic = false;
			// 
			// notifyIcon
			// 
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "IQatium Toolbox";
			this.notifyIcon.Visible = true;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ltvServices
			// 
			this.ltvServices.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.ltvServices.FullRowSelect = true;
			this.ltvServices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.ltvServices.HideSelection = false;
			this.ltvServices.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																						listViewItem1,
																						listViewItem2,
																						listViewItem3,
																						listViewItem4,
																						listViewItem5});
			this.ltvServices.LargeImageList = this.imageList;
			this.ltvServices.Location = new System.Drawing.Point(8, 56);
			this.ltvServices.MultiSelect = false;
			this.ltvServices.Name = "ltvServices";
			this.ltvServices.Size = new System.Drawing.Size(400, 72);
			this.ltvServices.TabIndex = 3;
			this.ltvServices.ItemActivate += new System.EventHandler(this.ltvServices_ItemActivate);

			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 131);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(416, 22);
			this.statusBar1.TabIndex = 4;
			this.statusBar1.Text = "For Help, press F1";
			// 
			// FrmToolbox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(416, 153);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar1,
																		  this.ltvServices,
																		  this.pnlToolbarCaption});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Menu = this.mainMenu;
			this.Name = "FrmToolbox";
			this.Text = "Iquomi .client";
			this.pnlToolbarCaption.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void mniFileExit_Click(object sender, System.EventArgs e) {
			Application.Exit();
		}
		
		
		private bool activateService(ListViewItem item) {
			if (item == null)
				return false;
			/*			
						ServicesListViewItem service = (ServicesListViewItem)item;
			
						Console.Out.WriteLine("Executing \"{0}\" ...", service.Name);
						HttpWebRequest req = (HttpWebRequest)WebRequest.Create(service.URI);
						req.Headers.Add("XPath", textBox1.Text);
			
						// Create a new instance of CredentialCache.
						CredentialCache credentialCache = new CredentialCache();
			
						// Create a new instance of NetworkCredential using the client
						// credentials.
						NetworkCredential credentials = new NetworkCredential("theill", "belle0");
			
						// Add the NetworkCredential to the CredentialCache.
						credentialCache.Add(
							new Uri(service.URI),
							"Digest",
							credentials
						);
			
						// Add the CredentialCache to the proxy class credentials.
						req.Credentials = credentialCache;
						req.PreAuthenticate = true;
			
						req.Timeout = 3000;
			
						WebResponse result = null;
						try {
							result = req.GetResponse();
							Stream ReceiveStream = result.GetResponseStream();
							Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
							StreamReader sr = new StreamReader(ReceiveStream, encode);
							XmlTextReader xml = new XmlTextReader(sr);
				
							// load DLL with service
							Assembly serviceAssembly = Assembly.LoadFrom(service.Form);
				
							// get class reference
							Type serviceType = serviceAssembly.GetType("NotesService.FrmNotesService");
				
							// find 'Show' method implemented since service needs to 
							// use a common interface
							MethodInfo serviceShowMethod = serviceType.GetMethod("Show");
				
			//				EventInfo e1 = serviceType.GetEvent("xLoad");
			//				EventInfo e2 = serviceType.GetEvent("xSave");
			//				EventInfo e3 = serviceType.GetEvent("xQuery");

			//				MethodInfo Method = SampleAssembly.GetTypes()[0].GetMethod("Show");
			//				
			//				// Obtain a reference to the parameters collection of the MethodInfo instance.
			//				ParameterInfo[] Params = Method.GetParameters();
			//
			//				// Display information about method parameters.
			//				// Param = sParam1
			//				//   Type = System.String
			//				//   Position = 0
			//				//   Optional=False
			//				foreach (ParameterInfo Param in Params){
			//					Console.WriteLine("Param=" + Param.Name.ToString());
			//					Console.WriteLine("  Type=" + Param.ParameterType.ToString());
			//					Console.WriteLine("  Position=" + Param.Position.ToString());
			//					Console.WriteLine("  Optional=" + Param.IsOptional.ToString());
			//				}
				
							object serviceObj = serviceAssembly.CreateInstance(serviceType.FullName);
							serviceShowMethod.Invoke(serviceObj, null);
				
							MethodInfo mi = serviceType.GetMethod("xLoad");
							mi.Invoke(serviceObj, new object[] { (XmlReader)xml });
				
						}
						catch (Exception e) {
							Console.Out.WriteLine(e.StackTrace);
						}
						finally {
							if (result != null) {
								result.Close();
							}
						}
			*/			
			return true;
		}

		private void ltvServices_ItemActivate(object sender, System.EventArgs e) {
			ListView lv = (ListView)sender;
			activateService(lv.FocusedItem);
		}

	}
}