<%@ Page language="c#" %>
<%@ Import namespace="System.Xml" %>
<%@ Import namespace="System.Xml.Schema" %>
<%@ Import namespace="System.IO" %>
<%@ Import namespace="log4net" %>

<html>
<head>
</head>

<body>
<%
	
	ILog log = LogManager.GetLogger("WebSite");

	log.Debug("Headers:");
	foreach (string e in Request.Headers.AllKeys) {
		log.Debug(e + " = " + Request.Headers[e]);
	}

	log.Debug("Body:");
	string all = new StreamReader(Request.InputStream).ReadToEnd();
	log.Debug(all);
	
%>
</body>
</html>