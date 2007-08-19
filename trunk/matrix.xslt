<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:xdb="urn:schemas-microsoft-com:xdb">
	<xsl:template match="/">
		<font color="#0000ff"><xsl:for-each select="//xdb:blue">
			<xsl:value-of select="@select" /><br/>
		</xsl:for-each></font>
		<font color="#ff0000"><xsl:for-each select="//xdb:red">
			<xsl:value-of select="@select" /><br/>
		</xsl:for-each></font>
	</xsl:template>
</xsl:stylesheet>
<!--?xml-stylesheet type="text/xsl" href="xpath.xsl"?-->
