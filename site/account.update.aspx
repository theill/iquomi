<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.AccountUpdatePage" CodeFile="account.update.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<%@ Register TagPrefix="iq" TagName="UcAccountTab" Src="ctl/UcAccountTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcAccount" Src="ctl/UcAccount.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<asp:Content ID="AccountContent" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcAccountTab ID="UcAccountTab" Runat="server" />
	<iq:Notification ID="Notification" runat="server" />
    <iq:UcAccount ID="View" Runat="server" />
</asp:Content>