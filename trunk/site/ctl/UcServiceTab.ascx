<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcServiceTab" CodeFile="UcServiceTab.ascx.cs" %>
<div id="Tabs">
	<table border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td><img id="Img1" src="~/gfx/dot.gif" width="4" runat="server" alt="" /></td>
		<td><img id="Img2" src="~/gfx/part.tab.left.gray.gif" runat="server" alt="" /></td>
		<td><div id="TabSelected">Service</div></td>
		<td><img id="Img3" src="~/gfx/part.tab.right.selected.gray.gif" runat="server" alt="" /></td>
		<!--
		<td><img src="~/gfx/part.tab.middle.selected.gray.gif" /></td>
		<td><div class="TabUnselected">Charges</div></td>
		<td><img src="~/gfx/part.tab.end.gray.gif" /></td>
		-->
	</tr>
	</table>
</div>
<div id="TabContent">
	<asp:Image id="UrlIcon" CssClass="Icon" runat="server" ImageUrl="~/gfx/dot.gif" />
	<div id="TabContentText">
		<asp:HyperLink ID="LnkServiceName" runat="server" />
		<div id="TabDescription">
			<asp:Label id="Description" runat="server" />
		</div>
		<div id="Authoring" runat="server" visible="false">
			<asp:HyperLink id="LnkManageService" runat="server" Text="Manage" Visible="false" />
		</div>
		
		<!--Service is currently in state <STRONG><asp:Label id="State" runat="server" /></STRONG>.-->
		
		<asp:validationsummary id="ValidationSummary" runat="server" CssClass="Validation" headertext="Please correct the following and try again:" />
	</div>
</div>