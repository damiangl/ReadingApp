# ReadingApp
## Introduction
Project created for fun. Application should be able to manage reading (gas, water, electricity) and predict maintenance costs.
ReadingApp contains two parts: WebAPI and Client (in future).
## Technologies
### WebAPI
Packages:
- ASP NET Core WebAPI with .NET7
- SQLite (file DB)
- Entity Framework Core (ORM)
- AutoMapper (Map from entity to DTO and reverse)
- NLog (logging errors etc)
- JwtBearer (authentication by JSON Web Token)
Trick Highlight:
- reflection (running extended assemby methods providing custom propertief for reading types)
- full of dependency injections
- IMiddleware by AspNetCore.Http (catching exceptions)
- IPasswordHasher by AspNetCore.Identity (hashing password in DB)
### Client
TODO (Angular, ASP.NET Core WebApp, WPF App or UWP)
## Setup
Setup database in WebAPI:
in /WebaPI/ReadingApp.WebAPI
- dotnet ef migrations add InitialCreate
- dotnet ef database update
