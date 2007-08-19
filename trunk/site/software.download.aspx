<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SoftwareDownloadPage" CodeFile="software.download.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		List of software releases you are able to download either because you're subscribed
		to a service providing this or because it's a core Iquomi client.
	</div>
	<iq:IqGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
		AutoGenerateColumns="False" EnableViewState="False" GridLines="None"
		PageSize="15">
		<Columns>
			<asp:imagefield>
				<itemstyle width="16px" />
				<headerstyle cssclass="mark" />
			</asp:imagefield>
			<asp:HyperLinkField DataNavigateUrlFields="Name" DataTextField="Name" HeaderText="Filename"
				SortExpression="Name" DataNavigateUrlFormatString="~/files/{0}" />
			<asp:BoundField DataField="Platform" HeaderText="Platform" SortExpression="Platform" />
			<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
			<asp:BoundField DataField="LastWriteTimeUtc" HeaderText="Last modified" SortExpression="LastWriteTimeUtc" />
		</Columns>
		<PagerStyle CssClass="pager" />
	</iq:IqGridView>
</asp:Content>
