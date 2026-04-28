# MotorON - Backend API

Backend API built with ASP.NET Core for vehicle maintenance tracking.

## Tech Stack
- .NET 8+
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Serilog for logging

## Setup

### Prerequisites
- .NET 8 SDK
- Docker & Docker Compose
- PostgreSQL (via Docker)

### Database Setup
```bash
docker-compose up -d
dotnet ef database update
```

### Run
```bash
dotnet run
```

## Project Structure
```
MotorON.Api/          # Main API project
├── Controllers/      # API endpoints
├── Models/          # Domain entities
├── Services/        # Business logic
└── Program.cs       # Configuration

MotorON.Tests/       # Unit tests
```

## API Documentation
Swagger available at `/swagger` when running.
