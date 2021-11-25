REM From Main Service project folder:
REM Add Migration:
 
dotnet ef migrations add FirstSetup -p ../Workshop.Blazor.DataAccessLayer/Workshop.Blazor.DataAccessLayer.csproj -s Workshop.BackendService.csproj

REM Remove last added Migration:

dotnet ef migrations remove -p ../Workshop.Blazor.DataAccessLayer/Workshop.Blazor.DataAccessLayer.csproj -s Workshop.BackendService.csproj

REM Update DB manually:

dotnet ef database update FirstSetup

REM Setup local db using docker
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_PID=Express' -e 'MSSQL_SA_PASSWORD=P@ssw0rd' -p 1433:1433 -v ~/volumes/mssql/data:/var/opt/mssql/data -v ~/volumes/mssql/log:/var/opt/mssql/log -v ~/volumes/mssql/secrets:/var/opt/mssql/secrets -d mcr.microsoft.com/mssql/server:2019-latest
