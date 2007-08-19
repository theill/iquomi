#region Using directives

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Text;

using log4net;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// Summary description for IqDocumentFactory.
	/// </summary>
	public abstract class IqDocumentFactory {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

//		public static IqDocument Create(IqDocumentType type, Api.Subscription subscription) {
//			switch (type) {
//				case IqDocumentType.Content:
//					return new ContentDocument(CreateContentDocument(subscription));
//
//				case IqDocumentType.RoleList:
//					return new RoleListDocument(CreateRoleListDocument(subscription));
//
//				case IqDocumentType.System:
//					Api.Service service = null;//subscription.ServiceId;
//					return new SystemDocument(CreateSystemDocument(service));
//
//				case IqDocumentType.Eventing:
//					return new NotifyListDocument(CreateEventingDocument(subscription));
//			}
//
//			throw new Exception("Can't create document - unknown type " + type.ToString());
//		}

		private static XmlDocument CreateContentDocument(Api.Subscription s) {
			return s.GetXmlDocument();
		}

		private static XmlDocument CreateRoleListDocument(Api.Subscription s) {
			XmlDocument d = new XmlDocument();

			StringBuilder xml = new StringBuilder();
			XmlSerializer serializer = new XmlSerializer(typeof(Services.RoleListType));
			serializer.Serialize(XmlWriter.Create(xml), s.RoleList);
			d.LoadXml(xml.ToString());
			
//			XmlElement e = d.CreateElement("roleList");
//
//			DbSubscriptionScope ss = new DbSubscriptionScope();
//			DbScope[] scopes = ss.DbFindAllScopesBySubscription();
//			foreach (DbScope scope in scopes) {
//				XmlElement scopeNode = d.CreateElement("scope");
//				scopeNode.SetAttribute("id", Convert.ToString(scope.Id));
//				scopeNode.SetAttribute("base", scope.Base);
//
//				DbShape[] shapes = scope.DbFindAllShapes();
//				foreach (DbShape shape in shapes) {
//					XmlElement shapeNode = d.CreateElement("shape");
//					shapeNode.SetAttribute("select", shape.Select);
//					shapeNode.SetAttribute("type", shape.Type);
//					scopeNode.AppendChild(shapeNode);
//				}
//				e.AppendChild(scopeNode);
//			}
//
//			DbRole[] roles = s.DbFindAllRoles();
//			foreach (DbRole role in roles) {
//				XmlElement roleNode = d.CreateElement("role");
//				if (role.ScopeId > 0) {
//					roleNode.SetAttribute(
//						"scopeRef", 
//						Convert.ToString(role.ScopeId)
//						);
//				}
//				roleNode.SetAttribute("roleTemplateRef", Convert.ToString(role.RoleTemplateId));
//				
//				XmlElement subjectNode = d.CreateElement("subject");
//				DbAccount account = new DbAccount();
//				account.Id = role.AccountId;
//				account = DbAccount.DbRead(account);
//				subjectNode.SetAttribute("userId", account.Iqid);
//				roleNode.AppendChild(subjectNode);
//
//				XmlElement activeFromNode = d.CreateElement("activeFrom");
//				activeFromNode.InnerText = role.ActiveFrom.ToString();
//				roleNode.AppendChild(activeFromNode);
//
//				XmlElement activeToNode = d.CreateElement("activeTo");
//				activeToNode.InnerText = role.ActiveTo.ToString();
//				roleNode.AppendChild(activeToNode);
//
//				e.AppendChild(roleNode);
//			}
//
//			d.AppendChild(e);

			return d;
		}

		private static XmlDocument CreateSystemDocument(Api.Service service) {
			XmlDocument d = new XmlDocument();

//			XmlElement systemNode = d.CreateElement("system");
//
			StringBuilder xml = new StringBuilder();
			xml.Append("<system>");

			XmlSerializer serializer = new XmlSerializer(typeof(Services.RoleMapType));
			serializer.Serialize(XmlWriter.Create(xml), service.RoleMap);

			xml.Append("</system>");
			d.LoadXml(xml.ToString());
			
//			// roleMap
//			XmlElement roleMapNode = d.CreateElement("roleMap");
//			DbServiceScope serviceScope = new DbServiceScope();
//			serviceScope.ServiceId = serviceId;
//			DbScope[] scopes = serviceScope.DbFindAllScopesByService();
//			foreach (DbScope scope in scopes) {
//				XmlElement scopeNode = d.CreateElement("scope");
//				scopeNode.SetAttribute("id", Convert.ToString(scope.Id));
//				scopeNode.SetAttribute("base", scope.Base);
//
//				DbShape[] shapes = scope.DbFindAllShapes();
//				foreach (DbShape shape in shapes) {
//					XmlElement shapeNode = d.CreateElement("shape");
//					shapeNode.SetAttribute("select", shape.Select);
//					shapeNode.SetAttribute("type", shape.Type);
//					scopeNode.AppendChild(shapeNode);
//				}
//				roleMapNode.AppendChild(scopeNode);
//			}
//
//			DbRoleTemplate rt = new DbRoleTemplate();
//			rt.ServiceId = serviceId;
//
//			DbRoleTemplate[] roleTemplates = rt.DbFindAllByService();
//			foreach (DbRoleTemplate roleTemplate in roleTemplates) {
//				XmlElement roleTemplateNode = d.CreateElement("roleTemplate");
//				roleTemplateNode.SetAttribute("id", Convert.ToString(roleTemplate.Id));
//				roleTemplateNode.SetAttribute("name", roleTemplate.Name);
//				roleTemplateNode.SetAttribute("priority", Convert.ToString(roleTemplate.Priority));
//
//				DbRoleTemplateMethod[] methods = roleTemplate.DbFindAllRoleTemplateMethodsByRoleTemplate();
//				foreach (DbRoleTemplateMethod roleTemplateMethod in methods) {
//					XmlElement methodNode = d.CreateElement("method");
//					DbMethodType methodType = new DbMethodType();
//					methodType.Id = roleTemplateMethod.MethodTypeId;
//					methodType.DbRead();
//					methodNode.SetAttribute("name", methodType.Name);
//					if (roleTemplateMethod.ScopeId > 0) {
//						methodNode.SetAttribute(
//							"scopeRef", 
//							Convert.ToString(roleTemplateMethod.ScopeId)
//							);
//					}
//					roleTemplateNode.AppendChild(methodNode);
//				}
//				roleMapNode.AppendChild(roleTemplateNode);
//
//			}
//			systemNode.AppendChild(roleMapNode);
//
//			// methodMap
//			// TODO: read service specific methods
//
//			// schemaMap
//			XmlElement schemaMapNode = d.CreateElement("schemaMap");
//
//			DbService service = new DbService();
//			service.Id = serviceId;
//			service.DbRead();
//			XmlDocument xsd = new XmlDocument();
//			xsd.LoadXml(service.Xsd);
//			XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
//			nsmgr.AddNamespace("xdb", "urn:schemas-iquomi-com:xdb");
//			XmlNodeList mappingNodes = xsd.SelectNodes("//xdb:namespaceMap/xdb:mapping", nsmgr);
//			if (mappingNodes != null) {
//				foreach (XmlElement mappingElement in mappingNodes) {
//					XmlElement schemaNode = d.CreateElement("schema");
//					schemaNode.SetAttribute("namespace", mappingElement.GetAttribute("uri"));
//					schemaNode.SetAttribute("schemaLocation", "");
//					schemaNode.SetAttribute("alias", mappingElement.GetAttribute("alias"));
//					schemaMapNode.AppendChild(schemaNode);
//				}
//			}
//			systemNode.AppendChild(schemaMapNode);
//
//			d.AppendChild(systemNode);

			return d;
		}

		private static XmlDocument CreateEventingDocument(Api.Subscription s) {
			/*
			<notifyList>
			 <listener creator="petertheill">
			  <filter>/m:iqProfile</filter>
			  <to>iq:iqEvents</to>
			 </listener>
			</notifyList>
			 */

			log.Debug("Creating \"Eventing\" document");
			XmlDocument d = new XmlDocument();

			XmlElement eventingNode = d.CreateElement("Eventing");

//			DbSubscriptionListener[] listeners = DbSubscriptionListener.DbFindAllBySubscriptionId(s.Id);
//			foreach (DbSubscriptionListener l in listeners) {
//				XmlElement listenerNode = d.CreateElement("listener");
//				
//				DbAccount account = new DbAccount();
//				account.Id = l.AccountId;
//				account = DbAccount.DbRead(account);
//				if (account.Id == 0) {
//					throw new SystemException("Unable to build notifyList document with missing account " + l.AccountId);
//				}
//				
//				string creator = account.Iqid;
//				listenerNode.SetAttribute("creator", creator);
//
//				XmlElement filterNode = d.CreateElement("filter");
//				filterNode.InnerText = l.Filter;
//				listenerNode.AppendChild(filterNode);
//
//				XmlElement toNode = d.CreateElement("to");
//				toNode.InnerText = l.To;
//				listenerNode.AppendChild(toNode);
//
//				eventingNode.AppendChild(listenerNode);
//			}

			d.AppendChild(eventingNode);

			log.Debug("Eventing document created as:\n" + d.OuterXml);

			return d;

// in version current++ we would like a structure like: 
//
//			 <wse xmlns="http://schemas.xmlsoap.org/ws/2004/01/eventing">
//			  <NotifyTo>
//			   <Address>iq:Notify</Address>
//			   <ReferenceProperties>
//				<Subject>
//				 <UserId>1234</UserId>
//				</Subject>
//			   </ReferenceProperties>
//			  </NotifyTo>
//			  <EndTo />
//			  <Expires />
//			  <Filter>/notes</Filter>
//			 </wse>

		}

	}
}