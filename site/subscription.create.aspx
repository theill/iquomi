<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>

<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionCreatePage" CodeFile="subscription.create.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		All available services available for subscribing. This include both core and owner
		specific services. Lists name, version, author name, any setup fees, the SLA, link
		for additional (external) resource as well as a detailed service description.
	</div>
	<asp:ScriptManager id="sm" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel id="up" runat="server">
		<contenttemplate>
	<iq:IqGridView ID="GvSubscriptions" runat="server" DataKeyNames="ServiceId" DataSourceID="SqlDataSource1"
		EnableViewState="False">
		<Columns>
			<asp:ImageField DataImageUrlField="ServiceUrlIcon">
				<headerstyle width="16px" cssclass="mark"></headerstyle>
			</asp:ImageField>
			<asp:TemplateField HeaderText="Service" SortExpression="ServiceName">
				<itemtemplate>
                <a href="<%# Link("service.subscribe.aspx", new object[] { Eval("ServiceId") }) %>"><%# Eval("ServiceName") %></a>
					<div class="nfo">
						<%# Eval("ServiceShortDescription")%>
					</div>
</itemtemplate>
				<headerstyle width="60%"></headerstyle>
			</asp:TemplateField>
			<asp:BoundField HeaderText="Version" DataField="ServiceVersion" SortExpression="ServiceVersion">
				<headerstyle width="10%"></headerstyle>
			</asp:BoundField>
			<asp:BoundField HeaderText="Author" DataField="AuthorName" SortExpression="AuthorName">
				<headerstyle width="30%"></headerstyle>
			</asp:BoundField>
			<asp:TemplateField HeaderText="Setup Fee">
				<itemtemplate>
					Free
</itemtemplate>
			</asp:TemplateField>
		</Columns>
	</iq:IqGridView>
</contenttemplate>
	</asp:UpdatePanel>
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="iqListProvisionedServices"
		EnableViewState="False" SelectCommandType="StoredProcedure" ConnectionString="<%$ ConnectionStrings:iquomi %>">
		<SelectParameters>
			<asp:ProfileParameter Type="Int32" DefaultValue="" Name="language_id" PropertyName="LanguageId">
			</asp:ProfileParameter>
		</SelectParameters>
	</asp:SqlDataSource>
</asp:Content>
