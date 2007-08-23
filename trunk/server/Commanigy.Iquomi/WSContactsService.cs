using System;
using System.Collections;
using System.Web.Services;
using System.Xml;
using Commanigy.Iquomi.Api;

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// Summary description for WSContactsService.
	/// </summary>
	public class WSContactsService : BaseService {
		public WSContactsService() {
			;
		}
/*
		[WebMethod]
		public Item[] GetCompanyContacts(string companyName) {
			Item i = new Item();
			i.StorePath = "//emails";
			
			ArrayList retArr = new ArrayList();
			Item[] emails = this.FindAll("contacts", i);
			foreach (Item email in emails) {
				XmlDocument d = new XmlDocument();
				d.LoadXml((string)email.StoreObject);
				XmlNodeList l = d.SelectNodes("/company/@name['" + companyName + "']");
				foreach (XmlNode n in l) {
					Item ni = new Item();
					ni.StoreObject = n.OuterXml;
					retArr.Add(ni);
				}
			}
			
			return (Item[])retArr.ToArray(typeof(Item[]));
		}
*/
	}
}