using FluentValidation;
using NGsystem.Dents.Application.Common;
using NGsystem.Dents.Application.Features.Pacientes.ListPacientes;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Core;

using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.Pacientes.GetPacientes;

public class GetPacienteHandler
{
    private readonly IValidator<PacienteRequestDto> _validator;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPacienteReadService _pacienteService;

    public GetPacienteHandler(IValidator<PacienteRequestDto> validator, IPacienteRepository pacienteRepository, IPacienteReadService pacienteService)
    {
        _validator = validator;
        _pacienteRepository = pacienteRepository;
        _pacienteService = pacienteService;
    }
    public async Task<Result<PacienteResponseDto>> Handle(PacienteRequestDto request)
    {
        //validación de aplicación
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion"));

            return Result<PacienteResponseDto>.Failure(null, validationErrors);
        }

        var response = await _pacienteService.GetPacienteDtoAsync(request.dni);

        return Result<PacienteResponseDto>.Success(response.MapToPacienteItem());

    }
}
