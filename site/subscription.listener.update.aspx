<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionListener" Src="ctl/UcSubscriptionListener.ascx" %>
<%@ Page Language="C#" Inherits="Commanigy.Iquomi.Web.SubscriptionListenerUpdatePage"
    CodeFile="subscription.listener.update.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        update subscription listener <iq:UcSubscriptionListener ID="UcSubscriptionListener"
            Runat="server" />
        <div id="Buttons">
            <asp:button id="btnUpdate" runat="server" text="Update" cssclass="btn" onclick="btnUpdate_Click" />
        </div>
</asp:Content>