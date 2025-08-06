# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY ./Amazon.Api.sln .                               # Assuming the .sln is inside Amazon.Api
COPY ./Amazon.Api/*.csproj ./Amazon.Api/

# Restore dependencies
RUN dotnet restore ./Amazon.Api.sln

# Copy all source code
COPY . .

# Build the project
WORKDIR /app/Amazon.Api
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/Amazon.Api/out ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Amazon.Api.dll"]

