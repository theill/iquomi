<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicesIqAlertsPage" CodeFile="services.iqalerts.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:Notification ID="Notification" Runat="server" />
    <div id="ContentDescription">
		iqAlerts<br />
		<br />
        send an alert to a given user.
    </div>
    <div class="Form">
        User:<br />
        <asp:textbox id="TbxUserId" runat="server"></asp:textbox>
        <br />
        <br />
        Message:<br />
        <asp:textbox id="TbxMessage" runat="server" textmode="MultiLine"></asp:textbox>
		<br />
		<br />
		<asp:DropDownList ID="DdlContentType" runat="server">
			<asp:ListItem>http://schemas.iquomi.com/2004/01/iqAlerts/HumanReadableArgot.xsd</asp:ListItem>
			<asp:ListItem>http://schemas.iquomi.com/2004/01/iqAlerts/MsnMessengerArgot.xsd</asp:ListItem>
		</asp:DropDownList><br />
        <br />
        <asp:button id="BtnSubmitAlert" runat="server" text="Submit Alert" onclick="BtnSubmitAlert_Click"></asp:button>
    </div>
</asp:Content>