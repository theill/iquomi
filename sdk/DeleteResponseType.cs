using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for DeleteResponseType.
	/// </summary>
	[Serializable()]
	public class DeleteResponseType : BaseResponseType {
		public int NewChangeNumber;
	}
}