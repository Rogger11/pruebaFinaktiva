# Utiliza la imagen oficial de .NET como imagen base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliza la imagen SDK para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiar el archivo de proyecto y restaurar dependencias
COPY ["Finaktiva.csproj", "./"]
RUN dotnet restore "Finaktiva.csproj"

# Copiar el resto de los archivos y construir la aplicación
COPY . .
WORKDIR "/src"
RUN dotnet build "Finaktiva.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finaktiva.csproj" -c Release -o /app/publish

# Utiliza la imagen base para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finaktiva.dll"]
