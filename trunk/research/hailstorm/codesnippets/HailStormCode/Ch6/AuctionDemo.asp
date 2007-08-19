<%@ Language=VBScript %>
<%

Option Explicit


Dim strUserID
Dim strLocation

Dim strMessageID

Dim strSoapAction
Dim strSoapRPNamespace
Dim strHSCoreNamespace
Dim strSecNamespace
Dim strServiceNamespace

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

strUserID = Request.Form("userID")
strLocation = Request.Form("location")

If strUserID = "" Then
  strUserID = Session("userID")
Else
  Session("userID") = strUserID
  Session("selectedLot") = ""
End If

If strLocation = "" Then
  strLocation = Session("location")
Else
  Session("location") = strLocation
End If

strMessageID = "2741D0E0-A82C-11d5-8465-0040957713FA"
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

Serializer.startEnvelope "SOAP-ENV", _
                         "http://schemas.xmlsoap.org/soap/encoding/", "UTF-8"
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
      Serializer.SoapAttribute "service", , "myProfile"
      Serializer.SoapAttribute "document", , "content"
      Serializer.SoapAttribute "method", , "query"
      Serializer.SoapAttribute "genResponse", , "always"
      Serializer.startElement "key", strHSCoreNamespace, , "h"
        Serializer.SoapAttribute "instance", , "0"
        Serializer.SoapAttribute "cluster", , "0"
        Serializer.SoapAttribute "puid", , strUserID
      Serializer.endElement
    Serializer.endElement
  Serializer.endHeader
  Serializer.startBody
    Serializer.startElement "queryRequest", strHSCoreNamespace, , "h"
      Serializer.SoapAttribute "xmlns:m", , strServiceNamespace
      Serializer.startElement "xpQuery", strHSCoreNamespace, , "h"
        Serializer.SoapAttribute "select", , "/m:myProfile"
      Serializer.endElement
    Serializer.endElement
  Serializer.endBody
Serializer.endEnvelope


Connector.EndMessage

Set Reader = Server.CreateObject("MSSOAP.SoapReader")
Reader.Load Connector.OutputStream

Set Body = Reader.Body

Set Dom = Reader.DOM
Dom.setProperty "SelectionLanguage", "XPath"
Dom.setProperty "SelectionNamespaces", _
                "xmlns:hs='" & strHSCoreNamespace & "' " & _
                "xmlns:m='" & strServiceNamespace & "'"

Set Title = Body.SelectSingleNode("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:name/m:title")
Set FirstName = Body.SelectSingleNode("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:name/m:givenName")
Set LastName = Body.SelectSingleNode("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:name/m:surname")

Set Street = Body.SelectSingleNode("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:address/hs:officialAddressLine")
Set City = Body.SelectSingleNode("hs:queryResponse/hs:xpQueryResponse/m:myProfile/m:address/hs:primaryCity")
%>

<html>
<body>
<form action="ChangeProfile.asp" method="post" name="details">

<%If Not Reader.Fault Is Nothing Then
  Response.Write "FAULT: " & Reader.faultstring.Text
ElseIf Title Is Nothing Or FirstName Is Nothing Or LastName Is Nothing Then
  Response.Write "Failed to get name"
ElseIf Street Is Nothing Or City Is Nothing Then
  Response.Write "Failed to get address"
Else
%>
<p>
<%= "Hello, " & Title.text & " " & FirstName.text & " " & LastName.text & " of " & Street.text & ", " & City.text %>
</p>
<%End If%>
<input id=submit1 name=submit1 type=submit value="Change Personal Details">
</form>

<form action="AuctionDemo.asp" method="post" name="select">
<%
Dim strSelectedLot
Dim strNewBid
Dim dblNewBid
Dim SQLConnection
Dim Recordset
Dim Record

Dim strLot
Dim strSelected
Dim strDetails
Dim dBid
Dim nBidUserID
Dim EndDate



strSelectedLot = Request.Form ("lot")

If strSelectedLot = "" Then
  strSelectedLot = Session("selectedLot")
Else
  Session("selectedLot") = strSelectedLot
  Session("bid") = ""
End If

strNewBid = Request.Form ("bid")

Set SQLConnection = Server.CreateObject ("ADODB.Connection")
SQLConnection.Open "Provider=sqloledb;Server=chrisu;Database=auction;UID=ben;PWD=ben;"
Set Recordset = Server.CreateObject ("ADODB.Recordset") 
Recordset.Open "lots", SQLConnection, 1, 2, 2

If strNewBid <> "" Then
  While Not Recordset.EOF
    strLot = Trim (Recordset.Fields.Item ("description"))

    If strLot = strSelectedLot Then
      Recordset.Fields.Item ("bid").Value = CCur (strNewBid)
      Recordset.Fields.Item ("puid").Value = CInt (strUserID)
      Recordset.Update
      Recordset.MoveLast
    Else
      Recordset.MoveNext
    End If
  Wend
  Recordset.MoveFirst
End If
%>

<select size=10 id=select1 name=lot>
<%

While Not Recordset.EOF
  strLot = Trim (Recordset.Fields.Item ("description"))

  If strLot = strSelectedLot Then
    strSelected = " SELECTED"
    dBid = Recordset.Fields.Item ("bid")
    nBidUserID = Recordset.Fields.Item ("puid")
    EndDate = Recordset.Fields.Item ("enddate")

    If dBid = 0.0 Then
      strDetails = "No bids yet"
    ElseIf CStr(nBidUserID) = strUserID Then
      strDetails = "Best bid is yours, at $" & dBid
    Else
      strDetails = "Best bid is $" & dBid
    End If

    strDetails = strDetails & ", auction ends on " & EndDate
  Else
    strSelected = ""
  End If
%>
<option <%=strSelected%>><%=strLot%></option>
<%
  Recordset.MoveNext
Wend
%>
</select></P>
<input id=submit2 name=submit2 type=submit value="Show Details of Selected Item">
</form>
<% If strSelectedLot <> "" Then%>
<form action="AuctionDemo.asp" method="post" name="bid">
<%=strDetails%></P>
<table>
  <tr>
    <td>Make your bid:</td>
    <td><input id=text1 name=bid></td>
    <td><input id=submit3 name=submit3 type=submit value="Bid">
  </tr>
</form>
<%End If%>
</body>
