using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class UpdateResponseType {
		public UpdateBlockStatusType[] UpdateBlockStatuses;
		public int NewChangeNumber;
	}
}