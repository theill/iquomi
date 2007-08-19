using System.Xml.Serialization;

namespace Commanigy.Iquomi.Services {
    /// <remarks/>
    public partial class InsertRequestType {
        private object[] itemsField;
        
        /// <remarks/>
		public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }

	/// <remarks/>
	public partial class ReplaceRequestType {
		private object[] itemsField;

		/// <remarks/>
		public object[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
	}

    
    /// <remarks/>
    public partial class ChangedBlueType {
        private object[] itemsField;
        
        /// <remarks/>
		public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    public partial class XpQueryResponseType {
        private object[] itemsField;
        
        /// <remarks/>
		public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }

	public partial class ListenTriggerTypeContext {
		private object[] itemsField;

		/// <remarks/>
		public object[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
	}

}