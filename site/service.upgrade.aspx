<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceUpgradePage" CodeFile="service.upgrade.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceUC" Runat="server" />
    <div id="ContentDescription">
        upgrade existing service by modifying the schema and adding additional code. it
        must be possible to associate an xslt which allows converting xml version n to xml
        version n+1 documents.
    </div>
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" cssclass="btn" text="Upgrade"></asp:button>
    </div>
</asp:Content>