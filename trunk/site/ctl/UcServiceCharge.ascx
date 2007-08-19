<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcServiceCharge" CodeFile="UcServiceCharge.ascx.cs" %>
<div class="frm">
    <script type="text/javascript">
    
        function InsertScript(t) {
            theForm.elements[t].value = 'if (Order.@Quantity <= 10) {\n  return this.UnitPrice * Order.@Quantity;\n} else {\n  // give user a 10 percent rebate\n  return (this.UnitPrice / 1.10) * Order.@Quantity;\n}';
        }
    
    </script>
    <div class="fld req">
        Schema Type:</div>
    <asp:DropDownList ID="FldSchemaType" Runat="server" CssClass="txt" />
    <asp:RequiredFieldValidator ID="RfvSchemaType" ControlToValidate="FldSchemaType"
        Display="None" ErrorMessage="The <b>Schema Type</b> is missing." Runat="server"
        SetFocusOnError="True" />
    <div class="fld req">
        Type:</div>
    <asp:DropDownList ID="FldMethodTypeId" Runat="server" CssClass="txt" />
    <asp:RequiredFieldValidator ID="RfvMethodTypeId" ControlToValidate="FldMethodTypeId" Display="None" ErrorMessage="The <b>Type</b> is missing." Runat="server" SetFocusOnError="True" />
    <div class="fld">
        Script: <a href="#" onclick="InsertScript('<%= FldScript.UniqueID %>'); return false;" style="color: #cc9; text-decoration: none;">use sample</a></div>
    <asp:TextBox ID="FldScript" Runat="server" CssClass="txt" TextMode="MultiLine"
        Rows="6"></asp:TextBox>
    <div class="fld req">
        Price:
        <asp:RequiredFieldValidator ID="RfvPrice" Runat="server" ErrorMessage="The <b>Price</b> is missing."
            ControlToValidate="FldPrice" SetFocusOnError="True">*</asp:RequiredFieldValidator></div>
    <asp:TextBox ID="FldPrice" Runat="server" CssClass="txt"></asp:TextBox>
    <div class="fld">
        Unit:</div>
    <asp:DropDownList ID="FldChargeUnitId" Runat="server" CssClass="txt">
    </asp:DropDownList>
</div>
