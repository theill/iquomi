<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
	CodeFile="beta.subscribe.aspx.cs" Inherits="Commanigy.Iquomi.Web.BetaSubscribePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="NoFormContentPlaceHolder" runat="Server">
	<div id="ContentDescription">
		It's now possible to purchase access to Iquomi. The website, webservices, plugins,
		extensions and services are currently in beta and may change at any time. You may
		use this subscription to subscribe and manage existing services such as iqProfile,
		iqContacts, iqAlerts and iqFavorites.
		<p />
		To purchase your access you may use PayPal or credit-card. Click the button below
		to continue.
	</div>
	<form action="https://www.paypal.com/cgi-bin/webscr" method="post">
		<input type="hidden" name="cmd" value="_s-xclick">
		<input type="image" src="https://www.paypal.com/en_US/i/btn/x-click-but20.gif" border="0"
			name="submit" alt="Make payments with PayPal - it's fast, free and secure!">
		<input type="hidden" name="encrypted" value="-----BEGIN PKCS7-----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-----END PKCS7-----
">
	</form>
	<p>
	</p>
	You will receive an email with setup information once we have registered your purchase.
</asp:Content>
