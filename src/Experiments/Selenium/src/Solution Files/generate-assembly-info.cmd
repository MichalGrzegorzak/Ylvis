@echo off

git describe --tags --long > version
set /p v=<version
del /F /Q version

git describe --tags --abbrev=0 > version2
set /p v2=<version2
del /F /Q version2

echo using System.Reflection;
echo [assembly: AssemblyCopyright("Copyright (c) %date:~0,4% AEGON / POSSIBLE")]
echo [assembly: AssemblyCompany("AEGON")]
echo [assembly: AssemblyInformationalVersion("%v%")]
echo [assembly: AssemblyVersion("%v2%")]
echo [assembly: AssemblyFileVersion("%v2%")]