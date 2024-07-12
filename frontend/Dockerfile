# Utiliza la imagen oficial de Node.js 18 para compilar la aplicación Angular
FROM node:18 AS build
WORKDIR /app

# Instalar Angular CLI globalmente
RUN npm install -g @angular/cli

# Instalar dependencias
COPY package.json package-lock.json ./
RUN npm install

# Copiar el código fuente
COPY . .

# Construir la aplicación
RUN ng build --configuration production

# Utiliza la imagen oficial de Nginx para servir la aplicación Angular
FROM nginx:alpine
COPY --from=build /app/dist/frontend /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
