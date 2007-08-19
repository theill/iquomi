<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.LogOnPage" CodeFile="logon.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="LogonContent" ContentPlaceHolderID="PageContentArea" runat="server">
	<asp:ValidationSummary ID="vsLogon" runat="server" HeaderText="Please correct the following and try again:"
		CssClass="Validation" />
	<div id="ContentDescription">
		You must log on to manage your services, view traffic statistic, download updated plugins for
		existing services, etc.
	</div>
	<div class="fld req">
		Email:
		<asp:RequiredFieldValidator ID="RfvEmail" runat="server" ErrorMessage="The <b>Email</b> is missing."
			ControlToValidate="TxtEmail" SetFocusOnError="True">*</asp:RequiredFieldValidator>
	</div>
	<asp:TextBox ID="TxtEmail" runat="server" CssClass="txt" />
	<div class="fld req">
		Password:
		<asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="The <b>Password</b> is missing."
			ControlToValidate="TxtPassword" SetFocusOnError="True">*</asp:RequiredFieldValidator>
	</div>
	<asp:TextBox ID="TxtPassword" runat="server" CssClass="txt" TextMode="Password" />
	<div id="Buttons">
		<asp:Button ID="BtnLogOn" runat="server" CssClass="btn" Text="Log On" OnClick="btnLogOn_Click" />
		<asp:CustomValidator ID="CvLogOn" runat="server" ErrorMessage="The entered e-mail &amp; password combination does not match an existing user."
			Display="None" EnableClientScript="False" OnServerValidate="CvLogOn_ServerValidate">
		</asp:CustomValidator>
	</div>
</asp:Content>
