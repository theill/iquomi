<%@ Import Namespace="Commanigy.Iquomi.Data" %>
<%@ Import Namespace="Commanigy.Iquomi.Ui" %>
<%@ Register TagPrefix="iq" Namespace="Commanigy.Iquomi" Assembly="Commanigy.Iquomi" %>

<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.PackagesPage" CodeFile="packages.aspx.cs"
	MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" runat="server">
	<div id="ContentDescription">
		Your list of available packages.
	</div>
	<iq:IqGridView ID="GvPackages" runat="server" DataSourceID="ObjectDataSource1">
		<Columns>
			<asp:imagefield dataimageurlfield="ServiceUrlIcon">
				<headerstyle cssclass="mark" width="16px" />
			</asp:imagefield>
			<asp:templatefield headertext="Name" sortexpression="ServiceName">
				<itemtemplate>
					<a href='<%# Link("package.read.aspx", new object[] { Eval("PackageId") }) %>'><%# Eval("ServiceName") %></a></itemtemplate>
			</asp:templatefield>
			<asp:boundfield headertext="Version" datafield="PackageVersion" sortexpression="PackageVersion" />
			<asp:boundfield headertext="Platform" datafield="PackagePlatformName" sortexpression="PackagePlatformName" />
			<asp:boundfield headertext="Release Date" datafield="PackageReleaseDate" dataformatstring="{0:u}"
				sortexpression="PackageReleaseDate" />
			<asp:templatefield headertext="State">
				<itemtemplate>
<%# DbUiHelper.ToPackageState((string)Eval("PackageState")) %>
</itemtemplate>
			</asp:templatefield>
			<asp:templatefield headertext="Total Size" sortexpression="PackageSize">
				<itemtemplate>
<%# DbUiHelper.ToFileSize((long)Eval("PackageSize")) %>
</itemtemplate>
			</asp:templatefield>
		</Columns>
	</iq:IqGridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Commanigy.Iquomi.Data.DbPackage"
		SelectMethod="DbFindAllByAuthorId">
		<SelectParameters>
			<asp:ProfileParameter Name="authorId" Type="Int32" PropertyName="AuthorId" />
			<asp:ProfileParameter Name="languageId" Type="Int32" PropertyName="LanguageId" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>
