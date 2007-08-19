<%@ Register TagPrefix="iq" TagName="UcShape" Src="ctl/UcShape.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceShapeUpdatePage" CodeFile="service.shape.update.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        Define shapes for this scope. Shapes defines the node set visible through the document
        when operating through this shape element. By using shapes you may limit a scope
        to either include or exclude elements from a returned scope element.
    </div>
    <iq:UcShape ID="UcShape" Runat="server" />
    <div id="Buttons">
        <asp:button id="BtnUpdate" runat="server" text="Update" cssclass="btn" onclick="BtnUpdate_Click" />
    </div>
</asp:Content>