# BUILD STAGE
FROM node:22-alpine AS builder

WORKDIR /app

# Copy package files
COPY package*.json ./

# Install dependencies with memory optimization
RUN npm install --legacy-peer-deps --loglevel error && \
    npm cache clean --force

# Copy source code
COPY . .

# Build Angular app with production optimization
RUN npm run build -- --configuration production --aot=true --build-optimizer=true || exit 1

# Verify build succeeded and output exists
RUN test -d /app/dist/signal-r.client || (echo "Build failed: dist directory not found" && exit 1)

# RUNTIME STAGE
FROM nginx:latest

# Copy nginx config - replace default
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Copy built app from builder
COPY --from=builder /app/dist/signal-r.client /usr/share/nginx/html

# Verify static files were copied
RUN ls -la /usr/share/nginx/html/ || exit 1

EXPOSE 80

# Health check for nginx
HEALTHCHECK --interval=15s --timeout=10s --start-period=30s --retries=5 \
    CMD nginx -t || exit 1
