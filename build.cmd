@echo off

echo Cleaning...
rd /s /q src\Paravaly\bin
rd /s /q src\Paravaly\obj
rd /s /q test\Paravaly.Tests\bin
rd /s /q test\Paravaly.Tests\obj

echo.
echo Restoring...
dotnet restore

echo.
echo Building project...
dotnet build src/Paravaly/project.json -c Release

echo.
echo Building tests...
dotnet build test/Paravaly.Tests/project.json -c Release

echo.
echo Running tests...
dotnet test test/Paravaly.Tests/project.json

echo.
echo Packaging...
dotnet pack src/Paravaly/project.json -c Release

echo.
echo Done.