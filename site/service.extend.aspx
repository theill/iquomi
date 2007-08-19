<%@ Register TagPrefix="iq" TagName="Service" Src="ctl/UcService.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceExtendPage" CodeFile="service.extend.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <asp:validationsummary id="ValidationSummary" runat="server" headertext="Please correct the following and try again:" />
    <div id="ContentDescription">
        select currently activated and extendable service; copy this and add additional
        schemas.
    </div>
    <div id="Buttons">
        <asp:button id="BtnExtend" runat="server" cssclass="btn" text="Extend" onclick="btnCreate_Click" />
    </div>
</asp:Content>