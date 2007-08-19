using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class Role {
		public int Id;
		public Guid SubscriptionId;
		public int AccountId;
		public int ScopeId;
		public int RoleTemplateId;
		public DateTime ActiveFrom;
		public DateTime ActiveTo;

		public Scope Scope;
		public bool ScopeExists;
		public RoleTemplate RoleTemplate;
		
		public Role() {
			;
		}
	}
}