using BpmsService.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BpmsService.Domain;

public static class BpmsServiceRegistrations
{
    public static IServiceCollection DomainRegistrations(this IServiceCollection services,IConfiguration configuratons)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuratons.GetConnectionString("DefaultConnection"));
        });
        return services;
    }   
}