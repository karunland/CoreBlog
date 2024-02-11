# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore ./BusinessLayer
RUN dotnet build ./BusinessLayer --configuration Release

RUN dotnet restore ./DataAccessLayer
RUN dotnet build ./DataAccessLayer --configuration Release

RUN dotnet restore ./EntityLayer
RUN dotnet build ./EntityLayer --configuration Release

RUN dotnet restore ./WebUI
RUN dotnet build ./WebUI --configuration Release

# ---- Publish stage ----
FROM build AS publish
RUN dotnet publish ./WebUI --configuration Release --output ./publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:5011
EXPOSE 5011

ENTRYPOINT ["dotnet", "WebUI.dll"]