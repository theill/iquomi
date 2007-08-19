<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="ProfilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="FrmProfile" runat="server">
		<mobile:Label ID="LblGivenName" Runat="server">Given Name:</mobile:Label>
		<mobile:TextBox ID="TbxGivenName" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="LblMiddleName" Runat="server">Middel Name:</mobile:Label>
		<mobile:TextBox ID="TbxMiddleName" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="LblSurName" Runat="server">Sur Name:</mobile:Label>
		<mobile:TextBox ID="TbxSurName" Runat="server">
		</mobile:TextBox>
		<mobile:Command ID="CmdLoad" Runat="server" BreakAfter="False" OnClick="Command1_Click">Load</mobile:Command>
		<mobile:Command ID="CmdSave" Runat="server">Save</mobile:Command>

    </mobile:Form><mobile:StyleSheet ID="StyleSheet1" Runat="server">
		<PagerStyle Name="PagerStyle1" StyleReference="">
		</PagerStyle>
	</mobile:StyleSheet>
</body>
</html>
