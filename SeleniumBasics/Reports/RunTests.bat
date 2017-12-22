@echo off
echo Running NUnit Console3
echo.
Selenium\nunit3-console Selenium\SeleniumBasics.dll
pause

echo Generating Report through ReportUnit
echo.
Selenium\ReportUnit.exe .
echo.
pause