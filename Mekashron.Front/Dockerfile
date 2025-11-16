# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

RUN mkdir -p /app/wwwroot/media && \
    mkdir -p /app/umbraco/Data && \
    mkdir -p /app/umbraco/Logs && \
    chmod -R 755 /app/wwwroot && \
    chmod -R 755 /app/umbraco

COPY *.csproj .
RUN dotnet restore


COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .


EXPOSE 10000

RUN mkdir -p /app/wwwroot/media && \
    mkdir -p /app/umbraco/Data && \
    mkdir -p /app/umbraco/Logs && \
    chmod -R 755 /app/wwwroot && \
    chmod -R 755 /app/umbraco
    
ENTRYPOINT ["dotnet", "Mekashron.Front.dll"]