# Dino API

An ASP.NET Core Web API for managing prehistoric animals (CRUD) using Entity Framework Core migrations to scaffold the database automatically.

## Technologies Used
- C#
- .NET 6
- ASP.NET Core Web API
- Entity Framework Core
- Swagger (Swashbuckle)
- MySQL

## Prerequisites
- .NET 6 SDK
- MySQL running locally (or reachable)
- (Optional) EF Core CLI: `dotnet tool install --global dotnet-ef`

## Quick Start

1. **Clone & enter the project**
   ```
   git clone <your-repo-url>
   cd DinoApi.Solution/DinoApi
   ```

2. **Configure the connection string**
   Create `appsettings.json` in `DinoApi.Solution/DinoApi`:
   ```
   {
     "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } },
     "AllowedHosts": "*",
     "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=dinoapi;uid=[YOUR ID];pwd=[YOUR_PASSWORD];"
     } 
   }
    ```

   _NOTE: Replace `YOUR ID` and `YOUR_PASSWORD` with your MySQL password. Use the exact schema name `todolist` (all lowercase)._

   _Use valid MySQL credentials. No other MySQL setup steps are required; migrations will create the schema._

3. **Restore & build**
   ```
   dotnet restore
   ```
   ```
   dotnet build
   ```

4. **Apply migrations (scaffold the DB)**
   ```
   dotnet ef migrations add Initial
   ```
   ```
   dotnet ef database update
   ```

5. **Run the API**
   ```
   dotnet run
   ```

   * _If you are seeing an error that tables cannot befound, there are missing or more than one DbContexts, or there are unresolvable errors related to the database use:_

     ```
      dotnet ef database drop -f --context DinoApiContext
      ```
    * _Then delete your migrations folder and everything in it, then rerun intial migrations and database update using dotnet as outlined above._

## Review endpoints
```
GET    /api/Animals
GET    /api/Animals/{id}
POST   /api/Animals
PUT    /api/Animals/{id}
DELETE /api/Animals/{id}
```

## Default URLs
```
http://localhost:5000
https://localhost:5001
```


## Swagger
```
http://localhost:5000/swagger
https://localhost:5001/swagger
```

## Example Requests

List all animals:
```bash
curl http://localhost:5000/api/Animals
```

Get one:
```bash
curl http://localhost:5000/api/Animals/1
```

Create:
```bash
curl -X POST http://localhost:5000/api/Animals \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Rexie\",\"species\":\"Dinosaur\",\"age\":10}"
```

Update:
```bash
curl -X PUT http://localhost:5000/api/Animals/1 \
  -H "Content-Type: application/json" \
  -d "{\"animalId\":1,\"name\":\"Rexie\",\"species\":\"Dinosaur\",\"age\":11}"
```

Delete:
```bash
curl -X DELETE http://localhost:5000/api/Animals/1
```

## Notes
- Database creation and schema updates are handled entirely by EF Core migrations. Ensure only that your connection string is valid and the MySQL user has permission to create and alter objects in the target database.

## License
* _Educational Use Only — This repository is provided for classroom and personal learning purposes. It is not licensed for public deployment, redistribution, or commercial use. No warranty or support is provided._

##

Copyright(c) 2023 Ashe Urban