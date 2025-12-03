using BpmsService.Infrastructure.Implementations;
using BpmsService.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BpmsService.Infrastructure;

public static class BpmsServiceInfraRegistrations
{
    public static IServiceCollection InfraRegistrations(this IServiceCollection services)
    {
        services.AddScoped<IProcessDefinitionService, ProcessDefinitionService>();
        return services;
    }
}