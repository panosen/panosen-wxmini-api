@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.WxMini.Api\bin\Release\Panosen.WxMini.Api.*.nupkg D:\LocalSavoryNuget\

pause