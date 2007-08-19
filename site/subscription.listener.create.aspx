<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionListener" Src="ctl/UcSubscriptionListener.ascx" %>
<%@ Page Language="C#" Inherits="Commanigy.Iquomi.Web.SubscriptionListenerCreatePage"
    CodeFile="subscription.listener.create.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />&nbsp;
    <iq:UcNotification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        setup new subscription listener for a specific user. the listener might be a remote
        user by having a context uri pointing to a remote server.</div>
    <iq:UcSubscriptionListener ID="UcSubscriptionListener" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" text="Create" cssclass="btn" onclick="btnCreate_Click" />
    </div>
</asp:Content>