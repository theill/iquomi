<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicesIqRssPage" CodeFile="services.iqrss.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<iq:Notification ID="Notification" runat="server" />
	<div id="ContentDescription">
		iqRss example
	</div>
    <asp:xml id="XmlView" runat="server" />	
</asp:Content>
