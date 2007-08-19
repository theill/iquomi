cd ..\services
xsd /nologo /c iqcommon.xsd xml.xsd /n:Commanigy.Iquomi.Services /o:..\sdk
cd ..\sdk
move /Y iqcommon_xml.cs iqcommon.cs