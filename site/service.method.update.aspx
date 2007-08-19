<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceMethodUpdatePage" CodeFile="service.method.update.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<%@ Register TagPrefix="iq" TagName="UcServiceMethod" Src="ctl/UcServiceMethod.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    <iq:UcServiceMethod ID="ServiceMethod" Runat="server" />
</asp:Content>