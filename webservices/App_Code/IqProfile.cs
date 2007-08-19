#region Using directives

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Commanigy.Iquomi.Services.IqProfile;

#endregion

namespace Commanigy.Iquomi.WebServices {
	/// <summary>
	/// Summary description for IqProfile.
	/// </summary>
	//[WebServiceBinding(ConformanceClaims = WsiClaims.BP10, EmitConformanceClaims = true)]
	[WebService(Description = "IqProfile", Namespace = "http://services.iquomi.com/2004/01/iqProfile")]
	public class IqProfile : IqProfileService {

	}

}