using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for RoleTemplate.
	/// </summary>
	[Serializable()]
	public class RoleTemplate {
		public int Id;
		public int ServiceId;
		public string Name;
		public int Priority;

		public RoleTemplateMethod[] RoleTemplateMethods;

		public RoleTemplate() {
			;
		}

		public override string ToString() {
			return "[id=" + Id + ",Name=" + Name + ",Priority=" + Priority + "]" + base.ToString();
		}

	}
}
