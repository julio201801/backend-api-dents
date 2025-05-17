using NGsystem.Dents.Domain.Common;
namespace NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
public interface IPacienteRepository: IRepository<Paciente>
{
    void SavePaciente(Paciente paciente);
}
