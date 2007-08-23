#region Using directives

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

using log4net;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Summary description for DbUtility.
	/// </summary>
	public class DbUtility : IDisposable {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private IDbConnection connection;
		private IDbCommand command;

		public DbUtility() : this(null) {

		}

		public DbUtility(string commandText) {
			connection = DataStore.Instance.GetConnection();
			if (commandText != null) {
				Cmd(commandText, CommandType.StoredProcedure);
			}
		}

		public void Cmd(string commandText, CommandType commandType) {
			command = connection.CreateCommand();
			command.CommandText = commandText;
			command.CommandType = commandType;
		}

		public void In(string name, DbType type, object v) {
			IDbDataParameter prm = command.CreateParameter();
			prm.ParameterName = name;
			prm.DbType = type;
			prm.Value = (v != null) ? v : DBNull.Value;
			command.Parameters.Add(prm);
		}

		#region Helper methods for commonly used types
		public void In(string name, int v) {
			this.In(name, DbType.Int32, v);
		}

		public void In(string name, string v) {
			this.In(name, DbType.String, v);
		}

		public void In(string name, float v) {
			this.In(name, DbType.Single, v);
		}

		public void In(string name, double v) {
			this.In(name, DbType.Double, v);
		}

		public void In(string name, DateTime v) {
			this.In(name, DbType.DateTime, v);
		}

		public void In(string name, Guid v) {
			this.In(name, DbType.Guid, v);
		}
		#endregion

		public void Out(string name, DbType type) {
			IDbDataParameter prm = command.CreateParameter();
			prm.ParameterName = name;
			prm.Direction = ParameterDirection.Output;
			prm.DbType = type;
			command.Parameters.Add(prm);
		}

		public object ExecuteScalar() {
			object o = null;
			try {
				Open();
				o = command.ExecuteScalar();
			}
			finally {
				Close();
			}
			return o;
		}

		public int ExecuteNonQuery() {
			int r = 0;
			try {
				Open();
				r = command.ExecuteNonQuery();
			}
			finally {
				Close();
			}
			return r;
		}

		/*
		public object ExecuteOut() {
			Open();
			command.ExecuteScalar();
			object o = ((IDbDataParameter)command.Parameters["@id"]).Value;
			Close();
			return o;
		}
		*/

		public object Fill(object obj) {
			try {
				Open();
				IDataReader rdr = command.ExecuteReader();
				if (rdr.Read()) {
					new DbColumnAdapter(obj).Load(rdr);
				}
			}
			finally {
				Close();
			}
			return obj;
		}

		public T Fill<T>(T obj) {
			try {
				Open();
				IDataReader rdr = command.ExecuteReader();
				if (rdr.Read()) {
					new DbColumnAdapter(obj).Load(rdr);
				}
			}
			finally {
				Close();
			}
			return obj;
		}

		public Array FillAll(System.Type t) {
			ArrayList list = new ArrayList();
			try {
				Open();
				IDataReader rdr = command.ExecuteReader();
				while (rdr.Read()) {
					object obj = Activator.CreateInstance(t);
					list.Add(new DbColumnAdapter(obj).Load(rdr));
				}
			}
			finally {
				Close();
			}
			return list.ToArray(t);
		}

		public List<object> GetList(System.Type t) {
			List<object> list = new List<object>();
			try {
				Open();
				IDataReader rdr = command.ExecuteReader();
				while (rdr.Read()) {
					object obj = Activator.CreateInstance(t);
					list.Add(new DbColumnAdapter(obj).Load(rdr));
				}
			}
			finally {
				Close();
			}
			return list;
		}

		public DataTable GetDataTable() {
			DataTable dt = new DataTable();
			try {
				Open();
				IDataReader rdr = command.ExecuteReader();

				DataTable schemaTable = rdr.GetSchemaTable();
				foreach (DataRow myRow in schemaTable.Rows) {
//				dt.Columns.Add(myRow["ColumnName"].ToString());
					dt.Columns.Add((string)myRow["ColumnName"], (Type)myRow["DataType"]);
				}

				while (rdr.Read()) {
					object[] v = new object[rdr.FieldCount];
					rdr.GetValues(v);
					dt.Rows.Add(v);
				}
			}
			finally {
				Close();
			}
			return dt;
		}

		private void Open() {
			connection.Open();
		}

		private void Close() {
			connection.Close();
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (connection.State == ConnectionState.Open)
			{
				this.Close();
				connection.Dispose();
				connection = null;
			}
		}

		#endregion
	}
}