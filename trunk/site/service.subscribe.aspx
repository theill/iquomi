<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="~/UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceSubscribePage" CodeFile="service.subscribe.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceUC" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    
    <div id="ContentDescription">
		Service details such as description, author, price details, sla, available
		plugins and extensions, etc.
	</div>
	
	<div class="fld req">Name:</div>
	<asp:TextBox ID="FldName" runat="server" CssClass="txt" />
	<asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="The <b>Name</b> is missing." ControlToValidate="FldName" Display="None" SetFocusOnError="True" />
	
    <asp:button id="SubscribeService" runat="server" cssclass="btn" text="Subscribe" onclick="SubscribeService_Click" />
</asp:Content>