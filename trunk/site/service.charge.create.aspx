<%@ Register TagPrefix="iq" TagName="ServiceCharge" Src="ctl/UcServiceCharge.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcServiceTab" Src="ctl/UcServiceTab.ascx" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ServiceChargeCreatePage" CodeFile="service.charge.create.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <iq:UcServiceTab ID="ServiceTab" Runat="server" />
    <iq:UcNotification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        Setup new charge. It's possible to setup charges based on all available methods
        and elements. If a "script" is added for this charge, it's getting the instance
        of the selected element and can be used to work out the final price e.g. if the
        "order" element contains an attribute name "quantity" the user might create special
        charging if this is above 10 copies.
    </div>
    <iq:ServiceCharge ID="ServiceCharge" Runat="server" />
    <div id="Buttons">
        <asp:button id="btnCreate" runat="server" text="Create" cssclass="btn" onclick="btnCreate_Click" />
    </div>
</asp:Content>