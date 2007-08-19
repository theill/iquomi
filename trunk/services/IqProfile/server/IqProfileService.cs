#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

using log4net;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Services.IqProfile {
	/// <summary>
	/// Core IqProfile service.
	/// 
	/// This service contains the ...
	/// </summary>
	//[System.Web.Services.Configuration.XmlFormatExtension("Xyz", "nothing", typeof(IqProfile.IqProfileType))]
	public class IqProfileService : IqCoreService {
		protected static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
		);
		
		public IqProfileService() {
			log.Debug("Service \"IqProfile\" initialized");
		}


		[WebMethod]
		[XmlInclude(typeof(IqProfileType))]
		public void Void(IqProfileType a) {
		}

		//[WebMethod]
		//public void TestQuery() {
		//    QueryRequestType q = new QueryRequestType();
		//    q.XpQuery = new XpQueryType[1];
		//    q.XpQuery[0] = new XpQueryType();
		//    q.XpQuery[0].Select = "/m:IqProfile";
		//    q.XpQuery[0].MinOccurs = 1;
		//    q.XpQuery[0].MaxOccurs = 1;

		//    QueryResponseType response = this.Query(q);
		//}

		public override System.Reflection.Module ServiceModule {
			get {
				return typeof(IqProfileType).Module;
			}
		}
}
}