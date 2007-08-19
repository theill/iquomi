<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceUpdatePage" CodeFile="service.update.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="~/ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="~/UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcService" Src="~/ctl/UcService.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    <iq:UcService ID="Service" Runat="server" />
</asp:Content>