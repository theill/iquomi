<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcAccountTab" CodeFile="UcAccountTab.ascx.cs" %>
<div id="Tabs">
	<table border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td><img src="~/gfx/dot.gif" width="4" runat="server" alt="" /></td>
		<td><img src="~/gfx/part.tab.left.gray.gif" runat="server" alt="" /></td>
		<td><div id="TabSelected">Account</div></td>
		<td><img src="~/gfx/part.tab.right.selected.gray.gif" runat="server" alt="" /></td>
	</tr>
	</table>
</div>
<div id="TabContent">
	<div id="TabContentText">
		<b><asp:Label id="FullName" runat="server" /></b>
		<div id="TabDescription">
			<asp:Label id="Description" runat="server" />
		</div>
		
		<asp:validationsummary id="ValidationSummary" runat="server" CssClass="Validation" headertext="Please correct the following and try again:" />
	</div>
</div>