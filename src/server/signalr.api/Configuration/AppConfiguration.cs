namespace SignalR.Api.Configuration;

/// <summary>
/// Centralized application configuration for ports, origins, and service URLs.
/// </summary>
public class AppConfiguration
{
    /// <summary>
    /// Gets or sets the frontend port.
    /// </summary>
    public int FrontendPort { get; set; } = 4200;

    /// <summary>
    /// Gets or sets the API port.
    /// </summary>
    public int ApiPort { get; set; } = 5000;

    /// <summary>
    /// Gets or sets the SignalR hub endpoint.
    /// </summary>
    public string SignalRHubEndpoint { get; set; } = "/signalR/applicationHub";

    /// <summary>
    /// Gets or sets the list of allowed origins for CORS.
    /// </summary>
    public string[] AllowedOrigins { get; set; } = new[]
    {
        "http://localhost:4200",
        "https://localhost:4200",
        "http://signalr-client",
        "http://signalr-client:80"
    };

    /// <summary>
    /// Gets or sets the API base URL.
    /// </summary>
    public string ApiBaseUrl { get; set; } = "http://localhost:5000";

    /// <summary>
    /// Gets or sets the frontend base URL.
    /// </summary>
    public string FrontendBaseUrl { get; set; } = "http://localhost:4200";
}
