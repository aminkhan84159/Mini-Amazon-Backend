# ----- Build Stage -----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy only the solution and project files
COPY Amazon.API/Amazon.Api/*.sln ./
COPY Amazon.API/Amazon.Api/*.csproj ./

# Copy the rest of the code
COPY Amazon.API/Amazon.Api/. ./

# Restore and publish
RUN dotnet restore Amazon.Api.sln
RUN dotnet publish -c Release -o /out

# ----- Runtime Stage -----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Amazon.Api.dll"]

