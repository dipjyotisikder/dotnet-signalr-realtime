# Signal Flow - Real-Time Communication Hub

Production-ready real-time communication platform built with ASP.NET Core SignalR and Angular.

## Quick Links

- [Tech Stack](#tech-stack)
- [Setup](#setup)
- [Development](#development)
- [Testing](#testing)
- [Deployment](#deployment)

## Tech Stack

Backend: ASP.NET Core 10.0, SignalR, Entity Framework Core, SQLite, Swagger/OpenAPI, JWT authentication
Frontend: Angular 17.3, SignalR Client, RxJS, TypeScript
DevOps: Docker, GitHub Actions

## Setup

### Prerequisites

- .NET 10.0 SDK or later
- Node.js 18.x or later
- npm 9.x or later
- Docker (optional)

### Installation

```bash
git clone https://github.com/yourusername/signalr-dotnet.git
cd signalr-dotnet
npm install
cd src/server/signalr.api
dotnet restore
cd ../../../
```

### Run

Terminal 1:

```bash
npm run start:server    # ASP.NET backend
```

Terminal 2:

```bash
npm run start:client    # Angular frontend
```

Access: http://localhost:4200 (Frontend) | http://localhost:5000/swagger (API)

## Development

Backend (.NET):

```bash
cd src/server/signalr.api
dotnet restore
dotnet build
dotnet run
```

Frontend (Angular):

```bash
cd src/client
npm install
npm start      # development server at http://localhost:4200
npm run build  # production build
npm test       # run tests
```

Open Solution:

```bash
# Using .slnx (modern solution format)
dotnet sln SignalR.slnx list
```

## Testing

Backend unit tests (src/server/signalr.test):

- HubServiceUnitTests.cs - SignalR hub service tests
- NotificationsServiceUnitTests.cs - Notification service tests

Run tests:

```bash
# Backend tests
cd src/server/signalr.test
dotnet test

# Backend with coverage
cd src/server/signalr.api
dotnet test /p:CollectCoverage=true

# Frontend tests
cd src/client
npm test -- --watch=false --code-coverage
```

## Deployment

Backend (ASP.NET Core 10.0-alpine):

```bash
docker build -f src/server/signalr.api/Dockerfile -t signalr-api:latest .
docker run -p 5000:5000 -p 5001:5001 signalr-api:latest
```

Frontend (Node 22-alpine + Nginx):

```bash
docker build -f src/client/Dockerfile -t signalr-client:latest ./src/client
docker run -p 80:80 signalr-client:latest
```

Docker Compose (all services):

```bash
docker-compose up
```

Access:

- Frontend: http://localhost (port 80)
- Backend API: http://localhost:5000
- API Documentation: http://localhost:5000/swagger

## Project Structure

- `src/server/signalr.api/` - ASP.NET Core 10.0 backend API
- `src/server/signalr.test/` - Unit tests (xUnit)
- `src/client/` - Angular 17.3 frontend
- `SignalR.slnx` - Solution file (modern format)
- `docker-compose.yml` - Multi-container setup

## Contributing

See CONTRIBUTING.md for guidelines.

## License

MIT License
