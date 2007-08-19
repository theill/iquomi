<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcShape" Src="ctl/UcShape.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionShapeCreatePage" CodeFile="subscription.shape.create.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="SubscriptionTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        Define shapes for this scope. Shapes defines the node set visible through the document
        when operating through this shape element. By using shapes you may limit a scope
        to either include or exclude elements from a returned scope element.
    </div>
    <iq:UcShape ID="UcShape" Runat="server" />
    <div id="Buttons">
        <asp:button id="BtnCreate" runat="server" text="Create" cssclass="btn" onclick="BtnCreate_Click" />
    </div>
</asp:Content>