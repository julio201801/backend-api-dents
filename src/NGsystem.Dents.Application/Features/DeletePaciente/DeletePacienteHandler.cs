using FluentValidation;
using NGsystem.Dents.Application.Common;
using NGsystem.Dents.Application.Features.UpdatePacientes;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Core;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace NGsystem.Dents.Application.Features.DeletePaciente;


public class DeletePacienteHandler
{
    private readonly IValidator<PacienteDeleteRequestDto> _validator;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPacienteReadService _pacienteReadService;
    public DeletePacienteHandler(IValidator<PacienteDeleteRequestDto> validator, IPacienteRepository pacienteRepository, IPacienteReadService pacienteReadService)
    {
        _validator = validator;
        _pacienteRepository = pacienteRepository;
        _pacienteReadService = pacienteReadService;
    }

    public async Task<Result<PacienteDeleteResponseDTO>> Handle(PacienteDeleteRequestDto request)
    {
        // Validación asíncrona
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors
                .Select(err => new CustomError(string.Empty, err.ErrorMessage, "Validación")).ToList();
            return Result<PacienteDeleteResponseDTO>.Failure(null, validationErrors);
        }

        // Buscar paciente
        var paciente = await _pacienteReadService.GetIdPacienteDtoAsync(request.Id);
        if (paciente == null)
        {
            return Result<PacienteDeleteResponseDTO>.Failure(new CustomError("Paciente", "No encontrado", "Negocio"), null);
        }
        // Actualizar propiedades
        paciente.MapToDeletePaciente(request);
        // Guardar cambios
        this._pacienteRepository.UpdatePaciente(paciente);
        await _pacienteRepository.UnitOfWork.SaveAsync();
        // Mapear y responder
        var response = paciente.MapToDeletePacienteResponse();
        return Result<PacienteDeleteResponseDTO>.Success(response);
    }
}