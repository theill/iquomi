var IE = (navigator.userAgent.indexOf("MSIE") !=-1&&navigator.userAgent.indexOf("Mac")==-1&&navigator.appVersion.substring(0,1)>=3);
var mIE = (navigator.userAgent.indexOf("MSIE") !=-1&& navigator.userAgent.indexOf("Win")==-1&&navigator.appVersion.substring(0,1)>=3);//mac
var NS = (navigator.userAgent.indexOf("Mozilla") !=-1&&navigator.userAgent.indexOf("Mac")==-1&&navigator.userAgent.indexOf("MSIE")==-1&& navigator.appVersion.substring(0,1)>=4);
var mNS = (navigator.userAgent.indexOf("Mozilla") !=-1&&navigator.userAgent.indexOf("Win")==-1&&navigator.userAgent.indexOf("MSIE")==-1&& navigator.appVersion.substring(0,1)>=4);//mac
expon = 0; slideShowDrop = 1; //sets regular font size (IE) and dropdown list visible
if (NS || mIE) {expon = 1} //configures the proper size for pc/mac for IE/NS
if (mNS) {expon = 2; slideShowDrop = 0} //hides dropdown in slideshow.inc for MAC-NS
var browsSize = new Array("xx-small","x-small","small","medium","large","x-large","xx-large","xx-large");
size1 = browsSize[0+expon]; //xx-small
size2 = browsSize[1+expon]; //x-small
size3 = browsSize[2+expon]; //small
size4 = browsSize[3+expon]; //medium
size5 = browsSize[4+expon]; //x-large
size6 = browsSize[5+expon]; //xx-large
fs = "font-size: "; localFonts = "font-family: Verdana, Arial, Helvetica;";
var styleSheet = "BODY, TABLE, TR, TD, P, DIV, SPAN, UL, LI {" + fs + size1 + ";" + localFonts + "}"
	+ "A:active, A:visited, A:link {text-decoration: none;" + localFonts + "}"
	+ "A:hover {color: #cc0000; text-decoration: underline;}"
	+ "H3 {" + fs + size2 + ";}"
	+ ".m10 {margin-left: 10;}"
	+ ".read {color: #cc0000;}"
	+ ".nav-r-wmt {background-color: #cccccc;}"
	+ ".arrow {list-style-image: url('/presspass/images/arrow2a.gif');}"
	+ ".prtitle {" + fs + size3 + "; color: #333366;}"
	+ ".prsubtitle {" + fs + size2 + "; color: #333366;}"
	+ ".galleryhead {" + fs + size2 + "; color: #333366; text-align: center; font-weight: bold;}"
	+ ".vprhead {" + fs + size3 + "; color: #000000; text-align: left; font-weight: bold;}"
	+ ".prindex2 {" + fs + size1 + "; color: #cc0000;}"
	+ ".prindex1 {" + fs + size2 + ";}"
	+ ".execname {" + fs + size4 + "; color: #000066;}"
	+ ".execdept {" + fs + size3 + ";}"
	+ ".toplinks {" + fs + size1 + "; color: #ffffff; text-decoration: none; font-weight: bold;}";
document.write("<style>" + styleSheet + "</style>"); //writes stylesheet