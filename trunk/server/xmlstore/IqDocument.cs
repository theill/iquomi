#region Using directives

using System;
using System.Xml;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// Summary description for IqDocument.
	/// </summary>
	public class IqDocument {
		protected XmlDocument document;
		
		#region Properties
		public XmlDocument XmlDocument {
			get {
				return document;
			}

			set {
				document = value;
			}
		}

		private Guid instanceId;

		/// <summary>
		/// This attribute is a unique identifier typically assigned to the 
		/// root element of a service. It is a read-only element and assigned 
		/// when a particular service is provisioned for a user.
		/// </summary>
		public Guid InstanceId {
			get {
				if (!document.DocumentElement.HasAttribute("InstanceId", Api.CoreUtility.CoreNamespace)) {
					//	throw new ArgumentException("Required 'InstanceId' attribute not found in document.");
					// subscription data is not a basic "Iquomi" so it's not posible to read
					// unique id from root element
					return Guid.Empty;
				}

				return new Guid(document.DocumentElement.GetAttribute("InstanceId", Api.CoreUtility.CoreNamespace));
			}

			protected set {
				instanceId = value;
			}
		}

		private string changeNumber;

		/// <summary>
		/// This attribute is designed to facilitate caching of the element 
		/// and its descendants. This attribute is assigned to this element 
		/// by the Iquomi system. The attribute is read only to applications. 
		/// Attempts to write this attribute are silently ignored.
		/// </summary>
		/// <returns></returns>
		public string ChangeNumber {
			get {
				if (!document.DocumentElement.HasAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace)) {
//					throw new ArgumentException("Required 'ChangeNumber' attribute not found in document.");
					// subscription data is not a basic "Iquomi" service so it's not 
					// possible to keep track of changes
					return null;
				}

				return document.DocumentElement.GetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace);
			}

			protected set {
				this.changeNumber = value;
			}
		}
		#endregion

		public IqDocument(XmlDocument document) {
			this.document = document;
		}
	}
}