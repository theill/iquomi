<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcShape"  CodeFile="UcShape.ascx.cs" %>
<div class="frm">
	<div class="fld req">Select:</div>
	<asp:TextBox id="TbSelect" runat="server" CssClass="txt"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="req" Runat="server"
        ErrorMessage="No <b>Select</b> specified." ControlToValidate="TbSelect" Display="None">
    </asp:RequiredFieldValidator>
	<div class="fld">Type:</div>
	<asp:DropDownList id="DdlType" runat="server" CssClass="txt"></asp:DropDownList>
</div>
