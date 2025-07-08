# Eventify Platform API

![.NET Version](https://img.shields.io/badge/.NET-9.0-512bd4)
![MySQL Version](https://img.shields.io/badge/MySQL-8.0-00758f)

## Summary
Eventify Platform API Application, made with Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence. It also illustrates open-api documentation configuration and integration with Swagger UI.
___
## Key Features

- **RESTful API** with HATEOAS support
- **Swagger UI** integration with OpenAPI 3.0 specification
- **Domain-Driven Design** architecture
- **Entity Framework Core 8** ORM with MySQL provider
- Automatic audit trails (CreatedAt/UpdatedAt)
- Custom conventions:
    - API route templates (`/api/v{version}/[controller]`)
    - ORM naming strategies (PascalCase ↔ snake_case)
- Modular bounded contexts
- Repository pattern implementation
- Response standardization middleware

## Technology Stack

| Category          | Technologies                                                                 |
|-------------------|------------------------------------------------------------------------------|
| **Core Framework**| .NET 8, C# 11, ASP.NET Core                                                 |
| **Data Layer**    | Entity Framework Core 8, MySQL 8, Pomelo.EntityFrameworkCore.MySql         |
| **API Support**   | Swashbuckle.AspNetCore 6.5, NSwag.AspNetCore 13.18                          |
| **Architecture**  | Clean Architecture, DDD, CQRS Pattern                                        |
| **Tooling**       | EF Core Power Tools, RevEng, dotnet-ef CLI                                  |

___
## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server 8+](https://dev.mysql.com/downloads/mysql/)
- [EF Core CLI Tools](https://learn.microsoft.com/ef/core/cli/dotnet)

### Installation
1. Clone repository:
```bash
git clone https://github.com/AngelDevs-Web/eventify-plaftorm.git
cd eventify-plaftorm
```

2. Configure database connection in `appsettings.json`:
```json
"ConnectionStrings" : {
  "DefaultConnection": "Server=localhost;Port=3306;Database=EventifyDB;Uid=root;Pwd=your_password;"
}
```

3. Apply database migrations:
```bash
dotnet ef database update --project src/Infrastructure --startup-project src/WebUI
```

4. Run the application:
```bash
dotnet run --project src/WebUI
```
___
## API Documentation

Access interactive documentation at:  
`https://localhost:5001/swagger`

### API Conventions
- Versioned endpoints: `/api/v1/[controller]`
- Standardized response format:
```json
{
  "data": {},
  "errors": [],
  "metadata": {
    "apiVersion": "1.0",
    "timestamp": "2025-07-08T11:26:11Z"
  }
}
```
- HTTP Status Codes:
    - 200 OK - Successful GET
    - 201 Created - Resource created
    - 400 Bad Request - Validation errors
    - 404 Not Found - Resource not exists
    - 500 Server Error - Unexpected errors
___
## Contributing

We follow [GitHub Flow](https://guides.github.com/introduction/flow/):
1. `git checkout -b feature/your-feature`
2. Commit changes using Conventional Commits:
    - `feat: add new endpoint`
    - `fix: resolve migration issue`
    - `docs: update API documentation`
3. `git push origin your-feature`
4. Create Pull Request with description of changes

___
## **Authors**

This project is maintained by the AngelDevs-Web team and contributors:

|            **Alumno**            | **Codigo** |
|:--------------------------------:|:----------:|
| Fabrizio Alexander Cutiri Agüero | U201914181 |
| Omar Christian Berrocal Ramirez  | U20201B529 |
|  Deybbi Anderson Crisanto Calle  | U202120569 |
|   July Zelmira Paico Calderon    | U20211D760 |
|     Jean Pierr Aldave Aldave     | U202120005 |

---
> 📬 **Maintainers**: [eventify2025@gmail.com](mailto:eventify2025@gmail.com)