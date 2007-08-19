<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="ServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceChargesPage" CodeFile="service.charges.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:ServiceTab ID="ServiceTab" Runat="server" />
    <div id="ContentDescription">
        List of defined charges for service with ability to create, edit and delete these.
    </div>
    <iq:IqGridView ID="GridView1" Runat="server" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:templatefield><ItemTemplate><asp:Literal id="RowId" runat="server" text='<%# Eval("ServiceChargeId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" /></ItemTemplate>
<HeaderStyle CssClass="mark" />
</asp:templatefield>
        <asp:templatefield headertext="Xsd Element" sortexpression="SchemaType"><ItemTemplate>
		<a href="<%# Link("service.charge.update.aspx", new object[] { Eval("ServiceId"), Eval("ServiceChargeId") }) %>"><%# Eval("SchemaType") %></a>
	</ItemTemplate>
	<HeaderStyle Width="30%" />
</asp:templatefield>
        <asp:boundfield headertext="Type" datafield="MethodTypeName" sortexpression="MethodTypeName"><HeaderStyle Width="20%" /></asp:boundfield>
        <asp:boundfield headertext="Price" datafield="Price" sortexpression="Price"><HeaderStyle Width="20%" /></asp:boundfield>
        <asp:boundfield headertext="Unit" datafield="ChargeUnitCommonName" sortexpression="ChargeUnitCommonName"><HeaderStyle Width="20%" /></asp:boundfield>
        <asp:templatefield headertext="Scripted"><ItemTemplate><%# (string.IsNullOrEmpty(Eval("Script") as string) ? _("No") : _("Yes")) %></ItemTemplate>

<HeaderStyle Width="10%" />
</asp:templatefield>
    </Columns>
    </iq:IqGridView>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Commanigy.Iquomi.Data.DbServiceCharge"
        selectmethod="DbFindAllByService" onselecting="ObjectDataSource1_Selecting" OnSelected="ObjectDataSource1_Selected"><SelectParameters>
<asp:Parameter Name="serviceId"></asp:Parameter>
</SelectParameters>
</asp:objectdatasource>
    <div id="Buttons">
        <asp:button id="BtnInsertItem" runat="server" text="Add Charge" cssclass="btn" onclick="AddChargeButton_Click" />
        <asp:button id="BtnDeleteItem" runat="server" cssclass="btn" text="Remove Charge"
            onclick="BtnDeleteItem_Click" />
    </div>
</asp:Content>