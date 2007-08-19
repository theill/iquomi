cd ..\..
xsd /nologo /c iqcommon.xsd xml.xsd IqAlerts\iqAlerts.xsd IqPresence\iqPresence.xsd /e:IqPresence /e:NotifyEndpointRequest /e:MessengerArgot /n:Commanigy.Iquomi.Services.IqPresence /o:IqPresence\sdk
cd IqPresence\sdk