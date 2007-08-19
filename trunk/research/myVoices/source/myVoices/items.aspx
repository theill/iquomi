<%@ Page language="c#" Codebehind="items.aspx.cs" AutoEventWireup="false" Inherits="myVoices.items" %>
<vxml version="1.0">
	<form id="form">
		<block>
			<prompt>
				The items in the list are
			</prompt>
			<%=GetResult()%>
			<goto next="services.aspx" />
		</block>
	</form>
</vxml>
