using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class ChangeQueryResponseType {
		public int BaseChangeNumber;
		public ChangeQueryResponseStatus Status;
		public ChangedBlueType[] ChangedBlues;
		public DeletedBlueType[] DeletedBlues;
	}
}