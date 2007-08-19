<%@ Register TagPrefix="iq" TagName="PackageItemManage" Src="ctl/UcPackageItem.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcPackageTab" Src="ctl/UcPackageTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.PackageItemUpdatePage" CodeFile="package.item.update.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcPackageTab ID="PackageTab" Runat="server" />
    <div id="ContentDescription">
        Update existing package item.
    </div>
    <iq:PackageItemManage ID="PackageItem" Runat="server" />
    <div id="Buttons">
        <asp:button id="BtnUpdate" runat="server" cssclass="btn" text="Update" onclick="BtnUpdate_Click" />
    </div>
</asp:Content>