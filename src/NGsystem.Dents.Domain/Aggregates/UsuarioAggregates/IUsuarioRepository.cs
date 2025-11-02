using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Common;

namespace NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;

public interface IUsuarioRepository : IRepository<Usuario>
{
    void AddUsers(Usuario usuario);
    //Task<Usuario> ValidateUsuarioAsunc(string correo, string plainPassword);
}
