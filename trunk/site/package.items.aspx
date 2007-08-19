<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Import Namespace="Commanigy.Iquomi.Ui" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="UcPackageTab" Src="ctl/UcPackageTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.PackageItemsPage" CodeFile="package.items.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcPackageTab ID="UcPackageTab" Runat="server" />
    <div id="ContentDescription">
        shows all files contained in this package.
    </div>
    <iq:IqGridView ID="GridView1" Runat="server" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:templatefield><ItemTemplate><asp:Literal id="RowId" runat="server" text='<%# Eval("PackageItemId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" /></ItemTemplate>
<HeaderStyle CssClass="mark" />
</asp:templatefield>
            <asp:templatefield headertext="Name" sortexpression="PackageItemName"><ItemTemplate>
		<a href="<%# Link("package.item.update.aspx", new object[] { Eval("PackageItemId") }) %>"><%# Eval("PackageItemName")%></a>
	</ItemTemplate>
	<HeaderStyle Width="30%" />
</asp:templatefield>
            <asp:boundfield headertext="Type" sortexpression="PackageItemType" datafield="PackageItemType" />
            <asp:templatefield headertext="Size" sortexpression="PackageItemSize"><ItemTemplate><%# DbUiHelper.ToFileSize((long)Eval("PackageItemSize")) %></ItemTemplate>

<HeaderStyle Width="10%" />
</asp:templatefield>
        </Columns>
    </iq:IqGridView>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Commanigy.Iquomi.Data.DbPackageItem"
        selectmethod="DbFindAllByPackage" onselecting="ObjectDataSource1_Selecting"><SelectParameters>
<asp:Parameter Name="packageId"></asp:Parameter>
</SelectParameters>
</asp:objectdatasource>
    <div id="Buttons">
        <asp:button id="Add" cssclass="btn" runat="server" text="Add Item" onclick="Add_Click"></asp:button>
        <asp:button id="Delete" cssclass="btn" runat="server" text="Delete Items" onclick="Delete_Click"></asp:button>
        <asp:button id="BtnExclude" cssclass="btn" runat="server" text="Exclude Items" Enabled="false" />
    </div>
</asp:Content>