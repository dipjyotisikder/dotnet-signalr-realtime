export const environment = {
  production: true,
  // In Docker, all requests are proxied through nginx to the backend
  // Use empty string so API calls are made to current origin (nginx)
  selfHostedServerURL: '',
  serverlessServerURL: '/signalR/applicationHub',
  // Centralized configuration (managed via .env files)
  apiBaseUrl: 'https://api.yourdomain.com',
  signalrHubEndpoint: '/signalR/applicationHub',
  signalrUrl: 'https://api.yourdomain.com/signalR/applicationHub',
};
