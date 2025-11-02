using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;
using NGsystem.Dents.Application.Features.Pacientes.DeletePaciente;
using NGsystem.Dents.Application.Features.Pacientes.GetPacientes;
using NGsystem.Dents.Application.Features.Pacientes.ListPacientes;
using NGsystem.Dents.Application.Features.Pacientes.UpdatePacientes;
using NGsystem.Dents.Application.Features.Usuario.CreateUsuario;
using NGsystem.Dents.Application.Features.Usuario.auth;
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
        services.AddScoped<CreateUsuarioHandler>();
        services.AddScoped<LoginHandler>();
        


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}