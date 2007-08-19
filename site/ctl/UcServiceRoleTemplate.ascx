<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcServiceRoleTemplate"
    CodeFile="UcServiceRoleTemplate.ascx.cs" %>
<div class="frm">
    <div class="fld req">
        Name:</div>
    <asp:TextBox ID="FldName" Runat="server" CssClass="txt"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Runat="server" ErrorMessage="The <b>Name</b> is missing."
        Display="None" ControlToValidate="FldName">
    </asp:RequiredFieldValidator>
    <div class="fld req">
        Priority:</div>
    <asp:TextBox ID="FldPriority" Runat="server" CssClass="txt"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Runat="server" ErrorMessage="The <b>Priority</b> is missing."
        Display="None" ControlToValidate="FldPriority">
    </asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" Runat="server" ErrorMessage="The <b>Priority</b> must be between 0 and 1024."
        Display="None" ControlToValidate="FldPriority" SetFocusOnError="True" Type="Integer"
        MinimumValue="0" MaximumValue="1024">
    </asp:RangeValidator>
</div>
