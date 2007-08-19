#region Using directives

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using Extensibility;

using Commanigy.Iquomi.Services.IqContacts.Client.IqContactsRef;

#endregion

namespace Commanigy.Iquomi.Services.IqContacts.Client {
	/// <summary>
	///   Iquomi iqContacts Outlook Add-In
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("995A0CD8-D213-4d75-8FB3-6BFC8BD54A7A"), ProgId("Commanigy.Iquomi.Services.IqContacts.Outlook.AddIn")]
	public class Connect : Object, Extensibility.IDTExtensibility2 {
		private Outlook.Application applicationObject;
		private object addInInstance;

		private IqContactsRef.IqContacts myService;

		private IquomiPropertyPage propertyPage;

		// need reference to namespace for "OptionsPagesAdd" event
		private Outlook.NameSpace outlookNamespace;

		// need reference to "Items" collection to have events fired
		private Outlook.Items outlookContacts;

		private Office.CommandBar cbOutlook;
		private Office.CommandBarPopup cbpIquomi;
		private Office.CommandBarButton cbbSynchronize;
		private Office.CommandBarButton cbbGetStarted;
		private Office.CommandBarButton cbbOptions;

		/// <summary>
		///	Implements the constructor for the Add-in object.
		///	Place your initialization code within this method.
		/// </summary>
		public Connect() {
			myService = new IqContactsRef.IqContacts();
			myService.SoapAuthenticationTypeValue = new SoapAuthenticationType();
			myService.SoapAuthenticationTypeValue.Iqid = "test1@iquomi.com";

			myService.SoapRequestTypeValue = new SoapRequestType();
			myService.SoapRequestTypeValue.Value = new RequestType();
			myService.SoapRequestTypeValue.Value.Service = "IqContacts";
			myService.SoapRequestTypeValue.Value.Key = new RequestTypeKey[] { new RequestTypeKey() };
			myService.SoapRequestTypeValue.Value.Key[0].Puid = "test1@iquomi.com";
		}

		/// <summary>
		/// Implements the OnConnection method of the IDTExtensibility2 interface.
		/// Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		/// Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		/// Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		/// Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom) {
			applicationObject = (Outlook.Application)application;
			addInInstance = addInInst;

			if (connectMode != Extensibility.ext_ConnectMode.ext_cm_Startup) {
				OnStartupComplete(ref custom);
			}
		}

		
		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom) {
			if (disconnectMode != Extensibility.ext_DisconnectMode.ext_dm_HostShutdown) {
				OnBeginShutdown(ref custom);
			}

			applicationObject = null;
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom) {

		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom) {

			outlookNamespace = applicationObject.GetNamespace("MAPI");

			// setup custom property for entire outlook application
			applicationObject.OptionsPagesAdd += new Outlook.ApplicationEvents_11_OptionsPagesAddEventHandler(applicationObject_OptionsPagesAdd);
			
			// setup custom property page for special folders
			outlookNamespace.OptionsPagesAdd += new Outlook.NameSpaceEvents_OptionsPagesAddEventHandler(ns_OptionsPagesAdd);

			Outlook.MAPIFolder contactsFolder = outlookNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
			
			outlookContacts = contactsFolder.Items;
			outlookContacts.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
			outlookContacts.ItemChange += new Outlook.ItemsEvents_ItemChangeEventHandler(Items_ItemChange);
			outlookContacts.ItemRemove += new Outlook.ItemsEvents_ItemRemoveEventHandler(Items_ItemRemove);

			SetupIquomiMenu();

			/*
						QueryRequestType q = new QueryRequestType();
						q.XpQuery = new XpQueryType[] { new XpQueryType() };
						q.XpQuery[0].Select = "/m:IqContacts/m:Contact";
			
						QueryResponseType response = myService.Query(q);
						foreach (ContactType c in response.XpQueryResponse[0].Items) {
							Outlook.ContactItem contact = (Outlook.ContactItem)applicationObject.CreateItem(Outlook.OlItemType.olContactItem);
							contact.FirstName = "__" + c.Name[0].GivenName.Value;
							contact.MiddleName = c.Name[0].MiddleName.Value;
							contact.LastName = c.Name[0].SurName.Value;
							contact.User1 = c.Puid;
							contact.Save();
						}
						*/

		}

		/// <summary>
		/// 
		/// </summary>
		private void SetupIquomiMenu() {
			cbOutlook = applicationObject.ActiveExplorer().CommandBars.ActiveMenuBar;

			cbpIquomi = cbOutlook.Controls.Add(Office.MsoControlType.msoControlPopup, Type.Missing, Type.Missing, cbOutlook.Controls["&Help"].Index, true) as Office.CommandBarPopup;
			cbpIquomi.Caption = "&Iquomi";
			cbpIquomi.Visible = true;

			cbbSynchronize = cbpIquomi.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true) as Office.CommandBarButton;
			cbbSynchronize.Caption = "&Synchronize All";
			cbbSynchronize.Visible = true;
			cbbSynchronize.FaceId = 1020; // refresh icon
			cbbSynchronize.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
			cbbSynchronize.Click += new Office._CommandBarButtonEvents_ClickEventHandler(cbbSynchronize_Click);

			cbbGetStarted = cbpIquomi.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true) as Office.CommandBarButton;
			cbbGetStarted.Caption = "&Get Started...";
			cbbGetStarted.Visible = true;
			cbbGetStarted.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(cbbGetStarted_Click);

			cbbOptions = cbpIquomi.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true) as Office.CommandBarButton;
			cbbOptions.Caption = "&Options...";
			cbbOptions.Visible = true;
			cbbOptions.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(cbbOptions_Click);
		}

		void cbbSynchronize_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault) {
			SyncAll();
		}

		void cbbGetStarted_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault) {
			MessageBox.Show("Get Started clicked");
		}

		void cbbOptions_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault) {
			MessageBox.Show("Options clicked");
		}

		void applicationObject_OptionsPagesAdd(Microsoft.Office.Interop.Outlook.PropertyPages Pages) {
			Application.EnableVisualStyles();

			propertyPage = new IquomiPropertyPage();
			Pages.Add(propertyPage, "Iquomi");
		}

		void ns_OptionsPagesAdd(Outlook.PropertyPages Pages, Outlook.MAPIFolder Folder) {
			if (Folder.DefaultItemType == Outlook.OlItemType.olContactItem) {
				//propertyPage = new IquomiPropertyPage();
				//Pages.Add(propertyPage, "Iquomi");
			}
		}

		void Items_ItemRemove() {
			//System.Windows.Forms.MessageBox.Show("ItemRemove");
		}

		void Items_ItemChange(object Item) {
			Outlook.ContactItem contactItem = Item as Outlook.ContactItem;
			if (contactItem == null) {
				return;
			}

			Sync(contactItem);
		}

		void Items_ItemAdd(object Item) {
			//System.Windows.Forms.MessageBox.Show("ItemAdd: " + Item);
		}

		public string GetProperty(Outlook.ContactItem contactItem, string userPropertyName) {
			Outlook.UserProperty up = contactItem.UserProperties.Find(userPropertyName, Type.Missing);
			return (up != null) ? up.Value as string : null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ContactType[] SyncAll() {
			ArrayList insertContactsList = new ArrayList();
			ArrayList replaceContactsList = new ArrayList();
			ArrayList deleteContactsList = new ArrayList();

			foreach (Outlook.ContactItem contactItem in outlookContacts) {
				string iqid = GetProperty(contactItem, "Iqid");
				if (iqid != null) {
					replaceContactsList.Add(contactItem);
					ContactType contact = Sync(contactItem);
					if (contact != null) {
//						up = contactItem.UserProperties.Add("Iqid", Outlook.OlUserPropertyType.olText, Type.Missing, Type.Missing);
//						up.Value = contact.Puid;
						contactItem.Save();
					}
				}
				else {
					insertContactsList.Add(contactItem);
					//ContactType contact = InsertContactSingle(contactItem);
				}
			}

			/*
			if (insertContactsList.Count > 0) {
				InsertContacts(insertContactsList);
				//InsertContacts((Outlook.ContactItem[])insertContactsList.ToArray(typeof(Outlook.ContactItem[])));
			}
			*/
			return null;
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contactItem"></param>
		/// <param name="iqid"></param>
		/// <returns></returns>
		private ContactType Sync(Outlook.ContactItem contactItem) {
			string iqid = GetProperty(contactItem, "Iqid");
			if (iqid == null) {
				// can't synchronize without Iqid mapping
				return null;
			}

			ContactType contact = QueryContact(iqid);
			if (contact == null) {
				return null;
			}

			if (contact.Name == null) {
				contact.Name = new NameType[1];
			}

			NameType name = contact.Name[0];
			if (name == null) {
				name = new NameType();
				name.ChangeNumber = "";
				name.Id = "";
				name.Creator = new byte[] { 0x00, 0x01 };
				contact.Name[0] = name;
			}

			name.GivenName = CreateLocalizableString(contactItem.FirstName);
			name.MiddleName = CreateLocalizableString(contactItem.MiddleName);
			name.SurName = CreateLocalizableString(contactItem.LastName);

			if (contact.WebSite == null) {
				contact.WebSite = new WebSiteBlueType[1];
			}

			WebSiteBlueType webSite = contact.WebSite[0];
			if (webSite == null) {
				webSite = new WebSiteBlueType();
				webSite.ChangeNumber = "";
				webSite.Id = "";
				webSite.Creator = new byte[] { 0x00, 0x01 };
				contact.WebSite[0] = webSite;
			}

			webSite.Url = contactItem.WebPage;

			if (contact.TelephoneNumber == null) {
				contact.TelephoneNumber = new TelephoneNumberBlueType[3];
			}

			TelephoneNumberBlueType telephoneNumber;

			// mobile
			telephoneNumber = contact.TelephoneNumber[0];
			if (telephoneNumber == null) {
				telephoneNumber = new TelephoneNumberBlueType();
				telephoneNumber.ChangeNumber = "";
				telephoneNumber.Id = "";
				telephoneNumber.Creator = new byte[] { 0x00, 0x01 };
				contact.TelephoneNumber[0] = telephoneNumber;
			}

			telephoneNumber.Number = contactItem.MobileTelephoneNumber;
			telephoneNumber.Cat = new CatType[] { new CatType() };
			telephoneNumber.Cat[0].Ref = "Mobile";

			// home
			telephoneNumber = contact.TelephoneNumber[1];
			if (telephoneNumber == null) {
				telephoneNumber = new TelephoneNumberBlueType();
				telephoneNumber.ChangeNumber = "";
				telephoneNumber.Id = "";
				telephoneNumber.Creator = new byte[] { 0x00, 0x01 };
				contact.TelephoneNumber[1] = telephoneNumber;
			}

			telephoneNumber.Number = contactItem.HomeTelephoneNumber;
			telephoneNumber.Cat = new CatType[] { new CatType() };
			telephoneNumber.Cat[0].Ref = "Home";

			// business
			telephoneNumber = contact.TelephoneNumber[2];
			if (telephoneNumber == null) {
				telephoneNumber = new TelephoneNumberBlueType();
				telephoneNumber.ChangeNumber = "";
				telephoneNumber.Id = "";
				telephoneNumber.Creator = new byte[] { 0x00, 0x01 };
				contact.TelephoneNumber[2] = telephoneNumber;
			}

			telephoneNumber.Number = contactItem.BusinessTelephoneNumber;
			telephoneNumber.Cat = new CatType[] { new CatType() };
			telephoneNumber.Cat[0].Ref = "Business";

			return ReplaceContact(contact) ? contact : null;
		}

		private ContactType QueryContact(string iqid) {
			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[] { new XpQueryType() };
			q.XpQuery[0].Select = string.Format(@"/m:IqContacts/m:Contact[@Synchronize='Yes' and m:Puid='{0}']", iqid);
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MinOccursSpecified = true;
			q.XpQuery[0].MaxOccurs = 1;
			q.XpQuery[0].MaxOccursSpecified = true;

			QueryResponseType response = myService.Query(q);
			if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
				return (ContactType)response.XpQueryResponse[0].Items[0];
			}

			return null;
		}

		//		private ContactType[] InsertContacts(Outlook.ContactItem[] contactItems) {
		private ContactType[] InsertContacts(ArrayList contactItems) {
			InsertRequestType request = new InsertRequestType();
			request.Select = @"/m:IqContacts";
			request.MinOccurs = 1;
			request.MinOccursSpecified = true;
			request.MaxOccurs = 1;
			request.MaxOccursSpecified = true;

			ContactType[] contacts = new ContactType[contactItems.Count];
			for (int i = 0; i < contacts.Length; i++) {
				contacts[i] = InsertContact(contactItems[i] as Outlook.ContactItem);
			}

			request.Items = contacts;

			InsertResponseType response = myService.Insert(request);
			return (response.Status == ResponseStatus.Success) ? contacts : null;
		}

		private ContactType InsertContact(Outlook.ContactItem contactItem) {
			ContactType contact = new ContactType();
			contact.ChangeNumber = "";
			contact.Id = "";
			contact.Creator = new byte[] { 0x00, 0x01 };
			contact.Synchronize = ContactTypeSynchronize.Yes;

			NameType name = new NameType();
			name.ChangeNumber = "";
			name.Id = "";
			name.Creator = new byte[] { 0x00, 0x01 };

			name.GivenName = new LocalizableString();
			name.GivenName.lang = "en-US";
			name.GivenName.Value = contactItem.FirstName;
			name.MiddleName = new LocalizableString();
			name.MiddleName.lang = "en-US";
			name.MiddleName.Value = contactItem.MiddleName;
			name.SurName = new LocalizableString();
			name.SurName.lang = "en-US";
			name.SurName.Value = contactItem.LastName;

			contact.Name = new NameType[] { name };

			return contact;
		}

		private ContactType InsertContactSingle(Outlook.ContactItem contactItem) {
			InsertRequestType request = new InsertRequestType();
			request.Select = @"/m:IqContacts";
			request.MinOccurs = 1;
			request.MinOccursSpecified = true;
			request.MaxOccurs = 1;
			request.MaxOccursSpecified = true;

			NameType name = new NameType();
			name.GivenName = new LocalizableString();
			name.GivenName.lang = "en-US";
			name.GivenName.Value = contactItem.FirstName;
			name.MiddleName = new LocalizableString();
			name.MiddleName.lang = "en-US";
			name.MiddleName.Value = contactItem.MiddleName;
			name.SurName = new LocalizableString();
			name.SurName.lang = "en-US";
			name.SurName.Value = contactItem.LastName;

			ContactType contact = new ContactType();
			contact.ChangeNumber = "";
			contact.Id = "";
			contact.Creator = new byte[] { 0x00, 0x01 };
			contact.Synchronize = ContactTypeSynchronize.Yes;

			contact.Name = new NameType[] { name };
			request.Items = new ContactType[] { contact };

			InsertResponseType response = myService.Insert(request);
			return (response.Status == ResponseStatus.Success) ? contact : null;
		}


		private bool ReplaceContact(ContactType contact) {
			ReplaceRequestType request = new ReplaceRequestType();
			request.Select = string.Format(@"/m:IqContacts/m:Contact[@Synchronize='Yes' and m:Puid='{0}']", contact.Puid);
			request.MinOccurs = 1;
			request.MinOccursSpecified = true;
			request.MaxOccurs = 1;
			request.MaxOccursSpecified = true;
			request.Items = new ContactType[] { contact };

			ReplaceResponseType response = myService.Replace(request);
			return response.Status == ResponseStatus.Success;
		}


		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom) {
			
		}

		#region Utilities
		
		public LocalizableString CreateLocalizableString(string v) {
			LocalizableString r = new LocalizableString();
			r.lang = "en-US";
			r.Value = v;
			return r;
		}
		
		#endregion
	}
}