#region Using directives

using System;
using System.Collections.Generic;
using System.Reflection;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// Summary description for XmlStoreRepository.
	/// </summary>
	public sealed class XmlStoreRepository {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private static readonly XmlStoreRepository instance = new XmlStoreRepository();

		private Dictionary<Guid, IXmlStore> cachedXmlStores;

		private XmlStoreRepository() {
			cachedXmlStores = new Dictionary<Guid, IXmlStore>();
		}

		public static XmlStoreRepository Instance {
			get {
				return instance;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public IXmlStore Find(RequestType request, Module serviceTypesModule) {
			DbAccount account = DbAccount.FindByIqid(request.Key[0].Puid);
			if (account.Id == 0) {
				throw new ApplicationException("User " + request.Key[0].Puid + " not found.");
			}

			DbSubscription subscription = new DbSubscription();
			subscription.AccountId = account.Id;
			subscription.Name = request.Service;
			subscription.DbFindByAccountIdName();
			if (Guid.Empty.Equals(subscription.Id)) {
				throw new ApplicationException("Subscription on " + request.Service + " for " + request.Key[0].Puid + " not found.");
			}

			DbService service = new DbService();
			service.Id = subscription.ServiceId;
			service.DbRead();
			if (service.Id == 0) {
				throw new ApplicationException("No service associated with subscription " + request.Service);
			}

			// TODO move these out into jobs implemented in .NET when 
			// Yukon is released
			SyncRoleList(subscription);
			SyncRoleMap(service);

//			log.Debug("subscription.RoleList: \n" + subscription.RoleList);
//			log.Debug("service.RoleMap: \n" + service.RoleMap);

			// TODO implement cache layer for returning same instance of document
			if (cachedXmlStores.ContainsKey(subscription.Id)) {
				return cachedXmlStores[subscription.Id];
			}

			XmlStore store = new XmlStore(
				ContentDocument.Create(subscription), 
				RoleListDocument.Create(subscription), 
				NotifyListDocument.Create(subscription), 
				SystemDocument.Create(service)
				);
			store.ServiceModule = serviceTypesModule;

			//TODO: disabled caused by issues with cross-service updates
			//cachedXmlStores[subscription.Id] = store;

			return store;
		}

		private void SyncRoleList(DbSubscription subscription) {
			RoleListType roleList = new RoleListType();

			DbRole[] roles = DbRole.DbFindAllBySubscriptionId(subscription.Id);
			roleList.Role = new RoleType[roles.Length];
			for (int i = 0; i < roles.Length; i++) {
				RoleType rt = new RoleType();

				rt.Notes = null;
				rt.Subject = new SubjectType();
				rt.Subject.UserId = DbAccount.FindById(roles[i].AccountId).Iqid;
				rt.ExpiresAt = roles[i].ActiveTo;
				rt.ScopeRef = roles[i].ScopeId.ToString();
				rt.RoleTemplateRef = roles[i].RoleTemplateId.ToString();

				roleList.Role[i] = rt;
			}

			DbScope[] scopes = DbSubscriptionScope.DbFindAllScopesBySubscription(subscription.Id);
			roleList.Scope = new RoleListScopeType[scopes.Length];
			for (int i = 0; i < scopes.Length; i++) {
				roleList.Scope[i] = (RoleListScopeType)SyncScope(new RoleListScopeType(), scopes[i]);
				roleList.Scope[i].Id = scopes[i].Id.ToString();
			}

			subscription.SetRoleList(roleList);
		}

		private void SyncRoleMap(DbService service) {
			RoleMapType roleMap = new RoleMapType();

			DbRoleTemplate[] roleTemplates = DbRoleTemplate.DbFindAllByService(service.Id);
			roleMap.RoleTemplate = new RoleTemplateType[roleTemplates.Length];
			for (int i = 0; i < roleTemplates.Length; i++) {
				RoleTemplateType roleTemplate = new RoleTemplateType();
				// TODO use? roleTemplate.Name = roleTemplates[i].Name;
				roleTemplate.Name = roleTemplates[i].Id.ToString();
				roleTemplate.Priority = roleTemplates[i].Priority;

				DbRoleTemplateMethod[] methods = roleTemplates[i].DbFindAllRoleTemplateMethodsByRoleTemplate();
				roleTemplate.Method = new RoleTemplateTypeMethod[methods.Length];
				for (int j = 0; j < methods.Length; j++) {
					RoleTemplateTypeMethod method = new RoleTemplateTypeMethod();
					method.Name = DbMethodType.GetNameForId(methods[j].MethodTypeId);
					method.ScopeRef = methods[j].ScopeId.ToString();
					roleTemplate.Method[j] = method;
				}

				roleMap.RoleTemplate[i] = roleTemplate;
			}

			DbScope[] scopes = DbServiceScope.DbFindAllScopesByService(service.Id);
			roleMap.Scope = new RoleMapTypeScope[scopes.Length];
			for (int i = 0; i < scopes.Length; i++) {
				roleMap.Scope[i] = (RoleMapTypeScope)SyncScope(new RoleMapTypeScope(), scopes[i]);
				roleMap.Scope[i].Id = scopes[i].Id.ToString();
			}

			service.SetRoleMap(roleMap);
		}

		private ScopeType SyncScope(ScopeType scope, DbScope dbScope) {
			scope.Name = new LocalizableString[] { 
					new LocalizableString()
					};
			scope.Name[0].Value = dbScope.Name;
			scope.Base = (dbScope.Base == DbScope.T) ? ScopeTypeBase.T : ScopeTypeBase.Nil;

			DbShape[] shapes = dbScope.DbFindAllShapes();
			scope.Shape = new ShapeType[shapes.Length];
			for (int j = 0; j < shapes.Length; j++) {
				ShapeType shape = new ShapeType();
				shape.Select = shapes[j].Select;
				shape.Type = (shapes[j].Type == DbShape.INCLUDE) ? ShapeTypeType.Include : ShapeTypeType.Exclude;
				scope.Shape[j] = shape;
			}

			return scope;
		}
	}
}