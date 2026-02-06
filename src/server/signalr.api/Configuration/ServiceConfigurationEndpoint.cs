using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR.Api.Constants;

namespace SignalR.Api.Configuration;

/// <summary>
/// Provides configuration endpoints for frontend applications.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ServiceConfigurationController : ControllerBase
{
    private readonly AppConfiguration _appConfiguration;

    public ServiceConfigurationController(AppConfiguration appConfiguration)
    {
        _appConfiguration = appConfiguration;
    }

    /// <summary>
    /// Gets the service configuration for frontend applications.
    /// This endpoint is NOT protected by authentication to allow frontend to load config before authentication.
    /// </summary>
    /// <returns>The service configuration.</returns>
    [HttpGet("client")]
    [AllowAnonymous]
    public IActionResult GetClientConfiguration()
    {
        var config = new
        {
            apiBaseUrl = _appConfiguration.ApiBaseUrl,
            signalrHubEndpoint = HubConstants.HUB_ENDPOINT,
            signalrUrl = $"{_appConfiguration.ApiBaseUrl}{HubConstants.HUB_ENDPOINT}"
        };

        return Ok(config);
    }

    /// <summary>
    /// Gets the full configuration (admin use only).
    /// </summary>
    /// <returns>The full application configuration.</returns>
    [HttpGet("all")]
    public IActionResult GetFullConfiguration()
    {
        return Ok(_appConfiguration);
    }
}
