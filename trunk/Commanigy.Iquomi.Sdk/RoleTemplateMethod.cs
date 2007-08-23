using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class RoleTemplateMethod {
		private int roleTemplateId;

		public int RoleTemplateId {
			get { return roleTemplateId; }
			set { roleTemplateId = value; }
		}

		private int methodTypeId;

		public int MethodTypeId {
			get { return methodTypeId; }
			set { methodTypeId = value; }
		}

		private int scopeId;

		public int ScopeId {
			get { return scopeId; }
			set { scopeId = value; }
		}

		public RoleTemplateMethod() {
			;
		}

		public override string ToString() {
			return "[RoleTemplateId=" + RoleTemplateId + ",MethodTypeId=" + MethodTypeId + ",ScopeId=" + ScopeId + "]";
		}

	}
}
