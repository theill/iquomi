using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for ServiceCharge.
	/// </summary>
	[Serializable()]
	public class ServiceCharge {
		private int id;

		public int Id {
			get { return id; }
			set { id = value; }
		}

		private int serviceId;

		public int ServiceId {
			get { return serviceId; }
			set { serviceId = value; }
		}

		private int methodTypeId;

		public int MethodTypeId {
			get { return methodTypeId; }
			set { methodTypeId = value; }
		}

		private string schemaType;

		public string SchemaType {
			get { return schemaType; }
			set { schemaType = value; }
		}

		private string script;

		public string Script {
			get { return script; }
			set { script = value; }
		}

		private float price;

		public float Price {
			get { return price; }
			set { price = value; }
		}
		private int chargeUnitId;

		public int ChargeUnitId {
			get { return chargeUnitId; }
			set { chargeUnitId = value; }
		}
		
		public ServiceCharge() {
			;
		}
	}
}