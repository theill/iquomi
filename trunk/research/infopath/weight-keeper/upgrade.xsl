<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2004-11-19T20:56:25" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" version="1.0">
	<xsl:output encoding="UTF-8" method="xml"/>
	<xsl:template match="text() | *[namespace-uri()='http://www.w3.org/1999/xhtml']" mode="RichText">
		<xsl:copy-of select="."/>
	</xsl:template>
	<xsl:template match="/">
		<xsl:copy-of select="processing-instruction() | comment()"/>
		<xsl:choose>
			<xsl:when test="my:myFields">
				<xsl:apply-templates select="my:myFields" mode="_0"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:variable name="var">
					<xsl:element name="my:myFields"/>
				</xsl:variable>
				<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_0"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="my:myFields" mode="_0">
		<xsl:copy>
			<xsl:element name="my:Date">
				<xsl:copy-of select="my:Date/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:Weight">
				<xsl:copy-of select="my:Weight/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:field1">
				<xsl:copy-of select="my:field1/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:field2">
				<xsl:apply-templates select="my:field2/text() | my:field2/*[namespace-uri()='http://www.w3.org/1999/xhtml']" mode="RichText"/>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>