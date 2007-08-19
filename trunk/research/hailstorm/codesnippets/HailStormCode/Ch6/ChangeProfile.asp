<%@ Language=VBScript %>
<%

Option Explicit

Dim strUserID
Dim strLocation

Dim strTitle
Dim strFirstName
Dim strLastName
Dim strStreet
Dim strCity

Dim strMessageID

Dim strSoapAction
Dim strSoapRPNamespace
Dim strHSCoreNamespace
Dim strSecNamespace
Dim strServiceNamespace

Dim strMethod

Dim Connector
Dim Serializer
Dim Reader
Dim Body
Dim Dom

Dim Title
Dim FirstName
Dim LastName
Dim Street
Dim City

strUserID = Session("userID")
strLocation = Session("location")

strTitle = Request.Form ("title")
strFirstName = Request.Form ("firstName")
strLastName = Request.Form ("lastName")
strStreet = Request.Form ("street")
strCity = Request.Form ("city")

If strTitle = "" Then
  strMethod = "query"
Else
  strMethod = "update"
End If

strMessageID = "C30D56F0-A91F-11d5-8467-0040957713FA"

strSoapAction        = "http://schemas.microsoft.com/hs/2001/10/core#request"
strSoapRPNamespace   = "http://schemas.xmlsoap.org/rp/"
strHSCoreNamespace   = "http://schemas.microsoft.com/hs/2001/10/core"
strServiceNamespace  = "http://schemas.microsoft.com/hs/2001/10/myProfile"
strSecNamespace      = "http://schemas.xmlsoap.org/soap/security/2000-12/"


Set Connector = Server.CreateObject("MSSOAP.HttpConnector")
Connector.Property("EndPointURL") = strLocation & "/myProfile"
Connector.Property("SoapAction") = strSoapAction
Connector.BeginMessage()

Set Serializer = Server.CreateObject("MSSOAP.SoapSerializer")
Serializer.Init Connector.InputStream

Serializer.startEnvelope "s", "http://schemas.xmlsoap.org/soap/encoding/", "UTF-8"
  Serializer.startHeader
    Serializer.startElement "path", strSoapRPNamespace, , "srp"
      Serializer.startElement "action", strSoapRPNamespace, , "srp"
        Serializer.writeString strSoapAction
      Serializer.endElement
      Serializer.startElement "rev", strSoapRPNamespace, , "srp"
        Serializer.startElement "via", strSoapRPNamespace, , "srp"
        Serializer.endElement
      Serializer.endElement
      Serializer.startElement "to", strSoapRPNamespace, , "srp"
        Serializer.writeString strLocation
      Serializer.endElement
      Serializer.startElement "id", strSoapRPNamespace, , "srp"
        Serializer.writeString strMessageID
      Serializer.endElement
    Serializer.endElement
    Serializer.startElement "licenses", strSecNamespace, , "ss"
      Serializer.startElement "identity", strHSCoreNamespace, , "h"
        Serializer.startElement "kerberos", strHSCoreNamespace, , "h"
          Serializer.writeString strUserID
        Serializer.endElement
      Serializer.endElement
    Serializer.endElement
    Serializer.startElement "request", strHSCoreNamespace, , "h"
      Serializer.SoapAttribute "service", ,"myProfile"
      Serializer.SoapAttribute "document", ,"content"
      Serializer.SoapAttribute "method", ,strMethod
      Serializer.SoapAttribute "genResponse", ,"always"
      Serializer.startElement "key", strHSCoreNamespace, , "h"
        Serializer.SoapAttribute "instance", ,"0"
        Serializer.SoapAttribute "cluster", ,"0"
        Serializer.SoapAttribute "puid", ,strUserID
      Serializer.endElement
    Serializer.endElement
  Serializer.endHeader
  Serializer.startBody

If strMethod = "query" Then
    Serializer.startElement "queryRequest", strHSCoreNamespace, , "h"
      Serializer.SoapAttribute "xmlns:m", , strServiceNamespace
      Serializer.startElement "xpQuery", strHSCoreNamespace, , "h"
        Serializer.SoapAttribute "select", , "/m:myProfile"
      Serializer.endElement
    Serializer.endElement
  Else

    Serializer.startElement "h:updateRequest"
      Serializer.SoapAttribute "xmlns:m", , strServiceNamespace
      Serializer.SoapAttribute "xmlns:h", , strHSCoreNamespace
      Serializer.startElement "h:updateBlock"
        Serializer.SoapAttribute "select", , "/m:myProfile"
        Serializer.startElement "h:replaceRequest"
          Serializer.SoapAttribute "select", , "./m:name"
            Serializer.startElement "m:name"
              Serializer.startElement "m:title"
              Serializer.SoapAttribute "xml:lang", , "en"
              Serializer.writeString strTitle
            Serializer.endElement
            Serializer.startElement "m:givenName"
              Serializer.SoapAttribute "xml:lang", , "en"
              Serializer.writeString strFirstName
            Serializer.endElement
            Serializer.startElement "m:surname"
              Serializer.SoapAttribute "xml:lang", , "en"
              Serializer.writeString strLastName
            Serializer.endElement
          Serializer.endElement
        Serializer.endElement
        Serializer.startElement "h:replaceRequest"
          Serializer.SoapAttribute "select", , "./m:address"
            Serializer.startElement "m:address"
              Serializer.startElement "h:officialAddressLine"
              Serializer.SoapAttribute "xml:lang", , "en"
              Serializer.writeString strStreet
            Serializer.endElement
            Serializer.startElement "h:primaryCity"
              Serializer.SoapAttribute "xml:lang", , "en"
              Serializer.writeString strCity
            Serializer.endElement
          Serializer.endElement
        Serializer.endElement
      Serializer.endElement
    Serializer.endElement
  End If

Serializer.endBody
Serializer.endEnvelope

Connector.EndMessage

Set Reader = Server.CreateObject("MSSOAP.SoapReader")
Reader.Load Connector.OutputStream

If strMethod = "query" Then

  Set Body = Reader.Body

  Set Dom = Reader.DOM
  Dom.setProperty "SelectionLanguage", "XPath"
  Dom.setProperty "SelectionNamespaces", _
                  "xmlns:hs='" & strHSCoreNamespace & "' " & _
                  "xmlns:m='" & strServiceNamespace & "'"

  Set Title = Body.SelectSingleNode ("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:name/m:title")
  Set FirstName = Body.SelectSingleNode ("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:name/m:givenName")
  Set LastName = Body.SelectSingleNode ("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:name/m:surname")

  Set Street = Body.SelectSingleNode ("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:address/hs:officialAddressLine")
  Set City = Body.SelectSingleNode ("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:address/hs:primaryCity")

End If

%>

<html>
<body>

<% If strMethod = "query" Then

If Not Reader.Fault Is Nothing Then
  Response.Write "FAULT: " & Reader.faultstring.Text
ElseIf Title Is Nothing Or FirstName Is Nothing Or LastName Is Nothing Then
  Response.Write "Failed to get name"
ElseIf Street Is Nothing Or City Is Nothing Then
  Response.Write "Failed to get address"
Else%>

<form action="ChangeProfile.asp" method="post" name="profile">
<p>
<table>
  <tr>
    <td>Title:</td>
    <td><input id="text1" name="title" value="<%=Title.text%>"></td>
  </tr>
  <tr>
    <td>First name:</td>
    <td><input id="text1" name="firstName" value="<%=FirstName.text%>"></td>
  </tr>
  <tr>
    <td>Last name:</td>
    <td><input id="text1" name="lastName" value="<%=LastName.text%>"></td>
  </tr>
  <tr>
    <td>&nbsp</td>
  </tr>
  <tr>
    <td>Street:</td>
    <td><input id="text1" name="street" value="<%=Street.text%>"></td>
  </tr>
  <tr>
    <td>City:</td>
    <td><input id="text1" name="city" value="<%=City.text%>"></td>
  </tr>
  <tr>
    <td>&nbsp</td>
  </tr>
  <tr>
    <td></td>
    <td><input id="submit1" name="submit1" type="submit" value="Change profile"></td>
  </tr>
</table></P>
</form>

<%End If%>
<%Else

If Not Reader.Fault Is Nothing Then
  Response.Write "FAULT: " & Reader.faultstring.Text
Else%>

<form action="AuctionDemo.asp" method="post" name="changed">
<input id=submit2 name=submit2 type=submit value="Return to Auction">

<%End If%>
<%End If%>
</body>
</html>
