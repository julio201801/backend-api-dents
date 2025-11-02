using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Common;

namespace NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;

public class Usuario: Entity<int>, IAggregateRoot
{
    public string Nombre { get;private set; }
    public string Correo { get;private set; }
    public string Clave { get; set; }

    public Usuario() { }

    public Usuario( string nombre, string correo, string clave)
    {    
        Nombre = nombre;
        Correo = correo;
        Clave = clave;
    }
    public static Usuario Create(string nombre, string correo,string clave)
    {
        return new(nombre, correo, clave);
    }
}

