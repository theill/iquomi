<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="ServiceRoleTemplateMethodManage" Src="ctl/UcServiceRoleTemplateMethod.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceRoleTemplateMethodCreatePage"
    CodeFile="service.role_template_method.create.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        Define methods available for this role template. Methods determines allowed actions
        for the role and allows you setup any kind of access such as full access, read only
        access, no access, etc.
    </div>
    <iq:ServiceRoleTemplateMethodManage ID="ServiceRoleTemplateMethodManage" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" text="OK" cssclass="btn" onclick="btnCreate_Click" />
    </div>
</asp:Content>