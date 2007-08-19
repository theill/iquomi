using System;
using System.Reflection;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class UpdateBlockStatusType : BaseResponseType {
		public InsertResponseType[] InsertResponses;
		public DeleteResponseType[] DeleteResponses;
		public ReplaceResponseType[] ReplaceResponses;
	}
}