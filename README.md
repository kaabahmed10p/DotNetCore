# DotNetCore POC


#### TODO List:
-------------------------------
1. Deployment Local (Windows with IIS & Linux with Nginx) - Done
2. Deployment AWS App Service - Done
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
> dotnet ef migrations add testPG
> dotnet ef database update


#### Docker:
-----------------------------
To build: docker build -t todoapi .
To run containedr: docker run -d -p 8013:1234 --name myapp8 todoapi
To take shell: docker exec -it myapp8 /bin/bash



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
