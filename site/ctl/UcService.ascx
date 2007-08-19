<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcService" CodeFile="UcService.ascx.cs" %>
<div class="frm">
	<asp:FormView ID="form" DefaultMode="Edit" DataSourceID="ObjectSource" runat="server">
		<EditItemTemplate>
			<div id="ContentDescription">
				update (own) service details, setup default charge schemas and role templates, sla.
			</div>
			<div class="fld req">
				Name:</div>
			<asp:TextBox ID="FldName" runat="server" Text='<%# Bind("Name") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="The <b>Name</b> is missing."
				ControlToValidate="FldName" Display="None" SetFocusOnError="True" />
			<div class="fld">
				Version:</div>
			<asp:TextBox ID="FldVersion" runat="server" Text='<%# Bind("Version") %>' CssClass="txt" />
			<div class="fld req">
				Schema Location:</div>
			<asp:TextBox ID="FldUrlXsd" runat="server" Text='<%# Bind("UrlXsd") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqUrlXsd" runat="server" ErrorMessage="The <b>Schema Location</b> is missing."
				ControlToValidate="FldUrlXsd" Display="None" SetFocusOnError="True" />
			<div class="fld req">
				Schema:</div>
			<asp:TextBox ID="FldXsd" runat="server" Text='<%# Bind("Xsd") %>' Rows="8" TextMode="MultiLine"
				CssClass="txt" Height="180px" />
			<asp:RequiredFieldValidator ID="ReqSchema" runat="server" ErrorMessage="The <b>Schema</b> is missing."
				ControlToValidate="FldXsd" Display="None" SetFocusOnError="True" />
			<div class="fld">
				Icon:</div>
			<asp:TextBox ID="FldUrlIcon" runat="server" Text='<%# Bind("UrlIcon") %>' CssClass="txt" /><div
				class="fld">
				Homepage:</div>
			<asp:TextBox ID="FldUrlHomepage" runat="server" Text='<%# Bind("UrlHomepage") %>'
				CssClass="txt" />
			<div id="Buttons">
				<asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="btn" CommandName="Update" />
				<asp:Button ID="BtnValidate" runat="server" Text="Validate" CssClass="btn" OnClick="BtnValidate_Click" />
			</div>
		</EditItemTemplate>
		<InsertItemTemplate>
			<div id="ContentDescription">
				create new service, own service, based on existing "core" service or one of your
				own services. setup default charge schemas and role templates.
			</div>
			<div class="fld req">
				Name:</div>
			<asp:TextBox ID="FldName" runat="server" Text='<%# Bind("Name") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="The <b>Name</b> is missing."
				ControlToValidate="FldName" Display="None" SetFocusOnError="True" />
			<div class="fld">
				Version:</div>
			<asp:TextBox ID="FldVersion" runat="server" Text='<%# Bind("Version") %>' CssClass="txt" />
			<div class="fld req">
				Schema Location:</div>
			<asp:TextBox ID="FldUrlXsd" runat="server" Text='<%# Bind("UrlXsd") %>' CssClass="txt" />
			<div class="fld req">
				Schema:</div>
			<asp:TextBox ID="FldXsd" runat="server" Text='<%# Bind("Xsd") %>' Rows="8" TextMode="MultiLine"
				CssClass="txt" Height="180px" /><asp:RequiredFieldValidator ID="ReqXsd"
					runat="server" ErrorMessage="The <b>Schema</b> is missing." ControlToValidate="FldXsd"
					Display="None" SetFocusOnError="True" />
			<div class="fld">
				Icon:</div>
			<asp:TextBox ID="FldUrlIcon" runat="server" Text='<%# Bind("UrlIcon") %>' CssClass="txt" /><div
				class="fld">
				Homepage:</div>
			<asp:TextBox ID="FldUrlHomepage" runat="server" Text='<%# Bind("UrlHomepage") %>'
				CssClass="txt" />
			<div id="Buttons">
				<asp:Button ID="btnCreate" runat="server" CssClass="btn" Text="Create" CommandName="Insert" />
			</div>
		</InsertItemTemplate>
		<ItemTemplate>
			(item template)
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="ObjectSource" runat="server" OnUpdated="ObjectSource_Updated"
		OnInserted="ObjectSource_Inserted" OnSelecting="ObjectSource_Selecting" DataObjectTypeName="Commanigy.Iquomi.Data.DbService"
		InsertMethod="DbCreate" UpdateMethod="DbUpdate" SelectMethod="DbRead" TypeName="Commanigy.Iquomi.Data.DbService"
		OnInserting="ObjectSource_Inserting" OnUpdating="ObjectSource_Updating">
		<SelectParameters>
			<asp:Parameter Type="Int32" Name="Id" />
			<asp:ProfileParameter Type="Int32" Name="AuthorId" PropertyName="AuthorId" />
			<asp:ProfileParameter Type="Int32" Name="LanguageId" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
</div>