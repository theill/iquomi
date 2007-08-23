using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for PackageItem.
	/// </summary>
	[Serializable()]
	public class PackageItem {
		public int Id;
		public int PackageId;
		public string Name;
		public string Type;
		public long Size;
		public object Data;

		public PackageItem() {
			;
		}
	}
}