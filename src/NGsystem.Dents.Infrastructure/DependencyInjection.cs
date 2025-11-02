using Microsoft.Extensions.Logging;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;
using NGsystem.Dents.Infrastructure.Persistence.Repositories;
using NGsystem.Dents.Infrastructure.Seguridad;

namespace NGsystem.Dents.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DentalContext>(options =>
        options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")
                 ).LogTo(Console.WriteLine, LogLevel.Information)
             );
        services.AddScoped<IPacienteReadService, PacienteRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthReadRepository, AuthRepository>();
        return services;
    }
}
