<%@ Page language="c#" Codebehind="favorites.aspx.cs" AutoEventWireup="false" Inherits="myVoices.favorites" %>
<vxml version="1.0">
	<form id="form">
		<field name="url">
			<prompt>
				Choose a web site <enumerate />
			</prompt>
			<%=GetResult()%>
			<filled>
				<prompt>
					the url is <value expr="url" />
				</prompt>
				<goto next="services.aspx" />
			</filled>
		</field>
	</form>
</vxml>
