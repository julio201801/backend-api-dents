using NGsystem.Dents.Application.Features.CreatePaciente;
using NGsystem.Dents.Application.Features.UpdatePacientes;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.ListPacientes;

public static class GetPacienteMapping
{
    public static PacienteResponseDto MapToPacienteItem(this Paciente paciente)
    {
        return new PacienteResponseDto(paciente.Id, paciente.Nombre, paciente.Apellido, paciente.FechaNacimiento.ToString(), paciente.Genero, paciente.Telefono, paciente.Direccion, paciente.Dni);
    }
}
