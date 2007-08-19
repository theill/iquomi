<xsl:stylesheet 
	version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:m="http://schemas.iquomi.com/2004/01/iqProfile">
	
	<xsl:template match="/m:IqProfile">
		<h1>Profile</h1>
		<xsl:apply-templates select="*" />
	</xsl:template>
	
	<xsl:template match="m:Name">
		<fieldset>
			<legend>Name</legend>
			<xsl:value-of select="concat(./m:GivenName, ' ', ./m:SurName)" />
		</fieldset>
	</xsl:template>
	
	<xsl:template match="m:EmailAddress">
		<fieldset>
			<legend>Email address</legend>
			<xsl:value-of select="./m:Name" />: <xsl:value-of select="./m:Email" />
		</fieldset>
	</xsl:template>
	
</xsl:stylesheet>