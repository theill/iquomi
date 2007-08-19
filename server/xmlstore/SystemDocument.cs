#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Security;

using Commanigy.Iquomi.Services;
//using Commanigy.Iquomi.Data;
//using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// Summary description for SystemDocument.
	/// </summary>
	public class SystemDocument : IqDocument {
		private RoleMapType roleMap;

		public static SystemDocument Create(Api.Service service) {
			XmlDocument d = new XmlDocument();

			StringBuilder xml = new StringBuilder();
			xml.Append("<system>");
//			xml.Append(service.RoleMap);
			xml.Append("</system>");
			d.LoadXml(xml.ToString());
			
			XmlElement systemNode = d.DocumentElement;

			// schemaMap
			XmlElement schemaMapNode = d.CreateElement("schemaMap");

			XmlDocument xsd = new XmlDocument();
			if (!string.IsNullOrEmpty(service.Xsd)) {
				xsd.LoadXml(service.Xsd);
			}
			else {
				xsd.Load(service.UrlXsd);
			}
			
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
			nsmgr.AddNamespace("xdb", "urn:schemas-iquomi-com:xdb");
			XmlNodeList mappingNodes = xsd.SelectNodes("//xdb:namespaceMap/xdb:mapping", nsmgr);
			if (mappingNodes != null) {
				foreach (XmlElement mappingElement in mappingNodes) {
					XmlElement schemaNode = d.CreateElement("schema");
					schemaNode.SetAttribute("namespace", mappingElement.GetAttribute("uri"));
					schemaNode.SetAttribute("schemaLocation", "");
					schemaNode.SetAttribute("alias", mappingElement.GetAttribute("alias"));
					schemaMapNode.AppendChild(schemaNode);
				}
			}
			systemNode.AppendChild(schemaMapNode);

			return new SystemDocument(d, service.GetRoleMap());
		}
		
		private SystemDocument(XmlDocument system, RoleMapType roleMap) : base(system) {
			this.roleMap = roleMap ?? new RoleMapType();
		}
		
		/// <summary>
		/// Setup Namespace Manager for handling aliases and referred schemas
		/// from service.
		/// </summary>
		/// <returns></returns>
		public XmlNamespaceManager GetNamespaceManager() {
			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());

			XmlNodeList schemas = this.document.SelectNodes("/system/schemaMap/schema");
			foreach (XmlElement e in schemas) {
				namespaceManager.AddNamespace(e.GetAttribute("alias"), e.GetAttribute("namespace"));
			}

			return namespaceManager;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="roleTemplateRef"></param>
		/// <returns></returns>
		public RoleTemplateType GetRoleTemplate(string roleTemplateRef) {
			foreach (RoleTemplateType rtt in roleMap.RoleTemplate) {
				if (rtt.Name.Equals(roleTemplateRef)) {
					return rtt;
				}
			}
			
			throw new SecurityException("Access denied caused by missing role template.");
			
//			XmlElement rtNode = (XmlElement)this.document.SelectSingleNode("/system/roleMap/roleTemplate[@id='" + id + "']");
//			if (rtNode == null) {
//				throw new Exception("No roleTemplate found for " + id);
//			}
//
//			RoleTemplateType rt = new RoleTemplateType();
//	//			rt.Id = Convert.ToInt32(rtNode.GetAttribute("id"));
//			rt.Name = rtNode.GetAttribute("name");
//			rt.Priority = Convert.ToInt32(rtNode.GetAttribute("priority"));
//			
//			XmlNodeList methods = this.document.SelectNodes("/system/roleMap/roleTemplate[@id='" + id + "']/method");
//			rt.Method = new RoleTemplateTypeMethod[methods.Count];
//			for (int i = 0; i < methods.Count; i++) {
//				XmlElement methodNode = (XmlElement)methods.Item(i);
//				RoleTemplateTypeMethod method = new RoleTemplateTypeMethod();
//				method.Name = methodNode.GetAttribute("name");
//				method.ScopeRef = methodNode.GetAttribute("scopeRef");
//	//				method.MethodTypeId = DbMethodType.GetIdForName(methodNode.GetAttribute("name"));
//	//				method.RoleTemplateId = rt.Id;
//
//				rt.Method[i] = method;
//			}
//			
//			return rt;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="scopeRef"></param>
		/// <returns></returns>
		public ScopeType GetScope(string scopeRef) {
			foreach (RoleMapTypeScope rmts in roleMap.Scope) {
				if (rmts.Id.Equals(scopeRef)) {
					return rmts;
				}
			}
			
			return null;

//			// TODO use XmlSerializer
//			XmlElement n = (XmlElement)this.document.SelectSingleNode("/system/roleMap/scope[@id='" + id + "']");
//			if (n == null) {
//				throw new Exception("No scope found for " + id);
//			}
//
//			ScopeType scope = new ScopeType();
//
//			XmlElement shape = (XmlElement)this.document.SelectSingleNode("/system/roleMap/scope[@id='" + id + "']/shape");
//			scope.Shape = new ShapeType();
//			scope.Shape.Base = "T".Equals(shape.GetAttribute("base")) ? ShapeTypeBase.T : ShapeTypeBase.Nil;
//
//			XmlNodeList includeShapes = shape.SelectNodes("include");
//			scope.Shape.Include = new ShapeAtomType[includeShapes.Count];
//			for (int i = 0; i < scope.Shape.Include.Length; i++) {
//				XmlElement shapeNode = (XmlElement)includeShapes.Item(i);
//				ShapeAtomType shapeAtom = new ShapeAtomType();
//				shapeAtom.Select = shapeNode.GetAttribute("select");
//
//				scope.Shape.Include[i] = shapeAtom;
//			}
//
//			XmlNodeList excludeShapes = shape.SelectNodes("exclude");
//			scope.Shape.Exclude = new ShapeAtomType[excludeShapes.Count];
//			for (int i = 0; i < scope.Shape.Exclude.Length; i++) {
//				XmlElement shapeNode = (XmlElement)excludeShapes.Item(i);
//				ShapeAtomType shapeAtom = new ShapeAtomType();
//				shapeAtom.Select = shapeNode.GetAttribute("select");
//
//				scope.Shape.Exclude[i] = shapeAtom;
//			}
//
//			return scope;
		}

		public ScopeType GetRoleTemplateScope(string roleTemplateRef, string methodTypeName) {
			RoleTemplateType rt = this.GetRoleTemplate(roleTemplateRef);
			
			foreach (RoleTemplateTypeMethod rttm in rt.Method) {
				if (rttm.Name.Equals(methodTypeName)) {
					return this.GetScope(rttm.ScopeRef);
				}
			}

			throw new SecurityException("Access denied caused by missing role template for " + methodTypeName + " method.");
		}

	}
}