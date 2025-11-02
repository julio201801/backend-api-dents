using System.Runtime.CompilerServices;

namespace NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;
public record PacienteCreateRequestDto(
     string? Nombre,
     string? Apellido,
     string? FechaNacimiento,
     string? Genero,
     string? Telefono,
     string? Direccion,
     string? Dni
    );
public record PacienteCreateResponseDTO(string dni, string mensaje);