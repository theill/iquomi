@echo off
set SCHEMAS=\\ichi\c$\hosting\iquomi\webservices\2004\01
xcopy *.xsd %SCHEMAS%\ /S /F /Y /D
xcopy iqcommon.xsd %SCHEMAS%\core\ /Y /D
xcopy iqdl.xsd %SCHEMAS%\core\ /Y /D
xcopy iqinfra.xsd %SCHEMAS%\core\ /Y /D