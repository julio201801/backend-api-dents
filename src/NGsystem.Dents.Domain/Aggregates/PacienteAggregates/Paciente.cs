
using NGsystem.Dents.Domain.Common;

namespace NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

public class Paciente :Entity<int>, IAggregateRoot
{
    public string ?Nombre { get;private set; }
    public string ?Apellido { get;private set; }
    public DateTime FechaNacimiento { get; private set; }
    public string ?Genero { get; private set; }
    public string ?Telefono { get;private set; }
    public string ?Direccion { get;private set; }
    public string? Dni { get; private set; }
    public bool? Activo { get; private set; }
    public Paciente() { }
    // Constructor privado para garantizar uso de métodos de fábrica
    private Paciente(string nombre, string apellido, string fechaNacimiento, string genero, string telefono, string direccion, string dni)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = DateTime.Parse(fechaNacimiento);
        Genero = genero;
        Telefono = telefono;
        Direccion = direccion;
        Dni = dni;
    }
    // Método de fábrica para crear una instancia
    public static Paciente Create(string nombre, string apellido, string fechaNacimiento, string genero, string telefono, string direccion, string dni)
    {
        return new (nombre, apellido, fechaNacimiento, genero, telefono, direccion, dni);
    }
  
    // Método de actualización desde el DTO
    public void Update(string nombre, string apellido, string fechaNacimiento, string genero, string telefono, string direccion, string dni)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = DateTime.Parse(fechaNacimiento);
        Genero = genero;
        Telefono = telefono;
        Direccion = direccion;
        Dni = dni;
    }
    public void ReplaceActivo(bool activo)
    { 
        Activo=activo;
    }

}