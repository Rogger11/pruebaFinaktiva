# Utiliza la imagen oficial de .NET como imagen base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliza la imagen SDK para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["backend/Finaktiva.csproj", "backend/"]
RUN dotnet restore "backend/Finaktiva.csproj"
COPY . .
WORKDIR "/src/backend"
RUN dotnet build "Finaktiva.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finaktiva.csproj" -c Release -o /app/publish

# Utiliza la imagen base para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finaktiva.dll"]
