using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;
using NGsystem.Dents.Domain.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NGsystem.Dents.Infrastructure.Persistence.Repositories;

public class UsuarioRepository: IUsuarioRepository
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public UsuarioRepository(DentalContext context)
    {
        _context = context;
    }
    public void AddUsers(Usuario usuario)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(usuario.Clave);
        usuario.Clave = passwordHash;
       
        _context.Usuario.Add(usuario);
    }
    
}
