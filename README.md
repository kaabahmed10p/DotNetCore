# DotNetCore POC


#### TODO List:
-------------------------------
1. Deployment Local (Windows with IIS & Linux with Nginx) - Done
2. Deployment Azure App Service - Done
3. Docker - Done 
4. CLI - Done
5. EF - Done
6. MVC
7. Middleware & logging - Done



Things we might look into later :

1. Unit Test
2. CI
3. Running migrations inside docker

#### EF:
-------------------------------
1. To add new migration file: dotnet ef migrations add testPG 
2. To run migrations: dotnet ef database update


#### Docker:
-----------------------------
1. To build: docker build -t todoapi .
2. To run containedr: docker run -d -p 8013:1234 --name myapp8 todoapi
3. To take shell: docker exec -it myapp8 /bin/bash

Current limitation: need to run migrations manually on postgres container ... need to work around this issue


### Misc:
--------------

POST http://127.0.0.1:1234/api/values :
{
  "DataEventRecordId":8,
  "Name":"Funny data",
  "Description":"yes",
  "Timestamp":"2015-12-27T08:31:35Z",
   "SourceInfo":
  { 
    "SourceInfoId":0,
    "Name":"Beauty",
    "Description":"second Source",
    "Timestamp":"2015-12-23T08:31:35+01:00",
    "DataEventRecords":[]
  },
 "SourceInfoId":0 
}

### Deployment: 
------------------------
Framework-dependent deployment (for IIS):
>	dotnet publish -f netcoreapp2.0 -c Release

Self-contained deployment:
>	dotnet publish -c Release -r win10-x64	
>	dotnet publish -c release -r ubuntu.16.10-x64
>	Add RuntimeIdentifiers:
	<RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.10-x64</RuntimeIdentifiers>

Microsoft Azure App Service:
> Deployment on cloud from VS: Type App Name, 
> select Subscription, Resource Group, App Service Plan
