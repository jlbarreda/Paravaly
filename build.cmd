@echo off

echo Cleaning...
rd /s /q src\Paravaly\bin
rd /s /q src\Paravaly\obj
rd /s /q test\Paravaly.Tests\bin
rd /s /q test\Paravaly.Tests\obj

echo.
echo Building project...
dotnet build -c Release

echo.
echo Building tests...
dotnet build -c Release

echo.
echo Running tests...
dotnet test test/Paravaly.Tests/Paravaly.Tests.csproj

echo.
echo Packaging...
dotnet pack src/Paravaly/Paravaly.csproj -c Release

echo.
echo Done.