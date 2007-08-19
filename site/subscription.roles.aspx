<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionRolesPage" CodeFile="subscription.roles.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<iq:UcSubscriptionTab ID="UcSubscriptionTab" runat="server" />
	<div id="ContentDescription">
		define access level for your subscription i.e. who is able to access your data,
		how much are they able to access and in which period of time.
	</div>
	<iq:IqGridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" OnSorted="GridView1_Sorted"
		OnRowCreated="GridView1_RowCreated">
		<Columns>
			<asp:templatefield headertext="&#160;">
				<headerstyle cssclass="mark" />
				<itemtemplate><asp:Literal id="RowId" runat="server" text='<%# Eval("RoleId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" /></itemtemplate>
				<itemstyle width="1px" />
			</asp:templatefield>
			<asp:templatefield headertext="Subject" sortexpression="Iqid">
				<itemtemplate><a href="<%# Link("subscription.role.update.aspx", new object[] { Eval("SubscriptionId"), Eval("RoleId") }) %>"><%# Eval("Iqid") %></a></itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="Role Template" sortexpression="RoleTemplateName">
				<itemtemplate>
				<%# String.Format("{1}", Eval("RoleTemplateDescription"), Eval("RoleTemplateName")) %>
			</itemtemplate>
			</asp:templatefield>
			<asp:boundfield headertext="Active From" datafield="ActiveFrom" sortexpression="ActiveFrom" />
			<asp:boundfield headertext="Active To" datafield="ActiveTo" sortexpression="ActiveTo" />
		</Columns>
	</iq:IqGridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Commanigy.Iquomi.Data.DbSubscription"
		SelectMethod="DbGetRoles" OnSelecting="ObjectDataSource1_Selecting" OnSelected="ObjectDataSource1_Selected">
		<SelectParameters>
			<asp:Parameter Name="subscriptionId" />
			<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<div id="Buttons">
		<asp:Button ID="BtnAddItem" runat="server" Text="Add Role" CssClass="btn" OnClick="BtnAddItem_Click" />
		<asp:Button ID="BtnDeleteItem" runat="server" Text="Delete Role" CssClass="btn" OnClick="BtnDeleteItem_Click" />
	</div>
</asp:Content>
