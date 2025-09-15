@echo off
echo Starting CSV Import Demo...
echo.

echo 1. Starting ASP.NET Core API...
start cmd /k "cd /d %~dp0 && dotnet run"

echo 2. Waiting 5 seconds for API to start...
timeout /t 5 /nobreak > nul

echo 3. Starting React App...
start cmd /k "cd /d %~dp0react-client && npm install && npm start"

echo.
echo Both applications are starting...
echo API should be available at: https://localhost:7071
echo React App should be available at: http://localhost:3000
echo.
pause