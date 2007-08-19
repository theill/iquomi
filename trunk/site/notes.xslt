<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" />
	
	<xsl:template match="/">
		<p>
			This is your entered notes.
		</p>
		
		<table class="list" cellspacing="0">
		<tr>
			<th>&#160;</th>
			<th>Note</th>
		</tr>
		<xsl:apply-templates select="//note" />
		</table>
	</xsl:template>
	
	<xsl:template match="note">
		<tr>
			<td width="8"><img src="gfx/ico.outlooknotes.gif" border="0" /></td>
			<td>
				<b><a href="#" onclick="prompt('GUID', '{@id}'); return false;"><xsl:value-of select="title" /></a></b><br />
				<nobr>GUID: <xsl:value-of select="@id" /></nobr><br />
				<xsl:value-of select="description" />
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>