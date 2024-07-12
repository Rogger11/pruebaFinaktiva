# Utiliza la imagen oficial de Node.js para compilar la aplicación Angular
FROM node:16 AS build
WORKDIR /app

# Instalar dependencias
COPY package.json package-lock.json ./
RUN npm install

# Copiar el código fuente
COPY . .

# Construir la aplicación
RUN npm run build -- --configuration production

# Utiliza la imagen oficial de Nginx para servir la aplicación Angular
FROM nginx:alpine
COPY --from=build /app/dist/frontend /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
