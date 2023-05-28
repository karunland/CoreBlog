FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY ./ ./
RUN dotnet publish ./BlogApi --configuration Release --output ./out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app	
  
# add globalization support
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# installs required packages
RUN apk add libgdiplus --no-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted
RUN apk add libc-dev --no-cache

COPY —-from=build-env /app/out .
ENTRYPOINT [“dotnet”, “ProductsAPIServices.dll”]