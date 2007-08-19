#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Security;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// The document is used to restrict access to the content document when 
	/// performing service methods (core such as Insert and Replace as well
	/// as custom methods).
	/// </summary>
	public class RoleListDocument : IqDocument {
		private RoleListType roleList;

		public static RoleListDocument Create(Api.Subscription s) {
			XmlDocument d = new XmlDocument();
			d.LoadXml(s.RoleList);

			return new RoleListDocument(d, s.GetRoleList());
		}

		private RoleListDocument(XmlDocument d, RoleListType roleList) : base(d) {
			this.roleList = roleList ?? new RoleListType();
		}

		public RoleType GetRole(SubjectType subject) {
			if (roleList.Role != null) {
				foreach (RoleType role in roleList.Role) {
					if (role.Subject.UserId == subject.UserId) {
						return role;
					}
				}
			}

			throw new SecurityException("Access denied for user " + subject.UserId);

//			XmlElement roleNode = (XmlElement)this.document.SelectSingleNode("/roleList/role[subject/@userId='" + subject.UserId + "']");
//			if (roleNode == null) {
//				throw new AccessControlException("Access denied for user " + subject.UserId);
//			}
//
//			// TODO use "XmlSerializer" to fill out these properties
//			RoleType role = new RoleType();
//			role.Subject = subject;
//			role.RoleTemplateRef = roleNode.GetAttribute("roleTemplateRef");
//			role.ScopeRef = roleNode.GetAttribute("scopeRef");
//
//			return role;
		}

		public RoleListScopeType GetRoleListScope(string scopeRef) {
			if (roleList.Scope != null && !string.IsNullOrEmpty(scopeRef)) {
				foreach (RoleListScopeType scope in roleList.Scope) {
					if (scope.Id.Equals(scopeRef)) {
						return scope;
					}
				}
			}

			return null;
		}
	}
}