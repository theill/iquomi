<%@ Page language="c#" Codebehind="lists.aspx.cs" AutoEventWireup="false" Inherits="myVoices.lists" %>
<vxml version="1.0">
	<form id="form">
		<field name="list">
			<prompt>
				Choose a list <enumerate />
			</prompt>
			<%=GetResult()%>
			<filled>
				<submit next="items.aspx" method="post" namelist="list" />
			</filled>
		</field>
	</form>
</vxml>
