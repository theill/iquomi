#region Using directives

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

using log4net;

using IqContactsRef;
using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Web;

#endregion

/// <summary>
/// TODO create web service so "IqSms" proxy classes are generated
/// </summary>
[DataObject(true)]
public class IqSmsHelper {
	protected static readonly ILog log = LogManager.GetLogger("WebSite");

	public ContactType[] Contacts;

	public IqSmsHelper() {

	}

	[DataObjectMethod(DataObjectMethodType.Select, true)]
	public static ContactType[] GetShortMessages() {
		log.Debug("IqSmsHelper.GetShortMessages()");

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
		q.XpQuery[0].Select = "/m:IqSms//m:ShortMessage";
		q.XpQuery[0].MinOccurs = 1;

		q.XpQuery[0].Options = new QueryOptionsType();
		q.XpQuery[0].Options.Sort = new SortType[] { new SortType()/*, new SortType() */};
		q.XpQuery[0].Options.Sort[0].Key = "concat(m:Name/mp:GivenName/text(), ' ', m:Name/mp:SurName/text())";
		q.XpQuery[0].Options.Sort[0].Direction = SortTypeDirection.Ascending;
//		q.XpQuery[0].Options.Sort[1].Key = "m:Name/mp:SurName/text()";
//		q.XpQuery[0].Options.Sort[1].Direction = SortTypeDirection.Ascending;

		QueryResponseType response = myService.Query(q);
		if (response.XpQueryResponse[0].Status == ResponseStatus.Success) {
			if (response.XpQueryResponse[0].Items != null) {
				return (ContactType[])Array.ConvertAll<object, ContactType>(response.XpQueryResponse[0].Items, delegate(object o) { return (ContactType)o; });
			}
		}

		return null;
	}

}