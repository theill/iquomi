using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for UpdateBlockType.
	/// </summary>
	[Serializable()]
	public class UpdateBlockType {
		public string Select;
		public UpdateBlockOnErrorType OnError;

		public InsertRequestType[] InsertRequests;
		public DeleteRequestType[] DeleteRequests;
		public ReplaceRequestType[] ReplaceRequests;
	}
}