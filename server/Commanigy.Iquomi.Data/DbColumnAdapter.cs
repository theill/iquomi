#region Using directives

using System;
using System.Data;
using System.Reflection;

using log4net;

#endregion

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// Summary description for DbColumnAdapter.
	/// </summary>
	public class DbColumnAdapter {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);
		
		private object instance_;

		public DbColumnAdapter(object obj) {
			instance_ = obj;
		}
		
		public object Load(IDataRecord record) {
			for (int i = 0; i < record.FieldCount; i++) {
				string n = record.GetName(i);
				object v = record.GetValue(i);
//				log.Debug(" " + n + " = " + v);
				
				SetProperty(n, v);
				SetField(n, v);
			}
			return instance_;
		}
		
		private void SetProperty(string n, object v) {
			PropertyInfo pi = instance_.GetType().GetProperty(
				AdaptColumnName(n)
				);
			if (pi == null) {
				return;
			}
			
			if (!v.Equals(DBNull.Value)) {
				pi.SetValue(instance_, v, null);
			}
		}
		
		private void SetField(string n, object v) {
			FieldInfo fi = instance_.GetType().GetField(
				AdaptColumnName(n)
				);
			if (fi == null) {
				return;
			}

			if (!v.Equals(DBNull.Value)) {
				try {
					fi.SetValue(instance_, v);
				}
				catch (Exception e) {
					log.Debug(string.Format("Failed to convert field \"{0}\" to value \"{1}\" ({2})", n, v, v.GetType().ToString()), e);
					throw;
				}
			}
		}

		/// <summary>
		/// Makes variable name based on column name.
		/// </summary>
		/// <param name="columnName">Name of column to 'convert'</param>
		/// <returns>Name of variable matching column.</returns>
		private string AdaptColumnName(string columnName) {
			string variableName = "";
			
			string[] np = columnName.ToLower().Split(new char[] {'_'});
			foreach (string n in np) {
				variableName += n.Substring(0, 1).ToUpper() + n.Substring(1);
			}

			return variableName;
		}
	}
}