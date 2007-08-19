<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicesIqSmsPage" CodeFile="services.iqsms.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:Notification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        IqSms
	</div>
	
	From:
	<asp:TextBox ID="TbxFrom" runat="server" />
	
	To:
	<asp:TextBox ID="TbxBody" runat="server" />
	
	<asp:Button ID="BtnSend" runat="server" OnClick="Button1_Click" Text="Send" />
	
	<div><asp:Label ID="Label1" runat="server" Text="" /></div>
</asp:Content>