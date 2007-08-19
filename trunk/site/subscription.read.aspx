<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionReadPage" CodeFile="subscription.read.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<iq:UcSubscriptionTab ID="SubscriptionUC" runat="server" />
	<iq:Notification ID="Notification" runat="server" />
	<div id="ContentDescription">
		help info about managing this subscription, e.g. showing details about subscription
		renewal, current usage, display customized gui if associated with service, etc. location
		of xml may be an external resource (currently no authentication) which will be used 
		in a push operation
	</div>
	<div class="Form">
		<div class="fld req">Name:</div>
		<asp:TextBox ID="FldName" runat="server" CssClass="txt" />
		<asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="The <b>Name</b> is missing." ControlToValidate="FldName" Display="None" SetFocusOnError="True" />
		<div class="fld">
			Xml:</div>
		<asp:TextBox ID="Xml" runat="server" TextMode="MultiLine" Rows="20" Columns="48"
			CssClass="txt" Height="240px" Wrap="False"></asp:TextBox>
		<div class="fld">
			Xml Location:</div>
		<asp:TextBox ID="UrlXml" runat="server" CssClass="txt" />
		<div class="fld">
			Filter:</div>
		<div style="position: relative">
		<asp:TextBox ID="TbxFilter" runat="server" CssClass="txt" />
		<div style="position: absolute; top: 2px; right: 27px;"><asp:Button ID="BtnFilter" runat="server" CssClass="btn" Text="Filter"
			OnClick="BtnFilter_Click" AccessKey="f" /></div></div>
		<div class="Xml"><asp:Label ID="LblFilterResult" runat="server" Text="" EnableViewState="false" /></div>
	</div>
	<div id="Buttons">
		<asp:Button ID="BtnRefresh" OnClick="BtnRefresh_Click" runat="server" CssClass="btn"
			Text="Refresh"></asp:Button>
		<asp:Button AccessKey="V" ID="BtnValidate" OnClick="BtnValidate_Click" runat="server"
			CssClass="btn" Text="Validate"></asp:Button>
		<asp:Button AccessKey="U" ID="BtnUpdate" OnClick="Update_Click" runat="server" CssClass="btn"
			Text="Update"></asp:Button>
		<asp:Button ID="BtnUnsubscribe" OnClick="Unsubscribe_Click" runat="server" CssClass="btn"
			Text="Unsubscribe"></asp:Button><asp:Button ID="BtnRoleLists" OnClick="BtnRoleLists_Click"
				runat="server" CssClass="btn" Text="Roles"></asp:Button>
		<asp:Button ID="BtnScopes" OnClick="BtnScopes_Click" runat="server" CssClass="btn"
			Text="Scopes"></asp:Button><asp:Button ID="BtnListeners" OnClick="BtnListeners_Click"
				runat="server" CssClass="btn" Text="Listeners"></asp:Button><asp:Button ID="BtnMethods" 
								runat="server" CssClass="btn" Text="Methods" Enabled="false" />
		</div>
</asp:Content>
