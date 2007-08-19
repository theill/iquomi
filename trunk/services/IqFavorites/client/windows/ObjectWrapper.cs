﻿#region Using directives

using System;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

#endregion

namespace Commanigy.Iquomi.Services.IqFavorites {

	/// <summary>
	/// 
	/// </summary>
	public abstract class ObjectWrapper {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public static object GetObject(System.Type type, XmlElement e) {
			XmlRootAttribute root = new XmlRootAttribute(e.LocalName);
			root.Namespace = GetNamespace(type);
			XmlSerializer serializer = new XmlSerializer(type, root);
			serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
			serializer.UnknownElement += new XmlElementEventHandler(serializer_UnknownElement);
			XmlNodeReader nr = new XmlNodeReader(e);
			return serializer.Deserialize(nr);
		}

		static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e) {
			if (!EventLog.SourceExists("Sdk")) {
				EventLog.CreateEventSource("Sdk", "Iquomi");
			}

			EventLog.WriteEntry("Sdk", "Unknown attribute. Name: " + e.Attr.Name + " (LocalName:" + e.Attr.LocalName + "): " + e.Attr.Value + ". Namespace: " + e.Attr.NamespaceURI + ". Prefix: " + e.Attr.Prefix + ". BaseURI: " + e.Attr.BaseURI + ". NamespaceURI: " + e.Attr.NamespaceURI);
		}

		static void serializer_UnknownElement(object sender, XmlElementEventArgs e) {
			if (!EventLog.SourceExists("Sdk")) {
				EventLog.CreateEventSource("Sdk", "Iquomi");
			}

			EventLog.WriteEntry("Sdk", "Unknown element: " + e.Element.Name);
		}

		public static object GetObject(System.Type type, XmlElement[] elements) {
			ArrayList list = new ArrayList();
			for (int i = 0; i < elements.Length; i++) {
				list.Add(GetObject(type, elements[i]));
			}
			return list.ToArray(type);
		}

		public static XmlElement SetObject(object o, string elementName) {
			System.Type type = o.GetType();
			XmlRootAttribute root = new XmlRootAttribute(elementName);
			root.Namespace = GetNamespace(type);
			XmlSerializer serializer = new XmlSerializer(type, root);
			//XmlTypeMapping myTypeMapping = new SoapReflectionImporter().ImportTypeMapping(type);
			//XmlSerializer serializer = new XmlSerializer(myTypeMapping);
			StringWriter sw = new StringWriter();
			serializer.Serialize(sw, o);
			XmlDocument d = new XmlDocument();
			d.LoadXml(sw.ToString());
			return d.DocumentElement;
		}

		/// <summary>
		/// Returns namespace for Type. The type must contain an attribute 
		/// of type "XmlTypeAttribute" and the "Namespace" field must be
		/// set. This is the case for proxy classes generated by xsd.exe.
		/// </summary>
		/// <param name="type">Type with an XmlTypeAttribute attribute</param>
		/// <returns>String containing namespace</returns>
		private static string GetNamespace(Type type) {
			object[] cas = type.GetCustomAttributes(typeof(XmlTypeAttribute), false);
			return (cas.Length > 0) ? ((XmlTypeAttribute)cas[0]).Namespace : "";
		}

	}


}
