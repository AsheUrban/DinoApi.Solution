# Dino API

An ASP.NET Core Web API for managing animals (demo CRUD).

## Technologies Used
- C#
- .NET 6
- ASP.NET Core Web API
- Entity Framework Core
- Swagger (Swashbuckle)
- MySQL

## Description
A simple Web API exposing CRUD endpoints for prehistoric animals. This project is API-only and does not include a separate UI. Use Swagger or curl/Postman to interact with it.

## App Settings & MySQL Configuration

Create `appsettings.json` in `DinoApi.Solution/DinoApi`:

```json
{
  "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=3306;Database=dino_api;Uid=YOUR UID;Pwd=YOUR_PASSWORD;"
  }
}
```

(Optional) Create `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

Create the database, user, and grants (run once in MySQL Workbench or CLI as root):

```sql
CREATE DATABASE IF NOT EXISTS dino_api
  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

CREATE USER IF NOT EXISTS 'YOUR UID'@'localhost' IDENTIFIED BY 'YOUR_PASSWORD';
CREATE USER IF NOT EXISTS 'YOUR UID'@'127.0.0.1' IDENTIFIED BY 'YOUR_PASSWORD';

GRANT ALL PRIVILEGES ON dino_api.* TO 'YOUR UID'@'localhost';
GRANT ALL PRIVILEGES ON dino_api.* TO 'YOUR UID'@'127.0.0.1';
FLUSH PRIVILEGES;
```

Apply EF Core migrations:

```bash
cd DinoApi.Solution/DinoApi
dotnet ef database update
```

## How To Launch

* cd into DinoApi.Solution/DinoApi OR cd .\DinoApi if you are already in the primary project directory
* dotnet ef database update
* dotnet run

## The app listens on:

```
http://localhost:5000
https://localhost:5001
```
## Endpoints

```
GET    http://localhost:5000/api/Animals
GET    http://localhost:5000/api/Animals/{id}
POST   http://localhost:5000/api/Animals
PUT    http://localhost:5000/api/Animals/{id}
DELETE http://localhost:5000/api/Animals/{id}
```

`{id}` should be replaced with the ID of the animal you want to GET, PUT, or DELETE.

## How To View With Swagger

Open:

```
http://localhost:5000/swagger
https://localhost:5001/swagger
```

## Using The API (Examples)

List all animals:
```bash
curl http://localhost:5000/api/Animals
```

Get a single animal:
```bash
curl http://localhost:5000/api/Animals/1
```

Create a new animal (POST body):
```json
{
  "name": "Rexie",
  "species": "Dinosaur",
  "age": 10
}
```

Example curl for POST:
```bash
curl -X POST http://localhost:5000/api/Animals \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Rexie\",\"species\":\"Dinosaur\",\"age\":10}"
```

Update an animal (PUT body should include `animalId` that matches the route `{id}`):
```json
{
  "animalId": 1,
  "name": "Rexie",
  "species": "Dinosaur",
  "age": 11
}
```

Example curl for PUT:
```bash
curl -X PUT http://localhost:5000/api/Animals/1 \
  -H "Content-Type: application/json" \
  -d "{\"animalId\":1,\"name\":\"Rexie\",\"species\":\"Dinosaur\",\"age\":11}"
```

Delete an animal:
```bash
curl -X DELETE http://localhost:5000/api/Animals/1
```
