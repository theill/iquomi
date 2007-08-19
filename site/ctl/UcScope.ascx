<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcScope"  CodeFile="UcScope.ascx.cs" %>
<div class="frm">
	<div class="fld req">Name:</div>
	<asp:TextBox id="TbName" runat="server" CssClass="txt"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="req" Runat="server"
        ErrorMessage="The <b>Name</b> is missing." ControlToValidate="TbName" Display="None">
    </asp:RequiredFieldValidator>
	<div class="fld">Base:</div>
	<asp:DropDownList id="DdlBase" runat="server" CssClass="txt"></asp:DropDownList>
</div>
