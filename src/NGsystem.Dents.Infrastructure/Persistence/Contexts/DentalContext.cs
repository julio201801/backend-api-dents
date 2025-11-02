
using Microsoft.EntityFrameworkCore;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;
using NGsystem.Dents.Domain.Common;
using NGsystem.Dents.Infrastructure.Persistence.Configurations;

namespace NGsystem.Dents.Infrastructure.Persistence.Contexts;
public class DentalContext : DbContext, IUnitOfWork
{
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    public DentalContext(DbContextOptions<DentalContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PacienteConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}