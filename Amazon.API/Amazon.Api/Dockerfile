# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files (they're in current folder)
COPY Amazon.API.sln .
COPY Amazon.Api.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy all project files
COPY . .

# Build the project
RUN dotnet publish -c Release -o out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Amazon.Api.dll"]

