using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;
public static class CreatePacienteMapping
{
    public static Paciente MapToPaciente(this PacienteCreateRequestDto request)
    {
        return Paciente.Create(request.Nombre, request.Apellido, request.FechaNacimiento, request.Genero, request.Telefono, request.Direccion, request.Dni);
    }
    public static PacienteCreateResponseDTO MapToPacienteResponse(this Paciente paciente)
    {
        return new PacienteCreateResponseDTO(paciente.Dni, "Paciente registrado correctamente");
    }
}
