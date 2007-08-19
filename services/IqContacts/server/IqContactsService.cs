#region Using directives

using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;

using log4net;

using Commanigy.Iquomi.Services;
using Commanigy.Iquomi.Store;

#endregion

namespace Commanigy.Iquomi.Services.IqContacts {
	/// <summary>
	/// Core IqContacts service.
	/// 
	/// This service contains the ...
	/// </summary>
	[System.Xml.Serialization.XmlInclude(typeof(IqContactsType))]
	public class IqContactsService : IqCoreService {
		protected static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
		);

		public IqContactsService() {
			log.Debug("Service \"IqContacts\" initialized");
		}

		[WebMethod]
		//[return: System.Xml.Serialization.XmlElement(typeof(IqContactsType))]
		public void Void(IqContactsType a) {
		}

		public override System.Reflection.Module ServiceModule {
			get {
				return typeof(IqContactsType).Module;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[WebMethod()]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public override void ListenResponse(ListenTriggerType listenTrigger) {
			log.Info("Using 'ListenResponse' method from contacts service");

			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

			QueryRequestType queryRequest = new QueryRequestType();
			queryRequest.XpQuery = new XpQueryType[] { new XpQueryType() };
			queryRequest.XpQuery[0].Select = "/m:IqContacts/m:Contact[@iq:Id='" + listenTrigger.Context.Uri + "']";
			queryRequest.XpQuery[0].MinOccurs = 1;
			queryRequest.XpQuery[0].MaxOccurs = 1;
			QueryResponseType queryResponse = store.Query(subject, queryRequest);

			IqContacts.ContactType contact = (IqContacts.ContactType)queryResponse.XpQueryResponse[0].Items[0];

			NameType name = (NameType)Api.ServiceUtils.GetObject(
				typeof(NameType),
				listenTrigger.Context.Any[0]
				);
			contact.Name[0] = name;

			ReplaceRequestType replaceRequest = new ReplaceRequestType();
			replaceRequest.Select = "/m:IqContacts/m:Contact[@iq:Id='" + listenTrigger.Context.Uri + "']";
			replaceRequest.Any = new XmlElement[] { 
				Api.ServiceUtils.SetObject(
					contact,
					"Contact"
					)
				};
			replaceRequest.MinOccurs = 1;
			replaceRequest.MaxOccurs = 1;
			ReplaceResponseType replaceResponse = store.Replace(subject, replaceRequest);

			base.Save(store, "listenResponse");
		}

		[WebMethod()]
		[SoapHeader("Authentication")]
		[SoapHeader("Request")]
		public IqContacts.ContactType[] FindByEmail(string email) {
			log.Info("Using 'FindByEmail' method on contacts service");

			SubjectType subject = GetSubject();

			IXmlStore store = XmlStoreRepository.Instance.Find(this.Request.Value, ServiceModule);

			QueryRequestType queryRequest = new QueryRequestType();
			queryRequest.XpQuery = new XpQueryType[] { new XpQueryType() };
			queryRequest.XpQuery[0].Select = "/m:IqContacts/m:Contact";
			QueryResponseType queryResponse = store.Query(subject, queryRequest);

			if (queryResponse.XpQueryResponse[0].Status == ResponseStatus.Success) {
//				return (IqContacts.ContactType[])queryResponse.XpQueryResponse[0].Items;
			}

			return new IqContacts.ContactType[0];
		}

	}
}