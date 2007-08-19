<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionRole" Src="ctl/UcSubscriptionRole.ascx" %>
<%@ Page Language="C#" Inherits="Commanigy.Iquomi.Web.SubscriptionRoleCreatePage"
    CodeFile="subscription.role.create.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        The roles are designed to describe who you are willing to share information with
        and how much.
    </div>
    <iq:UcSubscriptionRole ID="UcSubscriptionRole" Runat="server" />
    <div id="Buttons">
        <asp:button id="BtnCreate" runat="server" text="Create" cssclass="btn" onclick="BtnCreate_Click" />
    </div>
</asp:Content>