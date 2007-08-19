<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcManage" Src="ctl/UcServiceRoleTemplateDescription.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceRoleTemplateDescriptionCreatePage"
    CodeFile="service.role_template_description.create.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        Define role template description for this service.
    </div>
    <iq:UcManage ID="ServiceRoleTemplateDescription" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" text="OK" cssclass="btn" onclick="btnCreate_Click" />
    </div>
</asp:Content>