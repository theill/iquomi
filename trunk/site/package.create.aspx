<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.PackageCreatePage" CodeFile="package.create.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>
<%@ Register TagPrefix="iq" TagName="UcPackageTab" Src="~/ctl/UcPackageTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcPackage" Src="~/ctl/UcPackage.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="~/UcNotification.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
    <iq:UcPackageTab ID="PackageTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    <iq:UcPackage ID="PackageManage" runat="server" />
</asp:Content>