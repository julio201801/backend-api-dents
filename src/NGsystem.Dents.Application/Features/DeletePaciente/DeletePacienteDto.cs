namespace NGsystem.Dents.Application.Features.DeletePaciente;

public record PacienteDeleteRequestDto(
     int Id,
     bool Activo
      );
public record PacienteDeleteResponseDTO(string dni, string mensaje);
