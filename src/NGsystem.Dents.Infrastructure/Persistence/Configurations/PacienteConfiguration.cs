
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Infrastructure.Persistence.Configurations;
public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{

    public void Configure(EntityTypeBuilder<Paciente> builder)
    {

        builder.ToTable("Paciente");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Id");

        builder.Property(e => e.Nombre)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("nombre");

        builder.Property(e => e.Apellido)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("apellido");

        builder.Property(e => e.Genero)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasDefaultValue("")
               .HasColumnName("genero");

        builder.Property(e => e.Telefono)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasDefaultValue("")
               .HasColumnName("telefono");

        builder.Property(e => e.FechaNacimiento)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("fecha_nacimiento");

        builder.Property(e => e.Direccion)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("direccion");

        builder.Property(e => e.Dni)
              .IsRequired()
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("dni");

        builder.Property(e => e.Activo)
             .IsRequired()
             .UsePropertyAccessMode(PropertyAccessMode.Field)
             .HasColumnName("activo");

    }

}



