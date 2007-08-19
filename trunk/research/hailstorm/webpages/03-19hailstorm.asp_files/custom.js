var ToolBar_Supported = ToolBar_Supported ;
if (ToolBar_Supported != null && ToolBar_Supported == true)
{
	//To Turn on/off Frame support, set Frame_Supported = true/false.
	Frame_Supported = false;

	// Customize default ICP menu color - bgColor, fontColor, mouseoverColor
	setDefaultICPMenuColor("#000000", "white", "red");

	// Customize toolbar background color
	setToolbarBGColor("white");

	// display ICP Banner
	setICPBanner("/billgates/images/banner.jpg","/isapi/gomscom.asp?target=/billgates/","Bill Gates Home") ;
	
	//***** Add ICP menus *****
	//Home
	addICPMenu("HomeMenu", "HOME", "","/isapi/gomscom.asp?target=/billgates/");

	//Writing
	addICPMenu("WritingMenu", "WRITING", "","/isapi/gomscom.asp?target=/billgates/writing.htm");
	addICPSubMenu("WritingMenu","Business @ the Speed of &nbsp; &nbsp;  &nbsp; &nbsp;  &nbsp; Thought","/isapi/gomscom.asp?target=/billgates/book/");
	addICPSubMenu("WritingMenu","Essays","/isapi/gomscom.asp?target=/billgates/writing.htm");
	addICPSubMenu("WritingMenu","Columns","/isapi/gomscom.asp?target=/billgates/writing.htm#columns");

	//Bio
	addICPMenu("BioMenu", "BIOGRAPHY", "","/isapi/gomscom.asp?target=/billgates/bio.htm");

	//Speeches
	addICPMenu("SpeechesMenu", "SPEECHES", "","/isapi/gomscom.asp?target=/billgates/speeches.htm");
	
	//News
	addICPMenu("NewsMenu", "NEWS", "","/isapi/gomscom.asp?target=/billgates/news.htm");
	addICPSubMenu("NewsMenu","News","/isapi/gomscom.asp?target=/billgates/news.htm");
	addICPSubMenu("NewsMenu","Past News","/isapi/gomscom.asp?target=/billgates/news/pastfeatures.htm");
		
	//Giving
	addICPMenu("GivingMenu", "GIVING", "","http://www.gatesfoundation.org");
	
	

}
