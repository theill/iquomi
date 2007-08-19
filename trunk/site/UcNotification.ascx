<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcNotification" CodeFile="UcNotification.ascx.cs" %>
<div id="InformationSummary">
    <asp:Image ID="ImageControl" CssClass="Icon" Runat="server" ImageUrl="~/gfx/ico.success.gif" />
    <div id="TabContentText">
        <b><asp:Label ID="TitleControl" Runat="server" /></b>
        <div id="TabDescription">
            <asp:Label ID="DescriptionControl" Runat="server" />
            <div><asp:Xml ID="XmlView" Runat="server" /></div>
        </div>
    </div>
</div>
