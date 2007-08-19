<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceNotesPage" CodeFile="services.notes.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:Notification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        Notes
    </div>
    <asp:label id="serviceDescription" runat="server" />
    <asp:xml id="notes" runat="server" />
</asp:Content>