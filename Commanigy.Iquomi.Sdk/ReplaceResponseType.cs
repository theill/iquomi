using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class ReplaceResponseType : BaseResponseType {
		public int NewChangeNumber;
		public NewBlueIdType[] NewBlueIds;
	}
}