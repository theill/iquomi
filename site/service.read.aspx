<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceReadPage" CodeFile="service.read.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <div id="ContentDescription">
        info about current number of subscribers, showing graphs for usage for day, week,
        month, currently revenue, pending updates (new version), active package, latest
        new subscribers, etc.
    </div>
    <div style="text-align: center">
        <img src="gfx/mck.month-graph.gif" alt="Usage statistics" />
    </div>
    <div id="Buttons">
        <asp:button id="ProvisionService" runat="server" cssclass="btn" text="Provision"
            onclick="ProvisionService_Click" /><asp:button id="RetireButton" runat="server" text="Retire"
                cssclass="btn" onclick="RetireButton_Click"></asp:button><asp:button id="DeleteButton"
                    runat="server" text="Delete" cssclass="btn" onclick="DeleteButton_Click" />
        <br />
        <asp:button id="ManageButton" runat="server" text="Manage" cssclass="btn" onclick="ManageButton_Click" />
        <asp:button id="BtnUpgrade" runat="server" text="Upgrade" cssclass="btn" onclick="BtnUpgrade_Click" />
        <br />
        <asp:button id="ChargesButton" runat="server" text="Charges" cssclass="btn" onclick="ChargesButton_Click" />
        <asp:button id="MethodsButton" runat="server" text="Methods" cssclass="btn" OnClick="MethodsButton_Click" />
        <asp:button id="RolesButton" runat="server" text="Role Templates" cssclass="btn"
            onclick="RolesButton_Click" /><asp:button id="btnScopes" runat="server" text="Scopes"
                cssclass="btn" onclick="btnScopes_Click" />
    </div>
</asp:Content>