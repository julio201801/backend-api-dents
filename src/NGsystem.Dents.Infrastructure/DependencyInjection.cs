using Microsoft.Extensions.Logging;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Infrastructure.Persistence.Repositories;

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
        
        return services;
    }
}
