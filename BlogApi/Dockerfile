    FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

    WORKDIR /app
    COPY *.csproj ./
    RUN dotnet restore
    COPY . ./
    RUN dotnet publish ./BlogApi --configuration Release --output ./out
    
    FROM mcr.microsoft.com/dotnet/aspnet:3.1
    WORKDIR /app
    EXPOSE 5010/tcp
    ENV ASPNETCORE_URLS http://*:5010
    COPY —-from=build-env /app/out .
    ENTRYPOINT [“dotnet”, “ProductsAPIServices.dll”]