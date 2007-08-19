#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

//using Commanigy.Iquomi.Test.IqPresenceRef;
using Commanigy.Iquomi.Test.IqProfileRef;
using Commanigy.Iquomi.Data;

#endregion

namespace Commanigy.Iquomi.Test {
	[TestFixture]
	public class TestWebServiceLookup {
		private DbAccount account;
		//private IqPresence service;

		public TestWebServiceLookup() {

		}
		
		[SetUp]
		public void Setup() {
			account = new DbAccount();
			account.Iqid = new Guid().ToString();
			account.Email = account.Iqid + "@iquomi.com";
			account.Password = "password";
			account = DbAccount.DbCreate(account);

			DbService service = new DbService();
			service.Name = "IqProfile";
			service.AuthorId = 1;
			service.DbCreate();

			DbSubscription subscription = new DbSubscription();
			subscription.Name = service.Name;
			subscription.AccountId = account.Id;
			subscription.Xml = "<m:IqProfile />";
			subscription.DbCreate();

			//service = new IqPresence();
			
			//SoapAuthenticationType authentication = new SoapAuthenticationType();
			//authentication.Iqid = account.Iqid;
			//authentication.Password = "password";
			//service.SoapAuthenticationTypeValue = authentication;
			
			//SoapRequestType request = new SoapRequestType();
			//RequestType r = new RequestType();
			//r.Service = "iqPresence";
			//r.Document = RequestTypeDocument.Content;
			
			//RequestTypeKey rk = new RequestTypeKey();
			//rk.Puid = account.Iqid;
			//r.Key = new RequestTypeKey[] { rk };
			//request.Value = r;

			//service.SoapRequestTypeValue = request;
		}

		[Test]
		public void TestIqProfile() {
			Commanigy.Iquomi.Api.ServiceLocator serviceLocator = new Commanigy.Iquomi.Api.ServiceLocator(
				"http://services.iquomi.com", 
				account.Iqid, 
				account.Password
				);
			IqProfile service = serviceLocator.GetService(typeof(IqProfile), account.Iqid) as IqProfile;

			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[1];
			q.XpQuery[0] = new XpQueryType();
			q.XpQuery[0].Select = "/m:IqProfile";
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MaxOccurs = 1;

			QueryResponseType response = service.Query(q);
			Assert.IsTrue(response.XpQueryResponse[0].Status == ResponseStatus.Success);
		}

		[TearDown]
		public void TearDown() {
			DbAccount.DbDelete(account);
		}
	}
}