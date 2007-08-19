<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcSubscriptionTab" CodeFile="UcSubscriptionTab.ascx.cs" %>
<div id="Tabs">
	<table border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td>
				<img id="ImgDot" src="~/gfx/dot.gif" width="4" runat="server" alt="" /></td>
			<td>
				<img id="ImgLeft" src="~/gfx/part.tab.left.gray.gif" runat="server" alt="" /></td>
			<td>
				<div id="TabSelected">
					Subscription</div>
			</td>
			<td>
				<img id="ImgRight" src="~/gfx/part.tab.right.selected.gray.gif" runat="server" alt="" /></td>
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
		<br />
		<div>
		details about service and subscription such as service name, version and author.
		subscription details such as expiration date, usage in dollars, remaining usage,
		etc.
		</div>
		
		<asp:validationsummary id="ValidationSummary" runat="server" CssClass="Validation" headertext="Please correct the following and try again:" />
	</div>
</div>
