<%@ Register TagPrefix="iq" TagName="Notification" Src="UcNotification.ascx" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServicesIqContactsPage" CodeFile="~/services.iqcontacts.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
    <iq:Notification ID="Notification" runat="server" />
    <div id="ContentDescription">
        iqContacts example
    </div>
    <div class="Form">
        <asp:TextBox ID="TbxData" runat="server" Columns="40">/m:IqContacts/m:Contact</asp:TextBox>
        <asp:Button ID="BtnLoad" OnClick="BtnLoad_Click" runat="server" Text="Load" />
        <asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save" />
        <div>
            <asp:Literal ID="LblResponse" runat="server" EnableViewState="false"></asp:Literal></div>
        <p>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetContacts"
                TypeName="IqContactsHelper" OnDataBinding="ObjectDataSource1_DataBinding" OnSelecting="ObjectDataSource1_Selecting"
                DeleteMethod="DeleteContactByIqid">
                <DeleteParameters>
                    <asp:Parameter Name="iqid" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </p>
        <p>
            <iq:IqGridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" OnSorting="GridView1_Sorting" EnableViewState="True" >
                <Columns>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <itemtemplate>
							<asp:Label ID="LblName" runat="server" Text='<%# string.Format("{0} {1}&nbsp;", Eval("Name[0].GivenName.Value"), Eval("Name[0].SurName.Value")) %>'></asp:Label>
                        </itemtemplate>
                        <edititemtemplate>
							<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </edititemtemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Puid" HeaderText="Puid" SortExpression="Puid" />
                    <asp:BoundField DataField="ScreenName" HeaderText="ScreenName" SortExpression="ScreenName" />
                    <asp:TemplateField HeaderText="Telephone" SortExpression="TelephoneNumber">
                        <itemtemplate>
					        <asp:Label id="LblTelephone" runat="server" text='<%# string.Format("{0} {1} {2}&nbsp;", Eval("TelephoneNumber[0].CountryCode"), Eval("TelephoneNumber[0].NationalCode"), Eval("TelephoneNumber[0].Number")) %>'></asp:Label>
					    </itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pager" />
            </iq:IqGridView>
        </p>
    </div>
</asp:Content>
