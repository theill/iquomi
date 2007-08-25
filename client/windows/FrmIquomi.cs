#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Resources;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Services.Protocols;

using log4net;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Client.Sdk;
//using Commanigy.Iquomi.Api.Services;
//using Commanigy.Iquomi.Services; // xsd generated classes are in this scope

#endregion

namespace Commanigy.Iquomi.Client {

	public enum OnlineStatus {
		Online,
		Busy,
		BeRightBack,
		Away,
		OnThePhone,
		OutToLunch,
		AppearOffline,
		Offline
	}

	/// <summary>
	/// Summary description for FrmIquomi.
	/// </summary>
	public partial class FrmIquomi : System.Windows.Forms.Form, IPluginHost {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		public event AppShuttingdownEventHandler AppShuttingdown;
		public event SignInEventHandler SignedIn;
		public event SignOutEventHandler SignedOut;

		// load resources from separate assembly so it's possible to deliver
		// specialized .dll including added or updated resources (usually
		// messages but may include bitmaps as well)
		private ResourceManager messages_ = new ResourceManager(typeof(FrmIquomi));//new ResourceManager("IquomiResources.Messages", System.Reflection.Assembly.Load("IquomiResources"));

		private FrmPreferences frmPreferences;

		private OnlineStatus onlineStatus = OnlineStatus.Offline;
		private System.Windows.Forms.NotifyIcon ncIquomi;
		private MenuStrip msIquomi;
		private ToolStripMenuItem tsFile;
		private ToolStripMenuItem tsServices;
		private ToolStripMenuItem tsActions;
		private ToolStripMenuItem tsTools;
		private ToolStripMenuItem tsMenu;
		private StatusStrip ssIquomi;
		private ToolStripStatusLabel tsStatus;
		private ToolStripMenuItem signInToolStripMenuItem;
		private ToolStripMenuItem signOutToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem preferencesToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripContainer tscIquomi;
		private ToolStripMenuItem helpTopicsToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripMenuItem privacyPolicyToolStripMenuItem;
		private ToolStripMenuItem termsOfUseToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem tsmMyStatus;
		private ToolStripMenuItem onlineToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem debugToolStripMenuItem;
		private ToolStripMenuItem loaddevelopmentpluginToolStripMenuItem;
		private ContextMenuStrip cmsNotificationIcon;
		private ToolStripMenuItem tsmMyIquomiPage;
		private ToolStripMenuItem tsmExit;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripContainer toolStripContainer1;
		private ToolStripMenuItem aboutToolStripMenuItem;

		/// <summary>
		/// Retrieves a message from resource manager.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public string _(string name) {
			string s = messages_.GetString(name);
			if (s != null) {
				return s;
			}

			return "[" + name + "]";
		}


		private string iqid = "petertheill";
		public string Iqid {
			get {
				return this.iqid;
			}
			set {
				this.iqid = value;
			}
		}

		private string password = "g5zTb4oNXBR1VWyUqhNdcQ==";
		public string Password {
			get {
				return this.password;
			}
			set {
				this.password = value;
			}
		}

		private ServiceLocator serviceLocator = null;
		protected ServiceLocator ServiceLocator {
			get {
				if (serviceLocator == null || serviceLocator.Iqid != this.iqid || serviceLocator.Password != this.Password) {
					serviceLocator = new ServiceLocator("http://services.iquomi.com/", this.Iqid, this.Password);
				}

				return serviceLocator;
			}
		}

		private System.ComponentModel.IContainer components;

		public FrmIquomi() {
			InitializeComponent();
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
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIquomi));
			this.ncIquomi = new System.Windows.Forms.NotifyIcon(this.components);
			this.cmsNotificationIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmMyIquomiPage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
			this.msIquomi = new System.Windows.Forms.MenuStrip();
			this.tsFile = new System.Windows.Forms.ToolStripMenuItem();
			this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmMyStatus = new System.Windows.Forms.ToolStripMenuItem();
			this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsServices = new System.Windows.Forms.ToolStripMenuItem();
			this.tsActions = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loaddevelopmentpluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsTools = new System.Windows.Forms.ToolStripMenuItem();
			this.tsMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.helpTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.privacyPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.termsOfUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ssIquomi = new System.Windows.Forms.StatusStrip();
			this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tscIquomi = new System.Windows.Forms.ToolStripContainer();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.cmsNotificationIcon.SuspendLayout();
			this.msIquomi.SuspendLayout();
			this.ssIquomi.SuspendLayout();
			this.tscIquomi.BottomToolStripPanel.SuspendLayout();
			this.tscIquomi.TopToolStripPanel.SuspendLayout();
			this.tscIquomi.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ncIquomi
			// 
			this.ncIquomi.ContextMenuStrip = this.cmsNotificationIcon;
			this.ncIquomi.Icon = ((System.Drawing.Icon)(resources.GetObject("ncIquomi.Icon")));
			this.ncIquomi.Text = "Iquomi";
			this.ncIquomi.Visible = true;
			// 
			// cmsNotificationIcon
			// 
			this.cmsNotificationIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMyIquomiPage,
            this.toolStripSeparator6,
            this.tsmExit});
			this.cmsNotificationIcon.Name = "cmsNotificationIcon";
			this.cmsNotificationIcon.Size = new System.Drawing.Size(199, 54);
			this.cmsNotificationIcon.Click += new System.EventHandler(this.OpenMyPage_Click);
			// 
			// tsmMyIquomiPage
			// 
			this.tsmMyIquomiPage.Name = "tsmMyIquomiPage";
			this.tsmMyIquomiPage.Size = new System.Drawing.Size(198, 22);
			this.tsmMyIquomiPage.Text = "My Iquomi Page";
			this.tsmMyIquomiPage.Click += new System.EventHandler(this.OpenMyPage_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(195, 6);
			// 
			// tsmExit
			// 
			this.tsmExit.Name = "tsmExit";
			this.tsmExit.Size = new System.Drawing.Size(198, 22);
			this.tsmExit.Text = "Exit";
			this.tsmExit.Click += new System.EventHandler(this.FileExit_Click);
			// 
			// msIquomi
			// 
			this.msIquomi.Dock = System.Windows.Forms.DockStyle.None;
			this.msIquomi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFile,
            this.tsServices,
            this.tsActions,
            this.tsTools,
            this.tsMenu});
			this.msIquomi.Location = new System.Drawing.Point(0, 0);
			this.msIquomi.Name = "msIquomi";
			this.msIquomi.Padding = new System.Windows.Forms.Padding(0);
			this.msIquomi.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.msIquomi.Size = new System.Drawing.Size(252, 24);
			this.msIquomi.TabIndex = 2;
			this.msIquomi.Text = "msIquomi";
			// 
			// tsFile
			// 
			this.tsFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signInToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmMyStatus,
            this.toolStripMenuItem2,
            this.preferencesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.tsFile.Name = "tsFile";
			this.tsFile.Size = new System.Drawing.Size(40, 24);
			this.tsFile.Text = "&File";
			this.tsFile.DropDownOpened += new System.EventHandler(this.miFile_Popup);
			// 
			// signInToolStripMenuItem
			// 
			this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
			this.signInToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.signInToolStripMenuItem.Size = new System.Drawing.Size(183, 20);
			this.signInToolStripMenuItem.Text = "S&ign In...";
			this.signInToolStripMenuItem.Click += new System.EventHandler(this.mimFileSignIn_Click);
			// 
			// signOutToolStripMenuItem
			// 
			this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
			this.signOutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.signOutToolStripMenuItem.Size = new System.Drawing.Size(183, 20);
			this.signOutToolStripMenuItem.Text = "Sig&n Out";
			this.signOutToolStripMenuItem.Click += new System.EventHandler(this.mimFileSignOut_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
			// 
			// tsmMyStatus
			// 
			this.tsmMyStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem});
			this.tsmMyStatus.Name = "tsmMyStatus";
			this.tsmMyStatus.Padding = new System.Windows.Forms.Padding(0);
			this.tsmMyStatus.Size = new System.Drawing.Size(183, 20);
			this.tsmMyStatus.Text = "My Status";
			// 
			// onlineToolStripMenuItem
			// 
			this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
			this.onlineToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.onlineToolStripMenuItem.Text = "Online";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 6);
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(183, 20);
			this.preferencesToolStripMenuItem.Text = "&Preferences...";
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.mimFilePreferences_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 20);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.FileExit_Click);
			// 
			// tsServices
			// 
			this.tsServices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsServices.Name = "tsServices";
			this.tsServices.Size = new System.Drawing.Size(73, 24);
			this.tsServices.Text = "&Services";
			// 
			// tsActions
			// 
			this.tsActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
			this.tsActions.Name = "tsActions";
			this.tsActions.Size = new System.Drawing.Size(66, 24);
			this.tsActions.Text = "&Actions";
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loaddevelopmentpluginToolStripMenuItem});
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.debugToolStripMenuItem.Text = "Debug";
			// 
			// loaddevelopmentpluginToolStripMenuItem
			// 
			this.loaddevelopmentpluginToolStripMenuItem.Name = "loaddevelopmentpluginToolStripMenuItem";
			this.loaddevelopmentpluginToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.loaddevelopmentpluginToolStripMenuItem.Text = "Load Plugin";
			this.loaddevelopmentpluginToolStripMenuItem.Click += new System.EventHandler(this.loaddevelopmentpluginToolStripMenuItem_Click);
			// 
			// tsTools
			// 
			this.tsTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsTools.Name = "tsTools";
			this.tsTools.Size = new System.Drawing.Size(55, 24);
			this.tsTools.Text = "&Tools";
			// 
			// tsMenu
			// 
			this.tsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTopicsToolStripMenuItem,
            this.toolStripSeparator3,
            this.privacyPolicyToolStripMenuItem,
            this.termsOfUseToolStripMenuItem,
            this.toolStripSeparator4,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
			this.tsMenu.Name = "tsMenu";
			this.tsMenu.Size = new System.Drawing.Size(48, 24);
			this.tsMenu.Text = "&Help";
			// 
			// helpTopicsToolStripMenuItem
			// 
			this.helpTopicsToolStripMenuItem.Name = "helpTopicsToolStripMenuItem";
			this.helpTopicsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.helpTopicsToolStripMenuItem.Text = "Help Topics";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(212, 6);
			// 
			// privacyPolicyToolStripMenuItem
			// 
			this.privacyPolicyToolStripMenuItem.Name = "privacyPolicyToolStripMenuItem";
			this.privacyPolicyToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.privacyPolicyToolStripMenuItem.Text = "Privacy Policy";
			// 
			// termsOfUseToolStripMenuItem
			// 
			this.termsOfUseToolStripMenuItem.Name = "termsOfUseToolStripMenuItem";
			this.termsOfUseToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.termsOfUseToolStripMenuItem.Text = "Terms Of Use";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(212, 6);
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(212, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// ssIquomi
			// 
			this.ssIquomi.Dock = System.Windows.Forms.DockStyle.None;
			this.ssIquomi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
			this.ssIquomi.Location = new System.Drawing.Point(0, 0);
			this.ssIquomi.Name = "ssIquomi";
			this.ssIquomi.Size = new System.Drawing.Size(252, 23);
			this.ssIquomi.TabIndex = 3;
			this.ssIquomi.Text = "statusStrip1";
			// 
			// tsStatus
			// 
			this.tsStatus.Name = "tsStatus";
			this.tsStatus.Size = new System.Drawing.Size(237, 18);
			this.tsStatus.Spring = true;
			this.tsStatus.Text = "For Help, press F1";
			this.tsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tscIquomi
			// 
			// 
			// tscIquomi.BottomToolStripPanel
			// 
			this.tscIquomi.BottomToolStripPanel.Controls.Add(this.ssIquomi);
			// 
			// tscIquomi.ContentPanel
			// 
			this.tscIquomi.ContentPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.tscIquomi.ContentPanel.Size = new System.Drawing.Size(252, 424);
			this.tscIquomi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tscIquomi.Location = new System.Drawing.Point(0, 0);
			this.tscIquomi.Name = "tscIquomi";
			this.tscIquomi.Size = new System.Drawing.Size(252, 471);
			this.tscIquomi.TabIndex = 5;
			this.tscIquomi.Text = "toolStripContainer1";
			// 
			// tscIquomi.TopToolStripPanel
			// 
			this.tscIquomi.TopToolStripPanel.Controls.Add(this.msIquomi);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AutoScroll = true;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tscIquomi);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(252, 471);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(252, 496);
			this.toolStripContainer1.TabIndex = 7;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// FrmIquomi
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
			this.ClientSize = new System.Drawing.Size(252, 496);
			this.Controls.Add(this.toolStripContainer1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::Commanigy.Iquomi.Client.Properties.Settings.Default, "MainWindowSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.msIquomi;
			this.Name = "FrmIquomi";
			this.Text = "Iquomi";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmIquomi_Closing);
			this.Load += new System.EventHandler(this.FrmIquomi_Load);
			this.cmsNotificationIcon.ResumeLayout(false);
			this.msIquomi.ResumeLayout(false);
			this.msIquomi.PerformLayout();
			this.ssIquomi.ResumeLayout(false);
			this.ssIquomi.PerformLayout();
			this.tscIquomi.BottomToolStripPanel.ResumeLayout(false);
			this.tscIquomi.BottomToolStripPanel.PerformLayout();
			this.tscIquomi.TopToolStripPanel.ResumeLayout(false);
			this.tscIquomi.TopToolStripPanel.PerformLayout();
			this.tscIquomi.ResumeLayout(false);
			this.tscIquomi.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Returns the statusbar
		/// </summary>
		public StatusBar StatusBar {
			get {
				return new StatusBar();
			}
		}

		public string StatusBarText {
			get {
				return "unimplemented";
				//return this.sbApp.Text;
			}

			set {
				ncIquomi.ShowBalloonTip(3, "IqAlerts", value, ToolTipIcon.Info);
			}
		}

		public OnlineStatus OnlineStatus {
			get {
				return this.onlineStatus;
			}

			set {
				this.onlineStatus = value;
			}
		}

		///// <summary>
		///// 
		///// </summary>
		///// <param name="path"></param>
		///// <returns></returns>
		//private ArrayList SearchFolder(string path) {

		//    DirectoryInfo di = new DirectoryInfo(path);
		//    if (!di.Exists) {
		//        return null;
		//    }

		//    ArrayList list = new ArrayList();

		//    FileInfo[] files = di.GetFiles("*.dll");

		//    foreach (FileInfo info in files) {
		//        list.Add(info);
		//    }

		//    DirectoryInfo[] subdirs = di.GetDirectories();
		//    foreach (DirectoryInfo info in subdirs) {
		//        list.AddRange(SearchFolder(info.FullName));
		//    }

		//    return list;
		//}

		///// <summary>
		///// 
		///// </summary>
		///// <param name="path"></param>
		///// <returns></returns>
		//private FileInfo[] SearchForServices(string path) {
		//    ArrayList list = SearchFolder(path);

		//    return new FileInfo[] {
		//                              new FileInfo(@"..\..\..\NotesService\bin\Debug\NotesService.dll"),
		//                              new FileInfo(@"..\..\..\FavoritesService\bin\Debug\FavoritesService.dll")
		//                          };
		//    //			return (FileInfo[])list.ToArray(typeof(FileInfo));
		//}

		///// <summary>
		///// 
		///// </summary>
		///// <returns></returns>
		//private IquomiService[] LoadAvailableServices() {

		//    FileInfo[] locations = SearchForServices(@"..\..\..");

		//    ArrayList list = new ArrayList(locations.Length);
		//    foreach (FileInfo fi in locations) {
		//        IquomiService service = new IquomiService(fi.FullName);
		//        if (service.IsValid) {
		//            list.Add(service);
		//        }
		//    }

		//    return (IquomiService[])list.ToArray(typeof(IquomiService));
		//}

		private void FrmIquomi_Load(object sender, System.EventArgs e) {

			//ncIquomi.Icon = Icon.FromHandle(((Bitmap)this.imageList1.Images[0]).GetHicon());

			/*
			 * TODO:
			 * 
			 * load available services
			 * if (no services found) {
			 *   display page to user requesting him to
			 *    find available services online
			 *   return
			 * }
			 * 
			 * if (selected service) {
			 *   execute startup code for selected service
			 * } else {
			 *   show list of available services
			 * }
			 */
//			services_ = LoadAvailableServices();
//			Debug.Assert(services_ != null, "array of services should at least be instantiated");
			
//			if (services_.Length == 0) {
//				// display page requesting user to download one of the 
//				// available services online
//				return;
//			}

			if (Iqid != null && Password != null) {
				SignIn();
			}

//			string plugin = ConfigurationSettings.AppSettings["dev-plugin"];
//			if (plugin != null) {
//				RunPlugin(plugin);
//			}
		}

/* [>] Missing correct IqServices project in order to get an IqServicesRef web reference
		public void QueryServices() {
			Service myServices = this.GetService("iqServices", this.iqid);

			QueryRequestType req = new QueryRequestType();
			XpQueryType query = new XpQueryType();
			query.Select = "/m:iqServices/m:service";
			req.XpQuery = new XpQueryType[] { query };

			QueryResponseType res = myServices.Query(req);
			if (res != null && res.XpQueryResponse != null && res.XpQueryResponse[0].Status == ResponseStatus.Success) {
				if (res.XpQueryResponse[0].Any.Length == 0) {
					return;
				}

				serviceType[] services = (serviceType[])ServiceUtils.GetObject(typeof(serviceType), res.XpQueryResponse[0].Any);
				BuildServicesMenu(services);
			}
		}
*/

		
		/// <summary>
		/// Signs in user by updating presence service with information about
		/// a logged on request from Iquomi Messenger.
		/// </summary>
		private void SignIn() {
			// get reference to presence service
			IqPresenceRef.IqPresence myPresence = (IqPresenceRef.IqPresence)ServiceLocator.GetService(
				typeof(IqPresenceRef.IqPresence),
				this.Iqid
				);

			// update users messenger status (on all endpoints)
			IqPresenceRef.ReplaceRequestType req = new IqPresenceRef.ReplaceRequestType();
			req.Select = "/m:IqPresence/m:Endpoint/m:Argot[@Name='Iquomi Messenger']/*[local-name(.)='MessengerArgot']/@Status";
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;

			IqPresenceRef.RedAttributeType ra = new IqPresenceRef.RedAttributeType();
			ra.Name = "Status";
			ra.Value = "Online";
			req.Attributes = new IqPresenceRef.RedAttributeType[] { ra };

			myPresence.ReplaceCompleted += new Commanigy.Iquomi.Client.IqPresenceRef.ReplaceCompletedEventHandler(OnSignInResponse);
			myPresence.ReplaceAsync(req);
		}


		/// <summary>
		/// Called when [sign in response].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="Commanigy.Iquomi.Client.IqPresenceRef.ReplaceCompletedEventArgs"/> instance containing the event data.</param>
		private void OnSignInResponse(object sender, IqPresenceRef.ReplaceCompletedEventArgs e) {
			if (e.Result != null && e.Result.Status == IqPresenceRef.ResponseStatus.Success) {
				NotifySignIn();
			}
			else {
				MessageBox.Show("Sign in failed.");
			}
		}

		
		/// <summary>
		/// 
		/// </summary>
		private void SignOut() {
			// get reference to presence service
			IqPresenceRef.IqPresence myPresence = (IqPresenceRef.IqPresence)ServiceLocator.GetService(
				typeof(IqPresenceRef.IqPresence),
				this.Iqid
				);

			// update users messenger status (on all endpoints)
			IqPresenceRef.ReplaceRequestType req = new IqPresenceRef.ReplaceRequestType();
			req.Select = "/m:IqPresence/m:Endpoint/m:Argot[@Name='Iquomi Messenger']/*[local-name(.)='MessengerArgot']/@Status";
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;

			IqPresenceRef.RedAttributeType ra = new IqPresenceRef.RedAttributeType();
			ra.Name = "Status";
			ra.Value = "Offline";
			req.Attributes = new IqPresenceRef.RedAttributeType[] { ra };

			myPresence.ReplaceCompleted += new IqPresenceRef.ReplaceCompletedEventHandler(OnSignOutResponse);
			myPresence.ReplaceAsync(req);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSignOutResponse(object sender, IqPresenceRef.ReplaceCompletedEventArgs e) {
			if (e.Result != null && e.Result.Status == IqPresenceRef.ResponseStatus.Success) {
				NotifySignOut();
			}
			else {
				MessageBox.Show("Sign out failed.");
			}
		}


		/// <summary>
		/// Initializes the "Services" menu by displaying currently 
		/// subscribed services.
		/// </summary>
//		private void InitServicesMenu() {
//			adminWebService.AuthenticationTypeValue = new AdminRef.AuthenticationType();
//			adminWebService.AuthenticationTypeValue.Iqid = this.Iqid;
//			adminWebService.AuthenticationTypeValue.Password = this.Password;
//
//			adminWebService.BeginGetSubscriptionServices(new AsyncCallback(OnSubscriptionServices), adminWebService);
//
//			StatusBarText = _("Fetching subscriptions...");
//		}

//		private void OnSubscriptionServices(IAsyncResult result) {
//			AdminRef.IquomiWSAdmin aws = (AdminRef.IquomiWSAdmin)result.AsyncState;
//			AdminRef.Service[] services = adminWebService.EndGetSubscriptionServices(result);
//			if (services != null) {
//				StatusBarText = string.Format(_("{0} subscription(s) fetched."), services.Length);
//				BuildServicesMenu(services);
//			}
//		}

//		private void BuildServicesMenu(AdminRef.Service[] services) {
//			miServices.MenuItems.Clear();
//			foreach (AdminRef.Service s in services) {
//				miServices.MenuItems.Add(
//					s.Name,
//					new System.EventHandler(this.Services_Click)
//					);
//			}
//			miServices.MenuItems.Add("-");
//			miServices.MenuItems.Add(
//				"Refresh",
//				new System.EventHandler(this.ServicesRefresh_Click)
//				);
//		}

/*
		private void BuildServicesMenu(serviceType[] services) {
			miServices.MenuItems.Clear();
			foreach (serviceType s in services) {
//				miServices.MenuItems.Add(
//					s.name,
//					new System.EventHandler(this.Services_Click)
//					);
			}
			miServices.MenuItems.Add("-");
			miServices.MenuItems.Add(
				"Refresh",
				new System.EventHandler(this.ServicesRefresh_Click)
				);
		}
*/

/*
		private void Services_Click(object sender, System.EventArgs e) {
			MenuItem mi = (MenuItem)sender;
			log.Debug("Clicked on " + mi.Text);

			AdminRef.Package pkg = adminWebService.DownloadLatestPackage(mi.Text, "Any");
			if (pkg == null || pkg.Items == null || pkg.Items.Length == 0) {
				MessageBox.Show("Couldn't get package");
				return;
			}

			string pkgpath = String.Format(
				@"{0}\services\{1}\",
				new FileInfo(".").FullName,
				mi.Text
				);

			try {
				new DirectoryInfo(pkgpath).Delete(true);
			}
			catch (Exception exx) {
				log.Info("Unable to delete folder", exx);
			}

			try {
				new DirectoryInfo(pkgpath).Create();
			}
			catch (Exception exx) {
				log.Info("Unable to create folder", exx);
			}

			string app = "";
			foreach (AdminRef.PackageItem pkgi in pkg.Items) {
				byte[] x = (byte[])pkgi.Data;
				FileStream fs = new FileStream(pkgpath + pkgi.Name, FileMode.CreateNew);
				fs.Write(x, 0, x.Length);
				fs.Close();

				if ("application/octet-stream".Equals(pkgi.Type)) {
					app = pkgi.Name;
				}
			}

			System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(pkgpath + app);
			System.Type[] types = a.GetTypes();
//			foreach (Type t in types) {
//				if (t.IsSubclassOf(typeof(ServiceForm))) {
//					ServiceForm form = (ServiceForm)a.CreateInstance(t.FullName);
//					form.MdiParent = this;
//					form.WindowState = FormWindowState.Maximized;
//					form.Show();
//					return;
//				}
//			}
		}
*/
		

		///// <summary>
		///// 
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>
		//private void ServicesRefresh_Click(object sender, System.EventArgs e) {
		//    InitServicesMenu();
		//}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FileExit_Click(object sender, System.EventArgs e) {
			this.Close();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mimFilePreferences_Click(object sender, System.EventArgs e) {
			if (frmPreferences == null || frmPreferences.IsDisposed) {
				frmPreferences = new FrmPreferences();
				IqProfileRef.IqProfile myProfile = (IqProfileRef.IqProfile)ServiceLocator.GetService(
					typeof(IqProfileRef.IqProfile),
					this.Iqid
				);
				frmPreferences.IqProfileService = myProfile;
			}

			frmPreferences.Show();
			frmPreferences.Focus();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mimFileSignIn_Click(object sender, System.EventArgs e) {
			FrmSignIn signIn = new FrmSignIn();
			if (signIn.ShowDialog() == DialogResult.OK) {
				this.Iqid = signIn.Email;
				this.Password = signIn.Password;

				SignIn();
			}
		}


		/// <summary>
		/// Notifies all listeners about a shutdown of the main application. 
		/// This will allow services to do some last-minute write to a local
		/// file or maybe show a warning message to the user if they cannot
		/// determine what to do.
		/// </summary>
		private void NotifyAppShuttingdown() {
			if (AppShuttingdown != null) {
				AppShuttingdown(this, new AppShuttingdownEventArgs());
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void NotifySignIn() {
			OnlineStatus = OnlineStatus.Online;

			// notify listeners
			if (SignedIn != null) {
				SignInEventArgs args = new SignInEventArgs();
				SignedIn(this, args);
			}

//			InitServicesMenu();
		}


		/// <summary>
		/// 
		/// </summary>
		private void NotifySignOut() {
			OnlineStatus = OnlineStatus.Offline;

			// notify listeners
			if (SignedOut != null) {
				SignOutEventArgs args = new SignOutEventArgs();
				SignedOut(this, args);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmIquomi_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (OnlineStatus != OnlineStatus.Offline) {
				SignOut();
			}

			NotifyAppShuttingdown();

			Application.Exit();
		}


		private void mimFileSignOut_Click(object sender, System.EventArgs e) {
			SignOut();
		}


		private void RunPlugin(string filename) {
			IquomiService service = new IquomiService(filename);
			IPlugin plugin = service.Instantiate(this);
			if (plugin == null) {
				MessageBox.Show("Can't instantiate plugin");
				return;
			}

			if (plugin is IFormPlugin) {
				// Suspend layout to ensure proper resize of mdi child
				try {
					this.SuspendLayout();

					((IFormPlugin)plugin).UserInterface.MdiParent = this;
					((IFormPlugin)plugin).UserInterface.WindowState = FormWindowState.Maximized;
					((IFormPlugin)plugin).UserInterface.Show();
				}
				finally {
					this.ResumeLayout();
				}
			}
		}

		private void miFile_Popup(object sender, System.EventArgs e) {
			signInToolStripMenuItem.Enabled = (OnlineStatus == OnlineStatus.Offline);
			signOutToolStripMenuItem.Enabled = !signInToolStripMenuItem.Enabled;
			tsmMyStatus.Enabled = !signInToolStripMenuItem.Enabled;
		}


		private void OpenMyPage_Click(object sender, System.EventArgs e) {
			MessageBox.Show(_("Go to \"My Iquomi Page\"."));
		}

		#region IPluginHost Members
		public string Version {
			get {
				return "1.0.0.0";
			}
		}

		public IntPtr ContainerHandle {
			get {
				return this.Handle;
			}
		}

		public SoapHttpClientProtocol GetService(Type serviceType, string iqid) {
			return ServiceLocator.GetService(serviceType, iqid);
		}

		public object GetObject(Type type, XmlElement e) {
			return ServiceUtils.GetObject(type, e);
		}

		public object GetObject(Type type, XmlElement[] e) {
			return ServiceUtils.GetObject(type, e);
		}

		public XmlElement SetObject(object o, string elementName) {
			return ServiceUtils.SetObject(o, elementName);
		}

		/*
		public Api.Services.Service GetService(string name, string iqid) {
			Api.Services.Service myService = new Api.Services.Service();
			Api.Services.SoapAuthenticationType a = new Api.Services.SoapAuthenticationType();
			a.Iqid = this.Iqid;
			a.Password = this.Password;
			myService.SoapAuthenticationTypeValue = a;

			myService.SoapRequestTypeValue = new Api.Services.SoapRequestType();
			Api.Services.RequestType r = new Api.Services.RequestType();
			r.Service = name;
			Api.Services.RequestTypeKey rk = new Api.Services.RequestTypeKey();
			rk.Cluster = "";
			rk.Instance = "";
			rk.Puid = iqid;
			r.Key = new Api.Services.RequestTypeKey[] { rk };
			myService.SoapRequestTypeValue.Value = r;

			return myService;
		}
		*/
		#endregion

		private void miAbout_Click(object sender, System.EventArgs e) {
			new AboutForm().ShowDialog();
		}

		private void loaddevelopmentpluginToolStripMenuItem_Click(object sender, EventArgs e) {
			string plugin = ConfigurationManager.AppSettings["dev-plugin"];
			if (plugin != null) {
				RunPlugin(plugin);
			}
		}

	}
}