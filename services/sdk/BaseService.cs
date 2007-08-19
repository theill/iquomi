using System;
using System.Xml;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Store;

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// WebService accessing generic services by providing core insert, 
	/// delete, replace, update and query methods.
	/// </summary>
	public class BaseService : System.Web.Services.WebService {
		// Placeholders for soap headers - must be public
		public AuthenticationType Authentication;
		public RequestType Request;
		
		public BaseService() {
			;
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public InsertResponseType Insert(InsertRequestType req) {
			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.GetInstance().Find(this.Request);

			InsertResponseType res = store.Insert(subject, req);
			if (res.Status == ResponseStatus.Success) {
				DbSubscription subscription = GetSubscription();
				subscription.SetXmlDocument(store.ContentDocument.XmlDocument);
				subscription.DbUpdate();

				DbMethodHistory mh = new DbMethodHistory();
				mh.Method =  DbMethodType.Insert;
				mh.SubscriptionId = subscription.Id;
				mh.DbCreate();
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
		public DeleteResponseType Delete(DeleteRequestType req) {
			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.GetInstance().Find(this.Request);

			DeleteResponseType res = store.Delete(subject, req);
			if (res.Status == ResponseStatus.Success) {
				DbSubscription subscription = GetSubscription();
				subscription.SetXmlDocument(store.ContentDocument.XmlDocument);
				subscription.DbUpdate();

				DbMethodHistory mh = new DbMethodHistory();
				mh.Method =  DbMethodType.Delete;
				mh.SubscriptionId = subscription.Id;
				mh.DbCreate();
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
		public ReplaceResponseType Replace(ReplaceRequestType req) {
			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.GetInstance().Find(this.Request);

			ReplaceResponseType res = store.Replace(subject, req);
			if (res.Status == ResponseStatus.Success) {
				DbSubscription subscription = GetSubscription();
				subscription.SetXmlDocument(store.ContentDocument.XmlDocument);
				subscription.DbUpdate();

				DbMethodHistory mh = new DbMethodHistory();
				mh.Method =  DbMethodType.Replace;
				mh.SubscriptionId = subscription.Id;
				mh.DbCreate();
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
		public UpdateResponseType Update(UpdateRequestType req) {
			if (req.UpdateBlocks == null || req.UpdateBlocks.Length == 0) {
				throw new SoapException("At least one UpdateBlock must be specified", SoapException.ClientFaultCode);
			}

			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.GetInstance().Find(this.Request);
			
			// Used to determine if a subscription update is necessary
			bool updateSubscription = false;

			UpdateResponseType res = store.Update(subject, req);
			foreach (UpdateBlockStatusType up in res.UpdateBlockStatuses) {
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
				DbSubscription subscription = GetSubscription();
				subscription.SetXmlDocument(store.ContentDocument.XmlDocument);
				subscription.DbUpdate();

				DbMethodHistory mh = new DbMethodHistory();
				mh.Method = DbMethodType.Update;
				mh.SubscriptionId = subscription.Id;
				mh.DbCreate();
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
//		[SoapDocumentMethod(Action="http://services.iquomi.com/", 
//			 RequestNamespace="http://services.iquomi.com/",
//			 RequestElementName="QueryRequest",
//			 ResponseNamespace="http://services.iquomi.com/",
//			 ResponseElementName="QueryResponse",
//			 Use=SoapBindingUse.Literal)]
		public QueryResponseType Query(QueryRequestType req) {
			SubjectType subject = GetSubject();

			DbSubscription subscription = GetSubscription();

			IXmlStore store = XmlStoreRepository.GetInstance().Find(this.Request);

			QueryResponseType res = store.Query(subject, req);

			// TODO must include accountId as well or the user does not know *who*
			// performed the query
			DbMethodHistory mh = new DbMethodHistory();
			mh.Method = DbMethodType.Query;
			mh.SubscriptionId = subscription.Id;
			mh.DbCreate();

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
		public ListenResponseType Listen(ListenRequestType req) {
			SubjectType subject = GetSubject();
			
			ListenResponseType res = new ListenResponseType();
			res.SelectedNodeCount = 0;
			res.Status = ResponseStatus.Success;
			
			return res;
		}

		#region HelperMethods
		protected SubjectType GetSubject() {
			DbAccount account = DbAccount.DbLookup(this.Authentication.Iqid, this.Authentication.Password);
			if (account != null) {
				account.IpAddress = this.Context.Request.UserHostAddress;

				SubjectType st = new SubjectType();
				st.UserId = this.Authentication.Iqid;
				st.AppAndPlatformId = "iquomi@windows";
				return st;
			} else {
				throw new SoapException("Authorization failed for " + this.Authentication.Iqid, SoapException.ClientFaultCode);
			}
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
				service.Name = this.Request.Service;
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
			return DbAccount.FindByIqid(this.Request.OwnerIqid);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected DbAccount GetAccount() {
			try {
				DbAccount account = DbAccount.DbLookup(this.Authentication.Iqid, this.Authentication.Password);
				account.IpAddress = this.Context.Request.UserHostAddress;
				return account;
			}
			catch (Exception e) {
				throw new SoapException(e.Message, SoapException.ClientFaultCode);
			}
		}
		
		
		/// <summary>
		/// Lookup subscription based on requested service name and owner.
		/// </summary>
		/// <returns></returns>
		protected DbSubscription GetSubscription() {
			DbSubscription subscription = new DbSubscription();
			subscription.AccountId = GetOwnerAccount().Id;
			subscription.ServiceId = GetService().Id;
			subscription.DbFindByAccountService();

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