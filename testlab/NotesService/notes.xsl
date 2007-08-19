<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" indent="yes" encoding="UTF-8" />
	
	<xsl:template match="/">
		<xsl:apply-templates />
	</xsl:template>
	
	<xsl:template match="notes">
		<html>
			<head>
				<title></title>
				<style type="text/css">
					body, table, th, tr, td {
						font-family: Tahoma, Sans-serif;
						font-size: 8pt;
					}
					
					body {
						padding: 0px;
						margin: 0px;
					}
					
					tr {
						;
					}
					
					td {
						padding: 4px;
						vertical-align: top;
					}
					
					a {
						text-decoration: none;
						color: green;
					}
					
					a:hover {
						text-decoration: underline;
					}
					
					span#more {
						font-weight: bold;
						color: red;
					}
					
				</style>
			</head>
			
			<body>
				<xsl:apply-templates select="note" />
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="note">
		<table width="100%">
		<tr>
			<td><a href="iquomi://edit('123')">*</a></td>
			<td width="100%">
				<b><xsl:value-of select="title" /></b><br />
				<xsl:apply-templates select="description" />
			</td>
		</tr>
		</table>
		
	</xsl:template>
	
	<xsl:template match="description">
		
		<xsl:value-of select="substring(., 1, 128)" />
		<xsl:if test="string-length(.) > 128"><span id="more">...</span></xsl:if>
	</xsl:template>
	
</xsl:stylesheet>