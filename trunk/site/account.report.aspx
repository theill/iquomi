<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.AccountReportPage" CodeFile="account.report.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<asp:Content ID="Content" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		Displays method history across services, platforms and applications.
	</div>
	<asp:ScriptManager id="sm" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel id="UpdatePanel1" runat="server">
		<contenttemplate>
		<iq:IqGridView ID="GridView" runat="server" DataSourceID="ObjectDataSource1">
			<Columns>
				<asp:imagefield dataimageurlfield="ServiceUrlIcon" sortexpression="ServiceUrlIcon">
					<itemstyle width="16px" />
					<headerstyle cssclass="mark" />
				</asp:imagefield>
				<asp:boundfield headertext="Timestamp" datafield="MethodHistoryTimestamp" sortexpression="MethodHistoryTimestamp"
					dataformatstring="{0:u}">
					<itemstyle wrap="False" />
					<headerstyle width="10%" />
				</asp:boundfield>
				<asp:boundfield headertext="Subscription" datafield="SubscriptionName" sortexpression="SubscriptionName" />
				<asp:templatefield sortexpression="ServiceName" headertext="Service">
					<headerstyle width="30%" />
					<itemtemplate>
<asp:HyperLink id="HyperLink1" runat="server" Text='<%# Eval("ServiceName") + " " + Eval("ServiceVersion") %>' NavigateUrl='<%# Link("account.report.service.aspx", new object[] { Eval("ServiceId") }) %>'></asp:HyperLink><br /><asp:Label id=Label2 runat="server" Text='<%# Eval("ServiceShortDescription") %>'></asp:Label>
</itemtemplate>
				</asp:templatefield>
				<asp:boundfield headertext="Method" datafield="MethodHistoryMethod" sortexpression="MethodHistoryMethod">
					<headerstyle width="15%"></headerstyle>
				</asp:boundfield>
				<asp:boundfield headertext="Account" datafield="AccountIqid" sortexpression="AccountIqid">
					<headerstyle width="25%" />
				</asp:boundfield>
				<asp:boundfield headertext="Host address" datafield="MethodHistoryUserHostAddress"
					sortexpression="MethodHistoryUserHostAddress">
					<headerstyle width="20%"></headerstyle>
				</asp:boundfield>
			</Columns>
			<PagerStyle CssClass="Pager" />
		</iq:IqGridView>
</contenttemplate>
	</asp:UpdatePanel>
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Commanigy.Iquomi.Data.DbMethodHistory"
			SelectMethod="DbFindAll" EnableViewState="False">
			<selectparameters>
			<asp:ProfileParameter Name="accountId" PropertyName="AccountId" />
			<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" />
		</selectparameters>
		</asp:ObjectDataSource>
</asp:Content>
