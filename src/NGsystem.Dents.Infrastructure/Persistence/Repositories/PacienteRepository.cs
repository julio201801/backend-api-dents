

using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Common;

namespace NGsystem.Dents.Infrastructure.Persistence.Repositories;
public class PacienteRepository : IPacienteRepository, IPacienteService
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
               paciente.Telefono,
               paciente.Genero,
               paciente.Direccion,
               paciente.Dni)
               ).ToListAsync();
         
    }
    
    public async Task<Paciente?> GetPacienteDtoAsync(string dni)
    {
        //return await _context.Paciente
        //    .AsNoTracking()
        //    .Where(c => c.Dni == dni)
        //    .Select(paciente => new PacienteResponseDto(
        //        paciente.Id,
        //        paciente.Nombre,
        //        paciente.Apellido,
        //        paciente.FechaNacimiento.ToShortDateString(),
        //        paciente.Genero,
        //        paciente.Telefono,          
        //        paciente.Direccion,
        //        paciente.Dni
        //    ))
        //    .FirstOrDefaultAsync(); 
        return await _context.Paciente
            .AsNoTracking()
            .Where(p => p.Dni == dni)
            .FirstOrDefaultAsync();

    }
    public async Task<IEnumerable<PacienteResponseDto>> CreatePacienteDtoAsync(string dni)
    {
        var query = _context.Paciente
                        .AsNoTracking()
                        .AsQueryable();
        query = query.Where(c => c.Dni.Equals(dni));

        return await query.Select(paciente => new PacienteResponseDto(
                paciente.Id,
                paciente.Nombre,
                paciente.Apellido,
                paciente.FechaNacimiento.ToString(),
                paciente.Telefono,
                paciente.Genero,
                paciente.Direccion,
                paciente.Dni)
                ).ToListAsync();

    }
    public void SavePaciente(Paciente paciente)
    {
        if (_context.Entry(paciente).State == EntityState.Detached)
        {
            _context.Paciente.Add(paciente);
        }
        else
        {
            _context.Paciente.Update(paciente);
        }
    }
}

