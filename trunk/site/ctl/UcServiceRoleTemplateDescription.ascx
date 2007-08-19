<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcServiceRoleTemplateDescription"  CodeFile="UcServiceRoleTemplateDescription.ascx.cs" %>
<div class="frm">
	<div class="fld">Language:</div>
	<asp:DropDownList id="ddlLanguage" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
	<div class="fld">Description:</div>
	<asp:textbox id="FldDescription" runat="server" CssClass="txt"></asp:textbox>
</div>
