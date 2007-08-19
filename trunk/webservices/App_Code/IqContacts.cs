#region Using directives

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Commanigy.Iquomi.Services.IqContacts;

#endregion

namespace Commanigy.Iquomi.WebServices {
	/// <summary>
	/// Summary description for IqContacts.
	/// </summary>
	//[WebServiceBinding(ConformanceClaims = WsiClaims.BP10, EmitConformanceClaims = true)]

	// ref. 'core' since this method is overriding the one defined in
	// the IqCoreService class. if we do not reference this one, it's
	// not possible to generate a correct proxy class since it would
	// refer to e.g. http://services.iquomi.com/2004/01/iqContacts/Listen
	// instead.
	[WebService(Description = "Summary description for IqContacts.", Namespace = "http://services.iquomi.com/2004/01/core")]
	public class IqContacts : IqContactsService {

	}

}