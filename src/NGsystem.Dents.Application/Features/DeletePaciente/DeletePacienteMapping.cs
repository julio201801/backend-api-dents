
using NGsystem.Dents.Application.Features.UpdatePacientes;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.DeletePaciente;

public static class DeletePacienteMapping
{
    public static void MapToDeletePaciente(this Paciente paciente, PacienteDeleteRequestDto request)
    {
        paciente.ReplaceActivo(request.Activo);
    }
    public static PacienteDeleteResponseDTO MapToDeletePacienteResponse(this Paciente paciente)
    {
        return new PacienteDeleteResponseDTO(paciente.Dni, "Se desactivo correctamente");
    }
}