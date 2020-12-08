@echo off
:main
echo.
echo ===========Options===============
echo 1) Debug   Compile Windows 10 x64
echo 2) Debug   Compile Linux      x64
echo 3) Release Compile Windows 10 x64
echo 4) Release Compile Linux      x64
echo A) Compile ALL (Slow)
echo Q) Quit program
echo =================================
echo.
set /p response=What would you like to do?
if %response%==1 (dotnet build MiniConsole.csproj -r win10-x64 -c Debug)
if %response%==2 (dotnet build MiniConsole.csproj -r linux-x64 -c Debug)
if %response%==3 (dotnet build MiniConsole.csproj -r win10-x64 -c Release)
if %response%==4 (dotnet build MiniConsole.csproj -r linux-x64 -c Release)
if %response%==a (dotnet build MiniConsole.csproj -r win10-x64 -c Release & dotnet build MiniConsole.csproj -r linux-x64 -c Release & dotnet build MiniConsole.csproj -r win10-x64 -c Debug & dotnet build MiniConsole.csproj -r linux-x64 -c Debug)
if %response%==q (exit)
GOTO main

