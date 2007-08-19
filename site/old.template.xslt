<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output omit-xml-declaration="yes" />
	
	<xsl:template match="/document">
		<xsl:text disable-output-escaping="yes">
		<![CDATA[<!DOCTYPE html 
			PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
			"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">]]>
		</xsl:text>
		<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
		<head>
			<title>Iquomi</title>
			<meta http-equiv="Content-Language" content="en" />
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
			<link href="/css/xhtml.css" type="text/css" rel="stylesheet" />
			<link href="/css/controls.css" type="text/css" rel="stylesheet" />
			<link href="/css/firefox.css" type="text/css" rel="alternate stylesheet" title="FireFox Version" />
		</head>

		<body>
			
			<xsl:apply-templates select="div[@id='Header']" />
			
			<div id="Page">
				
				<xsl:apply-templates select="div[@id='Menu']" />

				<xsl:apply-templates select="div[@id='Content']" />
				
			</div>

			<xsl:apply-templates select="div[@id='Footer']" />
			
		</body>
		</html>
	</xsl:template>
	
	<xsl:template match="div[@id='Header']">
		<xsl:copy-of select="." />
	</xsl:template>

	<xsl:template match="div[@id='Menu']">
		<xsl:copy-of select="." />
	</xsl:template>
	
	<xsl:template match="div[@id='Content']">
		<xsl:value-of select="." disable-output-escaping="yes" />
		<!--
		<xsl:copy-of select="." />
		-->
	</xsl:template>
	
	<xsl:template match="div[@id='Footer']">
		<xsl:copy-of select="." />
	</xsl:template>
	
</xsl:stylesheet>