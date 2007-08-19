<%@ Register TagPrefix="iq" TagName="UcSubscriptionRole" Src="ctl/UcSubscriptionRole.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionRoleUpdatePage"
    CodeFile="subscription.role.update.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        The roles are designed to describe who you are willing to share information with.
    </div>
    <iq:UcSubscriptionRole ID="UcSubscriptionRole" Runat="server" />
    <div id="Buttons">
        <asp:button id="BtnUpdate" runat="server" text="Update" cssclass="btn" onclick="BtnUpdate_Click" />
    </div>
</asp:Content>