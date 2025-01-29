using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}