<%@ Page Language="c#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Commanigy.Iquomi.Web.Mobile.DefaultPage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
	<mobile:Form ID="FrmSignIn" Title="Iquomi Mobile" Runat="server">
		<mobile:Panel ID="StatusPanel" Runat="server" Visible="False" EnableViewState="False">
			<mobile:Label ID="LblStatus" Runat="server">
			</mobile:Label>
		</mobile:Panel>
		<mobile:ValidationSummary ID="ValidationSummary" Runat="server" FormToValidate="FrmSignIn" />
		<mobile:RequiredFieldValidator ID="RfvEmailAddress" Runat="server" Display="None"
			ControlToValidate="TbxUsername" ErrorMessage="You must enter a username">
		</mobile:RequiredFieldValidator>
		<mobile:RequiredFieldValidator ID="RfvPassword" Runat="server" Display="None" ControlToValidate="TbxPassword"
			ErrorMessage="You must enter a password">
		</mobile:RequiredFieldValidator>
		<mobile:Image ID="ImgSignIn" Runat="server" ImageUrl="~/gfx/lgo.iquomi_mobile.gif"
			NavigateUrl="~/">
		</mobile:Image>
		<mobile:Label ID="LblUsername" Runat="server">Username:</mobile:Label>
		<mobile:TextBox ID="TbxUsername" Title="Username" Runat="server" />
		<mobile:Label ID="LblPassword" Runat="server">Password:</mobile:Label>
		<mobile:TextBox ID="TbxPassword" Title="Password" Runat="server" Password="True" />
		<mobile:Command ID="CmdSignIn" Runat="server" OnClick="CmdSignIn_Click">Sign In</mobile:Command>
		<mobile:Command ID="Command1" Runat="server" OnClick="Command1_Click">Command</mobile:Command>
	</mobile:Form>
</body>
</html>