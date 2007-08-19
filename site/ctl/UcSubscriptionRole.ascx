<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcSubscriptionRole"  CodeFile="UcSubscriptionRole.ascx.cs" %>
<div class="frm">

	<div class="fld req">Iqid:<asp:Button id="BtnLookup" runat="server" CssClass="btn" Text="Lookup" Visible="False"></asp:Button></div>
	<asp:RequiredFieldValidator id="rfvIqid" CssClass="req" runat="server" ErrorMessage="The <b>Iqid</b> is missing." ControlToValidate="TbxIqid" Display="None"></asp:RequiredFieldValidator>
	<asp:TextBox id="TbxIqid" runat="server" CssClass="txt"></asp:TextBox>
	
	<div class="fld req">Role Template:</div>
	<asp:RegularExpressionValidator id="rfvRoleTemplate" CssClass="req" runat="server" ErrorMessage="The <b>Role Template</b> is missing." ControlToValidate="DdlRoleTemplates" Display="None" ValidationExpression="[1-9]\d*"></asp:RegularExpressionValidator>
	<asp:DropDownList id="DdlRoleTemplates" runat="server" CssClass="txt" />

	<div class="fld">Scope:</div>
	<asp:DropDownList id="DdlScopes" runat="server" CssClass="txt"></asp:DropDownList>
	<asp:Button id="BtnDefine" runat="server" CssClass="btn" Text="Define"></asp:Button>

	<div class="fld">Active From:<asp:Button id="BtnToday" runat="server" CssClass="btn" Text="Today" Visible="False"/></div>
	<asp:TextBox id="TbxActiveFrom" CssClass="txt" runat="server" />
	
	<div class="fld">Active To:</div>
	<asp:TextBox id="TbxActiveTo" CssClass="txt" runat="server"></asp:TextBox>
	
</div>
