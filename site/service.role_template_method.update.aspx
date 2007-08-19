<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="ServiceRoleTemplateMethodManage" Src="ctl/UcServiceRoleTemplateMethod.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceRoleTemplateMethodUpdatePage"
    CodeFile="service.role_template_method.update.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        Define methods available for this role template. Methods determines allowed actions
        for the role and allows you setup any kind of access such as full access, read only
        access, no access, etc.
    </div>
    <iq:ServiceRoleTemplateMethodManage ID="ServiceRoleTemplateMethodManage" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnUpdate" runat="server" text="Update" cssclass="btn" onclick="btnUpdate_Click"></asp:button>
    </div>
</asp:Content>