using System;
using System.Xml;

namespace Commanigy.Iquomi.Services.BookmarkSync {
	/// <summary>
	/// Summary description for XmlTreeNode.
	/// </summary>
	public class XmlTreeNode : System.Windows.Forms.TreeNode {
		public XmlNode XmlNode;

		public XmlTreeNode(string text) : base() {
			;
		}

		public XmlTreeNode(XmlNode n) : base() {
			try {
				this.Text = n.SelectSingleNode("title").InnerXml;
			}
			catch (Exception) {
				this.Text = "Untitled";
			}

			if (n.Name == "folder") {
				this.ImageIndex = this.SelectedImageIndex = 0;
			} else {
				this.ImageIndex = this.SelectedImageIndex = 1;
			}

			XmlNode = n;
		}
	}
}
