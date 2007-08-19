<%@ Page Language="c#" MasterPageFile="~/MasterPage.master" Inherits="Commanigy.Iquomi.Web.AccountPage" CodeFile="~/account.aspx.cs" %>
<%@ Import namespace="Commanigy.Iquomi.Data" %>
<asp:Content id="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		Manage your account by setting up name, address, credit cards, default
		notification delivery locations, see account balance, refill account
		balance, close account, change newsletter subscriptions, etc.
	</div>
	
	<p>Account</p>
	<ul>
		<li><a href="account.update.aspx">Update Account</a></li><li><a href="account.close.aspx">Close Account</a></li></ul>
	
	<p>Financial</p>
	<ul>
		<li>Credit Cards</li><li>Monthly Account Statements</li></ul>
	
	<p>Reports</p>
	<ul>
		<li>View monthly report</li></ul>
	
	<p>Preferences</p>
	<ul>
		<li>Notifications</li>
	</ul>
	
	<p>Application ID</p>
	<ul>
		<li style="font-family: Monospace;"><asp:Literal ID="ApplicationID" runat="server" /></li>
	</ul>
	
</asp:Content>