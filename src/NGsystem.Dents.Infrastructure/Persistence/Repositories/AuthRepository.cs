using NGsystem.Dents.Domain.Common;
using System.Text;
using System.Security.Cryptography;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Infrastructure.Seguridad;
using NGsystem.Dents.Application.Features.Usuario.auth;
namespace NGsystem.Dents.Infrastructure.Persistence.Repositories;
public class AuthRepository : IAuthReadRepository
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public readonly IJwtService _jwtService;
    public AuthRepository(DentalContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService=jwtService;

    }
    public async Task<LoginResponseDto> ValidateUsuarioAsunc(string correo, string plainPassword)
    {
        var usuario = await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Correo == correo);
        if (usuario == null)
            return new LoginResponseDto("Usuario no existe", "");

        //Verifica el hash
        bool isvalid = BCrypt.Net.BCrypt.Verify(plainPassword, usuario.Clave);
        if (!isvalid)
        {
            return new LoginResponseDto("Clave incorrecta", "");
            
        }
        var token = _jwtService.GenerateToken(usuario.Correo, "Admin");
        var reponse = new LoginResponseDto(usuario.Correo, token);
        return reponse;
    }
}
