## PoC for file upload

## Requirements

- .NET 6
- Mongo

## Setup

1. Create new database in Mongo with the name FilesDB and a collection inside it with the name Files
2. In FilesAPI/appsettins.json paste your connection url for the mongo database (it will be probably the same if you are using a local mongo instance)
3. in the root folder of this repository (where the FilesAPI folder and FilesAPI.sln is) run the command "dotnet run --project .\FilesAPI\"
4. Use the endpoint https://localhost:38327/api/v1/files for the REST CRUD operations
