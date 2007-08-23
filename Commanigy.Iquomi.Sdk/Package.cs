#region MyRegion

using System;

#endregion

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for Package.
	/// </summary>
	[Serializable()]
	public class Package {
		public const string StateNew = "N";
		public const string StateActivated = "A";
		public const string StateDeactivated = "D";
		public const string StateRetired = "R";

		private int id;

		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		private int serviceId;

		public int ServiceId {
			get {
				return serviceId;
			}
			set {
				serviceId = value;
			}
		}

		private int platformId;

		public int PlatformId {
			get {
				return platformId;
			}
			set {
				platformId = value;
			}
		}

		private string version;

		public string Version {
			get {
				return version;
			}
			set {
				version = value;
			}
		}

		private DateTime releaseDate;

		public DateTime ReleaseDate {
			get {
				return releaseDate;
			}
			set {
				releaseDate = value;
			}
		}

		private string state;

		public string State {
			get {
				return state;
			}
			set {
				state = value;
			}
		}

		public PackageItem[] Items;

		public Package() {
			;
		}
	}
}