#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

using Commanigy.Iquomi.Client.Sdk;

#endregion

namespace Commanigy.Iquomi.Services.IqFavorites {
	/// <summary>
	/// 
	///	 <favorite changeNumber="1" id="4EAEBF55-1224-4220-AFAF-C1B6B09F3946" creator="1">
	///	  <cat ref="#$PENDING" />
	///	  <title>Free Images - Free Stock Photos2</title>
	///	  <url>http://www.freeimages.co.uk/</url>
	///	 </favorite>
	///	
	/// </summary>
	public class FrmIqFavoritesService : System.Windows.Forms.Form {
		public delegate void FillTreeViewDelegate(favoriteType[] favorites, TreeNodeCollection col);
		
		private FileSystemWatcher fileSystemWatcher_;
		
		private XmlDocument favorites_;
		private ArrayList favoriteList = new ArrayList();
		
		// Needed for real case sensitive version of file or directory. The
		// lowercase version is always returned by FileSystemWatcher events.
		private Hashtable realNamesLookup_;
		
		private System.Windows.Forms.ImageList ilIcons;
		private System.Windows.Forms.TreeView tvFavorites;
		private System.Windows.Forms.TextBox xpath;
		private System.Windows.Forms.Button btnQuery;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblStatusHeader;
		private System.Windows.Forms.MainMenu mmnBookmarkSync;
		private System.Windows.Forms.MenuItem miSynchronize;
		private System.Windows.Forms.MenuItem miOrganize;
		private System.Windows.Forms.MenuItem miActions;
		private System.Windows.Forms.MenuItem miAutoSynchronize;
		private System.Windows.Forms.MenuItem miSeparator;
		
		public IPluginHost PluginHost;
		
		private Api.Services.Service myService;
		
		public FrmIqFavoritesService() : base() {
			InitializeComponent();
			
			realNamesLookup_ = new Hashtable();
			
			// Lookup users Favorites folder in order to watch it
			string favoritesFolder = System.Environment.GetFolderPath(
				System.Environment.SpecialFolder.Favorites
				);

			favoritesFolder = @"..\..\..\..\data\MyFavorites";

			fileSystemWatcher_.Path = favoritesFolder;
			
			favorites_ = ReadFavorites(fileSystemWatcher_.Path);
			favorites_.Save("favorites.xml");

			tvFavorites.Nodes.Clear();

			// WriteFavorites(favorites_, @"..\..\..\..\data\MyFavorites");
		}
		
		public void Initialize() {
//			myService = this.PluginHost.GetService("iqFavorites", "petertheill");
		}
		
		private TreeNode Locate(string name, TreeNodeCollection nodes) {
			foreach (TreeNode node in nodes) {
				if (node.Text == name) {
					return node;
				}
			}
			
			return null;
		}
		
		private TreeNode LocateFull(string fullPath, TreeNodeCollection nodes) {
			foreach (TreeNode n in nodes) {
				if (n.FullPath == fullPath) {
					return n;
				}
				
				TreeNode child = LocateFull(fullPath, n.Nodes);
				if (child != null) {
					return child;
				}
			}
			
			return null;
		}
		
		private void FillTreeView(favoriteType[] favorites, TreeNodeCollection c) {
			if (favorites == null || favorites.Length == 0) {
				return;
			}

			foreach (favoriteType f in favorites) {
				XmlTreeNode favorite = new XmlTreeNode(f);

				// Find parent placement for node
				string fullPath = "";
				if (f.cat != null && f.cat.Length > 0) {
					fullPath = f.cat[0].@ref.Substring(1);
				}

				TreeNodeCollection ptnc = c;

				string[] pathParts = fullPath.Split(new char[] { '/' });
				foreach (string part in pathParts) {
					TreeNode tn = Locate(part, ptnc);
					if (tn == null) {
						tn = new TreeNode(part);
						ptnc.Add(tn);
					}

					ptnc = tn.Nodes;
				}

				TreeNode fld = LocateFull(fullPath, c);
				if (fld != null) {
					fld.Nodes.Add(favorite);
				}
			}
		}

		private void EnumerateFolder(string path, XmlElement root) {
			string[] directories = Directory.GetDirectories(path);
			for (int i = 0; i < directories.Length; i++) {
				EnumerateFolder(directories[i], root);

				AddPathItem(directories[i]);
			}
			
			EnumerateFiles(path, root);
		}

		private void EnumerateFiles(string path, XmlElement root) {
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++) {
				favoriteType favorite = FavoriteConverter.Convert(files[i]);
				root.AppendChild(root.OwnerDocument.ImportNode(FavoriteConverter.ConvertToXml(favorite), true));

				AddPathItem(files[i]);
			}
		}

		private XmlDocument ReadFavorites(string path) {
			XmlDocument xml = new XmlDocument();
			XmlElement root = xml.CreateElement("iqFavorites");
			EnumerateFolder(path, root);
			xml.AppendChild(root);
			return xml;
		}

		
		private void WriteFiles(XmlElement element, string path) {
			XmlNodeList files = element.SelectNodes("./favorite");
			for (int i = 0; i < files.Count; i++) {
				XmlElement file = (XmlElement)files[i];
				string filepath = Path.Combine(path, file.GetAttribute("name") + ".url");
				StreamWriter sw = File.CreateText(filepath);
				XmlCDataSection data = (XmlCDataSection)file.FirstChild;
				sw.Write(data.Data);
				sw.Flush();
				sw.Close();
			}
		}
		
		private void WriteFolder(XmlElement element, string path) {
			XmlNodeList folders = element.SelectNodes("./folder");
			for (int i = 0; i < folders.Count; i++) {
				XmlElement folder = (XmlElement)folders[i];
				string folderpath = Path.Combine(path, folder.GetAttribute("name"));
				DirectoryInfo di = Directory.CreateDirectory(
					folderpath
					);
				WriteFolder(folder, di.FullName);
			}
			
			WriteFiles(element, path);
		}
		
		private void WriteFavorites(XmlDocument xml, string path) {
			if (xml == null) {
				throw new NullReferenceException("Not possible to write favorites with missing xml document");
			}
			
			WriteFolder(xml.DocumentElement, path);
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
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmIqFavoritesService));
			this.fileSystemWatcher_ = new System.IO.FileSystemWatcher();
			this.ilIcons = new System.Windows.Forms.ImageList(this.components);
			this.tvFavorites = new System.Windows.Forms.TreeView();
			this.xpath = new System.Windows.Forms.TextBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblStatusHeader = new System.Windows.Forms.Label();
			this.mmnBookmarkSync = new System.Windows.Forms.MainMenu();
			this.miActions = new System.Windows.Forms.MenuItem();
			this.miSynchronize = new System.Windows.Forms.MenuItem();
			this.miAutoSynchronize = new System.Windows.Forms.MenuItem();
			this.miSeparator = new System.Windows.Forms.MenuItem();
			this.miOrganize = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_)).BeginInit();
			this.SuspendLayout();
			// 
			// fileSystemWatcher_
			// 
			this.fileSystemWatcher_.EnableRaisingEvents = true;
			this.fileSystemWatcher_.IncludeSubdirectories = true;
			this.fileSystemWatcher_.SynchronizingObject = this;
			this.fileSystemWatcher_.Deleted += new System.IO.FileSystemEventHandler(this.ItemDeleted);
			this.fileSystemWatcher_.Renamed += new System.IO.RenamedEventHandler(this.ItemRenamed);
			this.fileSystemWatcher_.Created += new System.IO.FileSystemEventHandler(this.ItemCreated);
			// 
			// ilIcons
			// 
			this.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
			this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvFavorites
			// 
			this.tvFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tvFavorites.FullRowSelect = true;
			this.tvFavorites.ImageList = this.ilIcons;
			this.tvFavorites.Location = new System.Drawing.Point(8, 9);
			this.tvFavorites.Name = "tvFavorites";
			this.tvFavorites.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					new System.Windows.Forms.TreeNode("Node0"),
																					new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
																																									   new System.Windows.Forms.TreeNode("Node2")}),
																					new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
																																									   new System.Windows.Forms.TreeNode("Node5")})});
			this.tvFavorites.PathSeparator = "/";
			this.tvFavorites.ShowPlusMinus = false;
			this.tvFavorites.ShowRootLines = false;
			this.tvFavorites.Size = new System.Drawing.Size(216, 351);
			this.tvFavorites.TabIndex = 0;
			// 
			// xpath
			// 
			this.xpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.xpath.Location = new System.Drawing.Point(8, 422);
			this.xpath.Name = "xpath";
			this.xpath.Size = new System.Drawing.Size(176, 20);
			this.xpath.TabIndex = 1;
			this.xpath.Text = "//folder/bookmark[title=\'Real.com Radio Tuner\']";
			// 
			// btnQuery
			// 
			this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuery.Location = new System.Drawing.Point(192, 422);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(32, 25);
			this.btnQuery.TabIndex = 2;
			this.btnQuery.Text = "Go!";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatus.Location = new System.Drawing.Point(8, 384);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(216, 32);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "This service is currently running normally.";
			// 
			// lblStatusHeader
			// 
			this.lblStatusHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatusHeader.Location = new System.Drawing.Point(8, 368);
			this.lblStatusHeader.Name = "lblStatusHeader";
			this.lblStatusHeader.Size = new System.Drawing.Size(216, 23);
			this.lblStatusHeader.TabIndex = 4;
			this.lblStatusHeader.Text = "Status:";
			// 
			// mmnBookmarkSync
			// 
			this.mmnBookmarkSync.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.miActions});
			// 
			// miActions
			// 
			this.miActions.Index = 0;
			this.miActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miSynchronize,
																					  this.miAutoSynchronize,
																					  this.miSeparator,
																					  this.miOrganize});
			this.miActions.MergeOrder = 2;
			this.miActions.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.miActions.Text = "&Actions";
			// 
			// miSynchronize
			// 
			this.miSynchronize.Index = 0;
			this.miSynchronize.Text = "&Synchronize!";
			// 
			// miAutoSynchronize
			// 
			this.miAutoSynchronize.Checked = true;
			this.miAutoSynchronize.Index = 1;
			this.miAutoSynchronize.Text = "Auto Synchronize";
			// 
			// miSeparator
			// 
			this.miSeparator.Index = 2;
			this.miSeparator.Text = "-";
			// 
			// miOrganize
			// 
			this.miOrganize.Index = 3;
			this.miOrganize.Text = "&Organize...";
			this.miOrganize.Click += new System.EventHandler(this.miOrganize_Click);
			// 
			// FrmIqFavoritesService
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 453);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblStatusHeader);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.xpath);
			this.Controls.Add(this.tvFavorites);
			this.Menu = this.mmnBookmarkSync;
			this.Name = "FrmIqFavoritesService";
			this.Text = "Favorites";
			this.Load += new System.EventHandler(this.FrmFavoritesService_Load);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Real Path Names Handling
		private void AddPathItem(string path) {
			realNamesLookup_.Add(
				path.ToLower(),
				new PathItem(
					IsDirectory(path) ? PathType.Directory : PathType.File,
					GetRealName(path)
					)
				);
		}

		private void RemovePathItem(string key) {
			realNamesLookup_.Remove(key.ToLower());
		}

		private PathItem GetPathInfo(string key) {
			return (PathItem)realNamesLookup_[key.ToLower()];
		}
		#endregion
		
		private string[] SplitPath(string path) {
			return path.Split(new char[] { '\\' });
		}
		
		private string GetXPathForFolder(string folder) {
			string[] paths = SplitPath(folder.Substring(fileSystemWatcher_.Path.Length));

			StringBuilder buffer = new StringBuilder();
			buffer.Append("/xbel");
			foreach (string path in paths) {
				if ("".Equals(path)) {
					continue;
				}
				buffer.Append("/folder[title=\"" + path + "\"]");
			}
			
			return buffer.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <example>
		/// /xbel/folder[title="Development"]/folder[title="Components"]/bookmark[title="DSPack"]
		/// </example>
		/// <param name="filename"></param>
		/// <returns></returns>
		private string GetXPathForFile(string filename) {
			string xpath = GetXPathForFolder(Path.GetDirectoryName(filename));
			xpath += "/bookmark[title=\"" + Path.GetFileNameWithoutExtension(filename) + "\"]";
			return xpath;
		}
		
		private string GetXPath(string path) {
			PathItem item = GetPathInfo(path);
			if (item == null) {
				// Path not found so this must be root node
				return "/xbel";
			}

			if (item.PathType == PathType.File) {
				return this.GetXPathForFile(item.Path);
			} else {
				return this.GetXPathForFolder(item.Path);
			}
		}

		protected void OnSignIn(object sender, SignInEventArgs e) {
			this.lblStatus.BeginInvoke((MethodInvoker)delegate() { 
				this.lblStatus.Text = "This service is currently running normally.";
				this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
				});
		}

		protected void OnSignOut(object sender, SignOutEventArgs e) {
			this.lblStatus.BeginInvoke((MethodInvoker)delegate() {
				lblStatus.Text = "Can't synchronize while logged out";
				lblStatus.ForeColor = Color.Red;
				});
		}

		private void FrmFavoritesService_Load(object sender, System.EventArgs e) {
			this.PluginHost.SignedIn += new SignInEventHandler(OnSignIn);
			this.PluginHost.SignedOut += new SignOutEventHandler(OnSignOut);
			
			QueryRequestType q = new QueryRequestType();
			XpQueryType query = new XpQueryType();
			query.Select = "/m:iqFavorites/m:favorite";
			q.XpQuery = new XpQueryType[] { query };

			this.PluginHost.StatusBarText = "Retrieving all favorites...";
			myService.BeginQuery(q, new AsyncCallback(OnInitialQuery), myService);
		}

		private void OnInitialQuery(IAsyncResult result) {
			try {
				Service service = (Service)result.AsyncState;
				QueryResponseType response = service.EndQuery(result);
				if (response != null && response.XpQueryResponse != null && response.XpQueryResponse[0].Status == ResponseStatus.Success) {
					this.PluginHost.StatusBarText = "Successfully retrieved favorites.";
					this.lblStatus.BeginInvoke((MethodInvoker)delegate() {
						this.lblStatus.Text = "Favorites last syncronized at " + DateTime.Now + ".";
						});
					
//					XmlSerializer a1 = new XmlSerializer(typeof(iqFavorites));
//					foreach (XmlElement e in response.XpQueryResponses[0].Any) {
//						XmlNodeReader a2 = new XmlNodeReader(e);
//						favoriteType t = (favoriteType)a1.Deserialize(a2);
//					}
					
//					XmlDocument d = new XmlDocument();
//					XmlElement root = d.CreateElement("iqFavorites");
//					foreach (XmlElement e in response.XpQueryResponses[0].Any) {
//						root.AppendChild(d.ImportNode(e, true));
//					}
//					d.AppendChild(root);
//
//					XmlSerializer serializer = new XmlSerializer(typeof(iqFavorites));
//					XmlNodeReader nr = new XmlNodeReader(d.DocumentElement);
//					iqFavorites iqf = (iqFavorites)serializer.Deserialize(nr);
					
//					XmlElement e = response.XpQueryResponses[0].Any[0];

//					XmlSerializer serializer = new XmlSerializer(typeof(iqFavorites));
//					XmlNodeReader nr = new XmlNodeReader(e);
//					iqFavorites iqf = (iqFavorites)serializer.Deserialize(nr);
					
//					XmlRootAttribute root = new XmlRootAttribute(e.LocalName);
//					root.Namespace = e.NamespaceURI;
//					XmlSerializer serializer = new XmlSerializer(typeof(favoriteType), root);
//					XmlNodeReader nr = new XmlNodeReader(e);
//					favoriteType iqf = (favoriteType)serializer.Deserialize(nr);

					favoriteType[] favorites = new favoriteType[response.XpQueryResponse[0].Any.Length];
					for (int i = 0; i < favorites.Length; i++) {
						XmlElement e = response.XpQueryResponse[0].Any[i];
						favorites[i] = (favoriteType)ObjectWrapper.GetObject(typeof(favoriteType), e);
					}

					tvFavorites.BeginInvoke((MethodInvoker)delegate() {
						tvFavorites.BeginUpdate();
						tvFavorites.BeginInvoke(
							new FillTreeViewDelegate(FillTreeView),
							new object[] {favorites, tvFavorites.Nodes}
							);
						tvFavorites.ExpandAll();
						tvFavorites.EndUpdate();
						});
					this.lblStatus.BeginInvoke((MethodInvoker)delegate() {
						this.lblStatus.Text += " (" + tvFavorites.Nodes.Count + ")"; 
						});
				} else {
					MessageBox.Show("No response");
				}
			}
			catch (Exception e) {
				MessageBox.Show(e.Message + "\n\n" + e.InnerException);
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e) {
			QueryRequestType q = new QueryRequestType();
			XpQueryType query = new XpQueryType();
			query.Select = xpath.Text;
			q.XpQuery = new XpQueryType[] { query };
			
			try {
				QueryResponseType response = myService.Query(q);
				if (response != null && response.XpQueryResponse != null) {
					MessageBox.Show("Got:\n\n" + response.XpQueryResponse[0].Any[0].OuterXml);
				} else {
					MessageBox.Show("No response");
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}
		}

		private void ItemCreated(object sender, FileSystemEventArgs e) {
			AddPathItem(e.FullPath);

			string realName = GetRealName(e.FullPath);

			favoriteType favorite = FavoriteConverter.Convert(realName);

			string path = new FileInfo(realName).DirectoryName.Substring(this.fileSystemWatcher_.Path.Length + 1);
			path = path.Replace("\\", "/");
			path = path.Substring(0, 1).ToUpper() + path.Substring(1);

			InsertRequestType req = new InsertRequestType();
			req.Select = GetXPath(Path.GetDirectoryName(e.FullPath));
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;
			req.Any = new XmlElement[] { FavoriteConverter.ConvertToXml(favorite) };

			try {
				InsertResponseType res = myService.Insert(req);
				if (res != null && res.Status == ResponseStatus.Success) {
					this.PluginHost.StatusBarText = "Item successfully inserted";
					
					// Insert new node into treeview
					TreeNode fld = LocateFull(path, this.tvFavorites.Nodes);
					if (fld != null) {
						fld.Nodes.Add(favorite.title[0]);
					}
				} else {
					this.PluginHost.StatusBarText = "Item not inserted";
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}

		}

		private void ItemRenamed(object sender, RenamedEventArgs e) {

			string realName = GetRealName(e.FullPath);

			favoriteType favorite = FavoriteConverter.Convert(realName);

			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = GetXPath(e.OldFullPath);
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;
			req.MaxOccurs = 1;
			req.MaxOccursSpecified = true;
			req.Any = new XmlElement[] { FavoriteConverter.ConvertToXml(favorite) };

			try {
				ReplaceResponseType res = myService.Replace(req);
				if (res != null && res.Status == ResponseStatus.Success) {
					this.PluginHost.StatusBarText = "Item successfully replaced";
				} else {
					this.PluginHost.StatusBarText = "Item not replaced";
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}

			RemovePathItem(e.OldFullPath);
			AddPathItem(e.FullPath);
		}

		private void ItemDeleted(object sender, FileSystemEventArgs e) {
			
			DeleteRequestType req = new DeleteRequestType();
			req.Select = GetXPath(e.FullPath);
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;
			req.MaxOccurs = 1;
			req.MaxOccursSpecified = true;
			
			try {
				DeleteResponseType res = myService.Delete(req);
				if (res != null && res.Status == ResponseStatus.Success) {
					this.PluginHost.StatusBarText = "Item successfully deleted";
				} else {
					this.PluginHost.StatusBarText = "Item not deleted";
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}

			RemovePathItem(e.FullPath);
		}

		private bool IsDirectory(string path) {
			return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
		}

		private string GetRealName(string path) {
			if (!IsDirectory(path)) {
				return Directory.GetFiles(GetRealName(Path.GetDirectoryName(path)), Path.GetFileName(path))[0];
			} else {
				return Directory.GetParent(path).GetDirectories(Path.GetFileName(path))[0].FullName;
			}
		}

		private void miOrganize_Click(object sender, System.EventArgs e) {
			MessageBox.Show("Go to IE Organize dialog");
		}
	}
}