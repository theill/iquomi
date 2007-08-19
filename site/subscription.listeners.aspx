<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcSubscriptionTab" Src="~/ctl/UcSubscriptionTab.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SubscriptionListenersPage"
    CodeFile="subscription.listeners.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcSubscriptionTab ID="UcSubscriptionTab" Runat="server" />
    <iq:UcNotification ID="UcNotification" Runat="server" />
    <div id="ContentDescription">
        available listeners on subscription, i.e. people or applications getting certain
        notifications when the subscription is modified. e.g. if the subscription is a "profile"
        service it would notify listeners about change in the profile data. it's possible
        to add or remove listeners.
    </div>
    <iq:IqGridView ID="View" Runat="server" DataSourceID="ObjectDataSource1" OnRowDataBound="List_RowDataBound">
    <Columns>
        <asp:templatefield><ItemTemplate><asp:Literal id="RowId" runat="server" text='<%# Eval("SubscriptionListenerId") %>' visible="false" /><asp:CheckBox id="RowChecked" runat="server" /></ItemTemplate>
<HeaderStyle CssClass="mark" />
</asp:templatefield>
        <asp:templatefield headertext="User" sortexpression="Iqid">
					<HeaderStyle Width="30%"></HeaderStyle>
					<itemtemplate><a href="<%# Link("subscription.listener.update.aspx", new object[] { subscription.Id, Eval("SubscriptionListenerId") }) %>"><%# Eval("Iqid") %></a></itemtemplate>
				</asp:templatefield>
        <asp:boundfield headertext="Filter" datafield="Filter" sortexpression="Filter">
					<HeaderStyle Width="30%"></HeaderStyle>
				</asp:boundfield>
        <asp:boundfield headertext="Active From" datafield="ActiveFrom" sortexpression="ActiveFrom"
            nulldisplaytext="-" dataformatstring="{0:u}">
<ItemStyle Wrap="False"></ItemStyle>
					<HeaderStyle Width="20%"></HeaderStyle>
				</asp:boundfield>
        <asp:boundfield headertext="Active To" datafield="ActiveTo" sortexpression="ActiveTo"
            nulldisplaytext="-" dataformatstring="{0:u}">
<ItemStyle Wrap="False"></ItemStyle>
					<HeaderStyle Width="20%"></HeaderStyle>
				</asp:boundfield>
    </Columns>
    </iq:IqGridView>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Commanigy.Iquomi.Data.DbSubscriptionListener"
        selectmethod="DbListListenersBySubscription" onselecting="ObjectDataSource1_Selecting"><SelectParameters>
<asp:Parameter Name="subscriptionId"></asp:Parameter>
<asp:ProfileParameter Name="languageId" Type="Int32" PropertyName="LanguageId"></asp:ProfileParameter>
</SelectParameters>
</asp:objectdatasource>
    <div id="Buttons">
        <asp:button id="BtnAddListener" runat="server" text="Add Listener" cssclass="btn"
            onclick="BtnAddItem_Click"></asp:button><asp:button id="BtnRemoveListener"
                runat="server" text="Remove Listener" cssclass="btn" onclick="BtnRemoveItem_Click"></asp:button>
        <asp:button id="BtnSuspendListener" runat="server" text="Suspend Listener" cssclass="btn"
            onclick="BtnSuspendListener_Click"></asp:button>
    </div>
</asp:Content>