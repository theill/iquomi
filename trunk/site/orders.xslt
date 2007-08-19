<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/orders">
		Available Orders:
		<div>
		<xsl:apply-templates select="//order" />
		</div>
	</xsl:template>
	
	<xsl:template match="order">
	Id: <xsl:value-of select="@id" /><br />
	<xsl:value-of select="." />
	</xsl:template>

</xsl:stylesheet>