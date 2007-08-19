<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="ServicesMenu" Src="UcServicesMenu.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.AccountReportServicePage" CodeFile="account.report.service.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">

    <iq:UcServiceTab ID="ServiceTab" Runat="server" />

	<div id="ContentDescription">
		detailed description and user statistic for selected service.
	</div>

	<iq:ServicesMenu Runat="server" />
</asp:Content>