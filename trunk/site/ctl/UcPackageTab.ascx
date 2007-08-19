<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcPackageTab" CodeFile="UcPackageTab.ascx.cs" %>
<div id="Tabs">
	<table border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td><img src="~/gfx/dot.gif" width="4" runat="server" alt="" /></td>
		<td><img src="~/gfx/part.tab.left.gray.gif" runat="server" alt=""/></td>
		<td><div id="TabSelected">Package</div></td>
		<td><img src="~/gfx/part.tab.right.selected.gray.gif" runat="server" alt=""/></td>
	</tr>
	</table>
</div>

<div id="TabContent">
	<asp:Image id="ImgServiceUrlIcon" CssClass="Icon" runat="server" ImageUrl="~/gfx/dot.gif"/>
	<div id="TabContentText">
		<asp:Label ID="LblPackageDescription" runat="server" />
		<div id="TabDescription">
			<asp:Label ID="LblServiceDescription" runat="server" />
		</div>
		<br />
		Copyright© 2007 Commanigy, Inc. All rights reserved.
		<br />
		<br />
		<asp:Label ID="LblServiceState" runat="server" />
		
		<asp:ValidationSummary ID="validationSummary" runat="server" HeaderText="Please correct the following and try again:" />
	</div>
</div>
