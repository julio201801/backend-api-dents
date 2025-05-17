using FluentValidation;
using NGsystem.Dents.Application.Common;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Core;

using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.ListPacientes;

public class ListPacienteHandler
{
    private readonly IPacienteService _pacienteService;
    public ListPacienteHandler( IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }
    public async Task<Result<IEnumerable<LisPacienteResponseDto>>> Handle()
    {
        //validación de aplicación
       

        var response = await _pacienteService.ListPacienteDtoAsync();

        return Result<IEnumerable<LisPacienteResponseDto>>.Success(response);
        
    }
}
