

using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Common;

namespace NGsystem.Dents.Infrastructure.Persistence.Repositories;
public class PacienteRepository : IPacienteRepository, IPacienteReadService
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public PacienteRepository(DentalContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<LisPacienteResponseDto>> ListPacienteDtoAsync()
    {
        var query = _context.Paciente
                        .AsNoTracking()
                        .AsQueryable();

       return  await query.Select(paciente => new LisPacienteResponseDto(
               paciente.Id,
               paciente.Nombre,
               paciente.Apellido,
               paciente.FechaNacimiento.ToString(),
               paciente.Genero,
               paciente.Telefono,
               paciente.Direccion,
               paciente.Dni)
               ).ToListAsync();
    }
    
    public async Task<Paciente?> GetPacienteDtoAsync(string dni)
    {
        return await _context.Paciente
            .AsNoTracking()
            .Where(p => p.Dni == dni)
            .FirstOrDefaultAsync();
    }
    public async Task<Paciente?> GetIdPacienteDtoAsync(int id)
    {
        return await _context.Paciente
            .AsNoTracking()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }
    public void SavePaciente(Paciente paciente)
    {
        _context.Paciente.Add(paciente);        
    }
    public void UpdatePaciente(Paciente paciente)
    {
        _context.Paciente.Update(paciente);
        
    }
}

