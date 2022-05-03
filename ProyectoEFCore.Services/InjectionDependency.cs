using Microsoft.Extensions.DependencyInjection;
using ProyectoEFCore.Services.Profiles;

namespace ProyectoEFCore.Services;

public static class InjectionDependency
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddTransient<IPeliculaService, PeliculaService>();
        services.AddTransient<ITicketService, TicketService>();
        services.AddTransient<IProductoService, ProductoService>();

        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(p => p.AddProfile(new AutoMapperProfiles()));
        return services;
    }
}