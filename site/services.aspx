<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Import Namespace="Commanigy.Iquomi.Ui" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>

<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.MyServicesPage" CodeFile="services.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		List service providers own services, state of services together with statistics
		about currently number of active users, aggregated revenue, etc
	</div>
	<iq:IqGridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" DataKeyNames="ServiceId">
		<Columns>
			<asp:imagefield headertext="&#160;" dataimageurlfield="ServiceUrlIcon">
				<headerstyle cssclass="mark" />
				<itemstyle width="16px" />
			</asp:imagefield>
			<asp:templatefield headertext="Name" sortexpression="ServiceName">
				<headerstyle width="30%" />
				<itemtemplate>
<a href="<%# Link("service.read.aspx", new object[] { Eval("ServiceId") }) %>"><%# Eval("ServiceName")%></a>
</itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="State" sortexpression="ServiceState">
				<itemtemplate><%# new State(Convert.ToString(Eval("ServiceState"))).ToString()%></itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="Revenue">
				<itemstyle cssclass="currency" />
				<itemtemplate>829.39 USD</itemtemplate>
			</asp:templatefield>
			<asp:BoundField headertext="Subscribers" datafield="SubscriptionCount" SortExpression="SubscriptionCount">
				<itemstyle cssclass="integer" />
			</asp:BoundField>
			<asp:templatefield headertext="Packages">
				<itemtemplate>v1.0, v1.1, v2.0b</itemtemplate>
			</asp:templatefield>
		</Columns>
	</iq:IqGridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Commanigy.Iquomi.Data.DbService"
		SelectMethod="DbListAllByAuthor">
		<SelectParameters>
			<asp:ProfileParameter Name="authorId" PropertyName="AuthorId" />
			<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>