
namespace NGsystem.Dents.Application.Features.Usuario.CreateUsuario;
using NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;

using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;
public static class CreateUsuarioMapping
{
    public static Usuario MapToUsuario(this UsuarioRequestDto request)
    {
        return Usuario.Create(request.Nombre, request.Correo,request.Clave);
    }
    public static UsuarioResponseDto MapToUsuarioResponse(this Usuario usuario)
    {
        return new UsuarioResponseDto(usuario.Correo, "Usuario registrado correctamente");
    }
}
