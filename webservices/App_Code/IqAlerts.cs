#region Using directives

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Commanigy.Iquomi.Services.IqAlerts;

#endregion

namespace Commanigy.Iquomi.WebServices {
	/// <summary>
	/// Summary description for IqAlerts.
	/// </summary>
	[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1, EmitConformanceClaims=true)]
	[WebService(Description = "IqAlerts", Namespace = "http://services.iquomi.com/2004/01/iqAlerts")]
	public class IqAlerts : IqAlertsService {

	}
}