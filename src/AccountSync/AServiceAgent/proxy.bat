SET util="C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\svcutil.exe"
SET serv="http://localhost:8001/AlarmServer"


%util% %serv% /out:AServiceProxy.cs /namespace:*,AServiceAgent
pause

