# ---- Build aşaması ----
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Her bir katmanı kopyala ve bağımlılıkları restore et
COPY . .

# Her bir katmanı ayrı ayrı build et
RUN dotnet restore ./BusinessLayer
RUN dotnet build ./BusinessLayer --configuration Release

RUN dotnet restore ./DataAccessLayer
RUN dotnet build ./DataAccessLayer --configuration Release

RUN dotnet restore ./EntityLayer
RUN dotnet build ./EntityLayer --configuration Release

RUN dotnet restore ./WebUI
RUN dotnet build ./WebUI --configuration Release

# ---- Publish aşaması ----
FROM build AS publish
RUN dotnet publish ./WebUI --configuration Release --output ./publish

# ---- Runtime aşaması ----
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

# HTTPS yerine HTTP üzerinden Web API'yı çalıştır
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "WebUI.dll"]