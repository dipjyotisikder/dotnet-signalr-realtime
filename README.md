# SignalR DotNet - Real-Time Communication Platform

[![.NET Build & Test](https://github.com/yourusername/signalr-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/yourusername/signalr-dotnet/actions/workflows/dotnet.yml)
[![Angular Build & Test](https://github.com/yourusername/signalr-dotnet/actions/workflows/angular.yml/badge.svg)](https://github.com/yourusername/signalr-dotnet/actions/workflows/angular.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A modern, production-ready real-time communication platform built with **ASP.NET Core SignalR** and **Angular**. This repository demonstrates best practices for building scalable, real-time applications with modern web technologies.

## 📋 Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Quick Start](#quick-start)
- [Development](#development)
- [Testing](#testing)
- [Deployment](#deployment)
- [Documentation](#documentation)
- [Contributing](#contributing)
- [License](#license)

## ✨ Features

- **Real-Time Communication**: Bi-directional, low-latency messaging with SignalR
- **Scalable Architecture**: Event-driven design supporting multiple concurrent connections
- **Authentication & Authorization**: JWT token-based security
- **Database Integration**: SQLite with Entity Framework Core ORM
- **API Documentation**: Interactive Swagger/OpenAPI spec
- **Unit Testing**: Comprehensive test coverage for both backend and frontend
- **Docker Support**: Containerized deployment ready
- **CORS Configuration**: Secure cross-origin communication
- **Azure SignalR Integration**: Support for Azure cloud deployment

## 🛠 Tech Stack

### Backend

- **Framework**: ASP.NET Core 6.0
- **Real-Time**: SignalR with Azure SignalR support
- **Database**: Entity Framework Core 6.0 with SQLite
- **Authentication**: JWT Bearer tokens
- **Documentation**: Swagger/OpenAPI (Swashbuckle)
- **Testing**: xUnit/MSTest

### Frontend

- **Framework**: Angular 17.3
- **SignalR Client**: @microsoft/signalr 8.0
- **Styling**: CSS, Bootstrap compatibility
- **State Management**: RxJS observables
- **Testing**: Jasmine/Karma
- **Build Tool**: Angular CLI 17

### DevOps

- **Containerization**: Docker
- **CI/CD**: GitHub Actions
- **Version Control**: Git

## 📁 Project Structure

```
signalr-dotnet/
├── src/
│   ├── server/                           # .NET Backend
│   │   ├── signalr.api/                  # Main API project
│   │   │   ├── Hubs/                     # SignalR hubs
│   │   │   ├── Controllers/              # API endpoints
│   │   │   ├── Services/                 # Business logic
│   │   │   ├── Data/                     # DbContext and migrations
│   │   │   ├── Program.cs                # Application startup
│   │   │   └── Dockerfile
│   │   │
│   │   └── signalr.test/                 # Unit tests
│   │       └── HubServiceUnitTests.cs
│   │
│   └── client/                            # Angular Frontend
│       ├── src/
│       │   ├── app/
│       │   │   ├── components/           # Reusable components
│       │   │   ├── services/             # HTTP & SignalR services
│       │   │   ├── models/               # TypeScript interfaces
│       │   │   └── app.component.ts      # Root component
│       │   ├── assets/                   # Static assets
│       │   └── main.ts                  # Application entry point
│       ├── angular.json                  # Angular configuration
│       └── package.json                  # Dependencies
│
├── docs/                                 # Documentation
│   ├── API.md                           # API documentation
│   ├── ARCHITECTURE.md                  # System architecture
│   ├── SETUP.md                         # Detailed setup guide
│   └── DEPLOYMENT.md                    # Deployment guide
│
├── .github/
│   ├── workflows/                       # CI/CD pipelines
│   │   ├── dotnet.yml                  # .NET build & test
│   │   └── angular.yml                 # Angular build & test
│   └── ISSUE_TEMPLATE/                 # Issue templates
│       ├── bug_report.md
│       └── feature_request.md
│
├── .gitignore                           # Git ignore patterns
├── CONTRIBUTING.md                      # Contribution guidelines
├── LICENSE                              # MIT License
├── README.md                            # This file
├── Directory.Build.props                # Global .NET configuration
├── package.json                         # Workspace scripts
└── SignalR.sln                          # Visual Studio solution
```

## 🚀 Quick Start

### Prerequisites

- **.NET 6.0 SDK** or later
- **Node.js 18.x** or later
- **npm 9.x** or later
- **Docker** (optional, for containerized deployment)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/signalr-dotnet.git
   cd signalr-dotnet
   ```

2. **Setup both server and client**

   ```bash
   npm run setup
   ```

   Or separately:

   ```bash
   # Backend setup
   cd src/server/SignalR
   dotnet restore

   # Frontend setup
   cd src/client/SignalR.Client
   npm install
   ```

3. **Start the application**

   **Terminal 1 - Backend (from root)**

   ```bash
   npm run start:server
   ```

   **Terminal 2 - Frontend (from root)**

   ```bash
   npm run start:client
   ```

4. **Access the application**
   - Frontend: http://localhost:4200
   - API Documentation: http://localhost:5000/swagger

## 💻 Development

### Development Workspace Scripts

```bash
# Install all dependencies
npm run setup

# Build entire solution
npm run build

# Run development servers
npm start              # Starts both client and backend
npm run start:server   # Start .NET backend only
npm run start:client   # Start Angular frontend only

# Run tests
npm test              # Run all tests
npm run test:server   # Run backend tests only
npm run test:client   # Run frontend tests only

# Build for production
npm run build:server
npm run build:client
```

### Backend Development

```bash
cd src/server/SignalR

# Restore dependencies
dotnet restore

# Build
dotnet build

# Run
dotnet run --project SignalR.Api/SignalR.Api.csproj

# Run tests
dotnet test

# Entity Framework migrations
dotnet ef migrations add MigrationName --project SignalR.Api
dotnet ef database update
```

### Frontend Development

```bash
cd src/client/SignalR.Client

# Install dependencies
npm install

# Start development server (with hot reload)
npm start

# Build for production
npm run build

# Run tests
npm test

# Run linter
npm run lint
```

## 🧪 Testing

### Backend Tests

```bash
cd src/server/SignalR
dotnet test
# Specific test project
dotnet test SignalR.Test/SignalR.UnitTests.csproj
```

### Frontend Tests

```bash
cd src/client/SignalR.Client
npm test -- --watch=false --code-coverage
```

## 🐳 Docker Deployment

### Build Docker Image

```bash
docker build -f src/server/SignalR/SignalR.Api/Dockerfile -t signalr-api:latest .
```

### Run Container

```bash
docker run -p 5000:5000 -p 5001:5001 signalr-api:latest
```

## 📚 Documentation

Comprehensive documentation is available in the [docs/](docs/) directory:

- [**API Documentation**](docs/API.md) - REST API endpoint reference
- [**Architecture**](docs/ARCHITECTURE.md) - System design and patterns
- [**Setup Guide**](docs/SETUP.md) - Detailed installation instructions
- [**Deployment Guide**](docs/DEPLOYMENT.md) - Production deployment strategies

## 🤝 Contributing

Contributions are welcome! Please follow our [Contributing Guidelines](CONTRIBUTING.md) for:

- Code style standards
- Pull request process
- Testing requirements
- Commit message conventions

## 📝 License

This project is licensed under the [MIT License](LICENSE) - see the LICENSE file for details.

## 🆘 Support

- **Issues**: [GitHub Issues](https://github.com/yourusername/signalr-dotnet/issues)
- **Discussions**: [GitHub Discussions](https://github.com/yourusername/signalr-dotnet/discussions)

## 🔗 Useful Links

- [ASP.NET Core SignalR Documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr)
- [Angular Documentation](https://angular.io/docs)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)

---

Built with ❤️ by the development team

---

## Prerequisites

Ensure you have the following installed:

- .NET SDK (6.0 or higher)
- Node.js and npm (for Angular)
- Docker (optional, for containerized deployment)
- Visual Studio or any other IDE with .NET support
- A modern browser for testing the client-side application

---

## Getting Started

Follow these steps to run the project locally:

### 1. **Clone the Repository**

```bash
git clone https://github.com/dipjyotisikder/signalr-dotnet-demo.git
cd signalr-dotnet-demo

```

## .NET Best Practices

1. **Dependency Injection (DI):**  
   Ensures loose coupling and enhances testability.
2. **Entity Framework (EF) Core Migrations:**  
   Maintains database schema consistency across development environments.
3. **Swagger Integration:**  
   Provides user-friendly and interactive API documentation.
4. **Exception Handling Middleware:**  
   Ensures graceful error handling and consistent API responses.
5. **CORS Configuration:**  
   Allows controlled access to resources across different domains.
6. **Layered Architecture:**  
   Promotes clean separation of concerns for maintainable and scalable code.

## Angular Best Practices

1. **Reactive Forms:**  
   Implements a structured approach to form handling with improved validation.
2. **State Management:**  
   Effectively manages the component state using libraries like NgRx.
3. **Lazy Loading:**  
   Optimizes performance by loading modules only when needed.
4. **Service-Oriented Architecture:**  
   Ensures components are reusable and testable by relying on services.
5. **Strict Typing:**  
   Adopts TypeScript best practices for better reliability and maintainability.

# Use Cases

This project can serve as a foundational starting point for building:

1. **Live Chat Applications:**  
   Enable real-time communication between users.
2. **Real-Time Notifications:**  
   Deliver updates or alerts instantly to users.
3. **Collaborative Tools:**  
   Create applications for shared documents, whiteboards, or task management.
4. **Dynamic Dashboards:**  
   Provide real-time analytics and visualizations tailored to user needs.
