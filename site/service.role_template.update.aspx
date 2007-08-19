<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="ServiceRoleManage" Src="ctl/UcServiceRoleTemplate.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceRoleTemplateUpdatePage"
    CodeFile="service.role_template.update.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        define role template for this service. Role templates defines the set of methods
        allowed and the scope for each of these methods.
    </div>
    <iq:ServiceRoleManage ID="ServiceRoleManage" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnUpdate" runat="server" text="Update" cssclass="btn" onclick="btnUpdate_Click" />
        
        <p />
        
        <asp:button id="btnAddDescription" runat="server" cssclass="btn" text="Add Description"
            onclick="btnAddDescription_Click" />
    </div>
    <p />
    <iq:IqGridView ID="GridView1" Runat="server" DataSourceID="ObjectDataSource1" PageSize="<%$ AppSettings:GridView.PageSize %>"
        GridLines="<%$ AppSettings:GridView.GridLines %>">
    <Columns>
        <asp:templatefield><ItemTemplate><asp:Literal id="RowId" runat="server" text='<%# Eval("MethodTypeId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" /></ItemTemplate>
<HeaderStyle CssClass="mark" Width="16px" />
</asp:templatefield>
        <asp:templatefield sortexpression="MethodTypeName" headertext="Method"><ItemTemplate>
<a href='<%# Link("service.role_template_method.update.aspx", new object[] { service.Id, Eval("RoleTemplateId"), Eval("MethodTypeId") }) %>'><%# Eval("MethodTypeName") %></a>
</ItemTemplate>
</asp:templatefield>
        <asp:boundfield headertext="Scope" datafield="ScopeName" sortexpression="ScopeName" />
        <asp:templatefield headertext="Scope Shapes" sortexpression="ScopeBase, ScopeShapesAsString">
				<itemtemplate>
					<%# Eval("ScopeBase")%> (<%# Eval("ScopeShapesAsString") %>)
				</itemtemplate>
			</asp:templatefield>
    </Columns>
    </iq:IqGridView>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Commanigy.Iquomi.Data.DbRoleTemplateMethod"
        selectmethod="DbListAll" onselecting="ObjectDataSource1_Selecting"><SelectParameters>
		<asp:Parameter Name="roleTemplateId" />
		<asp:ProfileParameter Name="languageId" Type="Int32" PropertyName="LanguageId" />
</SelectParameters></asp:objectdatasource>
    <div id="Buttons">
        <asp:button id="btnAddMethod" runat="server" cssclass="btn" text="Add Method" onclick="btnAddMethod_Click"></asp:button>
        <asp:button id="btnDeleteMethod" runat="server" cssclass="btn" text="Delete Method"
            onclick="btnDeleteMethod_Click"></asp:button>
    </div>
</asp:Content>