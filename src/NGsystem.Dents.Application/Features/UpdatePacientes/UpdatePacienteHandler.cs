using FluentValidation;
using NGsystem.Dents.Application.Common;
using NGsystem.Dents.Application.Features.CreatePaciente;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Core;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.UpdatePacientes;

public class UpdatePacienteHandler
{
    private readonly IValidator<PacienteUpdateRequestDto> _validator;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPacienteReadService _pacienteReadService;
    public UpdatePacienteHandler(IValidator<PacienteUpdateRequestDto> validator, IPacienteRepository pacienteRepository, IPacienteReadService pacienteReadService)
    {
        _validator = validator;
        _pacienteRepository = pacienteRepository;
        _pacienteReadService = pacienteReadService;
    }

    public async Task<Result<PacienteUpdateResponseDTO>> Handle(PacienteUpdateRequestDto request)
    {
        // Validación asíncrona
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors
                .Select(err => new CustomError(string.Empty, err.ErrorMessage, "Validación")).ToList();
            return Result<PacienteUpdateResponseDTO>.Failure(null,validationErrors);
        }

        // Buscar paciente
        var paciente = await _pacienteReadService.GetPacienteDtoAsync(request.Dni);
        if (paciente == null)
        {
            return Result<PacienteUpdateResponseDTO>.Failure(new CustomError("Paciente", "No encontrado", "Negocio"),null);
        }
        // Actualizar propiedades
         paciente.MapToUpdatePaciente(request);
        // Guardar cambios
        this._pacienteRepository.UpdatePaciente(paciente);
        await _pacienteRepository.UnitOfWork.SaveAsync();
        // Mapear y responder
        var response = paciente.MapToUpdatePacienteResponse();
        return Result<PacienteUpdateResponseDTO>.Success(response);
    }
}