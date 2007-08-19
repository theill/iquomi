<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.AccountReportsMonthlyPage"
    CodeFile="account.reports.monthly.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <div id="ContentDescription">
        Displays method history across services, platforms and applications.
    </div>
    <asp:datagrid id="ItemsList" runat="server" cssclass="AccountReportsMonthlyList"
        autogeneratecolumns="False" allowsorting="True" allowpaging="True">
<Columns>
<asp:HyperLinkColumn Text="MonthName" HeaderText="Date"></asp:HyperLinkColumn>
<asp:BoundColumn DataField="ServiceName" HeaderText="Service"></asp:BoundColumn>
<asp:BoundColumn DataField="Gross" HeaderText="Gross"></asp:BoundColumn>
<asp:BoundColumn DataField="Fee" HeaderText="Fee"></asp:BoundColumn>
<asp:BoundColumn DataField="NetAmount" HeaderText="Net Amount"></asp:BoundColumn>
</Columns>

<PagerStyle Position="TopAndBottom" Mode="NumericPages">
</PagerStyle>
</asp:datagrid>
</asp:Content>