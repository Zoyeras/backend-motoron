# MotorON Backend 🔧

API REST desarrollada en C# con .NET 10 y ASP.NET Core, enfocada en exponer funcionalidades de mantenimiento predictivo, administración de recargas de combustible y resiliencia de la PWA.

## 🧱 Tecnologías

- **Framework**: .NET 10 (ASP.NET Core Web API)
- **ORM Base de Datos**: Entity Framework Core 10 (Migrations).
- **Base de Datos**: PostgreSQL 16
- **Contenedores**: Docker / Docker Compose

---

## 🚦 Primeros Pasos 

1. **Configuración de Variables**
   Para el entorno puedes basarte en `appsettings.Development.json` y apuntar tu **Connection String** al puerto expuesto de Docker (Ej: `5433`).

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5433;Database=motoron_db;Username=motoron;Password=dev_password_123;"
   }
   ```

2. **Base de Datos & Docker**
   Ve a la raíz de tu proyecto donde radica `docker-compose.yml` e inicializa el entorno de datos. 
   
   ```bash
   docker-compose up -d
   ```

3. **Creación / Restauración Tablas (Migrations)**
   El entorno fue diseñado bajo un flujo *Code-First*. Al encender el proyecto en un host limpio ejecuta:
   ```bash
   # Dentro de `/backend-motoron`
   dotnet ef database update --project src/MotorON.Api
   ```

4. **Correr Localmente**
   Simplemente compila y levanta la aplicación:
   ```bash
   dotnet run --project src/MotorON.Api
   ```
   **La API escuchará peticiones sobre:** `http://localhost:5014`.

## ⚙️ Arquitectura

- **Models**: `GastoCombustible.cs`, `Mantenimiento.cs`, `Vehicle.cs`. (Representan la BDD relacional).
- **Controllers**: Enrutadores limpios para servir JSONs `[Route("api/[controller]")]`. 
- **Services (`OilChangeService`)**: Núcleo predictivo del negocio; se encarga de cruzar los promedios de kilometraje y fechas para devolver la estructura real de previsión del próximo cambio de aceite.
- **DTOs**: Validaciones sin afectar de las entidades del DB de Entity Framework.

