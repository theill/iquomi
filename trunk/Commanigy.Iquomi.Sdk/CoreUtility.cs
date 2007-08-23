#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Api {
	public class CoreUtility {
		public const string CoreNamespace = "http://schemas.iquomi.com/2004/01/core";
		
		public CoreUtility() {

		}
		
		public static string SplitIqid(byte[] creator) {
			return Encoding.UTF8.GetString(creator);
		}

		public static byte[] JoinIqid(string iqid) {
			return Encoding.UTF8.GetBytes(iqid);
		}

		public static string SplitPlatformId(byte[] creator) {
			throw new NotImplementedException();
		}

		public static byte[] JoinPlatformId(string platformId) {
			throw new NotImplementedException();
		}

		public static string SplitApplicationId(byte[] creator) {
			throw new NotImplementedException();
		}

		public static byte[] JoinApplicationId(string applicationId) {
			throw new NotImplementedException();
		}

	}
}