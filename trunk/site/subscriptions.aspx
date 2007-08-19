<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>

<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionsPage" CodeFile="subscriptions.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="PageContent" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		Lists all my subscriptions showing details about expiration date, version, if a
		newer version is available for download, last modification date, if not free service,
		showing the aggregated cost.
	</div>
	<iq:IqGridView ID="SubscriptionsView" runat="server" DataSourceID="DsSubscriptions"
		DataKeyNames="SubscriptionId">
		<Columns>
			<asp:imagefield dataimageurlfield="ServiceUrlIcon" sortexpression="ServiceUrlIcon">
				<itemstyle width="16px" />
				<headerstyle cssclass="mark" />
			</asp:imagefield>
			<asp:templatefield sortexpression="SubscriptionName" headertext="Name">
				<itemtemplate>
<a href="<%# Link("subscription.read.aspx", new object[] { Eval("SubscriptionId"), Eval("ServiceId") }) %>" title='<%# Eval("ServiceShortDescription") %>'><%# Eval("SubscriptionName") %></a>
</itemtemplate>
			</asp:templatefield>
			<asp:boundfield headertext="Service" datafield="ServiceName" sortexpression="ServiceName" />
			<asp:boundfield headertext="Version" datafield="ServiceVersion" sortexpression="ServiceVersion" />
			<asp:boundfield headertext="Author" datafield="AuthorName" sortexpression="AuthorName" />
		</Columns>
	</iq:IqGridView>
	<asp:ObjectDataSource ID="DsSubscriptions" runat="server" TypeName="Commanigy.Iquomi.Data.DbSubscription"
		SelectMethod="DbListAllByAccount">
		<SelectParameters>
			<asp:ProfileParameter Name="accountId" Type="Int32" PropertyName="AccountId" />
			<asp:ProfileParameter Name="languageId" Type="Int32" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>
