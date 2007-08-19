#region Using directives

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.WebServices {
	/// <summary>
	/// Summary description for IqCore.
	/// </summary>
	//[WebServiceBinding(ConformanceClaims = WsiClaims.BP10, EmitConformanceClaims = true)]
	[WebService(Description = "IqCore", Namespace = "http://services.iquomi.com/2004/01/core")]
	public class IqCore : IqCoreService {
		public override System.Reflection.Module ServiceModule {
			get { return null; }
		}
	}
}