Option Explicit'''' SOAP Objects''Dim SerializerDim ReaderDim Connector'' SOAP Objects'' Create Connector and set propertiesSet Connector = CreateObject("MSSOAP.HttpConnector")''Replace jaws with the address of your HailStorm server here'Connector.Property("EndPointURL") = "http://jaws/myFavoriteWebSites"Connector.Property("SoapAction") = "http://schemas.microsoft.com/hs/2001/10/core#request"Connector.BeginMessage    '' Create Serializer    Set Serializer = CreateObject("MSSOAP.SoapSerializer")Serializer.Init Connector.InputStream    '' Build HailStorm SOAP PacketSerializer.startEnvelope "s", "http://schemas.xmlsoap.org/soap/encoding/", "UTF-8"Serializer.startHeaderSerializer.startElement "path", "http://schemas.xmlsoap.org/rp/", , "srp"Serializer.startElement "action", "http://schemas.xmlsoap.org/rp/", , "srp"Serializer.writeString "http://schemas.microsoft.com/hs/2001/10/core#request"Serializer.endElementSerializer.startElement "rev", "http://schemas.xmlsoap.org/rp/", , "srp"Serializer.startElement "via", "http://schemas.xmlsoap.org/rp/", , "srp"Serializer.endElementSerializer.endElementSerializer.startElement "to", "http://schemas.xmlsoap.org/rp/", , "srp"''Add address of your HailStorm server here'Serializer.writeString "http://jaws"Serializer.endElementSerializer.startElement "id", "http://schemas.xmlsoap.org/rp/", , "srp"Serializer.writeString "177c8982-a133-11d5-8c76-00a0c94515ad"Serializer.endElementSerializer.endElementSerializer.startElement "licenses", "http://schemas.xmlsoap.org/soap/security/2000-12/", , "ss"Serializer.startElement "identity", "http://schemas.microsoft.com/hailstorm/hs/", , "h"Serializer.startElement "kerberos", "http://schemas.microsoft.com/hailstorm/hs/", , "h"''Replace 10434 with your puid'Serializer.writeString "10434"Serializer.endElementSerializer.endElementSerializer.endElementSerializer.startElement "request", "http://schemas.microsoft.com/hailstorm/hs/", , "h"Serializer.SoapAttribute "service", ,"myFavoriteWebSites"Serializer.SoapAttribute "document", ,"content"Serializer.SoapAttribute "method", ,"insert"Serializer.SoapAttribute "genResponse", ,"always"Serializer.startElement "key", "http://schemas.microsoft.com/hailstorm/hs/", , "h"Serializer.SoapAttribute "instance", ,"0"Serializer.SoapAttribute "cluster", ,"0"''Replace 10434 with your puid'Serializer.SoapAttribute "puid", ,"10434"Serializer.endElementSerializer.endElementSerializer.endHeaderSerializer.startBodySerializer.startElement "insertRequest", "http://schemas.microsoft.com/hs/2001/10/core", , "hs"Serializer.SoapAttribute "xmlns:m", , "http://schemas.microsoft.com/hs/2001/10/myFavoriteWebSites"Serializer.SoapAttribute "select", "" , "/m:myFavoriteWebSites", ""Serializer.startElement "favoriteWebSite", "http://schemas.microsoft.com/hs/2001/10/myFavoriteWebSites", , "m"Serializer.startElement "title", "http://schemas.microsoft.com/hs/2001/10/myFavoriteWebSites", ,"m"Serializer.SoapAttribute "xml:lang", ,"en-us"Serializer.writeString "ASPToday"Serializer.endElementSerializer.startElement "url", "http://schemas.microsoft.com/hs/2001/10/myFavoriteWebSites", , "m"Serializer.writeString "http://www.asptoday.com"Serializer.endElementSerializer.endElementSerializer.endElementSerializer.endBodySerializer.endEnvelopeConnector.EndMessage    '' Read in SOAP Response from HailstormSet Reader = CreateObject("MSSOAP.SoapReader")Reader.Load Connector.OutputStream    '' Display XML (or errors)If Not Reader.Fault Is Nothing Then  WScript.Echo "FAULT: " & Reader.faultstring.TextElse  WScript.Echo Reader.Envelope.xmlEnd If