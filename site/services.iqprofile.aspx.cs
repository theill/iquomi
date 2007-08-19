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

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;
using Commanigy.Utils;

using IqProfileRef;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class ServicesIqProfilePage : Commanigy.Iquomi.Web.WebPage {
		protected static readonly ILog log = LogManager.GetLogger("WebSite");

		private IqProfileType profile;

		protected void Page_Load(object sender, System.EventArgs e) {
			profile = (IqProfileType)ViewState["profile"];
		}

		/*
		ReadRDF("http://www.xsltblog.com/index.rdf");
		private void ReadRDF(string s) {
			XmlTextReader r = new XmlTextReader(s);
			XmlDocument d = new XmlDocument();
			d.Load(r);
			XmlNamespaceManager ns = new XmlNamespaceManager(d.NameTable);
			ns.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
			XmlNodeList nl = d.SelectNodes("//rdf:RDF", ns);
			log.Debug("Got: " + nl.Count + " node(s)");
		}
		*/

		protected void BtnLoad_Click(object sender, EventArgs e) {

			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				UiAccount.Get().Iqid,
				UiAccount.Get().Password
				);

			IqProfile myService = (IqProfile)serviceLocator.GetService(
				typeof(IqProfile),
				UiAccount.Get().Iqid
				);

			QueryRequestType q = new QueryRequestType();
			q.XpQuery = new XpQueryType[1];
			q.XpQuery[0] = new XpQueryType();
			q.XpQuery[0].Select = "/m:IqProfile";
			q.XpQuery[0].MinOccurs = 1;
			q.XpQuery[0].MaxOccurs = 1;

			try {
				QueryResponseType response = myService.Query(q);
				if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
					Notification.Success("Profile read");

					profile = (IqProfileType)response.XpQueryResponse[0].Items[0];
					//profile = (IqProfileType)ServiceUtils.GetObject(typeof(IqProfileType), response.XpQueryResponse[0].Any[0]);
					if (profile.Name != null && profile.Name.Length > 0) {
						this.TbxGivenName.Text = profile.Name[0].GivenName != null ? profile.Name[0].GivenName.Value : "";
						this.TbxMiddleName.Text = profile.Name[0].MiddleName != null ? profile.Name[0].MiddleName.Value : "";
						this.TbxSurName.Text = profile.Name[0].SurName != null ? profile.Name[0].SurName.Value : "";
					}
					else {
						this.TbxGivenName.Text = "";
						this.TbxMiddleName.Text = "";
						this.TbxSurName.Text = "";
					}

					LblInstanceId.Text = profile.InstanceId;

					if (profile.EmailAddress != null && profile.EmailAddress.Length > 0) {
						this.TbxEmail.Text = profile.EmailAddress[0].Email;
					}
					else {
						this.TbxEmail.Text = "";
					}

					if (profile.TelephoneNumber != null && profile.TelephoneNumber.Length > 0) {
						this.TbxPhone.Text = profile.TelephoneNumber[0].Number;
					}
					else {
						this.TbxPhone.Text = "";
					}

					ViewState["profile"] = profile;
				} else {
					Notification.Failed("Unable to read profile.");
				}
			}
			catch (System.Net.WebException x) {
				Notification.Failed(x.Message);
			}
		}

		protected LocalizableString MyLocalizableString(string v) {
			LocalizableString s = new LocalizableString();
			s.lang = "en-US";
			s.Value = v;
			return s;
		}

		protected void BtnSave_Click(object sender, EventArgs e) {
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

			TelephoneNumberBlueType tn = null;
			if (profile.TelephoneNumber == null) {
				profile.TelephoneNumber = new TelephoneNumberBlueType[1];
				tn = new TelephoneNumberBlueType();
				tn.Id = "";
				tn.ChangeNumber = "";
				tn.Creator = Api.CoreUtility.JoinIqid(UiAccount.Get().Iqid);
			}
			else {
				tn = profile.TelephoneNumber[0];
			}

			tn.CountryCode = "45";
			tn.NationalCode = "45";
			tn.Number = TbxPhone.Text;

			profile.TelephoneNumber[0] = tn;

			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "/m:IqProfile";
			req.MinOccurs = 1;
			req.MaxOccurs = 1;

			req.Items = new object[] { profile };
			//req.Any = new XmlElement[] { ServiceUtils.SetObject(
			//                            profile,
			//                            "IqProfile"
			//                            ) };

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
		}

	}
}