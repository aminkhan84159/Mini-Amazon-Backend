# ----- Build Stage -----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all projects (copy entire Amazon.API folder)
COPY Amazon.API/. .

# Set working dir to main API folder (where the solution is)
WORKDIR /src/Amazon.Api

# Restore and publish
RUN dotnet restore Amazon.Api.sln
RUN dotnet publish Amazon.Api.csproj -c Release -o /app/publish

# ----- Runtime Stage -----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Amazon.Api.dll"]

