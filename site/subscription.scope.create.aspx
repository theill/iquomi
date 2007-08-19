<%@ Register TagPrefix="iq" TagName="UcScope" Src="ctl/UcScope.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionScopeCreatePage" CodeFile="subscription.scope.create.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        Define scopes for your subscription. Scopes are used to define which Xml node sets are
        visible to each authorized user. For example, a scope can define a node set that
        includes all information exposed by the service, only information this is considered
        "public", all information except for node sets that are marked "top-secret", etc.
    </div>
    <iq:UcScope ID="UcScope" Runat="server" />
    <div id="Buttons">
        <asp:button id="BtnCreate" runat="server" text="Create" cssclass="btn" onclick="BtnCreate_Click" />
    </div>
</asp:Content>