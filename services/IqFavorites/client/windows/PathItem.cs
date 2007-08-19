using System;

namespace Commanigy.Iquomi.Services.IqFavorites {

	/// <summary>
	/// Summary description for PathItem.
	/// </summary>
	public class PathItem {
		private PathType pathType;
		private string path;
		
		/// <summary>
		/// Property PathType (PathType)
		/// </summary>
		public PathType PathType {
			get {
				return this.pathType;
			}
			set {
				this.pathType = value;
			}
		}
		
		/// <summary>
		/// Property Path (string)
		/// </summary>
		public string Path {
			get {
				return this.path;
			}
			set {
				this.path = value;
			}
		}

		public PathItem(PathType pathType, string path) {
			this.pathType = pathType;
			this.path = path;
		}
	}

}