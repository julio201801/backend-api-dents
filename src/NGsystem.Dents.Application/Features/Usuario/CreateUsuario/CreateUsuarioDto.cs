
namespace NGsystem.Dents.Application.Features.Usuario.CreateUsuario;

public record UsuarioRequestDto(string Nombre, string Correo, string Clave);
public record UsuarioResponseDto( string Correo,string Mensaje);
