<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SearchPage" CodeFile="search.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <div id="ContentDescription">
		searches across services. search in 'services' with link to subscription 
		if available, search in 'packages' (package items) with link to subscription
		if avalable.
		<br />
		<br />
		Search for items containing:<br />
		<asp:TextBox ID="TbxQuery" runat="server" CssClass="Text" style="width: 320px"/>
		<asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="Search" CssClass="Button" /></div>
    
    <div>
		<asp:Label id="LblQuery" runat="server" />
	</div>
	
	<p />

	<iq:IqGridView ID="SearchView" runat="server" DataSourceID="DsQuerySubscriptions"
		DataKeyNames="SubscriptionId" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="List" EnableViewState="False" GridLines="None" PageSize="15">
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
			<asp:templatefield sortexpression="Rank" headertext="Rank" >
				<headerstyle width="100px" />
				<itemtemplate>
<div class="RankBar" style='width: <%# Math.Round(Convert.ToInt32(Eval("Rank")) / 10.0) %>%;' title='<%# Eval("Rank") %>'><img src="gfx/dot.gif" width="1" height="1" /></div>
</itemtemplate>
			</asp:templatefield>
		</Columns>
		<PagerStyle CssClass="Pager" />
	</iq:IqGridView>
	<br />
	<asp:ObjectDataSource ID="DsQuerySubscriptions" runat="server" TypeName="Commanigy.Iquomi.Data.DbSubscription"
		SelectMethod="DbQueryAll" OnSelected="DsSubscriptions_Selected" OnSelecting="DsQuerySubscriptions_Selecting">
		<SelectParameters>
			<asp:ProfileParameter Name="accountId" Type="Int32" PropertyName="AccountId" />
			<asp:ProfileParameter Name="languageId" Type="Int32" PropertyName="LanguageId" />
			<asp:ControlParameter ControlID="TbxQuery" Type="string" Name="query" />
		</SelectParameters>
	</asp:ObjectDataSource>

</asp:Content>