using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class RoleTemplateDescription {
		public int RoleTemplateId;
		public int LanguageId;
		public string Description;

		public RoleTemplateDescription() {
			;
		}
	}
}