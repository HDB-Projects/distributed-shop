# Distributed Shop

## Overview
Distributed Shop is a microservice-based e-commerce system built with modern backend and frontend technologies.  
The goal of this project is to explore scalable system design, clean architecture principles, and distributed system patterns.

### Tech Stack
- Backend: ASP.NET Core (.NET 8)
- Database: MS SQL Server (Docker)
- ORM: Entity Framework Core (Database First)
- Messaging (planned): Kafka
- Frontend (planned): Angular
- Containerization: Docker

---

## Current State
- Order Service (ASP.NET Core Web API)
- MS SQL Server (Docker)
- Database First with EF Core

### Setup

### Database Setup

1. Start SQL Server container:
   docker start sqlserver

2. Configure connection string:
   Rename `appsettings.Development.Example.json` to `appsettings.Development.json`
   and set your own password.

Example:
"Password=YOUR_PASSWORD"

---

## Implemented
- Order Service (ASP.NET Core Web API)
- Entity Framework Core with Database-First approach
- SQL Server running in Docker
- Custom validation attributes
- Global exception handling middleware
- Structured error handling (ProblemDetails)
- Unit Tests (Service Layer)
- Integration Tests (API + Middleware + Routing)

### In Progress / Planned
- API Gateway
- Additional services (e.g. Payment, User)
- Kafka integration for event-driven communication
- Frontend (Angular)
- Improved logging (structured logging / cloud-ready)

---

## Architecture Decisions
The system follows a **microservice-oriented architecture**:

- Database First approach for better control over schema
- Each service owns its own database
- Services communicate via APIs (and later events)
- Clean separation of concerns (Controller → Service → Data)
- Using GUIDs for distributed system compatibility
- Using Docker for reproducible environments

### Key Concepts

- **Dependency Injection** for loose coupling
- **Middleware Pipeline** for cross-cutting concerns (logging, error handling)
- **DTO Pattern** for API contracts
- **Factory Pattern** for entity creation
- **Test Isolation** using in-memory databases

---