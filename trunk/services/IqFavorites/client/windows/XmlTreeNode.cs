using System;
using System.Xml;
using System.Windows.Forms;

namespace Commanigy.Iquomi.Services.IqFavorites {
	/// <summary>
	/// Summary description for XmlTreeNode.
	/// </summary>
	public class XmlTreeNode : TreeNode {
		public XmlTreeNode(string text) : base() {
			;
		}

		public XmlTreeNode(favoriteType favorite) : base() {
			this.Text = favorite.title[0];
			this.ImageIndex = this.SelectedImageIndex = 1;
		}
	}
}
