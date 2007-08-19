<%@ Control Language="c#" Inherits="Commanigy.Iquomi.Web.UcServiceMethod" CodeFile="UcServiceMethod.ascx.cs" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi.Web" Assembly="Commanigy.Iquomi" %>
<div class="frm">
	<asp:FormView ID="ObjectView" DataSourceID="ObjectSource" runat="server" OnDataBound="ObjectView_DataBound">
		<InsertItemTemplate>
			<div id="ContentDescription">
				Setup new method - allow user to select type of response e.g. "image", "html", "xml",
				"binary"
			</div>
			<div class="fld req">
				Name:</div>
			<asp:TextBox ID="FldName" runat="server" Text='<%# Bind("Name") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="The <b>Name</b> is missing."
				ControlToValidate="FldName" Display="None" SetFocusOnError="True" />
			<div class="fld req">
				Type:</div>
			<asp:DropDownList ID="FldMethodTypeId" runat="server" CssClass="txt" DataSourceID="ObjectMethodTypes"
				DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" SelectedValue='<%# Bind("MethodTypeId") %>'>
				<asp:ListItem></asp:ListItem>
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="ReqMethodTypeId" ControlToValidate="FldMethodTypeId"
				Display="None" ErrorMessage="The <b>Type</b> is missing." runat="server" SetFocusOnError="True" />
			<div class="fld req">
				Select:</div>
			<asp:TextBox ID="FldSelect" runat="server" Text='<%# Bind("Select") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqSelect" runat="server" ErrorMessage="The <b>Select</b> is missing."
				ControlToValidate="FldSelect" Display="None" SetFocusOnError="True" />
			<div class="fld">
				Script:</div>
			<asp:TextBox ID="FldScript" runat="server" Text='<%# Bind("Script") %>' Rows="6"
				TextMode="MultiLine" CssClass="txt" />
			<div class="fld">
				Script Url:</div>
			<asp:TextBox ID="FldScriptUrl" runat="server" Text='<%# Bind("ScriptUrl") %>' CssClass="txt" />
			<div id="Buttons">
				<asp:Button ID="BtnCreate" runat="server" Text="Create" CssClass="btn" CommandName="Insert" />
			</div>
		</InsertItemTemplate>
		<EditItemTemplate>
			<div id="ContentDescription">
				Modify existing service method. Item is activated from url http://services.iquomi.com/get/&lt;iqid&gt;/&lt;subscription name&gt;/&lt;method name&gt;.rpc?token=&lt;token&gt;
			</div>
			<div class="fld req">
				Name:</div>
			<asp:TextBox ID="FldName" runat="server" Text='<%# Bind("Name") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="The <b>Name</b> is missing."
				ControlToValidate="FldName" Display="None" SetFocusOnError="True" />
			<div class="fld req">
				Type:</div>
			<asp:DropDownList ID="FldMethodTypeId" runat="server" CssClass="txt" DataSourceID="ObjectMethodTypes"
				DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" SelectedValue='<%# Bind("MethodTypeId") %>'>
				<asp:ListItem></asp:ListItem>
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="ReqMethodTypeId" ControlToValidate="FldMethodTypeId"
				Display="None" ErrorMessage="The <b>Type</b> is missing." runat="server" SetFocusOnError="True" />
			<div class="fld req">
				Select:</div>
			<asp:TextBox ID="FldSelect" runat="server" Text='<%# Bind("Select") %>' CssClass="txt" />
			<asp:RequiredFieldValidator ID="ReqSelect" runat="server" ErrorMessage="The <b>Select</b> is missing."
				ControlToValidate="FldSelect" Display="None" SetFocusOnError="True" />
			<div class="fld">
				Script:</div>
			<asp:TextBox ID="FldScript" runat="server" Text='<%# Bind("Script") %>' Rows="12"
				TextMode="MultiLine" CssClass="txt" />
			<div class="fld">
				Script Url:</div>
			<div style="position: relative">
			<asp:TextBox ID="FldScriptUrl" runat="server" Text='<%# Bind("ScriptUrl") %>' CssClass="txt" />
			<div style="position: absolute; top: 2px; right: 2px;"><asp:Button ID="BtnReadScriptUrl" runat="server" CssClass="btn" Text="Read" OnClick="BtnReadScriptUrl_Click" /></div></div>
			
			<div id="Buttons">
				<asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn" CommandName="Update" />
			</div>
			
			<div style="border: solid 1px #ccc; padding: 8px;">
				<div style="float: right"><asp:Literal ID="TestResponse" runat="server" /></div>
				<div class="fld">
					iqid:</div>
					<asp:TextBox ID="FldIqid" runat="server" />
				<div class="fld">
					password:</div>
					<asp:TextBox ID="FldPassword" runat="server" />
				<div class="fld">
					owneriqid:</div>
					<asp:TextBox ID="FldOwnerIqid" runat="server" />
					<asp:Button ID="BtnTest" runat="server" Text="Test" OnClick="BtnTest_Click" />
			</div>
		</EditItemTemplate>
        <ItemTemplate>
            (item template)
        </ItemTemplate>
	</asp:FormView>
	
	<asp:ObjectDataSource ID="ObjectMethodTypes" runat="server" SelectMethod="DbFindAll"
		TypeName="Commanigy.Iquomi.Data.DbMethodType" />
	
	<asp:ObjectDataSource ID="ObjectSource" runat="server" DataObjectTypeName="Commanigy.Iquomi.Data.DbServiceMethod"
		InsertMethod="DbCreate" UpdateMethod="DbUpdate" SelectMethod="DbRead" TypeName="Commanigy.Iquomi.Data.DbServiceMethod"
		OnUpdating="ObjectSource_Updating" OnInserting="ObjectSource_Inserting" OnInserted="ObjectSource_Inserted"
		OnUpdated="ObjectSource_Updated">
		<SelectParameters>
			<iq:SecureQueryStringParameter Type="Int32" Name="Id" QueryStringField="ServiceMethod.Id" />
		</SelectParameters>
	</asp:ObjectDataSource>
</div>