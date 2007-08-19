<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SignUpPage" CodeFile="signup.aspx.cs" MasterPageFile="~/MasterPage.master" %>
<%@ Register TagPrefix="iq" TagName="UcNotification" Src="UcNotification.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    <asp:validationsummary id="ValidationSummary" runat="server" headertext="Please correct the following and try again:">
		</asp:validationsummary>
    <iq:UcNotification ID="Notification" Runat="server" />
    <div id="ContentDescription">
        To sign up, please fill out the form below. Field "email" should be named "iqid" and is a global
        unique identifier used as an email address e.g. iqid 'theill' will be 'theill@iquomi.com' and should be
        used as an alias for one or more 'real' email addresses. The iqid must contain at least six 
        characters
    </div>
    <div class="frm">
        <div class="fld req">
            Email: <asp:requiredfieldvalidator id="ReqEmail" runat="server" controltovalidate="Email"
                errormessage="The <b>Email</b> is missing.">*</asp:requiredfieldvalidator></div>
        <asp:textbox id="Email" runat="server" cssclass="txt"></asp:textbox>
        <div class="fld req">
            Password: <asp:requiredfieldvalidator id="ReqPassword" runat="server"
                controltovalidate="Password" errormessage="The <b>Password</b> is missing.">*</asp:requiredfieldvalidator></div>
        <asp:textbox id="Password" runat="server" cssclass="txt" textmode="Password"></asp:textbox>
        <div class="fld req">
            Retype password: <asp:requiredfieldvalidator id="ReqRetypePassword" runat="server"
                controltovalidate="RetypePassword" errormessage="The <b>Retype password</b> is missing.">*</asp:requiredfieldvalidator></div>
        <asp:textbox id="RetypePassword" runat="server" cssclass="txt" textmode="Password"></asp:textbox>
    </div>
    <asp:comparevalidator id="ComparePasswords" runat="server" controltovalidate="RetypePassword"
        errormessage="Your entered passwords doesn't match." display="None" controltocompare="Password">
		</asp:comparevalidator>
    <div id="Buttons">
        <asp:button id="btnSubmit" runat="server" cssclass="btn" text="Create" onclick="btnSubmit_Click">
			</asp:button>
    </div>
</asp:Content>