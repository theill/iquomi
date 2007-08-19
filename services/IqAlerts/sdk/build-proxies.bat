xsd /nologo /c /n:Commanigy.Iquomi.Services.IqAlerts Notify.xsd

cd ..\..
xsd /nologo /c iqcommon.xsd xml.xsd IqAlerts\iqAlerts.xsd /e:IqAlerts /e:NotifyRequest /e:HumanReadable /n:Commanigy.Iquomi.Services.IqAlerts /o:IqAlerts\sdk
cd IqAlerts\sdk