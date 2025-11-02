namespace NGsystem.Dents.Application.Features.Pacientes.DeletePaciente;

public record PacienteDeleteRequestDto(
     int Id,
     bool Activo
      );
public record PacienteDeleteResponseDTO(string dni, string mensaje);
