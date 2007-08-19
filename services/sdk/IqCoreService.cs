#region Using directives

using System;
using System.Xml;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Store;

#endregion

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// WebService accessing generic services by providing core insert, 
	/// replace, update, delete and query methods.
	/// </summary>
	public abstract class IqCoreService : System.Web.Services.WebService {
		private static readonly ILog log = LogManager.GetLogger(
				System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		// Placeholders for soap headers - must be public
		public SoapAuthenticationType Authentication;
		public SoapRequestType Request;

		public abstract System.Reflection.Module ServiceModule { get; }

		public IqCoreService() {
			
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public virtual InsertResponseType Insert(InsertRequestType req) {
			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

			InsertResponseType res = store.Insert(subject, req);
			if (res.Status == ResponseStatus.Success) {
				Save(store, DbMethodType.Insert);
			}

			return res;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod()]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public virtual DeleteResponseType Delete(DeleteRequestType req) {
			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

			DeleteResponseType res = store.Delete(subject, req);
			if (res.Status == ResponseStatus.Success) {
				Save(store, DbMethodType.Delete);
			}

			return res;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod()]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public virtual ReplaceResponseType Replace(ReplaceRequestType req) {
			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

			ReplaceResponseType res = store.Replace(subject, req);
			if (res.Status == ResponseStatus.Success) {
				Save(store, DbMethodType.Replace);
			}

			return res;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public virtual UpdateResponseType Update(UpdateRequestType req) {
			if (req.UpdateBlock == null || req.UpdateBlock.Length == 0) {
				throw new SoapException("At least one UpdateBlock must be specified", SoapException.ClientFaultCode);
			}

			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

			// Used to determine if a subscription update is necessary
			bool updateSubscription = false;

			UpdateResponseType res = store.Update(subject, req);
			foreach (UpdateBlockStatusType up in res.UpdateBlockStatus) {
				if (up.Status == ResponseStatus.Success) {
					// One of the update blocks successed which means it's
					// necessary to update the entire subscription. Even
					// though other blocks might have failed the data is
					// consistent since each UpdateBlock will do proper 
					// rollback in case they fail
					updateSubscription = true;
					break;
				}
			}

			if (updateSubscription) {
				Save(store, DbMethodType.Update);
			}

			return res;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod()]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public virtual QueryResponseType Query(QueryRequestType req) {
			try {
				SubjectType subject = GetSubject();

				DbSubscription subscription = GetSubscription();

				IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

				QueryResponseType res = store.Query(subject, req);

				DbMethodHistory mh = new DbMethodHistory();
				mh.Method = DbMethodType.Query;
				mh.AccountId = GetAccount().Id;
				mh.SubscriptionId = subscription.Id;
				mh.UserHostAddress = Context.Request.UserHostAddress;
				mh.DbCreate();

				return res;
			}
			catch (Exception x) {
				log.Error("Failed to execute method", x);
				throw x;
			}
		}


		///// <summary>
		///// 
		///// </summary>
		///// <param name="req"></param>
		///// <returns></returns>
		//[WebMethod()]
		//[SoapHeader("Authentication")]
		//[SoapHeader("Request")]
		//public virtual ListenResponseType Listen(ListenRequestType req) {
		//    SubjectType subject = GetSubject();

		//    ListenResponseType res = new ListenResponseType();
		//    res.SelectedNodeCount = 0;
		//    res.Status = ResponseStatus.Success;

		//    DbSubscription subscription = GetSubscription();

		//    DbMethodHistory mh = new DbMethodHistory();
		//    mh.Method = DbMethodType.Listen;
		//    mh.AccountId = GetAccount().Id;
		//    mh.SubscriptionId = subscription.Id;
		//    mh.DbCreate();

		//    return res;
		//}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod()]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public virtual void ListenResponse(ListenTriggerType listenTrigger) {
			// void implementation
		}

		#region HelperMethods
		protected SubjectType GetSubject() {
			try {
				// TODO change to use WS-Security for user authentication
				DbAccount account = GetAccount();

				SubjectType st = new SubjectType();
				st.UserId = this.Authentication.Iqid;
				st.AppAndPlatformId = "iquomi@windows";
				return st;
			}
			catch (Exception x) {
				throw new SoapException("Authorization failed for " + this.Authentication.Iqid, SoapException.ClientFaultCode, x);
			}
		}

		protected void Save(IXmlStore store, string method) {
			log.Debug("Saving XmlStore instance \"" + store.ContentDocument.InstanceId + "\" using operation \"" + method + "\"");

			DbSubscription subscription = GetSubscription();
			subscription.SetXmlDocument(store.ContentDocument.XmlDocument);
			subscription.DbUpdate();

			DbMethodHistory mh = new DbMethodHistory();
			mh.Method = method;
			mh.AccountId = GetAccount().Id;
			mh.SubscriptionId = subscription.Id;
			mh.UserHostAddress = Context.Request.UserHostAddress;
			mh.DbCreate();
		}
		#endregion

		#region DbMethods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected DbService GetService() {
			try {
				DbService service = new DbService();
				service.Name = this.Request.Value.Service;
				return (DbService)service.DbFindByName();
			}
			catch (Exception e) {
				throw new SoapException(e.Message, SoapException.ClientFaultCode);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected DbAccount GetOwnerAccount() {
//			return DbAccount.FindByIqid(this.Request.OwnerIqid);
			return DbAccount.FindByIqid(this.Request.Value.Key[0].Puid);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected DbAccount GetAccount() {
			DbAccount account = DbAccount.FindByIqid(this.Authentication.Iqid);
//			if (account != null && account.Id != 0 && account.Password == this.Authentication.Password) {
			
			// TODO: Password check has been disabled!
			if (account != null && account.Id != 0) {
				account.IpAddress = this.Context.Request.UserHostAddress;
				return account;
			}

			throw new SoapException("Account not found", SoapException.ClientFaultCode);
		}


		/// <summary>
		/// Lookup subscription based on requested service name and owner.
		/// </summary>
		/// <returns></returns>
		protected DbSubscription GetSubscription() {
			DbSubscription subscription = new DbSubscription();
			subscription.AccountId = GetOwnerAccount().Id;
			subscription.Name = this.Request.Value.Service;
			subscription.DbFindByAccountIdName();

			if (!subscription.IsValid()) {
				throw new SoapException(
					"A subscription to specified service doesn't exist",
					SoapException.ClientFaultCode
					);
			}

			return subscription;
		}
		#endregion

	}
}