using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Api.Services;

namespace Commanigy.Iquomi.Services.BookmarkSync {
	/// <summary>
	/// The BookmarkSync Service is able to read a users Internet Explorer
	/// favourites and write them as an XBEL formatted document. Refer to
	/// http://pyxml.sourceforge.net/topics/dtds/xbel-1.0.dtd for details
	/// about this format.
	/// </summary>
    public class FrmFavoritesService : System.Windows.Forms.Form {
		public delegate void FillTreeViewDelegate(XmlNode node, TreeNodeCollection col);
		
		private FileSystemWatcher fileSystemWatcher;
		
		private XmlDocument favorites_;
		
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
		
		private Service myService;
		
		public FrmFavoritesService() : base() {
			InitializeComponent();

			realNamesLookup_ = new Hashtable();

			// Lookup users Favorites folder in order to watch it
			string favoritesFolder = System.Environment.GetFolderPath(
				System.Environment.SpecialFolder.Favorites
				);

			favoritesFolder = @"C:\temp\minefavorites";

			fileSystemWatcher.Path = favoritesFolder;
			
			favorites_ = ReadFavorites(fileSystemWatcher.Path);
			//			favorites_ = _request("/favorites/");
			favorites_.Save("favorites.xml");

			tvFavorites.Nodes.Clear();

			// _post(favorites_, "/favorites/");
			
			// WriteFavorites(favorites_, @"c:\temp\minefavorites");
			
			myService = this.GetService("bookmarksync");
		}

		private void FillTreeView(XmlNode r, TreeNodeCollection c) {
			foreach (XmlNode n in r.SelectNodes("folder")) {
				XmlTreeNode folder = new XmlTreeNode(n);
				FillTreeView(n, folder.Nodes);
				c.Add(folder);
			}

			foreach (XmlNode n in r.SelectNodes("bookmark")) {
				XmlTreeNode bookmark = new XmlTreeNode(n);
				c.Add(bookmark);
			}
		}

		private XmlElement CreateFolderElement(string path, XmlElement root) {
			XmlElement element = root.OwnerDocument.CreateElement("folder");
			element.SetAttribute("folded", "yes");
				
			XmlElement title = root.OwnerDocument.CreateElement("title");
			title.InnerText = Path.GetFileName(path);
			element.AppendChild(title);

			return element;
		}

		private XmlElement CreateBookmarkElement(string path, XmlElement root) {
			XmlElement element = root.OwnerDocument.CreateElement("bookmark");

			StreamReader reader = File.OpenText(path);
			string href = reader.ReadToEnd();
			href = href.Substring(href.IndexOf("URL=") + 4).Trim();
			element.SetAttribute("href", href);
			reader.Close();

			XmlElement title = root.OwnerDocument.CreateElement("title");
			title.InnerText = Path.GetFileNameWithoutExtension(path);
			element.AppendChild(title);

			return element;
		}
		
		private XmlElement EnumerateFolder(string path, XmlElement root) {
			string[] directories = Directory.GetDirectories(path);
			for (int i = 0; i < directories.Length; i++) {
				XmlElement element = CreateFolderElement(directories[i], root);

				element = EnumerateFolder(directories[i], element);
				root.AppendChild(element);

				AddPathItem(directories[i]);
			}
			
			root = EnumerateFiles(path, root);

			return root;
		}

		private XmlElement EnumerateFiles(string path, XmlElement root) {
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++) {
				XmlElement element = CreateBookmarkElement(files[i], root);
				root.AppendChild(element);

				AddPathItem(files[i]);
			}
			
			return root;
		}

		private XmlDocument ReadFavorites(string path) {
			XmlDocument xml = new XmlDocument();
			/* this is _slow_ when added
			xml.AppendChild(
				xml.CreateDocumentType(
				"XBEL", 
				"+//IDN python.org//DTD XML Bookmark Exchange Language 1.0//EN//XML", 
				"http://www.python.org/topics/xml/dtds/xbel-1.0.dtd",
				null
				)
				);
			*/
			XmlElement root = xml.CreateElement("xbel");
			root.SetAttribute("version", "1.0");
			root.SetAttribute("seqno", "107");
			root.SetAttribute("folded", "yes");
			root.AppendChild(xml.CreateElement("title"));
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmFavoritesService));
			this.fileSystemWatcher = new System.IO.FileSystemWatcher();
			this.ilIcons = new System.Windows.Forms.ImageList(this.components);
			this.tvFavorites = new System.Windows.Forms.TreeView();
			this.xpath = new System.Windows.Forms.TextBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblStatusHeader = new System.Windows.Forms.Label();
			this.mmnBookmarkSync = new System.Windows.Forms.MainMenu();
			this.miActions = new System.Windows.Forms.MenuItem();
			this.miSynchronize = new System.Windows.Forms.MenuItem();
			this.miOrganize = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
			this.SuspendLayout();
			// 
			// fileSystemWatcher
			// 
			this.fileSystemWatcher.EnableRaisingEvents = true;
			this.fileSystemWatcher.IncludeSubdirectories = true;
			this.fileSystemWatcher.SynchronizingObject = this;
			this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.ItemDeleted);
			this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.ItemRenamed);
			this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.ItemCreated);
			// 
			// ilIcons
			// 
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
			// miOrganize
			// 
			this.miOrganize.Index = 1;
			this.miOrganize.Text = "&Organize...";
			this.miOrganize.Click += new System.EventHandler(this.miOrganize_Click);
			// 
			// FrmFavoritesService
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 453);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblStatusHeader);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.xpath);
			this.Controls.Add(this.tvFavorites);
			this.Menu = this.mmnBookmarkSync;
			this.Name = "FrmFavoritesService";
			this.Text = "Favorites";
			this.Load += new System.EventHandler(this.FrmFavoritesService_Load);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
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
			string[] paths = SplitPath(folder.Substring(fileSystemWatcher.Path.Length));

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

		/*
		private void UpdateDOMFolder(XmlElement element, string path) {
			element.SetAttribute("name", Path.GetFileName(path));
			element.SetAttribute("search", Path.GetFileName(path.ToLower()));
		}

		private void UpdateDOMFavorite(XmlElement element, string filename) {
			element.SetAttribute("name", Path.GetFileNameWithoutExtension(filename));
			element.SetAttribute("search", Path.GetFileNameWithoutExtension(filename).ToLower());
		}

		private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e) {
			Console.Out.WriteLine("Changed (create, delete, update): " + e.Name);
		}

		private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e) {
			Console.Out.WriteLine("Renamed: " + e.OldFullPath + " > " + e.Name);
			
			if (!Directory.Exists(e.FullPath)) {
				UpdateDOMFavorite(
					(XmlElement)favorites_.SelectSingleNode(GetXPathForFile(e.OldFullPath.ToLower())), 
					e.FullPath
					);
			} else {
				UpdateDOMFolder(
					(XmlElement)favorites_.SelectSingleNode(GetXPathForFolder(e.OldFullPath.ToLower())), 
					e.FullPath
					);
			}

			favorites_.Save("favorites.xml");
		}
*/
		protected void OnSignIn(object sender, SignInEventArgs e) {
			Console.Out.WriteLine("Favorites says: The user signed in");
		}

		protected void OnSignOut(object sender, SignOutEventArgs e) {
			Console.Out.WriteLine("Favorties says: The user signed out!");
		}

		private void FrmFavoritesService_Load(object sender, System.EventArgs e) {
			this.ServiceContainer.SignedIn += new SignInEventHandler(OnSignIn);
			this.ServiceContainer.SignedOut += new SignOutEventHandler(OnSignOut);
			
			QueryRequestType q = new QueryRequestType();
			XpQueryType query = new XpQueryType();
			query.Select = "//folder";
			q.XpQueries = new XpQueryType[] { query };

			this.ServiceContainer.StatusBarText = _("Retrieving all bookmarks...");
			myService.BeginQuery(q, new AsyncCallback(OnInitialQuery), myService);
		}

		private void OnInitialQuery(IAsyncResult result) {
			try {
				this.ServiceContainer.StatusBarText = _("Successfully retrieved bookmarks.");

				this.lblStatus.Text = _("Bookmarks last syncronized at " + DateTime.Now + ".");

				Service s = (Service)result.AsyncState;
				QueryResponseType response = s.EndQuery(result);
				if (response != null && response.XpQueryResponses != null && response.XpQueryResponses[0].Status == ResponseStatus.Success) {
					XmlDocument d = new XmlDocument();
					XmlElement root = d.CreateElement("xbel");
					foreach (XmlElement e in response.XpQueryResponses[0].Any) {
						root.AppendChild(d.ImportNode(e, true));
					}
					d.AppendChild(root);
					tvFavorites.BeginUpdate();
					tvFavorites.Invoke(new FillTreeViewDelegate(FillTreeView), new object[] {d.DocumentElement, tvFavorites.Nodes});
					tvFavorites.ExpandAll();
					tvFavorites.EndUpdate();
					this.lblStatus.Text += " (" + tvFavorites.Nodes.Count + ")";
				} else {
					MessageBox.Show("No response");
				}
			}
			catch (Exception e) {
				MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e) {
			QueryRequestType q = new QueryRequestType();
			XpQueryType query = new XpQueryType();
			query.Select = xpath.Text;
			q.XpQueries = new XpQueryType[] { query };
			
			try {
				QueryResponseType response = myService.Query(q);
				if (response != null && response.XpQueryResponses != null) {
					MessageBox.Show("Got:\n\n" + response.XpQueryResponses[0].Any[0].OuterXml);
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

			XmlElement element;
			if (!IsDirectory(e.FullPath)) {
				element = CreateBookmarkElement(realName, this.favorites_.DocumentElement);
			} else {
				element = CreateFolderElement(realName, this.favorites_.DocumentElement);
			}

			InsertRequestType req = new InsertRequestType();
			req.Select = GetXPath(Path.GetDirectoryName(e.FullPath));
			req.Any = new XmlElement[] { element };

			try {
				InsertResponseType res = myService.Insert(req);
				if (res != null && res.Status == ResponseStatus.Success) {
					ServiceContainer.StatusBarText = _("Item successfully inserted");
					
					// Insert new node into treeview
//					foreach (XmlTreeNode n in tvFavorites.Nodes) {
						//tvFavorites.Nodes.Add(new XmlTreeNode(element));
//					}
				} else {
					ServiceContainer.StatusBarText = _("Item not inserted");
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}

		}

		private void ItemRenamed(object sender, RenamedEventArgs e) {
			/*
			if (!Directory.Exists(e.FullPath)) {
				UpdateDOMFavorite(
					(XmlElement)favorites_.SelectSingleNode(GetXPathForFile(e.OldFullPath.ToLower())), 
					e.FullPath
					);
			} else {
				UpdateDOMFolder(
					(XmlElement)favorites_.SelectSingleNode(GetXPathForFolder(e.OldFullPath.ToLower())), 
					e.FullPath
					);
			}
			*/

			string realName = GetRealName(e.FullPath);

			XmlElement element;
			if (!IsDirectory(e.FullPath)) {
				element = CreateBookmarkElement(realName, this.favorites_.DocumentElement);
			} else {
				element = CreateFolderElement(realName, this.favorites_.DocumentElement);
			}

			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = GetXPath(e.OldFullPath);
			req.MinOccurs = new MinOccursType();
			req.MinOccurs.Value = 1;
			req.MaxOccurs = new MaxOccursType();
			req.MaxOccurs.Value = 1;
			req.Any = new XmlElement[] { element };

			try {
				ReplaceResponseType res = myService.Replace(req);
				if (res != null && res.Status == ResponseStatus.Success) {
					ServiceContainer.StatusBarText = _("Item successfully replaced");
				} else {
					ServiceContainer.StatusBarText = _("Item not replaced");
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
			req.MinOccurs = new MinOccursType();
			req.MinOccurs.Value = 1;
			req.MaxOccurs = new MaxOccursType();
			req.MaxOccurs.Value = 1;
			
			try {
				DeleteResponseType res = myService.Delete(req);
				if (res != null && res.Status == ResponseStatus.Success) {
					ServiceContainer.StatusBarText = _("Item successfully deleted");
				} else {
					ServiceContainer.StatusBarText = _("Item not deleted");
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
		
		}
	}
}