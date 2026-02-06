using Microsoft.Extensions.DependencyInjection;
using SignalR.Api.Infrastructure.Services;

namespace SignalR.Api.Infrastructure.DependencyInjection;

/// <summary>
/// Contains the infrastructure dependencies.
/// </summary>
public static class InfrastructureDependency
{
    /// <summary>
    /// Adds the infrastructure dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddScoped<IAzureSignalRService, AzureSignalRService>();

        return services;
    }
}
