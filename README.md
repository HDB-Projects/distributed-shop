# Distributed Shop

## Overview
Microservice-based e-commerce system using .NET, Angular, Docker, and Kafka.

## Current State
- Order Service (ASP.NET Core Web API)
- MS SQL Server (Docker)
- Database First with EF Core

## Database Setup

1. Start SQL Server container:
   docker start sqlserver

2. Configure connection string:
   Rename `appsettings.Development.Example.json` to `appsettings.Development.json`
   and set your own password.

Example:
"Password=YOUR_PASSWORD"

## Setup


## Architecture Decisions
- Database First approach for better control over schema
- Separate database per service (logical separation)
- Using GUIDs for distributed system compatibility
- Using Docker for reproducible environments

### Requirements
- .NET 8
- Docker

### Start Database
docker start sqlserver

### Run Order Service
cd services/order-service
dotnet run

## Database
Schema is located in:
database/schema/001_initial_schema.sql