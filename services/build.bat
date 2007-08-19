@echo off

echo Building common Iquomi definition language
cd ..\sdk
call build-proxies.bat
cd ..\services
copy iqcommon.xsd ..\webservices\2004\01\core
copy iqdl.xsd ..\webservices\2004\01\core
copy iqinfra.xsd ..\webservices\2004\01\core
echo.

rem xsd /c iqcommon.xsd xml.xsd IqServices\iqServices.xsd /e:iqServices /n:Commanigy.Iquomi.Services /o:proxies

echo Building 'IqAlerts'
cd IqAlerts\sdk
call build-proxies.bat
cd ..\..
copy IqAlerts\iqAlerts.xsd ..\webservices\2004\01\iqAlerts
echo.

echo Building 'IqCalendar'
cd IqCalendar\sdk
call build-proxies.bat
cd ..\..
copy IqCalendar\iqCalendar.xsd ..\webservices\2004\01\iqCalendar
echo.

echo Building 'IqProfile'
cd IqProfile\sdk
call build-proxies.bat
cd ..\..
copy IqProfile\iqProfile.xsd ..\webservices\2004\01\iqProfile
echo.

echo Building 'IqContacts'
cd IqContacts\sdk
call build-proxies.bat
cd ..\..
copy IqContacts\iqContacts.xsd ..\webservices\2004\01\iqContacts
echo.

echo Building 'IqPresence'
cd IqPresence\sdk
call build-proxies.bat
cd ..\..
copy IqPresence\iqPresence.xsd ..\webservices\2004\01\iqPresence
echo.

echo Building 'IqFavorites'
cd IqFavorites\sdk
call build-proxies.bat
cd ..\..
copy IqFavorites\iqFavorites.xsd ..\webservices\2004\01\iqFavorites
echo.

echo Building 'IqSms'
cd IqSms\sdk
call build-proxies.bat
cd ..\..
copy IqSms\iqSms.xsd ..\webservices\2004\01\iqSms
echo.

rem xsd /c iqcommon.xsd /n:Commanigy.Iquomi.Api /o:proxies
