
# Event Management Application

## Descripción

Esta aplicación permite gestionar eventos mediante un backend en .NET 6 y un frontend en Angular 16. Los usuarios pueden registrar eventos, ver una lista de eventos y aplicar filtros para buscar eventos específicos. La aplicación asegura buena transaccionalidad, manejo desacoplado de la base de datos y registro de excepciones.

## Prueba

Se ha desplegado la aplicación en un ambiente de desarrollo en un Servidor Dedicado con Ubuntu 22.04.

[Backend](http://69.61.227.218:412/swagger)
[Frontend](http://69.61.227.218:413)

## Requisitos

- Docker
- Docker Compose
- .NET 6 SDK
- Node.js (versión 18 o superior)
- Angular CLI (versión 16)
- SQL Server (LocalDB o cualquier instancia de SQL Server)

## Configuración del Backend

1. **Clonar el Repositorio**:

   ```sh
   git clone https://github.com/Rogger11/pruebaFinaktiva/
   cd pruebaFinaktiva/backend
   ```

2. **Configurar la Base de Datos**:

   Asegúrate de que `appsettings.json` tenga la cadena de conexión correcta para tu instancia de SQL Server.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;User=admin;Password=Milton1103.;Database=Registration;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*"
   }
   ```

3. **Restaurar Paquetes y Crear la Base de Datos**:

   ```sh
   dotnet restore
   dotnet ef database update
   ```

4. **Ejecutar la Aplicación**:

   ```sh
   dotnet run
   ```

   La aplicación estará disponible en `https://localhost:5001`.

## Configuración del Frontend

1. **Instalar Dependencias**:

   ```sh
   cd ../frontend
   npm install
   ```

2. **Ejecutar la Aplicación**:

   ```sh
   ng serve
   ```

   La aplicación estará disponible en `http://localhost:4200`.

## Despliegue con Docker

1. **Construir y ejecutar los contenedores**:

   ```sh
   docker-compose up --build
   ```

2. **Verificar que los contenedores estén funcionando**:

   ```sh
   docker ps
   ```

3. **Acceder a la aplicación**:
   - El backend estará disponible en [http://localhost:412](http://localhost:412).
   - El frontend estará disponible en [http://localhost:413](http://localhost:413).

## Ejecución sin Docker

### Backend

1. **Clonar el Repositorio**:

   ```sh
   git clone https://github.com/Rogger11/pruebaFinaktiva/
   cd pruebaFinaktiva/backend
   ```

2. **Configurar la Base de Datos**:

   Asegúrate de que `appsettings.json` tenga la cadena de conexión correcta para tu instancia de SQL Server.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;User=admin;Password=Milton1103.;Database=Registration;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*"
   }
   ```

3. **Restaurar Paquetes y Crear la Base de Datos**:

   ```sh
   dotnet restore
   dotnet ef database update
   ```

4. **Ejecutar la Aplicación**:

   ```sh
   dotnet run
   ```

   La aplicación estará disponible en `https://localhost:5001`.

### Frontend

1. **Instalar Node.js y Angular CLI**:

   Asegúrate de tener Node.js versión 18 o superior y Angular CLI instalado globalmente.

   ```sh
   node -v
   npm install -g @angular/cli
   ```

2. **Clonar el Repositorio**:

   ```sh
   git clone https://github.com/Rogger11/pruebaFinaktiva/
   cd pruebaFinaktiva/frontend
   ```

3. **Instalar Dependencias**:

   ```sh
   npm install
   ```

4. **Ejecutar la Aplicación**:

   ```sh
   ng serve
   ```

   La aplicación estará disponible en `http://localhost:4200`.

## Uso de la Aplicación

1. **Registrar un Evento**:
   - Navega a la sección de registro de eventos.
   - Completa los campos "Description" y "Event Type".
   - Haz clic en "Register Event".

2. **Ver Lista de Eventos**:
   - La lista de eventos muestra todos los eventos registrados por defecto.

3. **Aplicar Filtros**:
   - Navega a la sección de filtros.
   - Selecciona el tipo de evento, la fecha de inicio y/o la fecha de fin.
   - Haz clic en "Apply Filters" para ver los eventos que coinciden con los criterios de búsqueda.

## Consideraciones de Diseño e Implementación

1. **Transaccionalidad**:
   - Las operaciones de creación de eventos en el backend utilizan transacciones para asegurar la consistencia de la base de datos.

2. **Manejo Desacoplado de la Base de Datos**:
   - El uso de Entity Framework Core permite un manejo desacoplado de la base de datos.
   - Los servicios en el backend (`EventLogService`) se encargan de la lógica de negocio, desacoplando el acceso a la base de datos de los controladores.

3. **Registro de Excepciones**:
   - Tanto en el backend como en el frontend, se manejan las excepciones y se registran errores.
   - En el backend, se utiliza `ILogger` para registrar excepciones.
   - En el frontend, se muestran mensajes de error amigables al usuario y se registran errores en la consola del navegador.

4. **Interfaz de Usuario**:
   - Se utiliza Bootstrap para un diseño limpio y responsivo.
   - Las alertas de Bootstrap se usan para mostrar mensajes de error al usuario.
   - La interfaz es accesible y fácil de usar, con formularios y tablas bien estructuradas.

## Conclusiones

Esta aplicación de gestión de eventos asegura una buena transaccionalidad, manejo desacoplado de la base de datos y registro de excepciones, cumpliendo con los requisitos especificados. La interfaz de usuario es intuitiva y accesible, facilitando el uso de la aplicación por parte de los usuarios.
