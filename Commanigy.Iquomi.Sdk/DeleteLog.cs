using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for DeleteLog.
	/// </summary>
	[Serializable()]
	public class DeleteLog {
		public Guid SubscriptionId;
		public UInt64 ChangeNumber;
		public Guid Uuid;
	}
}
