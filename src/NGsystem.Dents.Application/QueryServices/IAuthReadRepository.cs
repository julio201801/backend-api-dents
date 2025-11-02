using NGsystem.Dents.Application.Features.Usuario.auth;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;

namespace NGsystem.Dents.Application.QueryServices;

public interface IAuthReadRepository
{
    Task<LoginResponseDto> ValidateUsuarioAsunc(string correo, string plainPassword);
}
