<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceIqFavoritesPage" CodeFile="services.iqfavorites.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:Notification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        iqfavorites
    </div>
    <asp:label id="ServiceDescription" runat="server" />
    <asp:xml id="notes" runat="server" />
</asp:Content>