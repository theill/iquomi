cd ..\..
REM xsd /c iqcommon.xsd IqAlerts\iqAlerts.xsd IqCalendar\iqCalendar.xsd /e:IqContacts /n:Commanigy.Iquomi.Services.IqContacts /o:IqContacts\sdk
xsd /nologo /c iqcommon.xsd xml.xsd IqCalendar\iqCalendar.xsd IqProfile\iqProfile.xsd IqContacts\iqContacts.xsd /e:IqContacts /n:Commanigy.Iquomi.Services.IqContacts /o:IqContacts\sdk
cd IqContacts\sdk