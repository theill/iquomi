using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for UpdateRequestType.
	/// </summary>
	[Serializable()]
	public class UpdateRequestType {
		public UpdateBlockType[] UpdateBlocks;
	}
}