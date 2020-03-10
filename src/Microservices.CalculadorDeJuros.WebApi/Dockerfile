#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservices.CalculadorDeJuros.WebApi/Microservices.CalculadorDeJuros.WebApi.csproj", "src/Microservices.CalculadorDeJuros.WebApi/"]
COPY ["src/Microservices.CalculadorDeJuros.Services/Microservices.CalculadorDeJuros.Services.csproj", "src/Microservices.CalculadorDeJuros.Services/"]
COPY ["src/Microservices.CalculadorDeJuros.Domain/Microservices.CalculadorDeJuros.Domain.csproj", "src/Microservices.CalculadorDeJuros.Domain/"]
RUN dotnet restore "src/Microservices.CalculadorDeJuros.WebApi/Microservices.CalculadorDeJuros.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Microservices.CalculadorDeJuros.WebApi"
RUN dotnet build "Microservices.CalculadorDeJuros.WebApi.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "Microservices.CalculadorDeJuros.WebApi.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.CalculadorDeJuros.WebApi.dll"]
