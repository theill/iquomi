<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	
	<xsl:template match="/">
		Your bookmarks
		<ul>
			<xsl:apply-templates select="/*/folder" />
		</ul>
	</xsl:template>
	
	<xsl:template match="folder">
		<li style="list-style-image: url(gfx/ico.folder_open.gif)">
			<xsl:value-of select="title" />
		</li>
		<ul style="margin-left: 16px">
			<xsl:apply-templates select="bookmark" />
			<xsl:apply-templates select="folder" />
		</ul>
	</xsl:template>

	<xsl:template match="bookmark">
		<li style="list-style-image: url(gfx/ico.iebookmark.gif)">
			<a href="{@href}" style="text-decoration: none" target="_blank"><xsl:value-of select="./title" /></a>
		</li>
	</xsl:template>

</xsl:stylesheet>