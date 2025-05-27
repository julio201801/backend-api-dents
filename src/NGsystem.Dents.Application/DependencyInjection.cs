using Microsoft.Extensions.DependencyInjection;
using NGsystem.Dents.Application.Features.ListPacientes;
using System.Reflection;
using FluentValidation;
using NGsystem.Dents.Application.Features.CreatePaciente;
using NGsystem.Dents.Application.Features.UpdatePacientes;
using NGsystem.Dents.Application.Features.DeletePaciente;
namespace NGsystem.Dents.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetPacienteHandler>();
        services.AddScoped<ListPacienteHandler>();
        services.AddScoped<CreatePacienteHandler>();
        services.AddScoped<UpdatePacienteHandler>();
        services.AddScoped<DeletePacienteHandler>();
       
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}