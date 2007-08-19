#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Commanigy.Iquomi.Api;

using IqProfileRef;

#endregion

public partial class ProfilePage : System.Web.UI.MobileControls.MobilePage {
	protected void Page_Load(object sender, EventArgs e) {

	}

	protected void Command1_Click(object sender, EventArgs e) {
		ServiceLocator serviceLocator = new ServiceLocator(
			"http://services.iquomi.com/",
			"petertheill",
			"asdf"
			);

		IqProfile myService = (IqProfile)serviceLocator.GetService(
			typeof(IqProfile),
			"petertheill"
			);

		QueryRequestType req = new QueryRequestType();
		req.XpQuery = new XpQueryType[] { new XpQueryType() };
		req.XpQuery[0].Select = "/m:IqProfile";
		req.XpQuery[0].MinOccurs = 1;
		QueryResponseType res = myService.Query(req);
		if (res.XpQueryResponse[0].Status == ResponseStatus.Success) {
			IqProfileType p = (IqProfileType)res.XpQueryResponse[0].Items[0];
			TbxGivenName.Text = p.Name[0].GivenName.Value;
			TbxMiddleName.Text = p.Name[0].MiddleName.Value;
			TbxSurName.Text = p.Name[0].SurName.Value;
		}
		else {
			TbxGivenName.Text = "Can't load";
		}
	}
}
