<%@ Page language="c#" %>
<%@ Import namespace="System.Xml" %>
<%@ Import namespace="System.Xml.Schema" %>
<%@ Import namespace="System.IO" %>

<html>
<head>
</head>

<body>
<object id="HelloWorldControl1" classid="http:InternetExplorer.dll#InternetExplorer.Presence" height="320" width="500" VIEWASTEXT></object>
<%
	
	string xml = @"
<m:iqFavorites xmlns:m=""urn:favorites"" xmlns:iq=""urn:common"">
  <m:favorite>
    <m:group ref=""urn:private"" />
    <m:title>Free Images - Free Stock Photos2</m:title>
    <m:url>http://www.freeimages.co.uk/</m:url>
  </m:favorite>
</m:iqFavorites>	
	";
	
	string xsd = @"
<xsd:schema xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:iq=""http://schemas.iquomi.com/2004/01/core"" targetNamespace=""urn:favorites"" xmlns=""urn:favorites"" elementFormDefault=""qualified"" version=""1.0"">
  <xsd:import namespace=""http://schemas.iquomi.com/2004/01/core"" schemaLocation=""http://schemas.iquomi.com/2004/01/core/iqcommon.xsd"" />
  <xsd:element name=""iqFavorites"">
    <xsd:complexType>
      <xsd:complexContent>
        <xsd:extension base=""iqFavoritesType"" />
      </xsd:complexContent>
    </xsd:complexType>
  </xsd:element>

  <xsd:complexType name=""iqFavoritesType"">
    <xsd:sequence>
      <xsd:element name=""favorite"" type=""favoriteType"" minOccurs=""0"" maxOccurs=""unbounded"" />
    </xsd:sequence>
  </xsd:complexType>
  
  <xsd:complexType name=""favoriteType"">
    <xsd:sequence>
      <xsd:any processContents=""skip"" namespace=""##other"" minOccurs=""0"" maxOccurs=""unbounded"" />
      <xsd:element name=""group"" type=""iq:catType"" minOccurs=""1"" maxOccurs=""unbounded"" />
      <xsd:element name=""title"" type=""xsd:string"" minOccurs=""0"" maxOccurs=""unbounded"" />
      <xsd:element name=""url"" type=""xsd:anyURI"" minOccurs=""1"" maxOccurs=""1"" />
    </xsd:sequence>
  </xsd:complexType>
  
</xsd:schema>
	";

	/*
	StringReader reader = new StringReader(xsd);
	System.Xml.Schema.XmlSchema schema = XmlSchema.Read(
		reader,
		null
		);
	schema.Compile(null);

	XmlValidatingReader rdr = new XmlValidatingReader(xml, XmlNodeType.Element, null);
	rdr.ValidationType = ValidationType.Schema;
	rdr.Schemas.Add(schema);

	try {
		while (rdr.Read()) {
			;
		}
	}
	catch (Exception e) {
		Response.Write(e.Message);
	}
	*/
	
%>
</body>
</html>