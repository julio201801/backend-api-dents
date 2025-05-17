using NGsystem.Dents.Application.Features.CreatePaciente;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.UpdatePacientes;
public static class UpdatePacienteMapping
{
    public static void MapToUpdatePaciente(this Paciente paciente, PacienteUpdateRequestDto request)
    {
        paciente.Update(
            request.Nombre,
            request.Apellido,
            request.FechaNacimiento,
            request.Genero,
            request.Telefono,
            request.Direccion,
            request.Dni);
    }
    public static PacienteUpdateResponseDTO MapToUpdatePacienteResponse(this Paciente paciente)
    {
        return new PacienteUpdateResponseDTO(paciente.Dni, "Se actualizo correctamente");
    }
  
}