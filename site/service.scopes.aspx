<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceScopesPage" CodeFile="service.scopes.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<iq:UcServiceTab ID="ServiceTab" runat="server" />
	<div id="ContentDescription">
        Defined scopes for your service.
    </div>
	<iq:IqGridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">
		<Columns>
			<asp:templatefield headertext="&#160;">
				<headerstyle cssclass="mark" />
				<itemtemplate>
				<asp:Literal id="RowId" runat="server" text='<%# Eval("ScopeId") %>' visible="false" />
				<asp:CheckBox id="RowChecked" runat="server" />
			</itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="Name" sortexpression="ScopeName">
				<itemtemplate>
<a href="<%# Link("service.scope.update.aspx", new object[] { Eval("ServiceId"), Eval("ScopeId") }) %>"><%# Eval("ScopeName") %></a>
</itemtemplate>
			</asp:templatefield>
			<asp:boundfield headertext="Base" datafield="ScopeBase" sortexpression="ScopeBase" />
			<asp:boundfield headertext="Shapes" datafield="ShapesAsString" sortexpression="ShapesAsString"
				htmlencode="false" />
		</Columns>
	</iq:IqGridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Commanigy.Iquomi.Data.DbServiceScope"
		SelectMethod="DbListAllScopesByService" OnSelecting="ObjectDataSource1_Selecting">
		<SelectParameters>
			<asp:Parameter Type="Int32" Name="serviceId" />
			<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<div id="Buttons">
        <asp:button id="BtnAddScope" runat="server" text="Add Scope" cssclass="btn" onclick="BtnAddScope_Click" />
        <asp:button id="BtnDeleteScope" runat="server" text="Delete Scope" cssclass="btn"
            onclick="BtnDeleteScope_Click" />
    </div>
</asp:Content>
