FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy project files
COPY backend-motoron/src/MotorON.Api/*.csproj ./
RUN dotnet restore --no-cache

# Copy source code
COPY backend-motoron/src/MotorON.Api/ ./
RUN dotnet build -c Release --no-restore

# Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS publish
WORKDIR /app
COPY --from=build /app ./
RUN dotnet publish -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=publish /app/out .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "MotorON.Api.dll"]
