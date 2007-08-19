using System.Data;

using Commanigy.Iquomi.Api;
using System.ComponentModel;

namespace Commanigy.Iquomi.Data {
	/// <summary>
	/// 
	/// </summary>
	[DataObject()]
	public class DbServiceCharge : ServiceCharge, IDbObject<DbServiceCharge> {
		
		public DbServiceCharge() {
			;
		}
		
		#region IDbObject<DbServiceCharge> Members

		public DbServiceCharge DbCreate() {
			using (DbUtility db = new DbUtility("iqServiceChargeCreate")) {
				db.In("@service_id", this.ServiceId);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@schema_type", this.SchemaType);
				db.In("@script", DbType.String, DbHelper.ToNullString(this.Script));
				db.In("@price", DbType.Single, this.Price);
				db.In("@charge_unit_id", this.ChargeUnitId);
				Id = (int)db.ExecuteScalar();
				return this;
			}
		}

		public DbServiceCharge DbRead() {
			using (DbUtility db = new DbUtility("iqServiceChargeRead")) {
				db.In("@id", this.Id);
				return (DbServiceCharge)db.Fill(this);
			}
		}

		public DbServiceCharge DbUpdate() {
			using (DbUtility db = new DbUtility("iqServiceChargeUpdate")) {
				db.In("@id", this.Id);
				db.In("@service_id", this.ServiceId);
				db.In("@method_type_id", this.MethodTypeId);
				db.In("@schema_type", this.SchemaType);
				db.In("@script", DbType.String, DbHelper.ToNullString(this.Script));
				db.In("@price", DbType.Single, this.Price);
				db.In("@charge_unit_id", this.ChargeUnitId);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		public DbServiceCharge DbDelete() {
			using (DbUtility db = new DbUtility("iqServiceChargeDelete")) {
				db.In("@id", this.Id);
				return (db.ExecuteNonQuery() == 1) ? this : null;
			}
		}

		#endregion
		
		//public DataTable DbFindAll() {
		//    DbUtility db = new DbUtility("iqFindAllServiceCharges");
		//    db.In("@service_id", this.ServiceId);
		//    return db.GetDataTable();
		//}
		
		public static DataTable DbFindAllByService(int serviceId) {
			using (DbUtility db = new DbUtility("iqListAllServiceChargesByService")) {
				db.In("@service_id", serviceId);
				return db.GetDataTable();
			}
		}

	}
}