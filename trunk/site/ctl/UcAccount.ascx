<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcAccount" CodeFile="UcAccount.ascx.cs" %>
<div class="frm">
	<asp:FormView ID="form" runat="server" DataSourceID="ObjectSource" DefaultMode="Edit">
		<EditItemTemplate>
			<asp:RequiredFieldValidator ID="RfvUpdateEmail" runat="server" ErrorMessage="The <b>Email</b> is missing."
				ControlToValidate="UpdateEmail" Display="None" />
			<asp:CompareValidator ID="CvPasswords" Display="None" ErrorMessage="Your passwords don't match"
				runat="server" ControlToValidate="UpdateRetypePassword" ControlToCompare="UpdatePassword">
			</asp:CompareValidator>
			<asp:RequiredFieldValidator ID="RfvOldPassword" runat="server" Display="None" ControlToValidate="OldPassword"
				ErrorMessage="The <b>Old password</b> is missing." />
			<asp:RequiredFieldValidator ID="RfvPassword" runat="server" Display="None" ControlToValidate="UpdatePassword"
				ErrorMessage="The <b>New password</b> is missing." />
			<asp:RequiredFieldValidator ID="RfvRetypePassword" runat="server" Display="None"
				ControlToValidate="UpdateRetypePassword" ErrorMessage="The <b>Confirm new password</b> is missing." />
			<asp:CustomValidator ID="RfvOldPassword2" runat="server" Display="None" ControlToValidate="OldPassword"
				ErrorMessage="The <b>Old password</b> is incorrect." OnServerValidate="RfvOldPassword2_ServerValidate" />
			
			<div id="ContentDescription">
				update your account by modifying the sections below.</div>
			<div class="fld">
				Iqid:
			</div>
			<asp:TextBox ID="UpdateIqid" runat="server" Text='<%# Bind("Iqid") %>' CssClass="txt" Enabled="False" />
			<div class="fld req">
				Email:
			</div>
			<asp:TextBox ID="UpdateEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="txt"
				AutoCompleteType="Email" />
			<div class="fld req">
				Old password:
			</div>
			<asp:TextBox ID="OldPassword" runat="server" Text='' CssClass="txt" TextMode="Password" />
			<div class="fld req">
				New password:
			</div>
			<asp:TextBox ID="UpdatePassword" runat="server" Text='<%# Bind("Password") %>' CssClass="txt" TextMode="Password" />
			<div class="fld req">
				Confirm new password:&nbsp;
			</div>
			<asp:TextBox ID="UpdateRetypePassword" runat="server" CssClass="txt" TextMode="Password" />
			<div id="Buttons">
				<asp:Button ID="UpdateButton" runat="server" CssClass="btn" Text="Update" CommandName="Update" />
			</div>
		</EditItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="ObjectSource" runat="server" TypeName="Commanigy.Iquomi.Data.DbAccount"
		SelectMethod="DbLoad" UpdateMethod="DbSave" OnSelected="ObjectDataSource1_Selected"
		DataObjectTypeName="Commanigy.Iquomi.Api.Account" OnUpdated="ObjectSource_Updated"
	 OnUpdating="ObjectSource_Updating">
		<SelectParameters>
			<asp:ProfileParameter Name="Id" Type="Int32" PropertyName="AccountId" />
		</SelectParameters>
	</asp:ObjectDataSource>
</div>
