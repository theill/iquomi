#region Using directives

using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using outlook = Microsoft.Office.Interop.Outlook;
using office = Microsoft.Office.Core;

using Commanigy.Iquomi.Api;
using iqProfile = Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook.IqProfileRef;

#endregion

namespace Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook {
	public partial class ThisApplication {
		private IquomiPropertyPage propertyPage;

		private void ThisApplication_Startup(object sender, System.EventArgs e) {
			outlook.MAPIFolder f = this.ActiveExplorer().Session.GetDefaultFolder(outlook.OlDefaultFolders.olFolderContacts);
			f.Items.ItemChange += new outlook.ItemsEvents_ItemChangeEventHandler(Items_ItemChange);

			// initialize "iqProfile" web service
			ServiceLocator serviceLocator = new ServiceLocator(
				"http://services.iquomi.com/",
				"ptheill@commanigy.com",
				"g5zTb4oNXBR1VWyUqhNdcQ=="
				);
			
			iqProfile.IqProfile myProfile = (iqProfile.IqProfile)serviceLocator.GetService(
				typeof(iqProfile.IqProfile),
				"ptheill@commanigy.com"
				);

			// add 'Iquomi' menu if it doesn't exist

			// add 'Iquomi' tab (under "Tools | Options") if it doesn't exist
			this.OptionsPagesAdd += new outlook.ApplicationEvents_11_OptionsPagesAddEventHandler(ThisApplication_OptionsPagesAdd);

			// "Services..." button on 'Iquomi' tab opens new dialog

			// add "IqProfile" to this dialog
			//  - might contain "IqContacts", "IqPresence" as well

		}

		void ThisApplication_OptionsPagesAdd(outlook.PropertyPages Pages) {
			Application.EnableVisualStyles();

			propertyPage = new IquomiPropertyPage();
			Pages.Add(propertyPage, "Iquomi");
		}

		private void ThisApplication_Shutdown(object sender, System.EventArgs e) {

		}

		void Items_ItemChange(object Item) {
			outlook.ContactItem contactItem = Item as outlook.ContactItem;
			if (contactItem == null) {
				return;
			}

			Sync(contactItem);
		}

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup() {
			this.Startup += new System.EventHandler(ThisApplication_Startup);
			this.Shutdown += new System.EventHandler(ThisApplication_Shutdown);
		}

		#endregion

		private iqProfile.IqProfileType Sync(outlook.ContactItem contactItem) {
			string iqid = GetProperty(contactItem, "Iqid");
			if (iqid == null) {
				// can't synchronize without Iqid mapping
				return null;
			}

			return null;
		}

		public string GetProperty(outlook.ContactItem contactItem, string userPropertyName) {
			outlook.UserProperty up = contactItem.UserProperties.Find(userPropertyName, Type.Missing);
			return (up != null) ? up.Value as string : null;
		}
	}
}