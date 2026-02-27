# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore FiapHackatonAlertEngine/FiapHackatonAlertEngine.WebAPI.csproj

RUN dotnet publish FiapHackatonAlertEngine/FiapHackatonAlertEngine.WebAPI.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FiapHackatonAlertEngine.WebAPI.dll"]