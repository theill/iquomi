<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="ServiceTab" Src="ctl/UcServiceTab.ascx" %>

<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceMethodsPage" CodeFile="service.methods.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<iq:ServiceTab ID="ServiceTab" runat="server" />
	<div id="ContentDescription">
		List of defined methods for service with ability to create, edit and delete these.
	</div>
	<asp:ScriptManager id="sm" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel id="up" runat="server">
		<contenttemplate>
	<iq:IqGridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">
		<Columns>
			<asp:templatefield>
				<headerstyle cssclass="mark" />
				<itemtemplate>
<asp:Literal id="RowId" runat="server" text='<%# Eval("ServiceMethodId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" />
</itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="Name" sortexpression="ServiceMethodName">
				<headerstyle />
				<itemtemplate><a href="<%# Link("service.method.update.aspx", new object[] { Eval("ServiceId"), Eval("ServiceMethodId") }) %>"><%# Eval("ServiceMethodName") %></a></itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="Arguments" />
			<asp:boundfield headertext="Type" datafield="MethodTypeName" sortexpression="MethodTypeName">
				<headerstyle width="10%" />
			</asp:boundfield>
			<asp:templatefield headertext="Scripted">
				<headerstyle width="10%" />
				<itemtemplate>
<%# (string.IsNullOrEmpty(Eval("Script") as string) ? _("No") : _("Yes")) %>
</itemtemplate>
			</asp:templatefield>
		</Columns>
		<EmptyDataTemplate>
		No service methods associated with this service.
		</EmptyDataTemplate>
	</iq:IqGridView>
</contenttemplate>
	</asp:UpdatePanel>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Commanigy.Iquomi.Data.DbServiceMethod"
		SelectMethod="DbFindAllByService" OnSelecting="ObjectDataSource1_Selecting" OnSelected="ObjectDataSource1_Selected">
		<SelectParameters>
			<asp:Parameter Name="serviceId"></asp:Parameter>
		</SelectParameters>
	</asp:ObjectDataSource>
	<div id="Buttons">
		<asp:Button ID="BtnInsertItem" runat="server" Text="Add Method" CssClass="btn" OnClick="BtnInsertItem_Click" />
		<asp:Button ID="BtnDeleteItem" runat="server" CssClass="btn" Text="Remove Method"
			OnClick="BtnDeleteItem_Click" />
	</div>
</asp:Content>
