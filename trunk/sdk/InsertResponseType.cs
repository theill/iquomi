using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for InsertResponseType.
	/// </summary>
	[Serializable()]
	public class InsertResponseType : BaseResponseType {
		public int NewChangeNumber;
		public NewBlueIdType[] NewBlueIds;
	}
}