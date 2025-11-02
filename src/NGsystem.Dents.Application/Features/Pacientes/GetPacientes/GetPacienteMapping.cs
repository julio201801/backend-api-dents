using NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;
using NGsystem.Dents.Application.Features.Pacientes.UpdatePacientes;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.Pacientes.GetPacientes;

public static class GetPacienteMapping
{
    public static PacienteResponseDto MapToPacienteItem(this Paciente paciente)
    {
        return new PacienteResponseDto(paciente.Id, paciente.Nombre, paciente.Apellido, paciente.FechaNacimiento.ToString(), paciente.Genero, paciente.Telefono, paciente.Direccion, paciente.Dni);
    }
}
