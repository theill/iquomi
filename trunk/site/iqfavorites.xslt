<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:m="http://schemas.iquomi.com/2004/01/iqFavorites">
	
	<xsl:template match="/">
		<ul>
			<xsl:apply-templates select="//m:Favorite" />
		</ul>
	</xsl:template>
	
	<xsl:template match="m:Favorite">
		<li>
			<a href="{m:Url/.}" target="_blank"><xsl:value-of select="m:Title/." /></a>
		</li>
	</xsl:template>
	
</xsl:stylesheet>