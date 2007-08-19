<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:m="http://schemas.iquomi.com/2004/01/iqRss">
	<xsl:output method="html"/>
	
	<xsl:template match="/">
		<xsl:apply-templates select="//item" />
	</xsl:template>
	
	<xsl:template match="item">
		<h1>
				<xsl:value-of select="title" />
		</h1>
		<xsl:value-of select="description" disable-output-escaping="yes" />
	</xsl:template>
	
</xsl:stylesheet>