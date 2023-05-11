# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

# ASP.NET Core geliştirici sertifikasını yükle
# RUN dotnet dev-certs https --trust

# Run HTTP instead of HTTPS 
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "WebUI.dll"]