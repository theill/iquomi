<%@ Page language="c#" Codebehind="services.aspx.cs" AutoEventWireup="false" Inherits="myVoices.services" %>
<vxml version="1.0">
	<var name="puid" type="number" expr="<%=GetPuidApp()%>"/>
	<menu>
		<prompt>
			Choose.
			<enumerate />
		</prompt>
		<choice dtmf="1" next="favorites.aspx">
			Favorites</choice>
		<choice dtmf="2" next="lists.aspx">
			Lists</choice>
		<choice dtmf="3" next="contacts.aspx">
			Contacts</choice>
		<choice dtmf="4" next="calendar.aspx">
			Calendar</choice>
		<choice dtmf="5" next="inbox.aspx">
			Inbox</choice>
		<noinput>
			No input, Choose.
			<enumerate />
		</noinput>
		<nomatch>
			No match, Choose.
			<enumerate />
		</nomatch>
		<help>
			Help, Choose.
			<enumerate />
		</help>
	</menu>
</vxml>
