# Build stage
FROM node:20-alpine AS build
WORKDIR /app

# Copy package files
COPY package*.json ./
RUN npm ci --only=production

# Copy source and build
COPY . .
RUN npm run build --prod

# Runtime stage - serve with Nginx
FROM nginx:alpine AS runtime
COPY --from=build /app/dist/client /usr/share/nginx/html

# Copy custom nginx config for SPA routing
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80