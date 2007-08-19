<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="ServiceRoleManage" Src="ctl/UcServiceRoleTemplate.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceRoleTemplateCreatePage"
    CodeFile="service.role_template.create.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        Define role template for service.
    </div>
    <iq:ServiceRoleManage ID="ServiceRoleManage" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" text="OK" cssclass="btn" onclick="btnCreate_Click"></asp:button>
    </div>
</asp:Content>