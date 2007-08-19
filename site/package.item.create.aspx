<%@ Register TagPrefix="iq" TagName="PackageItemManage" Src="ctl/UcPackageItem.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcPackageTab" Src="ctl/UcPackageTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.PackageItemCreatePage" CodeFile="package.item.create.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcPackageTab ID="UcPackageTab" Runat="server" />
    <div id="ContentDescription">
        Create new package item.
    </div>
    <iq:PackageItemManage ID="PackageItem" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" cssclass="btn" text="Create" onclick="btnCreate_Click" />
    </div>
</asp:Content>