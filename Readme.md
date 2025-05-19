# Modular .NET Microservice Architecture

This repository contains a modular, scalable backend architecture built with .NET 8.  
It follows clean architectural layering with full support for Domain-Driven Design (DDD), CQRS, and async communication patterns(comming soon).

---

## Tech Stack

- **.NET 9**
- **EF Core** for relational data access
- **MongoDB** (optional for document-based storage) (coming soon)
- **MediatR** for request/response and domain event dispatching
- **AutoMapper** for DTO ↔ Entity mapping
- **PostgreSQL / SQL Server** support 

---

## Architectural Principles

- **Domain-Driven Design**  
  Clear separation between domain logic and application infrastructure.

- **Clean Architecture**  
  Each service is structured by layers: `Domain`, `Application`, `Infrastructure`, `API`.

- **CQRS Pattern**  
  Command and query responsibilities are separated to simplify business logic and improve scalability.

- **Microservice-ready**  
  Each module is designed to work independently and can be turned into a microservice when needed.

---

## Project Structure

```
/src
│
├── OrderService/
│   ├── OrderService.API/
│   ├── OrderService.Application/
│   ├── OrderService.Domain/
│   ├── OrderService.Infrastructure/
│   └── OrderService.Persistence/
│
├── Shared/
│   ├── Shared.EF/
│   ├── Shared/
```

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/onrcanogul/dotnet-core-microservices-starter.git
cd your-repo
```

### 2. Configure environment

- Update `appsettings.json` and connection strings in API projects
- Configure Docker if you're containerizing services

### 3. Run the app

```bash
dotnet build
dotnet run --project Order.Api
```


## Notes

- Each service is kept as clean and independent as possible.
- Shared libraries are introduced only where abstraction makes sense (e.g. `Shared.EF`, `Shared`).

