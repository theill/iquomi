<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subscriptions.aspx.cs" Inherits="subscriptions" %>

<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
	<mobile:Form ID="FrmSubscriptions" Runat="server" Title="Subscriptions">
		<mobile:ObjectList ID="ObjectList1" Runat="server" CommandStyle-StyleReference="subcommand"
			DataSource="<%# DsSubscriptions %>" LabelStyle-StyleReference="title">
		</mobile:ObjectList>
		<hr />
		<a href="signout.aspx">Sign out</a>
		<div>Copyright(C) 2006 Iquomi </div>
	</mobile:Form>
	<asp:objectdatasource id="DsSubscriptions" runat="server" typename="Commanigy.Iquomi.Data.DbSubscription"
		selectmethod="DbListAllByAccount" oldvaluesparameterformatstring="original_{0}"><SelectParameters>
<asp:ProfileParameter PropertyName="AccountId" Type="Int32" Name="accountId"></asp:ProfileParameter>
<asp:ProfileParameter PropertyName="LanguageId" Type="Int32" Name="languageId"></asp:ProfileParameter>
</SelectParameters>
</asp:objectdatasource>
</body>
</html>
