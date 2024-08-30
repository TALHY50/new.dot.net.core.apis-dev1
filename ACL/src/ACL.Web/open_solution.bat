@echo off
setlocal enabledelayedexpansion

set "solutionFile=%~1"

if not exist "%solutionFile%" (
    echo Solution file does not exist.
    exit /b 1
)

for /F "tokens=2 delims=[]" %%a in ('findstr /n /c:"Project(" "%solutionFile%"') do (
    for /F "tokens=2 delims=\" %%b in ("%%a") do (
        set "projectFile=%%b"
        set "projectFile=!projectFile:\=\\!"
        code "%projectFile%"
    )
)