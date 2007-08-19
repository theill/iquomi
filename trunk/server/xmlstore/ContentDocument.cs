#region Using directives

using System;
using System.Xml;
using System.Xml.XPath;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// Summary description for ContentDocument.
	/// </summary>
	public class ContentDocument : IqDocument {

		string volatileChangeNumber = string.Empty;
		public string VolatileChangeNumber {
			get {
				if (volatileChangeNumber == string.Empty) {
					volatileChangeNumber = Convert.ToString(Convert.ToUInt64(this.ChangeNumber) + 1);
				}
				
				return volatileChangeNumber;
			}
		}
		
		public static ContentDocument Create(Api.Subscription s) {
			ContentDocument d = new ContentDocument(s.GetXmlDocument());
			
			// standard Iquomi services contains 'InstanceId' and 'ChangeNumber' 
			// attributes to support caching and distribution - similar features
			// are not able to generic services thus we need fallback for these
			// kind of services

			if (d.InstanceId == Guid.Empty) {
				d.InstanceId = s.Id;
			}

			if (d.ChangeNumber == null) {
				d.ChangeNumber = "1";
			}

			return d;
		}

		private ContentDocument(XmlDocument content) : base(content) {

		}

		public XmlNodeList SelectNodes(string xpath, XmlNamespaceManager nsmgr) {
			return document.SelectNodes(xpath, nsmgr);
		}

		public XPathNodeIterator SelectNodes(string xpath, XmlNamespaceManager nsmgr, SortType[] sorting) {
			XPathNavigator nav = document.CreateNavigator();

			XPathExpression expr = nav.Compile(xpath);
			expr.SetContext(nsmgr);
			if (sorting != null) {
				for (int i = 0; i < sorting.Length; i++) {
					XPathExpression sortExpression = XPathExpression.Compile(sorting[i].Key);
					sortExpression.SetContext(nsmgr);

					expr.AddSort(
						sortExpression,
						(sorting[i].Direction == SortTypeDirection.Ascending) ? XmlSortOrder.Ascending : XmlSortOrder.Descending,
						XmlCaseOrder.None,
						"",
						XmlDataType.Text
						);
				}
			}

			return nav.Select(expr);
		}

		public XmlNode ImportNode(XmlNode node, bool deep) {
			return document.ImportNode(node, deep);
		}

		public void BeginEdit() {

		}

		public void AcceptChanges() {
			// TODO validate xml up against schema specified on service to
			// ensure we are storing a valid xml document into our database
			// XmlValidatingReader r = new XmlValidatingReader(new XmlTextReader(xml, XmlNodeType.Document, null));
			// r.ValidationType = ValidationType.Schema;
			// doc.Load(r);
		}
	}
}