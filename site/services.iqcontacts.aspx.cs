#region Using directives

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;
using Commanigy.Utils;

using IqContactsRef;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServicesIqContactsPage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private IqContactsType contacts;

		protected void Page_Load(object sender, System.EventArgs e) {
			contacts = (IqContactsType)ViewState["iqContacts"];
		}

		protected void BtnLoad_Click(object sender, EventArgs e) {
			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqContacts myService = (IqContacts)serviceLocator.GetService(
				typeof(IqContacts),
				UiAccount.Get().Iqid
				);

			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[] { new XpQueryType() };
			q.XpQuery[0].Select = TbxData.Text;
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MinOccursSpecified = true;
			q.XpQuery[0].MaxOccursSpecified = false;

			q.XpQuery[0].Options = new QueryOptionsType();
			q.XpQuery[0].Options.Sort = new SortType[] { new SortType()/*, new SortType()*/ };
			q.XpQuery[0].Options.Sort[0].Key = "concat(m:Name/mp:GivenName/text(), ' ', m:Name/mp:SurName/text())";
			q.XpQuery[0].Options.Sort[0].Direction = SortTypeDirection.Ascending;
//			q.XpQuery[0].Options.Sort[1].Key = "m:Name/mp:SurName/text()";
//			q.XpQuery[0].Options.Sort[1].Direction = SortTypeDirection.Ascending;

			try {
				QueryResponseType response = myService.Query(q);
				if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
					Notification.Success("Contacts read");

					//contacts = (IqContactsType)ServiceUtils.GetObject(
					//    typeof(IqContactsType), 
					//    response.XpQueryResponse[0].Any[0]
					//    );
					//contacts = (IqContactsType)GetObject(
					//    typeof(IqContactsType),
					//    response.XpQueryResponse[0].Any[0]
					//    );

					if (response.XpQueryResponse[0].Items != null) {
						LblResponse.Text = string.Format("Found {0} contacts:<br />", response.XpQueryResponse[0].Items.Length);
						foreach (ContactType contact in response.XpQueryResponse[0].Items) {
							LblResponse.Text += contact.Name[0].GivenName.Value + " | " +
								contact.Name[0].SurName.Value + "<br />";
						}
					}

/*
					if (response.XpQueryResponse[0].Any != null) {
						LblResponse.Text = string.Format("Found {0} contacts:<br />", response.XpQueryResponse[0].Any.Length);
						foreach (XmlElement element in response.XpQueryResponse[0].Any) {
							ContactType contact = (ContactType)ServiceUtils.GetObject(
								typeof(ContactType),
								element
								);

							LblResponse.Text += contact.Name[0].GivenName.Value + " | " +
								contact.Name[0].SurName.Value + "<br />";
						}
					}
*/
					//if (contacts.Contact != null) {
					//    LblResponse.Text = string.Format("Found {0} contacts:<br />", contacts.Contact.Length);

					//    foreach (ContactType contact in contacts.Contact) {
					//        LblResponse.Text += contact.Name[0].GivenName.Value + " | " + 
					//            contact.Name[0].SurName.Value + "<br />";
					//    }
					//}

					ViewState["iqContacts"] = contacts;
				} else {
					Notification.Failed("Unable to read contacts.");
				}
			}
			catch (System.Net.WebException x) {
				Notification.Failed(x.Message);
			}

			Notification.Display();
		}

		/*
				private string GetNamespace(Type type) {
					object[] cas = type.GetCustomAttributes(typeof(XmlTypeAttribute), false);
					return (cas.Length > 0) ? ((XmlTypeAttribute)cas[0]).Namespace : "";
				}

				protected object GetObject(System.Type type, XmlElement e) {
					XmlRootAttribute root = new XmlRootAttribute(e.LocalName);
					root.Namespace = GetNamespace(type);

					XmlAttributeOverrides overrides = new XmlAttributeOverrides();
					XmlAttributes attributes = new XmlAttributes();

					//XmlRootAttribute rattr = new XmlRootAttribute(e.LocalName);
					//rattr.Namespace = GetNamespace(type);
					//attributes.XmlRoot = rattr;
					//overrides.Add(type, attributes);

					XmlAttributeAttribute attributeAttribute = new XmlAttributeAttribute();
					attributes.XmlAttribute = attributeAttribute;
					//overrides.Add(type, "ChangeNumber", attributes);
					//overrides.Add(type, "InstanceId", attributes);

		//			XmlElementAttribute eattr = new XmlElementAttribute();
		//			attributes.XmlElements.Add(eattr);
		//			overrides.Add(type, "InstanceId", attributes);

		//			XmlSerializer serializer = new XmlSerializer(type, overrides);
					XmlSerializer serializer = new XmlSerializer(type, root);
		//			XmlSerializer serializer = new XmlSerializer(type, overrides, new Type[0], root, null);
					serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
					serializer.UnknownElement += new XmlElementEventHandler(serializer_UnknownElement);
					XmlNodeReader nr = new XmlNodeReader(e);
					return serializer.Deserialize(nr);
				}

				void serializer_UnknownElement(object sender, XmlElementEventArgs e) {
					Notification.Title = _("Validation failed");
					Notification.Description = "";
					Notification.AddMessage("Element: " + e.Element.Name + ": " + e.Element.Value);
				}

				void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e) {
					Notification.Title = _("Validation failed");
					Notification.Description = "";
					Notification.AddMessage("Attribute: " + e.Attr.Name + " = " + e.Attr.Value);
				}

		 protected LocalizableString MyLocalizableString(string v) {
					LocalizableString s = new LocalizableString();
					s.lang = "en-US";
					s.Value = v;
					return s;
				}
		*/

		protected void BtnSave_Click(object sender, EventArgs e) {
/*
			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqProfile myService = (IqProfile)serviceLocator.GetService(
				typeof(IqProfile),
				UiAccount.Get().Iqid
				);

			if (profile == null) {
				Notification.Failed("Cannot create new profile - load first");
				return;
			}

			// update internal structure before updating remotely
			NameType name = null;
			if (profile.Name == null) {
				profile.Name = new NameType[1];
				name = new NameType();
				name.Id = "";
				name.ChangeNumber = "";
				name.Creator = Api.CoreUtility.JoinIqid(UiAccount.Get().Iqid);
			} else {
				name = profile.Name[0];
			}

			name.GivenName = MyLocalizableString(TbxGivenName.Text);
			name.MiddleName = MyLocalizableString(TbxMiddleName.Text);
			name.SurName = MyLocalizableString(TbxSurName.Text);

			profile.Name[0] = name;


			EmailAddressBlueType email = null;
			if (profile.EmailAddress == null) {
				profile.EmailAddress = new EmailAddressBlueType[1];
				email = new EmailAddressBlueType();
				email.Id = "";
				email.ChangeNumber = "";
				email.Creator = Api.CoreUtility.JoinIqid(UiAccount.Get().Iqid);
			} else {
				email = profile.EmailAddress[0];
			}

			email.Name = MyLocalizableString("Personal E-mail");
			email.Email = TbxEmail.Text;

			profile.EmailAddress[0] = email;

			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "/m:IqProfile";
			req.MinOccurs = 1;
			req.MaxOccurs = 1;

			req.Any = new XmlElement[] { ServiceUtils.SetObject(
										profile,
										"IqProfile"
										) };

			try {
				ReplaceResponseType response = myService.Replace(req);
				if (response.Status == ResponseStatus.Success) {
					Notification.Success("Profile updated.");
				}
				else {
					Notification.Failed("Failed to update profile.");
				}
			}
			catch (System.Net.WebException x) {
				Notification.Failed(x.Message);
			}
 */
		}

		protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
			log.Debug("ObjectDataSource1_Selecting");
			return;

			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqContacts myService = (IqContacts)serviceLocator.GetService(
				typeof(IqContacts),
				UiAccount.Get().Iqid
				);

			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[1];
			q.XpQuery[0] = new XpQueryType();
			q.XpQuery[0].Select = TbxData.Text;
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MaxOccursSpecified = false;

			QueryResponseType response = myService.Query(q);
			if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
				if (response.XpQueryResponse[0].Items != null) {
					foreach (ContactType contact in response.XpQueryResponse[0].Items) {
						LblResponse.Text += contact.Name[0].GivenName.Value + " | " +
							contact.Name[0].SurName.Value + "<br />";
					}
				}
			}
		}

		protected void ObjectDataSource1_DataBinding(object sender, EventArgs e) {
			log.Debug("ObjectDataSource1_DataBinding");
		}
		
		protected void GridView1_Sorting(object sender, GridViewSortEventArgs e) {
			log.Debug("Sorting() SortDirection: " + e.SortDirection + ", SortExpression: " + e.SortExpression);
		}
	}
}