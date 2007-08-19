<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.SdkPage" CodeFile="sdk.aspx.cs"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContentArea" Runat="server">
    The Iquomi Software Development Kit (SDK) provides you with the ability to implement your
    own services.
    <p>
        An example of querying your "iqFavorites" service may look like:
    </p>
    <pre class="code">Service myService = this.PluginHost.GetService("iqFavorites", "username");

QueryRequestType q = new QueryRequestType();
XpQueryType query = new XpQueryType();
query.Select = "/m:IqFavorites/m:Favorite";
query.MinOccurs = 1;
q.XpQueries = new XpQueryType[] { query };

QueryResponseType response = myService.Query(q);
if (response.XpQueryResponses[0].Status != ResponseStatus.Success) {
  Console.WriteLine("Not possible to get favorites");
}

Console.WriteLine(
  "Found {0} favorite(s)",
  response.XpQueryResponses[0].Items.Length
  );
  
FavoriteType favorite = (FavoriteType)response.XpQueryResponses[0].Items[0];
Console.WriteLine("First one named: {0}", favorite.Title);
	</pre>
</asp:Content>