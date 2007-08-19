<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcPackageItem" CodeFile="UcPackageItem.ascx.cs" %>
<div class="frm">
    <div class="fld req">
        Name:</div>
    <asp:TextBox ID="FldName" Runat="server" CssClass="txt" />
    <asp:RequiredFieldValidator ID="NameRequiredValidator" Runat="server" ErrorMessage="The <b>Name</b> is missing."
        Display="None" ControlToValidate="FldName" />
    <div class="grp">
        <div class="hdr">
            <asp:RadioButton ID="RbItemManual" Runat="server" Checked="True" Text="Define custom"
                GroupName="ItemDefGroup" />
        </div>
        <div class="fld">
            Type:</div>
        <asp:DropDownList ID="FldType" Runat="server" CssClass="txt" />
        <div class="fld">
            Size:</div>
        <asp:TextBox ID="FldSize" Runat="server" CssClass="txt" />
        <div class="fld">
            Data:</div>
        <asp:TextBox ID="FldData" Runat="server" TextMode="MultiLine" Rows="4" CssClass="txt" />
    </div>
    <div class="grp">
        <div class="hdr">
            <asp:RadioButton ID="RbItemUploaded" Runat="server" Text="Upload existing" GroupName="ItemDefGroup" />
        </div>
        <div class="fld">
            Upload:</div>
        <input id="FldUpload" type="file" runat="server" />
    </div>
</div>
