<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcSubscriptionListener"
    CodeFile="UcSubscriptionListener.ascx.cs" %>
<div class="frm">
    <div class="fld req">
        Iqid:<asp:CustomValidator ID="CustomValidator1" ErrorMessage="<b>Iqid</b> not found" Runat="server"
            ControlToValidate="TbxIqid" OnServerValidate="CustomValidator1_ServerValidate"
            SetFocusOnError="True">*</asp:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="The <b>Iqid</b> is missing."
                Runat="server" ControlToValidate="TbxIqid">*</asp:RequiredFieldValidator><asp:Button ID="BtnLookup" Runat="server" CssClass="btn" Text="Lookup" Visible="False" /></div>
    <asp:TextBox ID="TbxIqid" Runat="server" CssClass="txt"></asp:TextBox>
    <div class="fld req">
        Filter:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="The <b>Filter</b> is missing."
            Runat="server" ControlToValidate="TbxFilter">
            *</asp:RequiredFieldValidator>
    </div>
    <asp:TextBox ID="TbxFilter" CssClass="txt" Runat="server" />
    <div class="fld req">
        Context Uri:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="The <b>Context Uri</b> is missing."
            Runat="server" ControlToValidate="TbxContextUri">
            *</asp:RequiredFieldValidator>
    </div>
    <asp:TextBox ID="TbxContextUri" CssClass="txt" Runat="server" />
    <!--
    <div class="fld">
        Context:&nbsp;
    </div>
    <asp:TextBox ID="TbxContextData" CssClass="txt" Runat="server" TextMode="MultiLine"
        Height="64px" />
        -->
    <div class="fld">
        Active From:<asp:Button ID="BtnActiveFromToday" Runat="server" CssClass="btn" Text="Today"
            Visible="False" /></div>
    <asp:TextBox ID="TbxActiveFrom" CssClass="txt" Runat="server" />
    <div class="fld">
        Active To:<asp:Button ID="BtnActiveToToday" Runat="server" CssClass="btn" Text="Today"
            Visible="False" /></div>
    <asp:TextBox ID="TbxActiveTo" CssClass="txt" Runat="server" />
    <div class="fld req">
        To:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="The <b>To</b> is missing."
            Runat="server" ControlToValidate="TbxTo">
            *</asp:RequiredFieldValidator></div>
    <asp:TextBox ID="TbxTo" CssClass="txt" Runat="server" /></div>
