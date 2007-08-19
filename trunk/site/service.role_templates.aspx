<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceRoleTemplatesPage"
    CodeFile="service.role_templates.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <div id="ContentDescription">
        defining templates for setting up roles providing access to this service.
    </div>
    <iq:IqGridView ID="GridView1" Runat="server" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:templatefield><ItemTemplate><asp:Literal id="RowId" runat="server" text='<%# Eval("RoleTemplateId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" /></ItemTemplate>
<HeaderStyle CssClass="mark" />
</asp:templatefield>
        <asp:templatefield headertext="Name" sortexpression="RoleTemplateName"><HeaderStyle Width="30%" /><ItemTemplate>
<a href="<%# Link("service.role_template.update.aspx", new object[] { service.Id, Eval("RoleTemplateId") }) %>"><%# Eval("RoleTemplateName")%></a>
</ItemTemplate>
</asp:templatefield>
        <asp:boundfield headertext="Priority" datafield="RoleTemplatePriority" sortexpression="RoleTemplatePriority"><HeaderStyle Width="20%" /></asp:boundfield>
        <asp:boundfield headertext="Method types" datafield="MethodsAsString" htmlencode="False"><HeaderStyle Width="50%" /></asp:boundfield>
    </Columns>
    </iq:IqGridView>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Commanigy.Iquomi.Data.DbRoleTemplate"
        selectmethod="DbListAllRoleTemplatesByService" onselecting="ObjectDataSource1_Selecting"><SelectParameters>
<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" />
</SelectParameters>
		</asp:objectdatasource>
    <div id="Buttons">
        <asp:button id="AddRoleButton" runat="server" text="Add Role Template" cssclass="btn"
            onclick="AddRoleButton_Click" /><asp:button id="DeleteRoleButton" runat="server"
                text="Delete Role Template" cssclass="btn" onclick="DeleteRoleButton_Click" />
    </div>
</asp:Content>