<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="~/ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="~/UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcService" Src="~/ctl/UcService.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicePage" CodeFile="service.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" Visible="False" EnableViewState="false" />
    <iq:UcService ID="Service" Runat="server" />
</asp:Content>