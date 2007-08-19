<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" encoding="UTF-8"/>

	<xsl:template match="/">
		<html>
		<head>
			<title></title>
			<style type="text/css">
			<![CDATA[
			    
				body {
					font: small-caption;
					background-color: buttonface;
				}
				
				input.full, textarea.full {
					font: message-box;
					width: 100%;
				}
				
				textarea {
					height: 64px;
				}
				
				input.btn {
					font: message-box;
					width: 64px;
				}
				
				div {
					;
				}
				
			]]>
			</style>
			
			<script type="text/jscript">
			<![CDATA[
				
				function formatXml(frm) {
					
					var obj = new ActiveXObject("MSXML2.DOMDocument.3.0");
					obj.load("note.xml");
					alert(obj.xml);
					
					for (var i = 0; i < frm.elements.length; i++) {
						var e = frm.elements[i];
						alert("xpath = " + e.name);
						var nl = obj.selectNodes(e.name);
						if (nl && nl.length == 1) {
							alert("inserting " + e.value);
							nl[0].appendChild(obj.createTextNode(e.value));
						}
					}
					
					alert(obj.xml);
				}
				
			]]>
			</script>
		</head>
		
		<body>
		
		<form method="post" onsubmit="formatXml(this); return false;">
			
			<xsl:apply-templates />
			
			<div style="position: absolute; bottom: 8px; right: 8px;">
				<input type="submit" name="submit" value=" OK " class="btn" /><xsl:text> </xsl:text>
				<input type="reset" name="reset" value=" Cancel " class="btn" />
			</div>
		</form>
		
		</body>
		</html>
	</xsl:template>
	
	<xsl:template match="string">
		<div><xsl:value-of select="@title" /></div>
		<input type="text" name="{concat('//service/list/string[@name=&quot;', @name, '&quot;]')}" value="{.}" class="full" />
	</xsl:template>

	<xsl:template match="string[@size>'1024']">
		<div><xsl:value-of select="@title" /></div>
		<textarea name="{concat('//service/list/string[@name=&quot;', @name, '&quot;]')}" class="full"><xsl:value-of select="." /></textarea>
	</xsl:template>

</xsl:stylesheet>