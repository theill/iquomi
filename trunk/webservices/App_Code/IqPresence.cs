#region Using directives

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Commanigy.Iquomi.Services.IqPresence;

#endregion

namespace Commanigy.Iquomi.WebServices {
	/// <summary>
	/// Summary description for IqPresence.
	/// </summary>
	[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1, EmitConformanceClaims=true)]
	[WebService(Description="IqPresence", Namespace="http://services.iquomi.com/2004/01/iqPresence")]
	public class IqPresence : IqPresenceService {

	}
}