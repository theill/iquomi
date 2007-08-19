using System;

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// Summary description for ServiceMethod.
	/// </summary>
	[Serializable()]
	public class ServiceMethod {
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

		private string name;

		public string Name {
			get { return name; }
			set { name = value; }
		}

		private string select;

		public string Select {
			get { return select; }
			set { select = value; }
		}

		private int methodTypeId;

		public int MethodTypeId {
			get { return methodTypeId; }
			set { methodTypeId = value; }
		}

		private string script;

		public string Script {
			get { return script; }
			set { script = value; }
		}

		private string scriptUrl;

		public string ScriptUrl {
			get { return scriptUrl; }
			set { scriptUrl = value; }
		}


		public ServiceMethod() {
			;
		}
	}
}