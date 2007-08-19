<%@ Page language="c#" Codebehind="rolodex.aspx.cs" AutoEventWireup="false" Inherits="myVoices.rolodex" %>
<vxml version="1.0">
	<form id="form">
		<field name="info">
			<prompt>
				Choose a contact<enumerate />
			</prompt>
			<%=GetResult()%>
			<filled>
				<prompt>
					their info is <value expr="info" />
				</prompt>
				<goto next="services.aspx" />
			</filled>
		</field>
	</form>
</vxml>
