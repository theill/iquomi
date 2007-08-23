using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Generated when listener is triggered.
	/// </summary>
	[Serializable()]
	public class ListenEventType {
		public ChangedBlueType[] ChangedBlues;
		public DeletedBlueType[] DeletedBlues;
	}
}