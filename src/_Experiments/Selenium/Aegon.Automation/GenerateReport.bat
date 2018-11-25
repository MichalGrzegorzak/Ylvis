rem COPY /V /Y specflow.exe.config "C:\tools\SpecFlow.1.9.0\tools\"

"C:\tools\NUnit.Runners.2.6.3\tools\nunit-console.exe" /labels /out=TestResult.txt /xml=TestResult.xml /framework=net-4.0 AegonAutomation.dll
rem "C:\tools\Solution Files\packages\SpecFlow.1.9.0\tools\specflow.exe" nunitexecutionreport /testcontainer:Aegon.Automation.dll /out:TestResult.html

IF NOT EXIST TestResult.xml GOTO FAIL
IF NOT EXIST TestResult.html GOTO FAIL
EXIT
 
:FAIL
echo FAILURE
EXIT /B 1

::Enable-PSRemoting –force
::winrm s winrm/config/client '@{TrustedHosts="PL-Bamsel"}'
::Test-WsMan Pl-Bamsel
::Test-WsMan 172.21.2.18
Invoke-Command -ComputerName PL-Bamsel -ScriptBlock { $A = Start-Process -FilePath c:\TESTS\Aegon\GenerateReport.bat -Wait -passthru;$a.ExitCode } -credential michal.grzegorzak
::Invoke-Command -ComputerName PL-Bamsel -ScriptBlock { Get-ChildItem C:\ } -credential michal.grzegorzak

