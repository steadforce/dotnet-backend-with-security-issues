# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.sln .
# Copy csproj and restore as distinct layers
COPY src/DotnetBackendWithSecurityIssues.Api/*.csproj ./src/DotnetBackendWithSecurityIssues.Api/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "DotnetBackendWithSecurityIssues.Api.dll"]