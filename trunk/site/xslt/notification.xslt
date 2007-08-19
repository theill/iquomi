<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	
	<xsl:template match="messages">
		<ul>
			<xsl:apply-templates select="message" />
		</ul>
	</xsl:template>
	
	<xsl:template match="message">
		<li>
			<xsl:value-of select="." />
		</li>
	</xsl:template>

</xsl:stylesheet>