using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;

namespace NGsystem.Dents.Infrastructure.Persistence.Configurations;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {

        builder.ToTable("Usuario");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdUsuario");

        builder.Property(e => e.Nombre)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Nombre");

        builder.Property(e => e.Correo)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Correo");

        builder.Property(e => e.Clave)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .IsRequired()
               .HasColumnName("Clave");
    }
}
