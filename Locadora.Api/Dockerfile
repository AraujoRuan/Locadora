#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8090
#EXPOSE 4443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Locadora.Api/Locadora.Api.csproj", "Locadora.Api/"]
COPY ["Locadora.Domain/Locadora.Domain.csproj", "Locadora.Domain/"]
COPY ["Locadora.Infra/Locadora.Infra.csproj", "Locadora.Infra/"]
RUN dotnet restore "Locadora.Api/Locadora.Api.csproj"
COPY . .
WORKDIR "/src/Locadora.Api"
RUN dotnet build "Locadora.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locadora.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locadora.Api.dll"]