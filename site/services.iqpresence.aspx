<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicesIqPresencePage" CodeFile="services.iqpresence.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <div id="ContentDescription">
        iqPresence example
    </div>
    
        <asp:Literal runat="server" ID="PresenceInfo" Mode="encode" />
    
</asp:Content>