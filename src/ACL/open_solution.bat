@echo off
setlocal

set "solutionFile=%1"

if not exist "%solutionFile%" (
    echo Solution file does not exist.
    exit /b 1
)

for /f "tokens=2 delims=[]" %%a in ('findstr /n /c:"Project(" "%solutionFile%"') do (
    for /f "tokens=2 delims=\" %%b in ("%%a") do (
        set "projectFile=%%b"
        set "projectFile=!projectFile:\=\\!"
        code "%projectFile%"
    )
)

endlocal
