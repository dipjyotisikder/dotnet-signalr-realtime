#BUILD STAGE START
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

#SET WORKING DIR
WORKDIR /app

#COPY everything first
COPY . .

#RESTORE with memory optimization
RUN dotnet restore "src/server/signalr.api/SignalR.Api.csproj" --nologo --verbosity quiet

#PUBLISH with Release configuration
RUN dotnet publish "src/server/signalr.api/SignalR.Api.csproj" \
    -c Release \
    --no-restore \
    --nologo \
    /p:EnforceCodeStyleInBuild=false \
    /p:TreatWarningsAsErrors=false \
    /p:EnableNETAnalyzers=false \
    /p:RunAnalyzersDuringBuild=false \
    /p:RunAnalyzersDuringPublish=false \
    /p:GenerateDocumentationFile=false \
    /p:Nullable=disable \
    -o /app/publish/

#RUNTIME STAGE START
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development

RUN apk add --no-cache wget

EXPOSE 5000
EXPOSE 5001

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SignalR.Api.dll"]