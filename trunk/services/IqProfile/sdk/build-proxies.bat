cd ..\..
xsd /nologo /c iqcommon.xsd xml.xsd IqAlerts\iqAlerts.xsd IqCalendar\iqCalendar.xsd IqProfile\iqProfile.xsd /e:IqProfile /n:Commanigy.Iquomi.Services.IqProfile /o:IqProfile\sdk

REM wsdl /fields /n:Commanigy.Iquomi.Services.IqProfile /o:IqProfile\sdk\test.cs iqcommon.xsd IqAlerts\iqAlerts.xsd IqCalendar\iqCalendar.xsd IqProfile\iqProfile.xsd 

cd IqProfile\sdk