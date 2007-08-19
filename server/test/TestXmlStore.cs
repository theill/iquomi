#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;

using NUnit.Framework;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Store;
using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Test {
	/// <summary>
	/// Summary description for TestXmlStore.
	/// </summary>

	[TestFixture]
	public class TestXmlStore {
		private DbAccount account, account2;
		private DbAuthor author;
		private DbService service;
		private DbSubscription subscription;

		public TestXmlStore() {

		}

		[SetUp]
		public void Setup() {
			account = new DbAccount();
			account.Iqid = "unittest-testiqid";
			account.Email = "foo@bar.com";
			account.Password = "iknownooooting";
			account = DbAccount.DbCreate(account);

			account2 = new DbAccount();
			account2.Iqid = "unittest-testiqid2";
			account2.Email = "foo2@bar.com";
			account2.Password = "iknownooooting";
			account2 = DbAccount.DbCreate(account2);

			XmlDocument standardRoleTemplates = new XmlDocument();
			standardRoleTemplates.LoadXml(
				@"<?xml version=""1.0"" encoding=""utf-8"" ?> 
				<standardRoleTemplates>
					<scope name=""s0"" base=""t"" />
					<scope name=""s1"" base=""nil"">
						<shape select=""//*[@creator='$callerId']"" type=""include"" />
					</scope>
					<scope name=""s2"" base=""nil"">
						<shape select=""//notify[@creator='$callerId']"" type=""include"" />
					</scope>
					<scope name=""s3"" base=""nil"">
						<shape select=""//*[cat/@ref='public']"" type=""include"" />
						<shape select=""//notify[@creator='$callerId']"" type=""include"" />
					</scope>
					<scope name=""s4"" base=""nil"" />
					
					<roleTemplate name=""rt0"">
						<fullDescription xml:lang=""en-US"" dir=""ltr"">
							The purpose of this role template is to provide full access to all information.
						</fullDescription>
						<method name=""query"" scopeRef=""s0"" />
						<method name=""insert"" scopeRef=""s0"" />
						<method name=""replace"" scopeRef=""s0"" />
						<method name=""delete"" scopeRef=""s0"" />
						<method name=""update"" scopeRef=""s0"" />
					</roleTemplate>
					
					<roleTemplate name=""rt1"">
						<fullDescription xml:lang=""en-US"" dir=""ltr"">
							The purpose of this role template is to provide full ability to read information with minimal ability to write. The caller can add information to the service, and can only delete information that is inserted or replaced.
						</fullDescription>
						<method name=""query"" scopeRef=""s0"" />
						<method name=""insert"" scopeRef=""s1"" />
						<method name=""replace"" scopeRef=""s1"" />
						<method name=""delete"" scopeRef=""s1"" />
					</roleTemplate>
					
					<roleTemplate name=""rt2"">
						<fullDescription xml:lang=""en-US"" dir=""ltr"">
							The purpose of this role template is to provide read-only access with ability to read and subscribe to all public information.
						</fullDescription>
						<method name=""query"" scopeRef=""s0"" />
						<method name=""insert"" scopeRef=""s2"" />
						<method name=""replace"" scopeRef=""s2"" />
						<method name=""delete"" scopeRef=""s2"" />
					</roleTemplate>

					<roleTemplate name=""rt3"">
						<fullDescription xml:lang=""en-US"" dir=""ltr"">
							The purpose of this role template is to provide read-only access with ability to subscribe to public events only.
						</fullDescription>
						<method name=""query"" scopeRef=""s0"" />
						<method name=""insert"" scopeRef=""s3"" />
						<method name=""replace"" scopeRef=""s3"" />
						<method name=""delete"" scopeRef=""s3"" />
					</roleTemplate>
					
					<roleTemplate name=""rt99"">
						<fullDescription xml:lang=""en-US"" dir=""ltr"">
							The purpose of this role template is to provide no access.
						</fullDescription>
					</roleTemplate>
					
				</standardRoleTemplates>
				");

			author = new DbAuthor();
			author.AccountId = account.Id;
			author.Name = "Test Author";
			author.DbCreate();

			service = new DbService();
			service.Name = "Test Service";
			service.Xsd = "<test />";
			service.State = "P";
			service.AuthorId = author.Id;

			// -- setup role templates, scopes and roles

			RoleMapType rmt = new RoleMapType();
/*
			RoleMapTypeScope s1 = new RoleMapTypeScope();
			s1.Id = "1";
			s1.Shape = new Services.ShapeType();
			s1.Shape.Base = ShapeTypeBase.T;
			s1.Shape.BaseSpecified = true;

			RoleMapTypeScope s2 = new RoleMapTypeScope();
			s2.Id = "2";
			s2.Shape = new Services.ShapeType();
			s2.Shape.Base = ShapeTypeBase.Nil;
			s2.Shape.BaseSpecified = true;
			ShapeAtomType sa2 = new ShapeAtomType();
			sa2.Select = "//*[@creator='$callerId']";
			s2.Shape.Include = new ShapeAtomType[] { sa2 };

			RoleMapTypeScope s3 = new RoleMapTypeScope();
			s3.Id = "3";
			s3.Shape = new Services.ShapeType();
			s3.Shape.Base = ShapeTypeBase.Nil;
			s3.Shape.BaseSpecified = true;
			ShapeAtomType sa3 = new ShapeAtomType();
			sa3.Select = "//subscription[@creator='$callerId']";
			s3.Shape.Include = new ShapeAtomType[] { sa3 };

			RoleMapTypeScope s4 = new RoleMapTypeScope();
			s4.Id = "4";
			s4.Shape = new Services.ShapeType();
			s4.Shape.Base = ShapeTypeBase.Nil;
			s4.Shape.BaseSpecified = true;
			ShapeAtomType sa4_1 = new ShapeAtomType();
			sa4_1.Select = "//*[cat/@ref='iq:public']";
			ShapeAtomType sa4_2 = new ShapeAtomType();
			sa4_2.Select = "//subscription[@creator='$callerId']";
			s4.Shape.Include = new ShapeAtomType[] { sa4_1, sa4_2 };

			RoleTemplateTypeMethod rtm1 = new RoleTemplateTypeMethod();
			rtm1.Name = "query";
			rtm1.ScopeRef = "1";

			RoleTemplateTypeMethod rtm2 = new RoleTemplateTypeMethod();
			rtm2.Name = "insert";
			rtm2.ScopeRef = "1";

			RoleTemplateTypeMethod rtm3 = new RoleTemplateTypeMethod();
			rtm3.Name = "replace";
			rtm3.ScopeRef = "1";

			RoleTemplateTypeMethod rtm4 = new RoleTemplateTypeMethod();
			rtm4.Name = "delete";
			rtm4.ScopeRef = "1";

			RoleTemplateTypeMethod rtm5 = new RoleTemplateTypeMethod();
			rtm5.Name = "update";
			rtm5.ScopeRef = "1";

			RoleTemplateType rt0 = new RoleTemplateType();
			rt0.Name = "rt0";
			rt0.Method = new RoleTemplateTypeMethod[] { rtm1, rtm2, rtm3, rtm4, rtm5 };

			RoleTemplateType rt1 = new RoleTemplateType();
			rt1.Name = "rt1";
			rt1.Method = new RoleTemplateTypeMethod[] { rtm1 };

			rmt.RoleTemplate = new RoleTemplateType[] { rt0, rt1 };
			rmt.Scope = new RoleMapTypeScope[] { s1, s2, s3, s4 };
*/
			service.SetRoleMap(rmt);
			service.DbCreate();
			
//			DbScope scope = new DbScope();
//			scope.Name = "t";
//			scope.Base = "t";
//			service.DbCreateScope(scope);
//
//			DbScope scope2 = new DbScope();
//			scope2.Name = "nil";
//			scope2.Base = "nil";
//			service.DbCreateScope(scope2);
//
//			DbShape shape = new DbShape();
//			shape.Type = "I";
//			shape.ScopeId = scope2.Id;
//			shape.Select = "/*/note[@Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
//			shape.DbCreate();
//
//			DbScope scope3 = new DbScope();
//			scope3.Name = "Only own information";
//			scope3.Base = "nil";
//			service.DbCreateScope(scope3);
//
//			DbShape shape2 = new DbShape();
//			shape2.Type = "I";
//			shape2.ScopeId = scope3.Id;
//			shape2.Select = "//*/note[@creator='2']";
//			shape2.DbCreate();
//
//			DbRoleTemplate rt = new DbRoleTemplate();
//			rt.Name = "Full Access";
//			rt.ServiceId = service.Id;
//			rt.DbCreate();
//
//			DbRoleTemplateMethod rtm = null;
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt.Id;
//			rtm.ScopeId = scope.Id;
//			rtm.MethodTypeId = 1;
//			rtm.DbCreate();
//
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt.Id;
//			rtm.ScopeId = scope.Id;
//			rtm.MethodTypeId = 2;
//			rtm.DbCreate();
//
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt.Id;
//			rtm.ScopeId = scope.Id;
//			rtm.MethodTypeId = 3;
//			rtm.DbCreate();
//
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt.Id;
//			rtm.ScopeId = scope.Id;
//			rtm.MethodTypeId = 4;
//			rtm.DbCreate();
//
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt.Id;
//			rtm.ScopeId = scope.Id;
//			rtm.MethodTypeId = 5;
//			rtm.DbCreate();
//
//			DbRoleTemplate rt2 = new DbRoleTemplate();
//			rt2.Name = "Limited Access";
//			rt2.ServiceId = service.Id;
//			rt2.DbCreate();
//
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt2.Id;
//			rtm.ScopeId = scope2.Id;
//			rtm.MethodTypeId = 5; // query
//			rtm.DbCreate();
//
//			rtm = new DbRoleTemplateMethod();
//			rtm.RoleTemplateId = rt2.Id;
//			rtm.ScopeId = scope3.Id;
//			rtm.MethodTypeId = 1; // insert
//			rtm.DbCreate();

			subscription = new DbSubscription();
			subscription.Id = new Guid("18ed9bfa-1c2c-4974-be82-9a36bf480484");
			subscription.AccountId = account.Id;
			subscription.ServiceId = service.Id;
			subscription.Name = service.Name;
			subscription.Xml = @"
				<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""3"">
					<note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1"">
						<title>Test</title>
						<description>asdf</description>
					</note>
					<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2"">
						<title>Test2</title>
						<description>asdf</description>
					</note>
					<note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1"">
						<title>Test3</title>
						<description>asdf</description>
					</note>
					<note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1"">
						<title>Test4</title>
						<description>asdf</description>
					</note>
				</notes>
			";

			RoleListType rl = new RoleListType();

			RoleType r1 = new RoleType();
			r1.Subject = new SubjectType();
			r1.Subject.UserId = "unittest-testiqid";
			r1.RoleTemplateRef = "rt0";
			r1.ScopeRef = "1";

			RoleType r2 = new RoleType();
			r2.Subject = new SubjectType();
			r2.Subject.UserId = "unittest-testiqid2";
			r2.RoleTemplateRef = "rt1";
			r2.ScopeRef = "1";

			rl.Role = new RoleType[] { r1, r2 };
/*
			RoleListScopeType rls = new RoleListScopeType();
			rls.Id = "1";
			rls.Shape = new Services.ShapeType();
			rls.Shape.Base = ShapeTypeBase.T;
			rls.Shape.BaseSpecified = true;
			rl.Scope = new RoleListScopeType[] { rls };
*/
			subscription.SetRoleList(rl);

			NotifyListType notifyList = new NotifyListType();
			notifyList.Listener = new ListenerType[1];
			notifyList.Listener[0] = new ListenerType();
			notifyList.Listener[0].To = "iq:iqAlerts";
			notifyList.Listener[0].Trigger = new ListenerTypeTrigger();
			notifyList.Listener[0].Trigger.Select = "/";
			notifyList.Listener[0].Trigger.Mode = ListenerTypeTriggerMode.IncludeData;
			subscription.SetNotifyList(notifyList);
			subscription.DbCreate();

//			DbRole r = new DbRole();
//			r.AccountId = account.Id;
//			r.RoleTemplateId = rt.Id;
//			r.SubscriptionId = subscription.Id;
//			r.DbCreate();
//
//			r = new DbRole();
//			r.AccountId = account2.Id;
//			r.RoleTemplateId = rt2.Id;
//			r.SubscriptionId = subscription.Id;
//			r.DbCreate();
		}

		[TearDown]
		public void TearDown() {
			subscription.DbDelete();
			service.DbDelete();
			DbAccount.DbDelete(account);
			DbAccount.DbDelete(account2);
		}

		public IXmlStore GetXmlStore() {
			RequestType request = new RequestType();
			RequestTypeKey rtk = new RequestTypeKey();
			rtk.Puid = "unittest-testiqid";
			request.Key = new RequestTypeKey[] { rtk };
			request.Service = "Test Service";
			return XmlStoreRepository.Instance.Find(request, null);
		}

		public SubjectType GetSubject() {
			SubjectType subject = new SubjectType();
			subject.UserId = "unittest-testiqid";
			subject.AppAndPlatformId = "";
			subject.CredType = "";
			return subject;
		}

		public SubjectType GetSubject2() {
			SubjectType subject = new SubjectType();
			subject.UserId = "unittest-testiqid2";
			subject.AppAndPlatformId = "";
			subject.CredType = "";
			return subject;
		}

		public XmlElement ToXmlElement(string xml) {
			XmlDocument d = new XmlDocument();
			d.LoadXml(xml);
			return d.DocumentElement;
		}

		#region Test Cases for "Insert" method
		[Test]
		public void Insert_SelectAttribute() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "//note[@Id='a9df1410-69a0-4be3-ab91-c017f6a44b58']/@priority";
			req.Any = new XmlElement[] { ToXmlElement("<d Id=\"3\" />") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			InsertResponseType res = GetXmlStore().Insert(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			// fails since we can't target an attribute value - instead use 'attributes'
			Assert.IsTrue(res.Status == ResponseStatus.Failure);
			Assert.IsTrue("3".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Insert_InsertAttributes() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/notes/note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757']";
			req.Any = new XmlElement[0];
			RedAttributeType at = new RedAttributeType();
			at.Name = "name";
			at.Value = "Peter Theill";
			RedAttributeType at2 = new RedAttributeType();
			at2.Name = "age";
			at2.Value = "26";
			req.Attributes = new RedAttributeType[] { at, at2 };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(store.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""4"" name=""Peter Theill"" age=""26""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				)
				);
		}

		[Test]
		public void Insert_UseClient() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/notes";
			req.Any = new XmlElement[] { ToXmlElement("<note Id=\"42\" ChangeNumber=\"\" />") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req); ;
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(store.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note><note Id=""42"" ChangeNumber=""4"" /></notes>"
				)
				);
		}

		[Test]
		public void Insert_NoUseClientIds() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/notes";
			req.Any = new XmlElement[] { ToXmlElement("<note Id=\"\" ChangeNumber=\"\" />") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = false;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req); ;
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.NewBlueId.Length == 1, "NewBlueId must contain one element");
			Assert.IsTrue(store.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note><note Id=""" + res.NewBlueId[0].Id + @""" ChangeNumber=""4"" /></notes>"
				));
		}

		[Test]
		public void Insert_MultipleUseClientIds() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/notes";
			req.Any = new XmlElement[] { ToXmlElement(@"<note Id=""42"" ChangeNumber=""""><title Id=""43"" /></note>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req); ;
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.NewBlueId.Length == 0);
			Assert.IsTrue(store.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note><note Id=""42"" ChangeNumber=""4""><title Id=""43"" /></note></notes>"
				));
		}

		[Test]
		public void Insert_MultipleNoUseClientIds() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/notes";
			req.Any = new XmlElement[] { ToXmlElement(@"<note Id="""" ChangeNumber=""""><title Id="""" /><description>something</description></note>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = false;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req); ;
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.NewBlueId.Length == 1);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(store.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note><note Id=""" + res.NewBlueId[0].Id + @""" ChangeNumber=""4""><title Id="""" /><description>something</description></note></notes>"
				));
		}

		[Test]
		public void Insert_MultipleInsertsNoUseClientIds() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "//note";
			req.Any = new XmlElement[] { ToXmlElement("<link>http://www.iquomi.com/</link>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = false;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req); ;
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 4);
			Assert.IsTrue(res.NewBlueId.Length == 0);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(store.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""4""><title>Test</title><description>asdf</description><link>http://www.iquomi.com/</link></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""4""><title>Test2</title><description>asdf</description><link>http://www.iquomi.com/</link></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""4"" priority=""1""><title>Test3</title><description>asdf</description><link>http://www.iquomi.com/</link></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""4""><title>Test4</title><description>asdf</description><link>http://www.iquomi.com/</link></note></notes>"
				));
		}

		[Test]
		public void Insert_MultipleInsertsMultipleNoUseClientIds() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "//note";
			req.Any = new XmlElement[] { ToXmlElement(@"<link Id="""">http://www.iquomi.com/</link>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = false;

			IXmlStore store = GetXmlStore();
			InsertResponseType res = store.Insert(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 4);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.NewBlueId.Length == 4, "NewBlueIds must contain four elements but " + res.NewBlueId.Length + " found");
		}

		//[Test]
		public void Insert_Role() {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/notes";
			req.Any = new XmlElement[] { ToXmlElement(@"<note Id="""" />") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = false;

			InsertResponseType res = GetXmlStore().Insert(GetSubject2(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.NewBlueId.Length == 1, "One Blue Id expected but " + res.NewBlueId.Length + " returned");
		}
		#endregion

		#region Test Cases for "Delete" method
		[Test]
		public void Delete_NoNodes() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "/foo";
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("3".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_AllNodes() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "/notes";

			IXmlStore store = GetXmlStore();
			DeleteResponseType res = store.Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_Attribute() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//note[@Id='a9df1410-69a0-4be3-ab91-c017f6a44b58']/@priority";
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_MaxOccursTooLow() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//note";
			req.MaxOccursSpecified = true;
			req.MaxOccurs = 1;
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Failure);
			Assert.IsTrue("3".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_MaxOccursEqual() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//note";
			req.MaxOccursSpecified = true;
			req.MaxOccurs = 4;
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_MinOccursTooLow() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//foobar";
			req.MinOccursSpecified = true;
			req.MinOccurs = 2;
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Failure);
			Assert.IsTrue("3".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_MinOccursEqual() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757']";
			req.MinOccursSpecified = true;
			req.MinOccurs = 1;
			IXmlStore xmlstore = GetXmlStore();
			DeleteResponseType res = xmlstore.Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				)
				);
		}

		[Test]
		public void Delete_MinOccursMaxOccursEqual() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//note";
			req.MinOccursSpecified = true;
			req.MinOccurs = 4;
			req.MaxOccursSpecified = true;
			req.MaxOccurs = 4;
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 4);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
		}

		[Test]
		public void Delete_MinOccursMaxOccursLowHigh() {
			DeleteRequestType req = new DeleteRequestType();
			req.Select = "//note";
			req.MinOccursSpecified = true;
			req.MinOccurs = 0;
			req.MaxOccursSpecified = true;
			req.MaxOccurs = 4;
			DeleteResponseType res = GetXmlStore().Delete(GetSubject(), req);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(res.SelectedNodeCount == 4);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
		}
		#endregion

		#region Test cases for "Replace" method
		[Test]
		public void Replace_UseClient() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757']";
			req.Any = new XmlElement[] { ToXmlElement(@"<d Id=""3""><e /></d>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.NewBlueId.Length == 0);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><d Id=""3""><e /></d><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				));
		}

		[Test]
		public void Replace_WithEmpty() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757']";
			req.Any = new XmlElement[0];
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.NewBlueId.Length == 0);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""4""></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				)
				);
		}

		[Test]
		public void Replace_Multiple() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note";
			req.Any = new XmlElement[] { ToXmlElement(@"<d name=""abc"" />") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 4);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><d name=""abc"" /><d name=""abc"" /><d name=""abc"" /><d name=""abc"" /></notes>"
				)
				);
		}

		[Test]
		public void Replace_SingleSub() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note[@Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
			req.Any = new XmlElement[] { ToXmlElement(@"<b Id=""2""><d name=""not_b"" /></b>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><b Id=""2""><d name=""not_b"" /></b><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				));
		}

		[Test]
		public void Replace_SingleSubWithId() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note[@Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
			req.Any = new XmlElement[] { ToXmlElement(@"<b Id="""" ChangeNumber=""""><d name=""not_b"" /></b>") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = false;

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.NewBlueId.Length == 1, "Got " + res.NewBlueId.Length + " but expected 1");
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><b Id=""" + res.NewBlueId[0].Id + @""" ChangeNumber=""4""><d name=""not_b"" /></b><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				)
				);
		}

		[Test]
		public void Replace_AttributeByAttributeSelect() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note[@Id='a9df1410-69a0-4be3-ab91-c017f6a44b58']/@priority";
			req.Any = new XmlElement[] { ToXmlElement(@"<illegal-content />") };
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;
			RedAttributeType at = new RedAttributeType();
			at.Name = "priority";
			at.Value = "42";
			req.Attributes = new RedAttributeType[] { at };

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue(res.Status == ResponseStatus.Failure);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""3""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				)
				);
		}

		[Test]
		public void Replace_Attribute() {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "//note[@Id='a9df1410-69a0-4be3-ab91-c017f6a44b58']/@priority";
			req.Any = new XmlElement[0];
			req.UseClientIdsSpecified = true;
			req.UseClientIds = true;

			RedAttributeType at = new RedAttributeType();
			at.Name = "priority";
			at.Value = "42";
			req.Attributes = new RedAttributeType[] { at };

			IXmlStore xmlstore = GetXmlStore();
			ReplaceResponseType res = xmlstore.Replace(GetSubject(), req);
			Assert.IsTrue(res.SelectedNodeCount == 1);
			Assert.IsTrue("4".Equals(res.NewChangeNumber));
			Assert.IsTrue(res.NewBlueId.Length == 0);
			Assert.IsTrue(res.Status == ResponseStatus.Success);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""4"" priority=""42""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				)
				);
		}
		#endregion

		#region Test cases for "Update" method
		[Test]
		public void Update_SimpleInsert() {
			UpdateRequestType req = new UpdateRequestType();
			UpdateBlockType u = new UpdateBlockType();
			InsertRequestType ir = new InsertRequestType();
			ir.Select = "/notes";
			ir.Any = new XmlElement[] { ToXmlElement("<note />") };
			ir.UseClientIdsSpecified = true;
			ir.UseClientIds = true;
			u.InsertRequest = new InsertRequestType[] { ir };
			req.UpdateBlock = new UpdateBlockType[] { u };

			IXmlStore xmlstore = GetXmlStore();
			UpdateResponseType res = xmlstore.Update(GetSubject(), req);
			Assert.IsTrue(res.UpdateBlockStatus[0].InsertResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue("4".Equals(res.UpdateBlockStatus[0].InsertResponse[0].NewChangeNumber));
			Assert.IsTrue(res.UpdateBlockStatus[0].Status == ResponseStatus.Success);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note><note /></notes>"
				)
				);
		}

		[Test]
		public void Update_InsertDelete() {
			UpdateRequestType req = new UpdateRequestType();
			UpdateBlockType u = new UpdateBlockType();

			InsertRequestType ir = new InsertRequestType();
			ir.Select = "/notes";
			ir.Any = new XmlElement[] { ToXmlElement(@"<note Id=""new-id"" />") };
			ir.UseClientIdsSpecified = true;
			ir.UseClientIds = true;
			u.InsertRequest = new InsertRequestType[] { ir };

			DeleteRequestType dr = new DeleteRequestType();
			dr.Select = "//note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757']";
			u.DeleteRequest = new DeleteRequestType[] { dr };

			req.UpdateBlock = new UpdateBlockType[] { u };

			IXmlStore xmlstore = GetXmlStore();
			UpdateResponseType res = xmlstore.Update(GetSubject(), req);
			Assert.IsTrue(res.UpdateBlockStatus[0].InsertResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.UpdateBlockStatus[0].DeleteResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.UpdateBlockStatus[0].Status == ResponseStatus.Success);
			Assert.IsTrue(xmlstore.ContentDocument.XmlDocument.OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""4""><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note><note Id=""new-id"" /></notes>"
				)
				);
		}
		#endregion

		#region Test cases for "Query.XpQuery" method
		[Test]
		public void Query_Simple() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "//note[@Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any.Length == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Any[0].OuterXml.Equals(
				@"<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note>"
				)
				);
		}

		[Test]
		public void Query_SimpleRole() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "/notes//note";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject2(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any.Length == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Any[0].OuterXml.Equals(
				@"<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note>"
				)
				);
		}


		[Test]
		public void Query_RoleExcludeSpecific() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "/*/note[@Id='18ed9bfa-1c2c-4974-be82-9a36bf480484']";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject2(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 0);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any.Length == 0);
		}

		[Test]
		public void Query_RoleIncludeSpecific() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "/*/note[@Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject2(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any.Length == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Any[0].OuterXml.Equals(
				@"<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note>"
				)
				);
		}

		[Test]
		public void Query_MultipleNodes() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "//note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757' or @Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 2);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any.Length == 2);
			Assert.IsTrue(res.XpQueryResponse[0].Any[0].OuterXml.Equals(
				@"<note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note>"
				));
			Assert.IsTrue(res.XpQueryResponse[0].Any[1].OuterXml.Equals(
				@"<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note>"
				));
		}

		[Test]
		public void Query_Multiple() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "//note[@Id='f3492deb-b41d-4c98-8324-e550a6c42757']";
			XpQueryType q2 = new XpQueryType();
			q2.Select = "//note[@Id='724334d8-dbc6-45db-b808-d6dbdc09a789']";
			req.XpQuery = new XpQueryType[] { q, q2 };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any[0].OuterXml.Equals(
				@"<note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note>"
				));
			Assert.IsTrue(res.XpQueryResponse[1].SelectedNodeCount == 1);
			Assert.IsTrue(res.XpQueryResponse[1].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[1].Any[0].OuterXml.Equals(
				@"<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note>"
				));
		}

		[Test]
		public void Query_NoNodes() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "//d";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 0);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
		}

		[Test]
		public void Query_TooManyNodes() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "//note";
			q.MaxOccursSpecified = true;
			q.MaxOccurs = 3;
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 4);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Failure);
		}

		[Test]
		public void Query_RootNode() {
			QueryRequestType req = new QueryRequestType();
			XpQueryType q = new XpQueryType();
			q.Select = "/notes";
			req.XpQuery = new XpQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue(res.XpQueryResponse[0].SelectedNodeCount == 1);
			Assert.IsTrue(res.XpQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.XpQueryResponse[0].Any[0].OuterXml.Equals(
				@"<notes InstanceId=""18ed9bfa-1c2c-4974-be82-9a36bf480484"" ChangeNumber=""3""><note Id=""f3492deb-b41d-4c98-8324-e550a6c42757"" ChangeNumber=""1""><title>Test</title><description>asdf</description></note><note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note><note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note><note Id=""80831c54-90e6-4e55-9150-6e57c8e8f2b5"" ChangeNumber=""1""><title>Test4</title><description>asdf</description></note></notes>"
				));
		}
		#endregion

		#region Test cases for "Query.ChangeQuery" method
		[Test]
		public void Query_ChangeQueryNoChange() {
			QueryRequestType req = new QueryRequestType();
			ChangeQueryType q = new ChangeQueryType();
			q.BaseChangeNumber = "3";
			q.Select = "/notes";
			req.ChangeQuery = new ChangeQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue("3".Equals(res.ChangeQueryResponse[0].BaseChangeNumber));
			Assert.IsTrue(res.ChangeQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue.Length == 0);
		}

		[Test]
		public void Query_ChangeQuerySingleChanges() {
			QueryRequestType req = new QueryRequestType();
			ChangeQueryType q = new ChangeQueryType();
			q.BaseChangeNumber = "2";
			q.Select = "/notes";
			req.ChangeQuery = new ChangeQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue("3".Equals(res.ChangeQueryResponse[0].BaseChangeNumber));
			Assert.IsTrue(res.ChangeQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue.Length == 1);
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue[0].Any[0].OuterXml.Equals(
				@"<note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note>"));
		}

		[Test]
		public void Query_ChangeQueryMultipleChanges() {
			QueryRequestType req = new QueryRequestType();
			ChangeQueryType q = new ChangeQueryType();
			q.BaseChangeNumber = "1";
			q.Select = "/notes";
			req.ChangeQuery = new ChangeQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue("3".Equals(res.ChangeQueryResponse[0].BaseChangeNumber));
			Assert.IsTrue(res.ChangeQueryResponse[0].Status == ResponseStatus.Success);
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue.Length == 2);
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue[0].Any[0].OuterXml.Equals(
				@"<note Id=""724334d8-dbc6-45db-b808-d6dbdc09a789"" ChangeNumber=""2""><title>Test2</title><description>asdf</description></note>"));
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue[1].Any[0].OuterXml.Equals(
				@"<note Id=""a9df1410-69a0-4be3-ab91-c017f6a44b58"" ChangeNumber=""3"" priority=""1""><title>Test3</title><description>asdf</description></note>"));
		}

		[Test]
		public void Query_ChangeQueryFailedTooManyNodes() {
			QueryRequestType req = new QueryRequestType();
			ChangeQueryType q = new ChangeQueryType();
			q.BaseChangeNumber = "2";
			q.Select = "/notes/note";
			req.ChangeQuery = new ChangeQueryType[] { q };

			QueryResponseType res = GetXmlStore().Query(GetSubject(), req);
			Assert.IsTrue("2".Equals(res.ChangeQueryResponse[0].BaseChangeNumber));
			Assert.IsTrue(res.ChangeQueryResponse[0].Status == ResponseStatus.Failure);
			Assert.IsTrue(res.ChangeQueryResponse[0].ChangedBlue.Length == 0);
			Assert.IsTrue(res.ChangeQueryResponse[0].DeletedBlue.Length == 0);
		}
		#endregion
		
		[Test]
		public void SerializeTest() {
			RoleListType rl = new RoleListType();

			RoleType r1 = new RoleType();
			r1.Subject = new SubjectType();
			r1.Subject.UserId = "unittest-testiqid";
			r1.RoleTemplateRef = "rt0";
			r1.ScopeRef = "1";

			RoleType r2 = new RoleType();
			r2.Subject = new SubjectType();
			r2.Subject.UserId = "unittest-testiqid2";
			r2.RoleTemplateRef = "rt1";
			r2.ScopeRef = "1";

			rl.Role = new RoleType[] { r1, r2 };
/*
			RoleListScopeType rls = new RoleListScopeType();
			rls.Id = "1";
			rls.Shape = new Services.ShapeType();
			rls.Shape.Base = ShapeTypeBase.T;
			rls.Shape.BaseSpecified = true;
			rl.Scope = new RoleListScopeType[] { rls };
*/			
			StringWriter buffer = new StringWriter();
			XmlSerializer serializer = new XmlSerializer(typeof(RoleListType));
			serializer.Serialize(buffer, rl);
			Console.Out.Write(buffer.ToString());
		}
	}
}