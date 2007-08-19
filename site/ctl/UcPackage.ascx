<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcPackage" CodeFile="UcPackage.ascx.cs" %>
<div class="frm">
	<asp:FormView ID="form" DefaultMode="Edit" DataSourceID="ObjectSource" runat="server">
		<EditItemTemplate>
			<div id="ContentDescription">
				Update package for your services.
			</div>
			<div class="fld req">
				Service:</div>
			<asp:DropDownList ID="DdlServices" runat="server" CssClass="txt" DataValueField="Id"
				DataTextField="Name" DataSourceID="OdsServices" AppendDataBoundItems="True" SelectedValue='<%# Bind("ServiceId") %>'
				Enabled="false">
				<asp:ListItem />
			</asp:DropDownList>
			<div class="fld req">
				Version:</div>
			<asp:TextBox ID="FldVersion" runat="server" Text='<%# Bind("Version") %>' CssClass="txt" />
			<div class="fld req">
				Platform:</div>
			<asp:DropDownList ID="DdlPlatforms" runat="server" CssClass="txt" DataSourceID="OdsPlatforms"
				DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" SelectedValue='<%# Bind("PlatformId") %>'>
				<asp:ListItem />
			</asp:DropDownList>
			<div class="fld req">
				Release Date:</div>
			<asp:TextBox ID="FldReleaseDate" runat="server" CssClass="txt" Text='<%# Bind("ReleaseDate", "{0:d}") %>' />
			<div id="Buttons">
				<asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="btn" CommandName="Update" />
				<asp:Button ID="BtnValidate" runat="server" Text="Validate" CssClass="btn" OnClick="BtnValidate_Click" />
			</div>
		</EditItemTemplate>
		<InsertItemTemplate>
			<div id="ContentDescription">
				Create a new package for your services.
			</div>
			<asp:RequiredFieldValidator ID="reqService" runat="server" Display="None" ControlToValidate="DdlServices"
				ErrorMessage="The <b>Service</b> is missing." />
			<asp:RequiredFieldValidator ID="reqVersion" runat="server" Display="None" ControlToValidate="FldVersion"
				ErrorMessage="The <b>Version</b> is missing." />
			<asp:RequiredFieldValidator ID="reqPlatform" runat="server" Display="None" ControlToValidate="DdlPlatforms"
				ErrorMessage="The <b>Platform</b> is missing." />
			<asp:RequiredFieldValidator ID="reqReleaseDate" runat="server" Display="None" ControlToValidate="FldReleaseDate"
				ErrorMessage="The <b>Release Date</b> is missing." />
			<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="FldReleaseDate"
				Display="None" ErrorMessage="The <b>Release Date</b> is in an incorrect format." SetFocusOnError="True" Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
			<div class="fld req">
				Service:</div>
			<asp:DropDownList ID="DdlServices" runat="server" CssClass="txt" DataValueField="Id"
				DataTextField="Name" DataSourceID="OdsServices" AppendDataBoundItems="True" SelectedValue='<%# Bind("ServiceId") %>'>
				<asp:ListItem />
			</asp:DropDownList>
			<div class="fld req">
				Version:</div>
			<asp:TextBox ID="FldVersion" runat="server" CssClass="txt" Text='<%# Bind("Version") %>' />
			<div class="fld req">
				Platform:</div>
			<asp:DropDownList ID="DdlPlatforms" runat="server" CssClass="txt" DataSourceID="OdsPlatforms"
				DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" SelectedValue='<%# Bind("PlatformId") %>'>
				<asp:ListItem />
			</asp:DropDownList>
			<div class="fld req">
				Release Date:</div>
			<asp:TextBox ID="FldReleaseDate" runat="server" CssClass="txt" Text='<%# Bind("ReleaseDate") %>' />
			<div id="Buttons">
				<asp:Button ID="btnCreate" runat="server" CssClass="btn" Text="Create" CommandName="Insert" />
			</div>
		</InsertItemTemplate>
		<ItemTemplate>
			(item template)
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="ObjectSource" runat="server" OnUpdated="ObjectSource_Updated"
		OnInserted="ObjectSource_Inserted" OnSelecting="ObjectSource_Selecting" DataObjectTypeName="Commanigy.Iquomi.Data.DbPackage"
		InsertMethod="DbCreate" UpdateMethod="DbUpdate" SelectMethod="DbRead" TypeName="Commanigy.Iquomi.Data.DbPackage"
		OnInserting="ObjectSource_Inserting" OnUpdating="ObjectSource_Updating">
		<SelectParameters>
			<asp:Parameter Type="Int32" Name="Id" />
			<asp:ProfileParameter Type="Int32" Name="AuthorId" PropertyName="AuthorId" />
			<asp:ProfileParameter Type="Int32" Name="LanguageId" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="OdsPlatforms" runat="server" SelectMethod="DbFindAll" TypeName="Commanigy.Iquomi.Data.DbPlatform">
		<SelectParameters>
			<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" Type="Int32" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="OdsServices" runat="server" SelectMethod="DbFindAllByAuthor"
		TypeName="Commanigy.Iquomi.Data.DbService">
		<SelectParameters>
			<asp:ProfileParameter Name="authorId" PropertyName="AuthorId" Type="Int32" />
			<asp:ProfileParameter Name="languageId" PropertyName="LanguageId" Type="Int32" />
		</SelectParameters>
	</asp:ObjectDataSource>
</div>
