public record PacienteRequestDto(string dni);
public record PacienteResponseDto(
     int ? Id,
     string? Nombre ,
     string? Apellido,
     string? FechaNacimiento,
     string? Genero,
     string? Telefono,
     string? Direccion,
     string? Dni
    );
