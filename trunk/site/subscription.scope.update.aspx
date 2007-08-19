<%@ Import Namespace="Commanigy.Iquomi.Ui" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="ctl/UcSubscriptionTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcScope" Src="ctl/UcScope.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionScopeUpdatePage" CodeFile="subscription.scope.update.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<%@ Import Namespace="Commanigy.Iquomi.Ui" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />
    <iq:Notification ID="Notification" Runat="server" Visible="False" />
    <div id="ContentDescription">
        Define scopes for your subscription. Scopes are used to define which Xml node sets are
        visible to each authorized user. For example, a scope can define a node set that
        includes all information exposed by the service, only information this is considered
        "public", all information except for node sets that are marked "top-secret", etc.
    </div>
    <iq:UcScope ID="UcScope" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnUpdate" runat="server" text="Update" cssclass="btn" onclick="btnUpdate_Click" />
    </div>
    <br />
    <iq:IqGridView ID="GridView1" Runat="server" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:templatefield headertext="&#160;">
			<headerstyle cssclass="mark" />
			<itemtemplate>
				<asp:Literal id="RowId" runat="server" text='<%# Eval("Id") %>' visible="false" />
				<asp:CheckBox id="RowChecked" runat="server" />
			</itemtemplate>
		</asp:templatefield>
        <asp:templatefield headertext="Select" sortexpression="Select">
			<itemtemplate>
<a href="<%# Link("subscription.shape.update.aspx", new object[] { subscription.Id, Eval("Id") }) %>"><%# Eval("Select") %></a>
</itemtemplate>
</asp:templatefield>
        <asp:templatefield headertext="Type" sortexpression="Type">
			    <itemtemplate>
			        <%# DbUiHelper.ToShapeType(Eval("Type").ToString()) %>
			    </itemtemplate>
			</asp:templatefield>
    </Columns>
    </iq:IqGridView>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Commanigy.Iquomi.Data.DbScope"
        selectmethod="DbListAllShapesByScope" onselecting="ObjectDataSource1_Selecting"><SelectParameters>
			<asp:Parameter Type="Int32" Name="scopeId" />
		</SelectParameters></asp:objectdatasource>
    <div id="Buttons">
        <asp:button id="BtnAddShape" runat="server" text="Add Shape" cssclass="btn" onclick="BtnAddItem_Click" />
        <asp:button id="BtnDeleteShape" runat="server" text="Delete Shape" cssclass="btn"
            onclick="BtnDeleteItem_Click" />
    </div>
</asp:Content>