<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="myVoices.myVoices" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>myVoices</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<H1>myVoices</H1>
<H2>.NET My Services (Hailstorm)&nbsp;and VoiceXML 
(VXML)</H2>
<P><A 
href="http://www.brains-N-brawn.com/myVoices">http://www.brains-N-brawn.com/myVoices</A> 
1/18/02 <A href="mailto:casey@brains-N-brawn.com">casey chesnut</A></P>
<H3>Introduction</H3>
<P>Can you say bleeding edge. myVoices is an ASP.NET 
VoiceXml interface that integrates to .NET My Services.</P>
<P>Came up with the idea because I have been specializing 
in Web Services and Wireless Development ... throw in 'idle handedness' because 
I am not currently on contract (hint hint&nbsp;-&gt; <A 
href="http://www.brains-N-brawn.com">resume</A>) and I 
decided to combine the 2. Had previously taught myself how to do VoiceXml in 
.NET back in November, and had been kicking around the .NET My Services SDK 
since xmas. The results of that previous work can be found here:</P>
<UL>
  <LI><A href="http://www.brains-n-brawn.com/vxml" 
  >Previous VoiceXml in .NET work</A> (Somebody wrote a 
  couple days ago, and this is still the only resource for VXML in .NET) 
  <LI><A href="http://65.116.26.5/hsPostWeb" 
  >Previous .NET My Services work</A> (An ip, because I am 
  not prepared to put the .NET My Services SDK on my server)</LI></UL>
<P>I used these wrox 'early adopter' books, as well as the 
MS press .NET My Services specification to teach myself</P>
<P align=center><IMG alt="" src="eaHailStorm.gif" >&nbsp;<IMG alt="" src="msMyServices.jpg" >&nbsp;<IMG alt="" src="eaVoiceXml.gif" ></P>
<H3 align=left>Usage</H3>
<P align=left>This is a typical scenario of a user 
interacting with myVoices</P>
<OL>
  <OL>
  <LI>
  <DIV align=left>USER: gets out their cell phone and dials 
  a phone # to access the app: </DIV>
  <OL>
    <LI>
    <DIV align=left>BeVocal Phone # 1.877.33VOCAL (86225) 
    </DIV></LI></OL>
  <LI>
  <DIV align=left>APP: Please enter your pin.</DIV>
  <LI>
  <DIV align=left>USER: 1 2 3 4 (I typically key this 
  in)</DIV>
  <LI>
  <DIV align=left>APP: What is your Account ID?</DIV>
  <LI>
  <DIV align=left>USER: 6 6 6 1 2 3 4 (I typically speak 
  this out loud)</DIV>
  <LI>
  <DIV align=left>APP: What is your Passport User ID?</DIV>
  <LI>
  <DIV align=left>USER: 3 8 1 9 (this is the only id i have provisioned for, any 
  other # will fail)</DIV>
  <LI>
  <DIV align=left>APP: Prompts with a&nbsp;menu of 
  applications</DIV>
  <OL>
    <LI>
    <DIV align=left>Say Time or Press 1 (this just returns 
    the time on my server in TX)</DIV>
    <LI>
    <DIV align=left>Say Jokes or Press 2 (this goes to my 
    1st VoiceXml app which tells knock knock jokes)</DIV>
    <LI>
    <DIV align=left>Say myVoices or Press 3 (this is the 
    integration with .NET My Services)</DIV></LI></OL>
  <LI>
  <DIV align=left>USER: myVoices</DIV>
  <LI>
  <DIV align=left>APP: Prompts with the myVoices menu</DIV>
  <OL>
    <LI>
    <DIV align=left>Say Favorites or Press 1 
    (myFavoriteWebSites)</DIV>
    <LI>
    <DIV align=left>Say Lists or Press 2 (myLists)</DIV>
    <LI>
    <DIV align=left>Say Contacts or Press 3 
    (myContacts)</DIV>
    <LI>
    <DIV align=left>Say Calendar or Press 4 
    (myCalendar)</DIV>
    <LI>
    <DIV align=left>Say Inbox or Press 5 (myInbox) - NOTE: 
    not implemented in this drop of SDK</DIV></LI></OL>
  <LI>
  <DIV align=left>USER: Lists</DIV>
  <LI>
  <DIV align=left>APP: Choose your list (These are your 
  .NET myLists)</DIV>
  <OL>
    <LI>
    <DIV align=left>ToDo</DIV>
    <LI>
    <DIV align=left>Groceries</DIV></LI></OL>
  <LI>
  <DIV align=left>USER: To Do</DIV>
  <LI>
  <DIV align=left>APP: Your items are workout, code, find 
  work.</DIV>
  <LI>
  <DIV align=left><STRONG>Repeat Step 
  8 and choose a different myService</STRONG></DIV></LI></OL></OL>
<P align=left>NOTE: I have little-to-no exception handling 
in this, happy-day scenario only, so it is brittle and easy to break</P>
<H3 align=left>Prerequisites</H3>
<P align=left>To do this, the following were 
used/needed:</P>
<UL>
  <LI>
  <DIV align=left>Win 2K Server</DIV>
  <LI>
  <DIV align=left>.NET My Services SDK Technical Preview (request it at <A 
  href="http://msdn.microsoft.com/netmyservices">http://msdn.microsoft.com/netmyservices</A>&nbsp;)</DIV>
  <LI>
  <DIV align=left>SQL Server 2K</DIV>
  <LI>
  <DIV align=left>VS.NET RC0</DIV>
  <LI>
  <DIV align=left>Motorola Mobile ADK for voice (see my previous VXML work link 
  above)</DIV>
  <LI>
  <DIV align=left>BeVocal developer account</DIV>
  <LI>
  <DIV align=left>Cell phone (wireless web is not needed, this is 
  different)</DIV></LI></UL>
<H3 align=left>Components</H3>
<P align=left>This layout should help you understand the different pieces of 
code I will be talking about later on, and what all is happening</P>
<P align=center><IMG alt="" src="myVoiceComponent.jpg" ></P>
<UL>
  <LI>
  <DIV align=left>Cell Phone- this is the browser. NOTE: this is not Wireless 
  Web. You do not use any sort of graphical browser; instead, you browse with 
  your voice</DIV>
  <LI>
  <DIV align=left>BeVocal Gateway - this service is provided free of charge to 
  developers like me. It supports the speech-to-text of user-to-app, the 
  fetching of VoiceXml pages from my server, and text-to-speech of 
  app-to-user</DIV>
  <LI>
  <DIV align=left>myVoices ASP.NET VoiceXml Web Application - this is the 
  application interface I coded which tells the BeVocal Gateway how to 
  interact/respond with/to the user, requests data from the .NET My Services, 
  and formats those responses into VXML instead of HTML pages</DIV>
  <LI>
  <DIV align=left>hsProxy Class Libary - created this as a proxy to wrap common 
  interactions with .NET My Services SDK</DIV>
  <LI>
  <DIV align=left>HsSoapExtension - project provided by MS to create the SOAP 
  header used when communication with .NET My Services</DIV>
  <LI>
  <DIV align=left>ServiceLocator - another project provided by MS which uses a 
  PUID to see if a user is provisioned for a service</DIV>
  <LI>
  <DIV align=left>my*WebReferences - the hsProxy Class Library has a web ref to 
  every .NET My Services SDK, so I do not have to add all of them to every 
  project I want to use the .NET My Services in ... just do it once</DIV>
  <LI>
  <DIV align=left>.NET My Services Tech Preview - this is the instance of 
  Hailstorm which is running on my local box, since they are not public on MS 
  servers yet</DIV>
  <LI>
  <DIV align=left>SQL Server - check out what happens in here, some cool 
  stuff</DIV></LI></UL>
<P align=left>Physically, my cell phone could be anywhere. I have no clue where 
the BeVocal Gateway is, nor do I care. The web pages from the /vxml app are on 
my server about 15 feet away, while the myVoices application is on my devbox 15 
inches away (if I get bored, I will&nbsp;move this piece over to my server). The 
.NET My Services are also on my devbox, because they are running locally for the 
technical preview; but ultimately they will be somewhere in MS land</P>
<H3 align=left>Pages</H3>
<P align=left>Different pages the application is composed of, which I will talk 
about in more detail</P>
<P align=center><IMG alt="" src="myVoicePage.jpg" ></P>
<P align=left>The 1st 3 pages (top-left) with the /vxml in them are all from my 
previous VoiceXml misadventures (see the link above). The only change is that 
the MENU page now has a 3rd option which redirects to the PUID page of myVoices. 
PUID asks the user for their Passport User ID (which is always 3819 in this 
case). Then it redirects to the SERVICES page which has a menu for selecting 
which .NET My Service you want to interact with. These 5 (FAVORITES, LISTS, 
CONTACTS, CALENDAR, and INBOX) were the logical ones I could think of. INBOX is 
not implemented, because it is not implemented in the .NET My Services SDK, 
which is odd, because it seems like it would be much simpler than the myCalendar 
service</P>
<H3 align=left>Process</H3>
<P align=left>We are almost to the good stuff, I think this is the last section 
for you to suffer through. Regardless, this is how I worked on it. It is 
currently 11 PM 1/18/02, and believe it or not, I came up with this whole idea 
yesterday around 4 PM. So if you have any problems with my code, or the projects 
incompleteness, take into consideration that the whole software lifecycle (minus 
documentation, which is being done now) took less than 24 hours; including 
minimal sleep and a couple trips to the gym. Development ended up being 
relatively easy, much easier than expected. The only tricky being that ASP.NET 
does not natively support VoiceXml, as well as the .NET MyServices SDK being a 
technical preview.</P>
<P align=left>First, I have a test.vxml page in my project, which is nothing but 
an XML page in VoiceXml format. I would make a test page for each of the pages 
above, and then test to see that it interacted properly as a VoiceXml doc. To 
test a VXML, there are 3 steps. 1st, make sure it is valid XML, by opening in 
IE. 2nd, you can use Motorolas Mobile ADK for Voice (see my previous /vxml) 
which lets you test the page with a keyboard or microphone. 3rd, you can call in 
with your phone, to make sure the Voice Gateway can handle it; although I did 
not do this until the end ... and felt the Mobile ADK was good enough of a test 
at this point. So with this test.vxml page I know had the presentation mocked 
up, which I would transfer to a corresponding ASP.NET page. You have to rip all 
the auto-generated HTML out of the aspx pages, the code-behing page declaration 
can stay, since it will not get rendered</P>
<P align=left>Second, I had to insert some data into the .NET My Services that I 
could eventually pull out. NOTE: myVoice only reads from .NET myServices; 
programatically it is cake to insert data, but doing this over the phone would 
be challenging and would be quite frustrating. Of course, it took me a couple 
steps to get data into .NET My Services as well. 1st, I would create a 
my*Insert.xml file and use their command line hsPost.exe to try and insert the 
data. This utility was great because it gives good error info as to what is 
wrong with the format of your request; e.g. how it does not match the schema. So 
between the schema, hsPost error info, and brute force trial-and-error I would 
get some data inserted. Which brings up how hsPost sucks, in that it is command 
line. So once I had a valid insert, I would take that xml, and shove it in my 
hsPostWeb ASP.NET app. Its an app I created a couple weeks ago, which is 
basically a web version of hsPost ... duh. So I would modify the xml, and was 
able to work with it more easily in this environment. After the final insert 
statement was created, I would do the same process for querying the data, and 
then for deleting. When I could do these steps, I would clean out the data, and 
do one final insert of clean data</P>
<P align=left>Third, now that I had clean data to go against, I could pull it 
out. Since all of the work in step 2 was XML, I felt like going back to 
old-school object oriented development (have you heard the term schema-oriented 
development yet ... i like it). This was my 1st foray into interacting with the 
.NET My Services and the lightweight objects that VS.NET creates through the 
WSDL. I must say it is way too easy. Keep kicking ass MS. Since, I already knew 
what the queries needed to look like in XML, it was trivial to recreate that as 
an object which would get serialized to be the same ... especially with 
intellisense</P>
<P align=left>Fourth, now that I had the data pulled out of the .NET My 
Services, all I had to do was serialize it into the same XML format that was 
needed for the VXML pages I had already mocked up. You'll see this code later 
on, in which I create an XML doc, add the appropriate elements, attributes, and 
values; and then just grab that XML and render directly into the middle of the 
aspx pages, which render as VXML, instead of HTML</P>
<P align=left>Finally, I tested. 1st, with IE to make sure I had valid XML. 2nd, 
with the Mobile ADK, which I cannot say how invaluable it is for doing VoiceXml. 
The only complaint is that it depends on a Java (spit) runtime, which I 
begrudgingly installed with disgust. I made an ugly face when I installed it, 
trust me. I am making an ugly face now ... 3rd, I busted out my cell phone, 
called up BeVocal, and started talking to .NET My Services :)</P>
<H3 align=left>Development</H3>
<P align=left>Now I will go step-by-step and page-by-page&nbsp;through what is 
happening in the myVoice application. I developed the pages in order of 
perceived difficulty. Favorites being the easiest, then Lists, then Contacts, 
and finally Calendar as the hardest. Inbox being unimplementable (you are 
allowed to make up words as a software engineer).</P>
<H5 align=left><EM>GlobalPage.cs</EM></H5>
<P align=left>Made all .aspx pages inherit from GlobalPage.cs. GlobalPage.cs 
inherits from System.Web.UI.Page as expected. I use this page to avoid some code 
duplication that I would have across all the pages. It has no presentation 
associated with it</P>
<H5 align=left><EM>puid.aspx </EM><A 
href="puid.vxml">puid.vxml</A></H5>
<P align=left>Has no codebehind associated with it, it is 
pure VXML.&nbsp;All it does is prompt the user for their Passport User ID, and then posts this data to services.aspx </P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>&lt;?xml version="1.0" ?&gt;
&lt;vxml version="1.0"&gt;
	&lt;form id="form"&gt;
		&lt;field name="puid" type="digits"&gt; 
		   &lt;prompt&gt; 
		      Welcome to my Voice. What is your Passport User I D? 
		   &lt;/prompt&gt; 
		   &lt;filled&gt; 
		      &lt;submit next= "services.aspx" method="post" namelist= "puid" /&gt;
			&lt;/filled&gt;
			&lt;noinput&gt;
			   No input. 
			&lt;/noinput&gt; 
			&lt;nomatch&gt; 
			   No match.
			&lt;/nomatch&gt;
			&lt;help&gt; 
			   Help. What is your Passport User I D?
			&lt;/help&gt;
		&lt;/field&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H5 align=left><EM>services.aspx</EM> <A 
href="services.vxml">services.vxml</A></H5>
<P align=left>On pageLoad, its codeBehind&nbsp;sets a 
session variable "puid"&nbsp;using the value passed from puid.aspx. This PUID is needed later 
on</P>
<P align=left>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><pre>Session["puid"] = Request["puid"];</pre></BLOCKQUOTE>
<P dir=ltr>After that, the page is just a menu&nbsp;to direct the user to one of 
the following my*Service pages</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;vxml version="1.0"&gt;
	&lt;var name="puid" type="number"/&gt;
	&lt;menu&gt;
		&lt;prompt&gt;
			Choose.
			&lt;enumerate /&gt;
		&lt;/prompt&gt;
		&lt;choice dtmf="1" next="favorites.aspx"&gt;
			Favorites&lt;/choice&gt;
		&lt;choice dtmf="2" next="lists.aspx"&gt;
			Lists&lt;/choice&gt;
		&lt;choice dtmf="3" next="contacts.aspx"&gt;
			Contacts&lt;/choice&gt;
		&lt;choice dtmf="4" next="calendar.aspx"&gt;
			Calendar&lt;/choice&gt;
		&lt;choice dtmf="5" next="inbox.aspx"&gt;
			Inbox&lt;/choice&gt;
		&lt;noinput&gt;
			No input, Choose.
			&lt;enumerate /&gt;
		&lt;/noinput&gt;
		&lt;nomatch&gt;
			No match, Choose.
			&lt;enumerate /&gt;
		&lt;/nomatch&gt;
		&lt;help&gt;
			Help, Choose.
			&lt;enumerate /&gt;
		&lt;/help&gt;
	&lt;/menu&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<P></P>
<P align=left></P>
<H4 align=left><U>Favorites</U></H4>
<OL>
  <LI>
  <DIV align=left>USER: Favorites</DIV>
  <LI>
  <DIV align=left>APP: Choose a web site: brains-N-brawn, D N U G</DIV>
  <LI>
  <DIV align=left>USER: brains-N-brawn</DIV>
  <LI>
  <DIV align=left>APP: The url is <A 
  href="http://www.brains-N-brawn.com">http://www.brains-N-brawn.com</A></DIV></LI></OL>
<P align=left>The requests to insert, query, and delete&nbsp;data look like 
this:</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>&lt;insertRequest select="/" xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;favoriteWebSite xmlns="http://schemas.microsoft.com/hs/2001/10/myFavoriteWebSites"&gt;
      &lt;cat ref="system" /&gt;
      &lt;title xml:lang="en"&gt;brains-N-brawn.com&lt;/title&gt;
      &lt;url&gt;http://www.brains-N-brawn.com&lt;/url&gt;
   &lt;/favoriteWebSite&gt;
&lt;/insertRequest&gt;

&lt;queryRequest xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;xpQuery select="/m:myFavoriteWebSites/m:favoriteWebSite" /&gt;
&lt;/queryRequest&gt;

&lt;deleteRequest select="/m:myFavorites/m:favoriteWebSite" xmlns="http://schemas.microsoft.com/hs/2001/10/core" /&gt;</PRE></BLOCKQUOTE>
<H5 align=left><EM>favorites.aspx </EM><A 
href="favorites.vxml">favorites.vxml</A></H5>
<P align=left>Here is what happens in the codeBehind on pageLoad:</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>hsProxy.hsProxy hsp = new hsProxy.hsProxy();
int puid = GetPuid(); 
myFavoriteWebSites myFav = (myFavoriteWebSites) hsp.GetMyService(typeof(myFavoriteWebSites), puid);</PRE></BLOCKQUOTE>
<P>These lines create an instance of my hsProxy class library. It also gets the 
PUID from the session which we saved earlier. GetPuid() is a method of the 
GlobalPage class. A PUID and the my*Service type are needed by the 
ServiceLocator object to get a proxy object to make SOAP requests against a 
my*Service. GetMyService() is just a small method in my hsProxy class that keeps 
the myVoice application from having to know about the ServiceLocator project. In 
the end, I have an instance of a proxy object to make calls against the .NET 
myFavorites service</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>queryRequestType queryRequest = new queryRequestType();
xpQueryType xpQuery = new xpQueryType();
xpQuery.select="/m:myFavoriteWebSites/m:favoriteWebSite";
queryRequest.xpQuery = new xpQueryType[]{xpQuery};
queryResponseType queryResponse = myFav.query(queryRequest);
queryResponseTypeXpQueryResponse xqr = queryResponse.xpQueryResponse[0];
</PRE></BLOCKQUOTE>
<P>This block creates an instance of queryRequest type. It then creates an 
xpQueryType with an xPath expression and associates it with the queryRequest. 
Finally the myFav proxy object, has its query method called with the query 
instance to get the response. If you serialized the queryRequest object, it 
would look very similar to the XML queryRequests I used against hsPost.exe 
above. Note the xPath expression 
'/m:myFavoriteWebSites/m:favoriteWebSite'&nbsp;will return every favoriteWebSite 
the user has in the myFavorites service</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>XmlDocument xd = new XmlDocument();
XmlElement root = xd.CreateElement("root");
xd.AppendChild(root);
int dtmf = 1;
foreach(favoriteWebSiteType fwst in xqr.Items)
{
	XmlElement xe = xd.CreateElement("option");
	XmlAttribute xa1 = xd.CreateAttribute("dtmf");
	xa1.Value = dtmf.ToString();
	dtmf++; //iter for next element
	XmlAttribute xa2 = xd.CreateAttribute("value");
	xa2.Value = fwst.url;
	xe.Attributes.Append(xa1);
	xe.Attributes.Append(xa2);
	xe.InnerText = fwst.title[0].Value;
	root.AppendChild(xe);
}
result = root.InnerXml;</PRE></BLOCKQUOTE>
<P>This block is used to iterate through the results, and create an Xml Fragment 
that can be serialized into the appropriate VoiceXml format. The above will 
serialize into the 2 &lt;option&gt; elements that appear below within the middle 
of the document. The 'result' string, is bound to the page through this syntax 
&lt;%=GetResult()%&gt;. The GetResult() method is part of the GlobalPage 
class</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>&lt;vxml version="1.0"&gt;
	&lt;form id="form"&gt;
		&lt;field name="url"&gt;
			&lt;prompt&gt;
				Choose a web site &lt;enumerate /&gt;
			&lt;/prompt&gt;
			&lt;option dtmf="1" value="http://www.brains-n-brawn.com"&gt;brains-n-brawn&lt;/option&gt;
			&lt;option dtmf="2" value="http://www.dnug.net"&gt;D N U G&lt;/option&gt;
			&lt;filled&gt;
				&lt;prompt&gt;
					the url is &lt;value expr="url" /&gt;
				&lt;/prompt&gt;
				&lt;goto next="services.aspx" /&gt;
			&lt;/filled&gt;
		&lt;/field&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H4 align=left><U>Lists</U></H4>
<OL>
  <LI>
  <DIV align=left>USER: Lists</DIV>
  <LI>
  <DIV align=left>APP: Choose a list: To Do, Groceries</DIV>
  <LI>
  <DIV align=left>USER: To Do</DIV>
  <LI>
  <DIV align=left>APP: The items in the list are: workout, find work, 
  code</DIV></LI></OL>
<P align=left>The requests to insert, query, and delete&nbsp;data look like 
this:</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>
&lt;insertRequest select="/" xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;list idName="to do" xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;to do&lt;/title&gt;
   &lt;/list&gt;
   &lt;list idName="grocery" xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;grocery&lt;/title&gt;
   &lt;/list&gt;
&lt;/insertRequest&gt;</PRE></BLOCKQUOTE>
<P dir=ltr>NOTE: I did multiple inserts with one insertRequest above. Also, NOTE 
that list and item elements live at the same level in the schema, so that you 
have to associate them with an ID, instead of with heirarchy, like the other 
services demonstrated here. When I inserted the above, I got the following IDs 
for each list. So I used those same IDs when inserting items into the lists. 
</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;m:list idName="to do" id="D0FF71AF-74F4-4D60-A1E5-718A5B5B04A8"&gt;
&lt;m:list idName="grocery" id="9CA876CA-0B8C-454B-B6F7-EDA428FDC441"&gt;

&lt;insertRequest select="/" xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;item xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;workout&lt;/title&gt;
      &lt;listRef order="1" ref="D0FF71AF-74F4-4D60-A1E5-718A5B5B04A8"/&gt;
   &lt;/item&gt;
   &lt;item xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;get a job&lt;/title&gt;
      &lt;listRef order="2" ref="D0FF71AF-74F4-4D60-A1E5-718A5B5B04A8"/&gt;
   &lt;/item&gt;
   &lt;item xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;code&lt;/title&gt;
      &lt;listRef order="3" ref="D0FF71AF-74F4-4D60-A1E5-718A5B5B04A8"/&gt;
   &lt;/item&gt;
   &lt;item xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;milk&lt;/title&gt;
      &lt;listRef order="1" ref="9CA876CA-0B8C-454B-B6F7-EDA428FDC441"/&gt;
   &lt;/item&gt;
   &lt;item xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;cereal&lt;/title&gt;
      &lt;listRef order="2" ref="9CA876CA-0B8C-454B-B6F7-EDA428FDC441"/&gt;
   &lt;/item&gt;
   &lt;item xmlns="http://schemas.microsoft.com/hs/2001/10/myLists"&gt;
      &lt;title xml:lang="en"&gt;v8 juice&lt;/title&gt;
      &lt;listRef order="3" ref="9CA876CA-0B8C-454B-B6F7-EDA428FDC441"/&gt;
   &lt;/item&gt;
&lt;/insertRequest&gt;

&lt;queryRequest xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;xpQuery select="/m:myLists/m:list" /&gt;
   &lt;xpQuery select="/m:myLists/m:item[./m:listRef/@ref='9CA876CA-0B8C-454B-B6F7-EDA428FDC441']" /&gt;
&lt;/queryRequest&gt;

&lt;deleteRequest select="/m:myLists/m:list" xmlns="http://schemas.microsoft.com/hs/2001/10/core" /&gt;
&lt;deleteRequest select="/m:myLists/m:item" xmlns="http://schemas.microsoft.com/hs/2001/10/core" /&gt;</PRE></BLOCKQUOTE>
<H5 dir=ltr><EM>lists.aspx </EM><A 
href="lists.vxml">lists.vxml</A></H5>
<P dir=ltr>This page is generated the same as favorites.aspx. The only 
difference being that we use a myLists proxy object, the xPath expression 
changes, and the resulting lightweight objects we iterate through relate to the 
myLists schema. The value attrib's 'value' is the ID that is used to find which 
items belong to which list. That value is posted to the items.aspx page</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;vxml version="1.0"&gt;
	&lt;form id="form"&gt;
		&lt;field name="list"&gt;
			&lt;prompt&gt;
				Choose a list &lt;enumerate /&gt;
			&lt;/prompt&gt;
			&lt;option dtmf="1" value="36958F80-6A39-4A1C-8110-029CFEA84A43"&gt;to do&lt;/option&gt;
			&lt;option dtmf="2" value="DECDFEA0-8B9A-4402-9C90-0D7AD8B3AB20"&gt;grocery&lt;/option&gt;
			&lt;filled&gt;
				&lt;submit next="items.aspx" method="post" namelist="list" /&gt;
			&lt;/filled&gt;
		&lt;/field&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H5 dir=ltr><EM>items.aspx</EM> <A 
href="items.vxml">items.vxml</A></H5>
<P dir=ltr>This page receives the ID for the list, and uses the myLists proxy 
object to query with this xPath expression: 
'/m:myLists/m:item[./m:listRef/@ref='" + listId + "']'. This will only return 
the items for the specified list. Also, instead of serializing to &lt;option&gt; 
elements, they are serialized to &lt;prompt&gt; elements, which simply read them 
out loud, instead of being an option for a user response</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;vxml version="1.0"&gt;
	&lt;form id="form"&gt;
		&lt;block&gt;
			&lt;prompt&gt;
				The items in the list are
			&lt;/prompt&gt;
			&lt;prompt&gt;workout&lt;/prompt&gt;
			&lt;prompt&gt;get a job&lt;/prompt&gt;
			&lt;prompt&gt;code&lt;/prompt&gt;
			&lt;goto next="services.aspx" /&gt;
		&lt;/block&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H4 align=left><U>Contacts</U></H4>
<OL>
  <LI>
  <DIV align=left>USER: Contacts</DIV>
  <LI>
  <DIV align=left>APP: What is the 1st letter of their first or last 
  name?</DIV>
  <LI>
  <DIV align=left>USER: 'c'</DIV>
  <LI>
  <DIV align=left>APP: Choose a contact: Casey Chesnut</DIV>
  <LI>
  <DIV align=left>USER: Casey Chesnut</DIV>
  <LI>
  <DIV align=left>APP: &nbsp;Their info is: email: casey@brains-N-brawn.com 
  phone: 2142821556 </DIV></LI></OL>
<P align=left>NOTE: it reads my phone # as 2 billion 142 million 821 thousand 
and 556. There is a VoiceXml &lt;sayas&gt; element that could be used to make it 
read it as a phone number</P>
<P align=left>The requests to insert, query, and 
delete&nbsp;data look like this. This one ended up being tricky because the 
namespaces on the elements kept varying from being in the myContacts schema, to the myProfile 
schema</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>&lt;insertRequest select="/" xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;contact synchronize="no" xmlns="http://schemas.microsoft.com/hs/2001/10/myContacts"&gt;
      &lt;name&gt;
         &lt;givenName xml:lang="en" xmlns="http://schemas.microsoft.com/hs/2001/10/myProfile"&gt;casey&lt;/givenName&gt;
         &lt;surname xml:lang="en" xmlns="http://schemas.microsoft.com/hs/2001/10/myProfile"&gt;chesnut&lt;/surname&gt;
      &lt;/name&gt;
      &lt;emailAddress&gt;
         &lt;email xmlns="http://schemas.microsoft.com/hs/2001/10/myProfile"&gt;casey@brains-N-brawn.com&lt;/email&gt;
      &lt;/emailAddress&gt;
      &lt;screenName&gt;
         &lt;name xml:lang="en" xmlns="http://schemas.microsoft.com/hs/2001/10/myProfile"&gt;kcchesnut@hotmail.com&lt;/name&gt;
      &lt;/screenName&gt;
      &lt;telephoneNumber&gt;
         &lt;nationalCode xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;214&lt;/nationalCode&gt;
         &lt;number xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;2821556&lt;/number&gt;
      &lt;/telephoneNumber&gt;
   &lt;/contact&gt;
&lt;/insertRequest&gt;

//value
&lt;queryRequest 
  xmlns="http://schemas.microsoft.com/hs/2001/10/core" 
  xmlns:mc="http://schemas.microsoft.com/hs/2001/10/myContacts"
  xmlns:mp="http://schemas.microsoft.com/hs/2001/10/myProfile"&gt;
     &lt;xpQuery select="/mc:myContacts/mc:contact" /&gt;
     &lt;xpQuery select="/mc:myContacts/mc:contact[./mc:name/mp:surname='chesnut']" /&gt;
&lt;/queryRequest&gt;</PRE></BLOCKQUOTE>
<P dir=ltr>NOTE:&nbsp;the following query is what I should have done in my code, 
but the .NET My Services SDK does not currently support searches by substring. 
So in my code, I query for all contacts, and then programatically iterate 
through them, doing the search</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>//substring
&lt;queryRequest 
  xmlns="http://schemas.microsoft.com/hs/2001/10/core" 
  xmlns:mc="http://schemas.microsoft.com/hs/2001/10/myContacts"
  xmlns:mp="http://schemas.microsoft.com/hs/2001/10/myProfile"&gt;
     &lt;xpQuery select="/mc:myContacts/mc:contact[substring(string(./mc:name/mp:surname),1,1) = 'c']" /&gt;
&lt;/queryRequest&gt;

&lt;deleteRequest select="/m:myContacts/m:contact" xmlns="http://schemas.microsoft.com/hs/2001/10/core" /&gt;</PRE></BLOCKQUOTE>
<H5 dir=ltr><EM>contacts.aspx </EM><A 
href="contacts.vxml">contacts.vxml</A></H5>
<P dir=ltr>This page has no codeBehind associated with it. It is pure VXML. All 
it does is prompt the user, and then get a single letter response, and then post 
that to the next page</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;vxml version="1.0"&gt;
	&lt;form id="form"&gt;
		&lt;field name="letter"&gt;
			&lt;prompt&gt;
				What is the 1st letter of their first or last name?
			&lt;/prompt&gt;
			&lt;grammar type="application/x-gsl"&gt;
				[a b c d e f g h i j k l m n o p q r s t u v w x y z]&lt;/grammar&gt;
			&lt;filled&gt;
				&lt;submit next="rolodex.aspx" method="post" namelist="letter" /&gt;
			&lt;/filled&gt;
		&lt;/field&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H5 dir=ltr><EM>rolodex.aspx </EM><A 
href="rolodex.vxml">rolodex.vxml</A></H5>
<P dir=ltr>This page receives the letter, and here is where it should to the 
substring search query I noted above. But since that does not currently work, 
and hacking is fun, I just grab all the contacts, iterate through them, and toss 
out the ones that do not start with the letter the user specified. Instead of 
just being a &lt;prompt&gt; element, I use &lt;option&gt; because their could be 
multiple people that have a first or last name that starts with the same name 
obviously. Wanted this one to do a search though, unlike the Favorites example 
above, to make it more complicated, and you certainly would not return an entire 
person's contact list</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;vxml version="1.0"&gt;
	&lt;form id="form"&gt;
		&lt;field name="info"&gt;
			&lt;prompt&gt;
				Choose a contact&lt;enumerate /&gt;
			&lt;/prompt&gt;
			&lt;option dtmf="1" value="email: casey@brains-N-brawn.com phone: 2142821556"&gt;casey chesnut&lt;/option&gt;
			&lt;filled&gt;
				&lt;prompt&gt;
					their info is &lt;value expr="info" /&gt;
				&lt;/prompt&gt;
				&lt;goto next="services.aspx" /&gt;
			&lt;/filled&gt;
		&lt;/field&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H4><U>Calendar</U></H4>
<OL>
  <LI>USER: Calendar 
  <LI>APP: Your appointments are: dallas .NET user group meeting on 1/17/2002, 
  get oil changed on 1/18/2002, haircut on 1/19/2002, hot date on 
1/20/2002</LI></OL>
<P>NOTE: the date is hardcoded to always return these. It should really allow 
the user to specify dates or a date-range somehow, but that&nbsp;would just be 
grunt work repeating what we have already learned, so I dodged it</P>
<P align=left>The requests to insert, query, and delete&nbsp;data look like 
this:</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>&lt;insertRequest select="/" xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;event xmlns="http://schemas.microsoft.com/hs/2001/10/myCalendar"&gt;
      &lt;body&gt;
         &lt;title xml:lang="en"&gt;get oil changed&lt;/title&gt;
         &lt;startTime&gt;2002-01-18T15:23:17.0000000-07:00&lt;/startTime&gt;
         &lt;endTime&gt;2002-01-18T16:23:17.0000000-07:00&lt;/endTime&gt;
      &lt;/body&gt;
   &lt;/event&gt;
   &lt;event xmlns="http://schemas.microsoft.com/hs/2001/10/myCalendar"&gt;
      &lt;body&gt;
         &lt;title xml:lang="en"&gt;dallas .NET user group meeting&lt;/title&gt;
         &lt;startTime&gt;2002-01-17T15:23:17.0000000-07:00&lt;/startTime&gt;
         &lt;endTime&gt;2002-01-17T16:23:17.0000000-07:00&lt;/endTime&gt;
      &lt;/body&gt;
   &lt;/event&gt;
   &lt;event xmlns="http://schemas.microsoft.com/hs/2001/10/myCalendar"&gt;
      &lt;body&gt;
         &lt;title xml:lang="en"&gt;haircut&lt;/title&gt;
         &lt;startTime&gt;2002-01-19T15:23:17.0000000-07:00&lt;/startTime&gt;
         &lt;endTime&gt;2002-01-19T16:23:17.0000000-07:00&lt;/endTime&gt;
      &lt;/body&gt;
   &lt;/event&gt;
   &lt;event xmlns="http://schemas.microsoft.com/hs/2001/10/myCalendar"&gt;
      &lt;body&gt;
         &lt;title xml:lang="en"&gt;hot date&lt;/title&gt;
         &lt;startTime&gt;2002-01-20T15:23:17.0000000-07:00&lt;/startTime&gt;
         &lt;endTime&gt;2002-01-20T16:23:17.0000000-07:00&lt;/endTime&gt;
      &lt;/body&gt;
   &lt;/event&gt;
&lt;/insertRequest&gt;

//generic
&lt;queryRequest xmlns="http://schemas.microsoft.com/hs/2001/10/core"&gt;
   &lt;xpQuery select="/m:myCalendar/m:event" /&gt;
&lt;/queryRequest&gt;</PRE></BLOCKQUOTE>
<P dir=ltr>NOTE: that this is a myCalendar domain specific 
getCalendarDaysRequest, and not the generic queryRequest that we have used for 
all the other services</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE>//command line
&lt;m:getCalendarDaysRequest 
  xmlns:hs="http://schemas.microsoft.com/hs/2001/10/core" 
  xmlns:m="http://schemas.microsoft.com/hs/2001/10/myCalendar"&gt;
     &lt;m:startTime&gt;2002-01-14T15:23:17.0000000-07:00&lt;/m:startTime&gt;
     &lt;m:endTime&gt;2002-01-21T16:23:17.0000000-07:00&lt;/m:endTime&gt;
&lt;/m:getCalendarDaysRequest&gt;

//web
&lt;getCalendarDaysRequest 
  xmlns="http://schemas.microsoft.com/hs/2001/10/myCalendar"&gt;
     &lt;startTime&gt;2002-01-14T15:23:17.0000000-07:00&lt;/startTime&gt;
     &lt;endTime&gt;2002-01-21T16:23:17.0000000-07:00&lt;/endTime&gt;
&lt;/getCalendarDaysRequest&gt;

&lt;deleteRequest select="/m:myCalendar/m:event" xmlns="http://schemas.microsoft.com/hs/2001/10/core" /&gt;</PRE></BLOCKQUOTE>
<H5 dir=ltr><EM>calendar.aspx </EM><A 
href="calendar.vxml">calendar.vxml</A></H5>
<P dir=ltr>OK, so I thought this one was going to be the hardest ... I lied. 
Contacts proved much more challenging, with the whole namespace thing. From 
looking at the Calendar schema though, it is huge, and powerful. If I was not 
doing the simplest example, it could become complicated real quick. Regardless, 
inserting the data proved easy, so I tricked it up by using a domain specific 
request. The code changed for this as well:</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>getCalendarDaysRequest daysRequest = new getCalendarDaysRequest();
//hardcoded
daysRequest.startTime = new DateTime(2002, 1, 15, 0,0,0);
daysRequest.endTime = new DateTime(2002, 1, 21, 0, 0, 0);
getCalendarDaysResponse daysResponse = myCal.getCalendarDays(daysRequest);</PRE></BLOCKQUOTE>
<P dir=ltr>Once again MS ... kick ass!</P>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px"><PRE dir=ltr>&lt;vxml version="1.0" application="services.aspx"&gt;
	&lt;form id="form"&gt;
		&lt;block&gt;
			&lt;prompt&gt;
				your appointments are:
			&lt;/prompt&gt;
			&lt;prompt&gt;dallas .NET user group meeting on 1/17/2002&lt;/prompt&gt;
			&lt;prompt&gt;get oil changed on 1/18/2002&lt;/prompt&gt;
			&lt;prompt&gt;haircut on 1/19/2002&lt;/prompt&gt;
			&lt;prompt&gt;hot date on 1/20/2002&lt;/prompt&gt;
			&lt;goto next="services.aspx" /&gt;
		&lt;/block&gt;
	&lt;/form&gt;
&lt;/vxml&gt;</PRE></BLOCKQUOTE>
<H4 align=left><U>Inbox</U></H4>
<P align=left>Repeat: cannot develop against this one yet</P>
<H3 align=left>Source</H3>
<P align=left><A href="myVoices.zip">C# Source Code</A> ... It has my 2 projects 
(myVoices, and hsProxy) and the 2 MS projects (ServiceLocator, 
HsSoapExtension)</P>
<H3 align=left>Future</H3>
<P align=left>Hell, writing about this, took almost as long as coding it. So its 
all great and cool, now its time to reflect/complain:</P>
<UL>
  <LI>
  <DIV align=left>I would like to see VoiceXml support in VS.NET. Should be 
  simple since there is a schema, and it could have intellisense like the HTML 
  editor currently does, letting you know what elements and attribs are valid in 
  certain situations. The Mobile.NET Toolkit should have it</DIV>
  <LI>
  <DIV align=left>MS has an XSLT file they use for transforming the&nbsp;.NET My 
  Service schemas into a more readable format they call Schema Fragments ... I 
  want them to make that file publicly available ... because reading schemas in 
  a type of pain I am not into</DIV>
  <LI>
  <DIV align=left>If I get bored (likely), then I might kick this around some 
  more</DIV>
  <LI>
  <DIV align=left>Bet the Mobile Information Server 200X ends up doing a larger 
  scale version of this</DIV></LI></UL>
<BLOCKQUOTE dir=ltr style="MARGIN-RIGHT: 0px">
  <P align=left>USER: Exit</P></BLOCKQUOTE>
</body>
</HTML>
