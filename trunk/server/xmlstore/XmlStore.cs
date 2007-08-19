#region Using directives

using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using log4net;

using Commanigy.Iquomi.Services;

// TODO remove this reference and pattern out usage
using Commanigy.Iquomi.Data;

#endregion

// TODO we need to figure out another way of using referring "DeleteLog"
// since this is currently located in .Api - either place in .Store or
// figure out how to make an .Api <> .Store wrapper

// TODO look at "Role", "Scope" and "Shape" as well

// Research:
//  http://weblogs.asp.net/cazzu/archive/2004/05/31/144922.aspx

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// The <b>XmlStore</b> is capable of handling requests to update an Xml 
	/// document associated with an Iquomi subscription. This class supports
	/// five core operations: insert, replace, delete, update and query as 
	/// well as any number of service specific operations.
	/// </summary>
	public class XmlStore : IXmlStore {
		private static readonly ILog log = LogManager.GetLogger(
				MethodBase.GetCurrentMethod().DeclaringType
			);

		private Module serviceModule;
		
		#region Document definitions
		private ContentDocument content;
		private RoleListDocument roleList;
		private SystemDocument system;
		private NotifyListDocument notifyList;

		/// <summary>
		/// Property Content (ContentDocument)
		/// </summary>
		public ContentDocument ContentDocument {
			get {
				return this.content;
			}
		}

		/// <summary>
		/// Property RoleList (RoleListDocument)
		/// </summary>
		public RoleListDocument RoleListDocument {
			get {
				return this.roleList;
			}
		}

		/// <summary>
		/// Property System (SystemDocument)
		/// </summary>
		public SystemDocument SystemDocument {
			get {
				return this.system;
			}
		}

		/// <summary>
		/// Property Eventing (NotifyListDocument)
		/// </summary>
		public NotifyListDocument NotifyListDocument {
			get {
				return this.notifyList;
			}
		}
		#endregion

		public Module ServiceModule {
			get {
				return this.serviceModule;
			}

			set {
				this.serviceModule = value;
			}
		}

		public XmlStore(ContentDocument content, RoleListDocument roleList, NotifyListDocument notifyList, SystemDocument system) {
			log.Info("XmlStore initialized for content document \"" + content.InstanceId + "\"");
			this.content = content;
			this.roleList = roleList;
			this.notifyList = notifyList;
			this.system = system;
		}

		#region Insert
		/// <summary>
		/// A request to insert an <b>xdb:blue</b> or <b>xdb:red</b> into the 
		/// specified <b>xdb:blue</b>. The <b>Select</b> attribute must always 
		/// select an <b>xdb:blue</b>. This element selects a node-set within 
		/// the specified document relative to the externally established 
		/// current context.
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		public InsertResponseType Insert(SubjectType subject, InsertRequestType request) {

			if (string.IsNullOrEmpty(request.Select)) {
				throw new ArgumentException("Required \"Select\" attribute missing.");
			}

			InsertResponseType response = new InsertResponseType();

			List<XmlNode> nodes = GetNodes(subject, request.Select, RequestTypeMethod.Insert, null);

			// Initialize response with base data
			response = (InsertResponseType)InitResponse(response, nodes);

			// Get currently used changeNumber for subscription data
			string changeNumber = response.NewChangeNumber;

			if (!ValidateSelect(request, response)) {
				return response;
			}

			// Initiate document changes
			content.BeginEdit();

			// Increase changeNumber for use with changed nodes
			changeNumber = content.VolatileChangeNumber;

			if (request.Items != null) {
				request.Any = ConvertFromItems(request.Items);
			}

			// Ensure user has something to insert. If that's not the case
			// it is not necessary to iterate through all selected nodes.
			if (request.Any != null && request.Any.Length > 0) {

				List<NewBlueIdType> insertedGuids = new List<NewBlueIdType>(nodes.Count);

				// Perform actual insertion of node(s) as child of selected 
				// element(s). In case users "Select" targets attributes the
				// code fails
				try {
					// Iterate through all insertion points
					foreach (XmlElement element in nodes) {
						// Iterate through all user nodes needed to be 
						// inserted at this insertion point
						foreach (XmlElement userElement in request.Any) {
							// Import data element into subscription xml
							XmlElement input = (XmlElement)element.AppendChild(
								content.ImportNode(userElement, true)
								);

							// Check if user provides his own ids or if system 
							// should create GUIDs for each inserted node 
							// having an 'id' placeholder
							if (!request.UseClientIdsSpecified || !request.UseClientIds) {
								// TODO should be based by XSD and xdb:blue instead

								// Figure out which nodes in the input Xml 
								// we need to update with GUIDs by searching 
								// all elements having an empty id attribute
								insertedGuids.AddRange(InsertGuids(input));
							}

							// Update ChangeNumber attribute in node hierarchy
							UpdateChangeNumbers(input, Convert.ToString(changeNumber));

							PropagateChangeNumber(input, changeNumber);
						}
					}

					// Insert created GUIDs into response
					response.NewBlueId = insertedGuids.ToArray();
				}
				catch (Exception x) {
					response.Status = ResponseStatus.Failure;
					response.Message = x.Message;
					return response;
				}
			}

			// Insert any attributes specified in request as well
			foreach (XmlElement element in nodes) {
				if (SetAttributes(request.Attributes, element)) {
					PropagateChangeNumber(element, changeNumber);
				}
			}

			// Send events to subscribers for changed nodes
			NotifyListeners(subject, changeNumber);

			// Store updated Xml back into subscription
			content.AcceptChanges();

			// Report new change number back to client
			response.NewChangeNumber = changeNumber;

			response.Status = ResponseStatus.Success;

			return response;
		}
		#endregion Insert

		#region Delete
		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public DeleteResponseType Delete(SubjectType subject, DeleteRequestType request) {

			if (string.IsNullOrEmpty(request.Select)) {
				throw new ArgumentException("No \"Select\" attribute specified.");
			}

			DeleteResponseType response = new DeleteResponseType();

			List<XmlNode> nodes = GetNodes(subject, request.Select, RequestTypeMethod.Delete, null);

			// Initialize response with base data
			response = (DeleteResponseType)InitResponse(response, nodes);

			// Get currently used changeNumber for subscription data
			string changeNumber = response.NewChangeNumber;

			if (!ValidateSelect(request, response)) {
				return response;
			}

			// Initiate document changes
			content.BeginEdit();

			// Increase changeNumber for use with changed nodes
			changeNumber = content.VolatileChangeNumber;

			// Perform the actual removal of nodes from document based on
			// selected node type. It's possible to delete both element and
			// attributes
			foreach (XmlNode node in nodes) {
				if (node.NodeType == XmlNodeType.Element) {
					XmlNode parentNode = node.ParentNode;
					if (parentNode != null) {
						// TODO consider failing is root node is going to 
						// be deleted - might be catched by xsd validation
						parentNode.RemoveChild(node);
						string uuid = ((XmlElement)node).GetAttribute("Id", Api.CoreUtility.CoreNamespace);
						if (!string.IsNullOrEmpty(uuid)) {
							CreateDeleteLog(changeNumber, new Guid(uuid));
							PropagateChangeNumber(parentNode, changeNumber);
						}
					}
				}
				else if (node.NodeType == XmlNodeType.Attribute) {
					XmlAttribute a = (XmlAttribute)node;
					XmlElement e = (XmlElement)a.OwnerElement;
					e.RemoveAttribute(node.Name);

					// It's not possible to delete 'id' attribute so it is
					// safe to select it and store it into delete log.
					string uuid = e.GetAttribute("Id", Api.CoreUtility.CoreNamespace);
					CreateDeleteLog(changeNumber, new Guid(uuid));

					PropagateChangeNumber(e, changeNumber);
				}
			}

			// Send events to subscribers for changed nodes
			NotifyListeners(subject, changeNumber);

			// Store updated Xml back into subscription
			content.AcceptChanges();

			// Report new change number back to client
			response.NewChangeNumber = changeNumber;

			response.Status = ResponseStatus.Success;

			return response;
		}
		#endregion Delete

		#region Replace
		/// <summary>
		/// 
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		public ReplaceResponseType Replace(SubjectType subject, ReplaceRequestType request) {
			if (string.IsNullOrEmpty(request.Select)) {
				throw new ArgumentException("No \"Select\" attribute specified.");
			}

			ReplaceResponseType response = new ReplaceResponseType();

			List<XmlNode> nodes = GetNodes(subject, request.Select, RequestTypeMethod.Replace, null);

			// Initialize response with base data
			response = (ReplaceResponseType)InitResponse(response, nodes);

			// Get currently used changeNumber for subscription data
			string changeNumber = response.NewChangeNumber;

			if (!ValidateSelect(request, response)) {
				return response;
			}

			// Initiate document changes
			content.BeginEdit();

			// Increase ChangeNumber for use with changed nodes
			changeNumber = content.VolatileChangeNumber;

			bool dataReplaced = false;

			if (request.Items != null) {
				request.Any = ConvertFromItems(request.Items);
			}

			if (request.Any != null && request.Any.Length > 0) {
				try {
					dataReplaced |= ReplaceElements(request, response, nodes, changeNumber);
				}
				catch (Exception x) {
					// User might have selected an attribute with Select in
					// which case it's not allowed to have "Any" content filled
					response.Status = ResponseStatus.Failure;
					response.Message = x.Message;
					return response;
				}
			}
			else {
				dataReplaced = true;

				// All element nodes must be emptied 
				foreach (XmlNode n in nodes) {
					if (n.NodeType == XmlNodeType.Element) {
						XmlElement e = (XmlElement)n;
						e.InnerText = "";

						PropagateChangeNumber(e, changeNumber);
					}
				}
			}

			// Insert any attributes specified in request as well
			if (request.Attributes != null && request.Attributes.Length > 0) {
				dataReplaced |= ReplaceAttributes(request, nodes, changeNumber);
			}

			if (dataReplaced) {
				// Store updated Xml back into subscription
				content.AcceptChanges();
			}

			// Send events to subscribers for changed nodes
			if (response.NewBlueId.Length > 0 || response.NewChangeNumber != content.ChangeNumber) {
				NotifyListeners(subject, changeNumber);
			}

			// Report new change number back to client
			response.NewChangeNumber = content.ChangeNumber;

			response.Status = ResponseStatus.Success;

			return response;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="response"></param>
		/// <param name="nodes"></param>
		/// <param name="changeNumber"></param>
		/// <returns>True if some elements were replaced; false otherwise</returns>
		private bool ReplaceElements(ReplaceRequestType request, ReplaceResponseType response, List<XmlNode> nodes, string changeNumber) {
			List<NewBlueIdType> insertedGuids = new List<NewBlueIdType>(nodes.Count);

			bool elementsReplaced = false;

			// Perform actual insertion of node(s) as child of selected 
			// element(s). In case users "Select" selects attributes the
			// code fails
			foreach (XmlElement element in nodes) {
				foreach (XmlElement userElement in request.Any) {

					if (!IsChanged(element, userElement)) {
						log.Debug("Elements haven't changed: " + element.OuterXml);
						continue;
					}

					elementsReplaced = true;

					// Clone element to avoid modifying request node
					XmlElement input = (XmlElement)userElement.Clone();

					log.Debug("Replacing node:\n" + element.OuterXml + "\n with node:\n" + input.OuterXml);

					// Check if user provides his own ids or if system 
					// should create GUIDs for each inserted node 
					// having an 'id' placeholder
					if (!request.UseClientIdsSpecified || !request.UseClientIds) {
						// Figure out which nodes in the input Xml 
						// we need to update with GUIDs by searching 
						// all elements having an Id attribute being empty
						insertedGuids.AddRange(InsertGuids(input));
					}

					// Update ChangeNumber attribute in node hierarchy
					UpdateChangeNumbers(input, Convert.ToString(changeNumber));

					// notify parent element (and up) since 'element' is already 
					// having correct changeNumber (since it is replacing)
					PropagateChangeNumber(element.ParentNode, changeNumber);

					// Replace found node with new content
					element.ParentNode.ReplaceChild(
						content.ImportNode(input, true),
						element
						);
				}
			}

			// Insert created GUIDs into response
			response.NewBlueId = insertedGuids.ToArray();

			return elementsReplaced;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="nodes"></param>
		/// <param name="changeNumber"></param>
		private bool ReplaceAttributes(ReplaceRequestType request, List<XmlNode> nodes, string changeNumber) {
			bool attributesReplaced = false;

			foreach (XmlNode node in nodes) {
				XmlElement e = null;
				if (node.NodeType == XmlNodeType.Element) {
					e = (XmlElement)node;
				}
				else if (node.NodeType == XmlNodeType.Attribute) {
					XmlAttribute a = (XmlAttribute)node;
					e = (XmlElement)a.OwnerElement;
				}

				if (e == null) {
					continue;
				}

				if (SetAttributes(request.Attributes, e)) {
					attributesReplaced = true;

					PropagateChangeNumber(e, changeNumber);
				}
			}

			return attributesReplaced;
		}
		#endregion Replace

		#region Update
		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public UpdateResponseType Update(SubjectType subject, UpdateRequestType request) {

			UpdateResponseType response = new UpdateResponseType();
			response.UpdateBlockStatus = new UpdateBlockStatusType[request.UpdateBlock.Length];

			// Initialize UpdateBlock Statuses. It's needed since a given
			// block might fail in which case a full response is still being
			// returned to client.
			for (int i = 0; i < response.UpdateBlockStatus.Length; i++) {
				response.UpdateBlockStatus[i] = new UpdateBlockStatusType();
				response.UpdateBlockStatus[i].Status = ResponseStatus.NotAttempted;
			}

			// Iterate each update block and perform atomic operations.
			for (int i = 0; i < request.UpdateBlock.Length; i++) {
				XmlDocument backup = (XmlDocument)this.content.XmlDocument.Clone();

				UpdateBlockType block = request.UpdateBlock[i];

				response.UpdateBlockStatus[i] = this.UpdateBlock(subject, block);
				if (response.UpdateBlockStatus[i].Status != ResponseStatus.Failure) {
					continue;
				}

				switch (block.OnError) {
					case UpdateBlockTypeOnError.Ignore:
						// The block failed but it's acceptable so the
						// status must be updated to "Success"
						response.UpdateBlockStatus[i].Status = ResponseStatus.Success;
						break;

					case UpdateBlockTypeOnError.RollbackBlockAndContinue:
						// The block failed and the entire insert, 
						// delete and replace actions should be rolled
						// back however the other blocks should continue
						// to execute
						content.XmlDocument = backup;
						response.UpdateBlockStatus[i].Status = ResponseStatus.Rollback;
						break;

					case UpdateBlockTypeOnError.RollbackBlockAndFail:
						// The block failed and the entire block must be
						// rolled back and the update operation must then
						// fail.
						content.XmlDocument = backup;
						response.UpdateBlockStatus[i].Status = ResponseStatus.Rollback;
						return response;
				}
			}

			return response;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="block"></param>
		/// <returns></returns>
		public UpdateBlockStatusType UpdateBlock(SubjectType subject, UpdateBlockType block) {

			//			if (string.IsNullOrEmpty(block.Select)) {
			//				throw new ArgumentException("No \"select\" attribute specified.");
			//			}

			UpdateBlockStatusType response = new UpdateBlockStatusType();

			// TODO Use "Select" to allow block update of partial DOM

			//			XmlNodeList nodes = xml.SelectNodes(block.Select);
			//			
			//			// Return number of returned nodes matched by select
			//			response.SelectedNodeCount = (nodes != null) ? nodes.Count : 0;

			response.Status = ResponseStatus.Success;

			ArrayList responses = null;

			// Perform all "Insert" requests and capture responses
			if (block.InsertRequest != null) {
				responses = new ArrayList();
				foreach (InsertRequestType insertReq in block.InsertRequest) {
					InsertResponseType res = this.Insert(subject, insertReq);
					if (res.Status == ResponseStatus.Failure) {
						response.Status = ResponseStatus.Failure;
					}
					responses.Add(res);
				}
				response.InsertResponse = (InsertResponseType[])responses.ToArray(
					typeof(InsertResponseType)
					);
			}

			// Perform all "Delete" requests and capture responses
			if (block.DeleteRequest != null) {
				responses = new ArrayList();
				foreach (DeleteRequestType deleteReq in block.DeleteRequest) {
					DeleteResponseType res = this.Delete(subject, deleteReq);
					if (res.Status == ResponseStatus.Failure) {
						response.Status = ResponseStatus.Failure;
					}
					responses.Add(res);
				}
				response.DeleteResponse = (DeleteResponseType[])responses.ToArray(
					typeof(DeleteResponseType)
					);
			}

			// Perform all "Replace" requests and capture responses
			if (block.ReplaceRequest != null) {
				responses = new ArrayList();
				foreach (ReplaceRequestType replaceReq in block.ReplaceRequest) {
					ReplaceResponseType res = this.Replace(subject, replaceReq);
					if (res.Status == ResponseStatus.Failure) {
						response.Status = ResponseStatus.Failure;
					}
					responses.Add(res);
				}
				response.ReplaceResponse = (ReplaceResponseType[])responses.ToArray(
					typeof(ReplaceResponseType)
					);
			}

			return response;
		}
		#endregion Update

		#region Query
		/// <summary>
		/// 
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		public QueryResponseType Query(SubjectType subject, QueryRequestType request) {

			QueryResponseType response = new QueryResponseType();

			if (request.XpQuery != null) {
				response.XpQueryResponse = new XpQueryResponseType[request.XpQuery.Length];
				for (int i = 0; i < request.XpQuery.Length; i++) {
					XpQueryType query = request.XpQuery[i];
					response.XpQueryResponse[i] = this.XpQuery(subject, query);
				}
			}

			if (request.ChangeQuery != null) {
				response.ChangeQueryResponse = new ChangeQueryResponseType[request.ChangeQuery.Length];
				for (int i = 0; i < request.ChangeQuery.Length; i++) {
					ChangeQueryType query = request.ChangeQuery[i];
					response.ChangeQueryResponse[i] = this.ChangeQuery(subject, query);
				}
			}

			return response;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		protected XpQueryResponseType XpQuery(SubjectType subject, XpQueryType query) {
			if (string.IsNullOrEmpty(query.Select)) {
				throw new ArgumentException("No \"Select\" attribute specified.");
			}

			XpQueryResponseType response = new XpQueryResponseType();

			log.Debug("Executing query \"" + query.Select + "\"");

			// Calculate nodeset for subject performing operation
			List<XmlNode> nodes = GetNodes(subject, query.Select, RequestTypeMethod.Query, query.Options != null ? query.Options.Sort : null);

			// Return number of returned nodes matched by select after users
			// nodeset has been calculated and applied on content document.
			response.SelectedNodeCount = (nodes != null) ? nodes.Count : 0;
			
			// Initialize response to avoid returning a 'null' Any attribute
			response.Any = new XmlElement[0];

			if (!ValidateSelect(query, response)) {
				return response;
			}

			response.Any = nodes.ConvertAll<XmlElement>(delegate(XmlNode n) { return (XmlElement)n; }).ToArray();
			response.Items = ConvertToItems(nodes);

			return response;
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="nodes"></param>
		/// <returns></returns>
		protected object[] ConvertToItems(List<XmlNode> nodes) {
			if (ServiceModule == null) {
				return null;
			}

			if (nodes.Count == 0) {
				return new object[0];
			}

			string typeName = nodes[0].LocalName + "Type";
			string serviceName = this.content.XmlDocument.DocumentElement.LocalName;

			Type t = serviceModule.GetType("Commanigy.Iquomi.Services." + serviceName + "." + typeName);
			XmlSerializer xs = Api.ServiceUtils.GetSerializer(t, nodes[0].LocalName);

			return nodes.ConvertAll<object>(delegate(XmlNode n) {
				// TODO get type based on XSD and figure out a better way to
				// lookup this from module
				return Api.ServiceUtils.GetObject(xs, (XmlElement)n);
				//string typeName = n.LocalName + "Type";
				//string serviceName = this.content.XmlDocument.DocumentElement.LocalName;

				//Type t = serviceModule.GetType("Commanigy.Iquomi.Services." + serviceName + "." + typeName);
				//return Api.ServiceUtils.GetObject(t, (XmlElement)n);
				}).ToArray();
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		protected XmlElement[] ConvertFromItems(object[] items) {
			XmlElement[] elements = new XmlElement[items.Length];
			for (int i = 0; i < items.Length; i++) {
				string elementName = items[i].GetType().Name;
				elementName = elementName.Remove(elementName.Length - 4);
				elements[i] = Api.ServiceUtils.SetObject(items[i], elementName);
			}
			return elements;
		}

		//void validator_ValidationEventHandler(object sender, ValidationEventArgs e) {
		//    Console.Write(e);
		//}

		//void xsdset_ValidationEventHandler(object sender, ValidationEventArgs e) {
		//    Console.Write(e);
		//}

		//void xrs_ValidationEventHandler(object sender, ValidationEventArgs e) {
		//    Console.Write(e);
		//}

		//void Schemas_ValidationEventHandler(object sender, ValidationEventArgs e) {
		//    Console.Write(e);
		//}


		/// <summary>
		/// It is an error condition to select more than a single node.
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		protected ChangeQueryResponseType ChangeQuery(SubjectType subject, ChangeQueryType query) {

			if (string.IsNullOrEmpty(query.Select)) {
				throw new ArgumentException("No \"Select\" attribute specified.");
			}

			ChangeQueryResponseType response = new ChangeQueryResponseType();

			// Init response
			response.BaseChangeNumber = query.BaseChangeNumber;
			response.ChangedBlue = new ChangedBlueType[0];
			response.DeletedBlue = new DeletedBlueType[0];
			response.Status = ResponseStatus.Failure;

			// It's only possible to select one "blue" node. These kind of 
			// nodes contains an "Id" and "ChangeNumber" attribute which 
			// are necessary for synchronization
			List<XmlNode> nodes = GetNodes(subject, query.Select, RequestTypeMethod.Query, null);
			if (nodes.Count != 1) {
				response.Status = ResponseStatus.Failure;
				return response;
			}

			XmlElement topElement = (XmlElement)nodes[0];
			string topChangeNumber = topElement.GetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace);

			// Locate any deleted blue nodes from the delete log
			Api.DeleteLog[] deleteLog = GetDeleteLog();
			response.DeletedBlue = new DeletedBlueType[deleteLog.Length];
			for (int i = 0; i < deleteLog.Length; i++) {
				response.DeletedBlue[i] = new DeletedBlueType();
				response.DeletedBlue[i].Id = deleteLog[i].Uuid.ToString();
			}

			// Don't process children if no changes has been made to top node
			if (Convert.ToUInt64(topChangeNumber) <= Convert.ToUInt64(query.BaseChangeNumber)) {
				response.Status = ResponseStatus.Success;
				return response;
			}

			// Select all direct children having Id and ChangeNumber attributes
			// i.e. select blue nodes
			XmlNodeList children = topElement.SelectNodes("./*[@*[iq:Id] and @*[iq:ChangeNumber]]", system.GetNamespaceManager());

			ArrayList changed = new ArrayList(children.Count);
			foreach (XmlElement e in children) {
				// Return children with change numbers greater than base
				UInt64 changeNumber = Convert.ToUInt64(e.GetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace));
				if (changeNumber > Convert.ToUInt64(query.BaseChangeNumber)) {
					changed.Add(e);
				}
			}

			if (changed.Count > 0) {
				response.ChangedBlue = new ChangedBlueType[changed.Count];
				for (int i = 0; i < changed.Count; i++) {
					response.ChangedBlue[i] = new ChangedBlueType();
					response.ChangedBlue[i].Any = new XmlElement[] { (XmlElement)changed[i] };
				}
			}
			else {
				// TODO this is an interesting scenario. the requested node
				// doesn't contain any changed children so either one or
				// more nodes were -deleted- (handled by deletedBlue) or one 
				// of the attributes on the requested node has been changed.
				// Should we consider adding 'changedRed' and 'deletedRed'
				// node elements as well? Since we do only allow *one* node
				// to be selected in the "select" it's possible to do it.
			}

			// Sync returned change number with currently stored number on 
			// requested node.
			response.BaseChangeNumber = topChangeNumber.ToString();

			response.Status = ResponseStatus.Success;

			return response;
		}
		#endregion Query

		#region Utility Methods
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected Api.DeleteLog[] GetDeleteLog() {
			DbDeleteLog d = new DbDeleteLog();
			d.SubscriptionId = content.InstanceId;
			return d.DbFindAll();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="changeNumber"></param>
		/// <param name="uuid"></param>
		protected void CreateDeleteLog(string changeNumber, Guid uuid) {
			DbDeleteLog d = new DbDeleteLog();
			d.SubscriptionId = content.InstanceId;
			d.ChangeNumber = Convert.ToUInt64(changeNumber);
			d.Uuid = uuid;
			d.DbCreate();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="minOccursSpecified"></param>
		/// <param name="minOccurs"></param>
		/// <param name="maxOccursSpecified"></param>
		/// <param name="maxOccurs"></param>
		/// <param name="selectedNodeCount"></param>
		/// <param name="responseStatus"></param>
		/// <returns></returns>
		private bool ValidateSelect(bool minOccursSpecified, int minOccurs, bool maxOccursSpecified, int maxOccurs, int selectedNodeCount, out ResponseStatus responseStatus) {
			if (selectedNodeCount == 0) {
				// No nodes selected. Look at "MinOccurs" attribute to 
				// determine if this is a failure or expected
				if (!minOccursSpecified || minOccurs == 0) {
					responseStatus = ResponseStatus.Success;
				}
				else {
					responseStatus = ResponseStatus.Failure;
				}

				return false;
			}

			// Too few nodes was selected with xpath so these should not 
			// be handled; fail
			if (minOccursSpecified && minOccurs > selectedNodeCount) {
				responseStatus = ResponseStatus.Failure;
				return false;
			}

			// Too many nodes was selected with xpath so these should not 
			// be handled; fail
			if (maxOccursSpecified && maxOccurs < selectedNodeCount) {
				responseStatus = ResponseStatus.Failure;
				return false;
			}

			responseStatus = ResponseStatus.Success;
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nodes"></param>
		/// <param name="req"></param>
		/// <param name="res"></param>
		/// <returns></returns>
		protected bool ValidateSelect(InsertRequestType req, InsertResponseType res) {
			ResponseStatus rs;
			bool ret = ValidateSelect(req.MinOccursSpecified, req.MinOccurs, req.MaxOccursSpecified, req.MaxOccurs, res.SelectedNodeCount, out rs);
			res.Status = rs;
			return ret;
		}

		protected bool ValidateSelect(DeleteRequestType req, DeleteResponseType res) {
			ResponseStatus rs;
			bool ret = ValidateSelect(req.MinOccursSpecified, req.MinOccurs, req.MaxOccursSpecified, req.MaxOccurs, res.SelectedNodeCount, out rs);
			res.Status = rs;
			return ret;
		}

		protected bool ValidateSelect(ReplaceRequestType req, ReplaceResponseType res) {
			ResponseStatus rs;
			bool ret = ValidateSelect(req.MinOccursSpecified, req.MinOccurs, req.MaxOccursSpecified, req.MaxOccurs, res.SelectedNodeCount, out rs);
			res.Status = rs;
			return ret;
		}

		protected bool ValidateSelect(XpQueryType req, XpQueryResponseType res) {
			ResponseStatus rs;
			bool ret = ValidateSelect(req.MinOccursSpecified, req.MinOccurs, req.MaxOccursSpecified, req.MaxOccurs, res.SelectedNodeCount, out rs);
			res.Status = rs;
			return ret;
		}

		/*
				/// <summary>
				/// 
				/// </summary>
				/// <param name="select"></param>
				/// <returns></returns>
				protected string ShapeSelection(string select) {
					// $ns1[count(. | $ns2) = count($ns2)]
					// /xbel/*[count(. | //folder[title!='Applications']) = count(//folder[title!='Applications'])]
			
					// select all nodes under a given 'blue node' (for inserts)
					// (/)[count(. | /xbel/*) = count(/xbel/*)] | (//*)[count(. | /xbel) = count(/xbel)]

					// (//folder[folder/title='Browsers'])[count(. | /xbel/*) = count(/xbel/*)]
					return select;
			
		//			string shape = "";
		//			if (shapes != null && shapes.Length > 0) {
		//				StringBuilder buffer = new StringBuilder();
		//				buffer.Append("[");
		//				foreach (Shape s in shapes) {
		//					buffer.Append(String.Format("count(. | {0}) = count({0})", s.Select));
		//					buffer.Append(" or ");
		//				}
		//
		//				// Trim out last 'and'
		//				buffer.Length = buffer.Length - 4;
		//
		//				buffer.Append("]");
		//
		//				shape = buffer.ToString();
		//
		//				log.Debug("Preparing to execute xpath with shape: " + shape);
		//			}
		//
		//			log.Debug("Shaped selection: " + String.Format("({0}){1}", select, shape));
		//			return String.Format("({0}){1}", select, shape);
				}
		*/


		/// <summary>
		/// 
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		private List<XmlNode> GetNodes(SubjectType subject, string select, RequestTypeMethod method, SortType[] sorting) {
			// Initially select out all nodes matching users query
			XPathNodeIterator nodes = content.SelectNodes(select, system.GetNamespaceManager(), sorting);
			if (nodes == null || nodes.Count == 0) {
				return new List<XmlNode>();
			}

			// Based on this query filter out nodes the user can't see based on
			// roletemplate and scope

			// Get role of user executing request. Throws exception if user isn't
			// allow to access content document of service
			RoleType r = roleList.GetRole(subject);

			ScopeType roleListScope = roleList.GetRoleListScope(r.ScopeRef);

			ScopeType roleTemplateScope = system.GetRoleTemplateScope(
				r.RoleTemplateRef, 
				Enum.GetName(typeof(RequestTypeMethod), method)
				);

			return ShapeNodes(nodes, roleListScope, roleTemplateScope);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="nodes">Initial nodeset selected by query</param>
		/// <param name="roleListScope">Scope to apply on nodeset overriding any shapes from a role template scope</param>
		/// <param name="roleTemplateScope">Scope to apply on nodeset</param>
		/// <returns></returns>
		private List<XmlNode> ShapeNodes(XPathNodeIterator nodes, ScopeType roleListScope, ScopeType roleTemplateScope) {
			XmlNamespaceManager nsmgr = system.GetNamespaceManager();

			// Get all nodes available for selection by applying shapes for
			// calculated role template
			Dictionary<string, ShapeType> shapedNodes = new Dictionary<string, ShapeType>();

			foreach (ShapeType s in roleTemplateScope.Shape) {
				XmlNodeList shapeNodes = content.SelectNodes(s.Select, nsmgr);

				// Every shape *must* target elements - attributes are not allowed!
				foreach (XmlElement e in shapeNodes) {
					// Use attribute "Id" since it's a required attribute on 
					// all "blue" nodes possible to shape in/out.
//					string id = e.GetAttribute("Id", Api.CoreUtility.CoreNamespace);
					string id = e.OuterXml;
					shapedNodes.Add(id, s);
				}
			}

			// adds role list scope shapes and override any existing ones 
			// from role template scope
			if (roleListScope != null) {
				foreach (ShapeType s in roleListScope.Shape) {
					XmlNodeList shapeNodes = content.SelectNodes(s.Select, nsmgr);

					// Every shape *must* target elements - attributes are not allowed!
					foreach (XmlElement e in shapeNodes) {
						// Use attribute "Id" since it's a required attribute on 
						// all "blue" nodes possible to shape in/out.
//						string id = e.GetAttribute("Id", Api.CoreUtility.CoreNamespace);
						string id = e.OuterXml;
						if (shapedNodes.ContainsKey(id)) {
							shapedNodes[id] = s;
						}
						else {
							shapedNodes.Add(id, s);
						}
					}
				}
			}

			List<XmlNode> intersectedNodes = new List<XmlNode>();
			while (nodes.MoveNext()) {
				XmlNode n = ((IHasXmlNode)nodes.Current).GetNode();
				//if (nodes.Current is IHasXmlNode) {
				//    n = ((IHasXmlNode)nodes.Current).GetNode();
				//}

//	XPathNavigator node = nodes.Current;

				XmlElement secureElement = null;
				if (n.NodeType == XmlNodeType.Element) {
					secureElement = (XmlElement)n;
				}
				else if (n.NodeType == XmlNodeType.Attribute) {
					XmlAttribute attribute = (XmlAttribute)n;
					secureElement = attribute.OwnerElement;
				}

				// An "Id" attribute is required on a selected node
//				string id = secureElement.GetAttribute("Id", Api.CoreUtility.CoreNamespace);
				string id = secureElement.OuterXml;

				ShapeType shape = null;
				if (shapedNodes.ContainsKey(id)) {
					shape = shapedNodes[id];
				}
				else {
					if (roleListScope != null) {
						if (roleListScope.Base == ScopeTypeBase.T) {
							intersectedNodes.Add(n);
							continue;
						}
					}
					else if (roleTemplateScope.Base == ScopeTypeBase.T) {
						intersectedNodes.Add(n);
						continue;
					}
				}

				ShapeTypeType shapeType = (shape != null) ? shape.Type : ShapeTypeType.Exclude;

				if (shapeType == ShapeTypeType.Exclude) {
					;
				}
				else if (shapeType == ShapeTypeType.Include) {
					if (n.NodeType == XmlNodeType.Attribute) {
						// what to do?
					}

					intersectedNodes.Add(n);
				}
			}

			return intersectedNodes;
		}
		
		
/*
		private IEnumerator ShapeSelection(XmlNodeList selection, out int nodeCount) {
			if (roleTemplateScope == null || roleTemplateScope.Shapes == null || roleTemplateScope.Shapes.Length == 0) {
				nodeCount = selection.Count;
				return selection.GetEnumerator();
			}

			Hashtable ht = new Hashtable();
			foreach (Shape s in roleTemplateScope.Shapes) {
				XmlNodeList shapeNodes = xml.SelectNodes(s.Select);
				foreach (XmlNode n in shapeNodes) {
					ht.Add(n.GetHashCode(), s.Type);
				}
			}

			if (ht.Count == 0) {
				// WHY?!?!?
				nodeCount = selection.Count;
				return selection.GetEnumerator();
			}

			ArrayList safeNodes = new ArrayList();
			foreach (XmlNode n in selection) {
				string t = (string)ht[n.GetHashCode()];
				if ("E".Equals(t)) {
					;
				} else if ("I".Equals(t)) {
					if (n.NodeType == XmlNodeType.Attribute) {
						;
					}
					XmlNode n2 = n.Clone();
					safeNodes.Add(n2);
				} else if (t == null && roleTemplateScope.Base == "T") {
					// TODO look at base from scope
					safeNodes.Add(n);
				}
			}

			nodeCount = safeNodes.Count;

			return safeNodes.GetEnumerator();
		}
*/


		/// <summary>
		/// Notify all subscribers listening to blue nodes with the selected
		/// "ChangeNumber". Since a "ChangeNumber" is propagated up in the
		/// tree it's possible to listen on a top level and get notification
		/// when a child is changed.
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="changeNumber"></param>
		protected void NotifyListeners(SubjectType subject, string changeNumber) {
			log.Debug(string.Format("NotifyListeners(subject={0}, changeNumber={1})", subject.UserId, changeNumber));

			ListenerType[] listeners = notifyList.GetListeners();
			log.Debug("Listeners: " + (listeners != null ? listeners.Length : 0));
			foreach (ListenerType listener in listeners) {
				List<XmlNode> nl = null;
				try {
					SubjectType st = new SubjectType();
					st.UserId = Api.CoreUtility.SplitIqid(listener.Creator);
					nl = GetNodes(st, listener.Trigger.Select, RequestTypeMethod.Query, null);
					if (log.IsDebugEnabled) {
						log.Debug(string.Format("{0} node(s) retrieved:", nl.Count));
						log.Debug(" To:     " + listener.To);
						log.Debug(" Select: " + listener.Trigger.Select);
					}
				}
				catch (System.Security.SecurityException se) {
					log.Debug("User '" + Api.CoreUtility.SplitIqid(listener.Creator) + "' has no access to '" + listener.Trigger.Select + "' in this subscription. " + se.Message);
					continue;
				}
				catch (Exception e) {
					log.Debug("Can't get listener nodes since filter \"" + listener.Trigger.Select + "\" is malformed", e);
					continue;
				}

				foreach (XmlNode n in nl) {
					if (n.NodeType != XmlNodeType.Element) {
						// listeners MUST only target blue nodes
						if (log.IsDebugEnabled) {
							log.Debug("Node below wasn't an element:");
							log.Debug(n.OuterXml);
						}
						continue;
					}
					
					XmlElement e = (XmlElement)n;

					if (!e.HasAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace)) {
						log.Debug("Element doesn't have a 'ChangeNumber' attribute");
						continue;
					}

					log.Debug("ChangeNumber " + changeNumber + " is being propagated");

					// Notify when change number has been just updated
					string listenChangeNumber = e.GetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace);
					if (listenChangeNumber.Equals(changeNumber)) {
						Notify(subject, listener, e);
					}
				}
			}
		}

		/// <summary>
		/// Notify a specific listener.
		/// </summary>
		/// <param name="e" />
		/// <param name="listener" />
		/// <param name="subject" />
		protected void Notify(SubjectType subject, ListenerType listener, XmlElement e) {
			log.Debug("Notifying listener \"" + Api.CoreUtility.SplitIqid(listener.Creator) + "\" via \"" + listener.To + "\" about changed element \"" + e.Name + "\"");

			switch (listener.To) {
				case "iq:iqAlerts":
				case "iqAlerts":
				case "IqAlerts":
					NotifyIqAlerts(subject, listener, e);
					break;

				case ".NET Alerts":
					// TODO dispatch as MS .NET Alerts; special service contract
					// is needed for this one.
					log.Debug("Notifying using .NET Alerts");
					break;

				default:
					NotifyExternal(listener, e);
					break;
			}
		}

		private void NotifyIqAlerts(SubjectType subject, ListenerType listener, XmlElement e) {
			log.Debug("Using iqAlerts as notification channel");

			// TODO setup trust somehow => no need to forward password
			Api.ServiceLocator serviceLocator = new Api.ServiceLocator(
				"http://services.iquomi.com/",
				subject.UserId,
				""
				);
			IqAlertsRef.IqAlerts iqAlerts = (IqAlertsRef.IqAlerts)serviceLocator.GetService(
				typeof(IqAlertsRef.IqAlerts),
				Api.CoreUtility.SplitIqid(listener.Creator)
				);

			if (listener.Trigger.Mode == ListenerTypeTriggerMode.IncludeData) {
				;
			}

			IqAlertsRef.NotifyType nt = new IqAlertsRef.NotifyType();
			nt.Content = new IqAlertsRef.ViewType();
			nt.Content.ContentType = "text/html";
			nt.Content.DeviceHint = "None";
			nt.Content.Subject = "My subject";
			nt.Content.Value = e.OuterXml;
			nt.Language = "en-US";
			nt.Meta = new IqAlertsRef.MetaType();
			nt.Meta.ActionUrl = "http://action.iquomi.com/";
			nt.Meta.BaseUrl = "http://service.iquomi.com/";
			nt.Meta.IconUrl = "None";
			nt.Meta.Subject = "Meta subject";
			nt.Meta.SubscriptionUrl = "http://subscribe.iquomi.com/";

			iqAlerts.NotifyCompleted += new IqAlertsRef.NotifyCompletedEventHandler(myService_NotifyCompleted);
			iqAlerts.NotifyAsync(nt);
		}

		private void NotifyExternal(ListenerType listener, XmlElement e) {
			log.Debug("Notifying external webservice at \"" + listener.To + "\"");

			// TODO setup trust somehow => no need to forward password
			Api.ServiceLocator serviceLocator = new Api.ServiceLocator(
				"http://services.iquomi.com/",
				Api.CoreUtility.SplitIqid(listener.Creator),
				""
				);
			IqCoreRef.IqCore iqService = (IqCoreRef.IqCore)serviceLocator.GetService(
				typeof(IqCoreRef.IqCore),
				Api.CoreUtility.SplitIqid(listener.Creator)
				);
			iqService.Url = listener.To;
			// TODO find better way to extract service name
			iqService.SoapRequestTypeValue.Value.Service = listener.To.Substring(
				listener.To.LastIndexOf('/') + 1,
				listener.To.IndexOf(".asmx") - listener.To.LastIndexOf('/') - 1
				);

			IqCoreRef.ListenTriggerType lr = new IqCoreRef.ListenTriggerType();
			lr.Context = new IqCoreRef.ListenTriggerTypeContext();
			lr.Context.Uri = listener.Context.Uri;
			lr.Context.Any = new XmlElement[] { e };
			iqService.ListenResponse(lr);
		}

		void myService_NotifyCompleted(object sender, IqAlertsRef.NotifyCompletedEventArgs e) {
			if (e.Error == null) {
				log.Debug("Got Notify response. Status: " + e.Result.Status.ToString());
			}
			else {
				log.Error("Failed to receive Notify response. " + e.Error.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributes"></param>
		/// <param name="dst"></param>
		private bool SetAttributes(RedAttributeType[] attributes, XmlElement dst) {
			if (attributes == null || attributes.Length == 0) {
				return false;
			}

			foreach (RedAttributeType attr in attributes) {
				dst.SetAttribute(attr.Name, attr.Value);
			}

			return true;
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="n"></param>
		/// <param name="changeNumber"></param>
		private void PropagateChangeNumber(XmlNode n, string changeNumber) {
			if (n == null || n.NodeType != XmlNodeType.Element) {
				return;
			}

			XmlElement e = (XmlElement)n;

			// TODO look up this logic from xsd instead

			// Update nodes having a changeNumber attribute
			if (e.HasAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace)) {
				string cn = Convert.ToString(changeNumber);
				if (!e.GetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace).Equals(cn)) {
					e.SetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace, cn);
				}
			}

			PropagateChangeNumber(e.ParentNode, changeNumber);
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="original"></param>
		/// <param name="updated"></param>
		/// <returns></returns>
		private bool IsChanged(XmlElement original, XmlElement updated) {
			return !original.OuterXml.Equals(updated.OuterXml);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="guidList"></param>
		/// <param name="changeNumber"></param>
		/// <returns></returns>
		private ArrayList MergeGuidIntoDocument(XmlNodeList guidList, string changeNumber) {
			// Figure out which nodes in the input Xml we need to update 
			// with GUIDs by searching all elements having an empty id
			// attribute
			ArrayList insertedGuids = new ArrayList();

			if (guidList != null && guidList.Count > 0) {
				string changeNumberString = Convert.ToString(changeNumber);

				// Create global unique id (GUID) for inserted node
				foreach (XmlElement e in guidList) {
					e.SetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace, changeNumberString);
					insertedGuids.Add(InsertGuid(e));
				}
			}

			return insertedGuids;
		}


		private NewBlueIdType InsertGuid(XmlElement e) {
			NewBlueIdType blueId = new NewBlueIdType();
			blueId.Id = Guid.NewGuid().ToString();
			e.SetAttribute("Id", Api.CoreUtility.CoreNamespace, blueId.Id);
			return blueId;
		}


		/// <summary>
		/// Iterates XmlElement and its childnodes and inserts GUIDs for all
		/// empty "Id" attributes.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		private IEnumerable<NewBlueIdType> InsertGuids(XmlElement e) {
			// TODO look up this logic from xsd instead

			List<NewBlueIdType> list = new List<NewBlueIdType>();

			if (e.HasAttribute("Id", Api.CoreUtility.CoreNamespace) && "".Equals(e.GetAttribute("Id", Api.CoreUtility.CoreNamespace))) {
				list.Add(InsertGuid(e));
			}

			if (!e.HasChildNodes) {
				return list;
			}

			foreach (XmlNode n in e.ChildNodes) {
				if (n.NodeType == XmlNodeType.Element) {
					list.AddRange(InsertGuids(n as XmlElement));
				}
			}

			return list;
		}


		private void UpdateChangeNumbers(XmlElement e, string changeNumber) {
			// Update and *override* any ChangeNumber attributes available
			// in searched hierarchy
			// TODO look up this logic from xsd instead
			if (e.HasAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace)) {
				e.SetAttribute("ChangeNumber", Api.CoreUtility.CoreNamespace, changeNumber);
			}

			foreach (XmlNode n in e.ChildNodes) {
				if (n.NodeType == XmlNodeType.Element) {
					UpdateChangeNumbers(n as XmlElement, changeNumber);
				}
			}
		}


		private InsertResponseType InitResponse(InsertResponseType response, IList nodes) {
			// Return number of returned nodes matched by select
			response.SelectedNodeCount = (nodes != null) ? nodes.Count : 0;
			response.Status = ResponseStatus.NotAttempted;

			// Get currently used changeNumber for subscription data
			response.NewChangeNumber = content.ChangeNumber;
			response.NewBlueId = new NewBlueIdType[0];

			return response;
		}


		private DeleteResponseType InitResponse(DeleteResponseType response, IList nodes) {
			// Return number of returned nodes matched by select
			response.SelectedNodeCount = (nodes != null) ? nodes.Count : 0;
			response.Status = ResponseStatus.NotAttempted;

			// Get currently used changeNumber for subscription data
			response.NewChangeNumber = content.ChangeNumber;

			return response;
		}


		private ReplaceResponseType InitResponse(ReplaceResponseType response, IList nodes) {
			// Return number of returned nodes matched by select
			response.SelectedNodeCount = (nodes != null) ? nodes.Count : 0;
			response.Status = ResponseStatus.NotAttempted;
			
			// Get currently used changeNumber for subscription data
			response.NewChangeNumber = content.ChangeNumber;
			response.NewBlueId = new NewBlueIdType[0];

			return response;
		}

		#endregion
	}
}