#region Using directives

using System;
using System.Xml.Serialization;

using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Locator {
	/// <summary>
	/// Summary description for ServiceRepository.
	/// </summary>
	[Serializable]
	public class ServiceRepository {
		public ServiceRepository() {
			;
		}
		
		public Service Get(string serviceName) {
			Service s = new Service();
			s.Name = serviceName;
			return s;
		}
	}
}