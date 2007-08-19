<%@ Register TagPrefix="iq" TagName="UcPackageTab" Src="ctl/UcPackageTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.PackagePage" CodeFile="package.read.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcPackageTab ID="UcPackageTab" Runat="server" />
    <div id="ContentDescription">
        display some package statistics such as last subscribed user, last action, service
        rate scheme, etc.
    </div>
    <div id="Buttons">
        <asp:button id="BtnFiles" runat="server" text="Files" cssclass="btn" onclick="BtnFiles_Click" />
        <asp:button id="BtnManage" runat="server" text="Manage" cssclass="btn" OnClick="BtnManage_Click" />
        <asp:button id="BtnRetire" runat="server" text="Retire" cssclass="btn" OnClick="BtnRetire_Click" />
        <asp:button id="BtnCopy" runat="server" text="Copy" cssclass="btn" Enabled="false" />
        <asp:button id="BtnDelete" runat="server" text="Delete" cssclass="btn" OnClick="BtnDelete_Click" />
    </div>
</asp:Content>