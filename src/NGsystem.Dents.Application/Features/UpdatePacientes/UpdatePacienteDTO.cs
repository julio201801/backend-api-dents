namespace NGsystem.Dents.Application.Features.UpdatePacientes;

public record PacienteUpdateRequestDto(
     int? id,
     string? Nombre,
     string? Apellido,
     string? FechaNacimiento,
     string? Genero,
     string? Telefono,
     string? Direccion,
     string? Dni
    );
public record PacienteUpdateResponseDTO(string dni, string mensaje);