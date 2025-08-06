# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything in the current directory (where Dockerfile is)
COPY . .

# Restore and build the solution
RUN dotnet restore Amazon.Api.sln
RUN dotnet publish Amazon.Api.csproj -c Release -o /app/publish

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output from build stage
COPY --from=build /app/publish .

# Set environment and expose port
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "Amazon.Api.dll"]

