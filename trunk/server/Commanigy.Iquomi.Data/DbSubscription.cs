#region Using directives

using System;
using System.Data;
using System.Xml.Schema;
using System.Collections.Generic;
using System.Collections;

using log4net;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Services;
using System.ComponentModel;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Maps "subscription" database table.
	/// </summary>
	[DataObject()]
	public class DbSubscription : Subscription, IDbObject<DbSubscription> {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);
		
		public DbSubscription() {
			;
		}

		#region IDbObject Members

		public DbSubscription DbCreate() {
			using (DbUtility db = new DbUtility("iqSubscriptionCreate")) {
				db.In("@id", this.Id);
				db.In("@account_id", this.AccountId);
				db.In("@service_id", this.ServiceId);
				db.In("@name", this.Name);
				db.In("@xml", this.Xml);
				db.In("@url_xml", this.UrlXml);
				db.In("@role_list", this.RoleList);
				db.In("@notify_list", this.NotifyList);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}
		
		public DbSubscription DbRead() {
			using (DbUtility db = new DbUtility("iqSubscriptionRead")) {
				db.In("@id", DbType.Guid, Id);
				return (DbSubscription)db.Fill(this);
			}
		}
		
		public DbSubscription DbUpdate() {
			using (DbUtility db = new DbUtility("iqSubscriptionUpdate")) {
				db.In("@id", this.Id);
				db.In("@account_id", this.AccountId);
				db.In("@name", this.Name);
				db.In("@xml", this.Xml);
				db.In("@url_xml", this.UrlXml);
				db.In("@role_list", this.RoleList);
				db.In("@notify_list", this.NotifyList);
				return (DbSubscription)db.Fill(this);
			}
		}
		
		public DbSubscription DbDelete() {
			using (DbUtility db = new DbUtility("iqSubscriptionDelete")) {
				db.In("@id", this.Id);
				db.In("@account_id", this.AccountId);
				if (db.ExecuteNonQuery() == 1) {
					this.Id = Guid.Empty;
				}

				return this;
			}
		}

		#endregion

		public static DbSubscription DbRead(Guid id) {
			DbSubscription a = new DbSubscription();
			a.Id = id;
			return a.DbRead();
		}

		public static DbSubscription[] DbFindAllByUrl(string urlXml) {
			using (DbUtility db = new DbUtility("iqSubscriptionFindAllByUrlXml")) {
				db.In("@url_xml", urlXml);
				return (DbSubscription[])db.FillAll(typeof(DbSubscription));
			}
		}

		public static DataTable DbGetRoles(Guid subscriptionId, Int32 languageId) {
			using (DbUtility db = new DbUtility("iqListRolesBySubscription")) {
				db.In("@subscription_id", subscriptionId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}

			/*
			List<RoleType> a = new List<RoleType>();
			RoleType rt = new RoleType();
			rt.Subject = new SubjectType();
			rt.Subject.UserId = "peter theill";
			rt.Subject.CredType = "cred type";
			rt.Notes = new LocalizableString[] { new LocalizableString() };
			rt.Notes[0].Value = "asdf";
			a.Add(rt);
			
			rt = new RoleType();
			rt.Subject = new SubjectType();
			rt.Subject.UserId = "svend jensen";
			rt.Subject.CredType = "cred type";
			rt.Notes = new LocalizableString[] { new LocalizableString() };
			rt.Notes[0].Value = "fsdkl ejkl ejkl jekl djkl d";
			a.Add(rt);
			
			rt = new RoleType();
			rt.Subject = new SubjectType();
			rt.Subject.UserId = "johannes den sjove";
			rt.Subject.CredType = "cred type";
			rt.Notes = new LocalizableString[] { new LocalizableString() };
			rt.Notes[0].Value = "asdf";
			a.Add(rt);
			return a;
			*/
		}

		/// <summary>
		/// Creates initial document based on service schema.
		/// 
		///   <?xml version="1.0" encoding="utf-8" ?>
		///   <m:myFavoriteWebSites 
		///		changeNumber="1" 
		///		instanceId="16a661b3-a860-476d-9ffd-bb9bd1901b8b"
		///		xmlns:m="http://schemas.iquomi.com/myFavoriteWebSites" />
		/// 
		/// It's then possible to use this root node when performing
		/// the InsertRequest with a Select attribute of:
		/// 
		///   /m:myFavoriteWebSites
		/// 
		/// </summary>
		/// <returns></returns>
		public DbSubscription DbCreateDocument() {
			this.Id = Guid.NewGuid();

			DbService service = new DbService();
			service.Id = this.ServiceId;
			service.DbRead();

			XmlSchema xsd = service.GetXmlSchema();
//			xsd.Compile(null);
			XmlSchemaSet schemas = new XmlSchemaSet();
			schemas.Add(xsd);
			schemas.Compile();

			IEnumerator en = xsd.Elements.Values.GetEnumerator();
			if (!en.MoveNext()) {
				throw new InvalidOperationException("No elements in schema!");
			}

			// TODO figure out a way to generate a "base" document based on schema
			XmlSchemaElement e = (XmlSchemaElement)en.Current;
			this.Xml = "<" + e.Name + " iq:ChangeNumber=\"1\" iq:InstanceId=\"" + this.Id.ToString() + "\" xmlns=\"" + xsd.TargetNamespace + "\" xmlns:iq=\"http://schemas.iquomi.com/2004/01/core\" />";

			return this.DbCreate();
		}


		public DbScope DbCreateScope(DbScope v) {
			using (DbUtility db = new DbUtility("iqScopeCreateBySubscription")) {
				db.In("@subscription_id", this.Id);
				db.In("@language_id", v.LanguageId);
				db.In("@name", v.Name);
				db.In("@base", v.Base);
				v.Id = (int)db.ExecuteScalar();
				return (DbScope)v;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DbSubscription DbFindByAccountIdName() {
			DbSubscription subscription = null;
			using (DbUtility db = new DbUtility("iqSubscriptionFindByAccountIdName")) {
				db.In("@account_id", this.AccountId);
				db.In("@name", this.Name);
				subscription = (DbSubscription)db.Fill(this);
			}
			if (Guid.Empty.Equals(subscription.Id)) {
				return subscription;
			}

			DbRole[] roles = DbRole.DbFindAllBySubscriptionId(subscription.Id);

			// TODO: a 1:1 map must be implemented. the current solution is 
			// not good enough
			RoleListType roleList = new RoleListType();
			roleList.Role = new RoleType[roles.Length];
			for (int i = 0; i < roles.Length; i++) {
				RoleType rt = new RoleType();
				rt.Id = Convert.ToString(roles[i].Id);
				rt.RoleTemplateRef = Convert.ToString(roles[i].RoleTemplateId);
				rt.ScopeRef = Convert.ToString(roles[i].ScopeId);
				rt.ExpiresAt = roles[i].ActiveTo;
				rt.ExpiresAtSpecified = (roles[i].ActiveTo != null) ? roles[i].ActiveTo.Equals(DateTime.MinValue) : false;
				rt.Subject = new SubjectType();
				rt.Subject.UserId = Convert.ToString(roles[i].AccountId);

				roleList.Role[i] = rt;
			}

			subscription.SetRoleList(roleList);

			// get all listeners for this subscription in order to build a 
			// version of the NotifyList document.
			DbSubscriptionListener[] listeners = DbSubscriptionListener.DbFindAllBySubscriptionId(subscription.Id);

			// TODO: a 1:1 map must be implemented. the current solution is 
			// not good enough
			NotifyListType notifyList = new NotifyListType();
			notifyList.Listener = new ListenerType[listeners.Length];
			for (int i = 0; i < listeners.Length; i++) {
				ListenerType lt = new ListenerType();
				lt.Id = listeners[i].Id.ToString();
				lt.Creator = Api.CoreUtility.JoinIqid(DbAccount.FindById(listeners[i].AccountId).Iqid);
				lt.Context = new ListenerTypeContext();
				lt.Context.Uri = listeners[i].ContextUri;
				lt.Context.Any = null;
				lt.Trigger = new ListenerTypeTrigger();
				lt.Trigger.Select = listeners[i].Filter;
				lt.Trigger.Mode = ListenerTypeTriggerMode.IncludeData;
				lt.Trigger.BaseChangeNumber = "0";
				lt.To = listeners[i].To;

				notifyList.Listener[i] = lt;
			}

			subscription.SetNotifyList(notifyList);

			return subscription;
		}

		public static DataTable DbListAllByAccount(int accountId, int languageId) {
			using (DbUtility db = new DbUtility("iqListMySubscriptions")) {
				db.In("@account_id", accountId);
				db.In("@language_id", languageId);
				return db.GetDataTable();
			}
		}

		public static DataTable DbQueryAll(int accountId, int languageId, string query) {
			log.DebugFormat("Querying subscriptions for \"{0}\"", query);

			using (DbUtility db = new DbUtility("iqQuerySubscriptions")) {
				db.In("@account_id", accountId);
				db.In("@language_id", languageId);
				db.In("@query", query);
				return db.GetDataTable();
			}
		}

//		public DbRole[] DbFindAllRoles() {
//			DbUtility db = new DbUtility();
//			db.Cmd("iqFindAllRolesBySubscription", CommandType.StoredProcedure);
//			db.In("@subscription_id", DbType.Guid, this.Id);
//			return (DbRole[])db.FillAll(typeof(DbRole));
//		}
	}
}