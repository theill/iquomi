#region Using statements

using System;
using System.Configuration;
using System.Xml;
using System.Data;
using System.Collections;
using System.Text;

using log4net;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// The <b>DataStore</b> handles database connections.
	/// </summary>
	class DataStore {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private string connectionString = ConfigurationManager.ConnectionStrings["iquomi"].ConnectionString;
		
		private static readonly DataStore instance = new DataStore();
		
		private DataStore() {
			if (string.IsNullOrEmpty(connectionString)) {
				throw new ConfigurationErrorsException("Failed to look up connectionstring on property " + typeof(DataStore).FullName);
			}

			log.DebugFormat("DataStore initialized as {0}", this);
		}

		[Obsolete("Use instance property instead")]
		public static DataStore GetInstance() {
			return instance;
		}

		public static DataStore Instance {
			get {
				return instance;
			}
		}
		
		public IDbConnection GetConnection() {
			return new System.Data.SqlClient.SqlConnection(connectionString);
		}
	}
}