<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicesIqProfilePage" CodeFile="services.iqprofile.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<iq:Notification ID="Notification" runat="server" />
	<div id="ContentDescription">
		iqProfile example<br />
		<br />
		InstanceId:
		<asp:Label ID="LblInstanceId" runat="server"></asp:Label></div>
	<div class="Form">
		Given Name:<br />
		<asp:TextBox ID="TbxGivenName" runat="server"></asp:TextBox>
		<br />
		<br />
		Middle Name:<br />
		<asp:TextBox ID="TbxMiddleName" runat="server"></asp:TextBox>
		<br />
		<br />
		Sur Name:<br />
		<asp:TextBox ID="TbxSurName" runat="server"></asp:TextBox>
		<br />
		<br />
		Email:<br />
		<asp:TextBox ID="TbxEmail" runat="server"></asp:TextBox><br />
		<br />
		Phone:<br />
		<asp:TextBox ID="TbxPhone" runat="server"></asp:TextBox><br />
		<br />
		<p>
		</p>
		<asp:Button ID="BtnLoad" OnClick="BtnLoad_Click" runat="server" Text="Load"></asp:Button>
		<asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save"></asp:Button>
	</div>
</asp:Content>
