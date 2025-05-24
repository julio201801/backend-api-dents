using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.QueryServices;

public interface IPacienteReadService
{
    Task<IEnumerable<LisPacienteResponseDto>> ListPacienteDtoAsync();
    Task<Paciente> GetPacienteDtoAsync(string dni);
}
