<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
   <xsl:output omit-xml-declaration="no" method="xml" indent="yes"/>
   
   <xsl:template match="/xsd:schema">
      <xsl:apply-templates select="xsd:element[1]"/>
   </xsl:template>
   
   <xsl:template match="xsd:element">
      <xsl:element name="{@name}">
         <xsl:attribute name="type"><xsl:value-of select="@type" /></xsl:attribute>
         <xsl:apply-templates select="*"/>
      </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:element[@name and @type]">
      <xsl:element name="{@name}">
         <xsl:attribute name="type"><xsl:value-of select="@type" /></xsl:attribute>
         <xsl:apply-templates select="/xsd:schema/xsd:complexType[@name=current()/@type]"/>
      </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:complexType">
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:simpleType">
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:simpleType[@name]">
       <xsl:element name="{@name}">
          <xsl:attribute name="type"><xsl:value-of select="@type" /></xsl:attribute>
          <xsl:apply-templates select="*"/>
       </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:complexContent">
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:simpleContent">
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:sequence">
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:any">
      <xsl:element name="any">
         <xsl:apply-templates select="*"/>
      </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:extension">
      <xsl:apply-templates select="/xsd:schema/xsd:complexType[@name=current()/@base]"/>
      <xsl:apply-templates select="/xsd:schema/xsd:simpleType[@name=current()/@base]"/>
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:restriction">
      <xsl:attribute name="base"><xsl:value-of select="@base" /></xsl:attribute>
      <xsl:apply-templates select="*"/>
   </xsl:template>
   
   <xsl:template match="xsd:enumeration">
      <xsl:element name="enum">
         <xsl:attribute name="value"><xsl:value-of select="@value" /></xsl:attribute>
         <xsl:apply-templates select="*"/>
      </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:attributeGroup">
      <xsl:element name="attributeGroup">
         <xsl:attribute name="ref"><xsl:value-of select="@ref" /></xsl:attribute>
         <xsl:apply-templates select="*"/>
      </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:attribute">
      <xsl:element name="attrib_{@name}">
         <xsl:attribute name="type"><xsl:value-of select="@type" /></xsl:attribute>
         <xsl:apply-templates select="*"/>
      </xsl:element>
   </xsl:template>
   
   <xsl:template match="xsd:annotation"></xsl:template>
   
   <xsl:template match="xsd:documentation"></xsl:template>
   
</xsl:stylesheet>
<!--?xml-stylesheet type="text/xsl" href="skeleton.xsl"?-->
