<%@ Control Language="C#" CodeFile="UcAccountOverview.ascx.cs" Inherits="UcAccountOverview_ascx" %>
<div id="AccountOverview">
	<div class="Caption">My Balance</div>
	<div class="Text"><asp:Label ID="Balance" Runat="server" CssClass="MyBalance" /></div>
	<div class="Caption">My Details</div>
	<div class="Text"><asp:Label ID="Details" Runat="server" CssClass="MyDetails" /></div>
	<div class="Caption">My Devices</div>
	<div class="Text"><asp:Label ID="Devices" Runat="server" CssClass="MyDevices" /></div>
</div>