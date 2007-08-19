<%@ Page language="c#" Codebehind="calendar.aspx.cs" AutoEventWireup="false" Inherits="myVoices.calendar" %>
<vxml version="1.0" application="services.aspx">
	<form id="form">
		<block>
			<prompt>
				your appointments are:
			</prompt>
			<%=GetResult()%>
			<goto next="services.aspx" />
		</block>
	</form>
</vxml>
