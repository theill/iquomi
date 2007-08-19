<%@ Page Language="c#" Inherits="Commanigy.Iquomi.Web.ClientPage" CodeFile="client.aspx.cs" %>
<!DOCTYPE html 
			PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
			"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
	<title>Iquomi</title>
	<meta http-equiv="Content-Language" content="en" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link href="css/xhtml.css" type="text/css" rel="stylesheet" />
	<link href="css/client-windows.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="js/remote.js"></script>
	<script>
	
		function Query() {
			QueryIquomi('iqRss', 'FrontPageJS', 'petertheill', 'petertheill', 'g5zTb4oNXBR1VWyUqhNdcQ==');
		}
		
		function OnFrontPageJSResponse(data) {
			document.getElementById("Content").innerHTML = data;
		}
						
	</script>
</head>

<body onload="Query()">

<div id="Content">
	Welcome to the client page.
</div>

</body>
</html>