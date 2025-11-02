using FluentValidation;
using NGsystem.Dents.Application.Common;
using NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;
using NGsystem.Dents.Core;
using NGsystem.Dents.Domain.Aggregates.PacienteAggregates;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;

namespace NGsystem.Dents.Application.Features.Usuario.CreateUsuario;
public class CreateUsuarioHandler
{
    private readonly IValidator<UsuarioRequestDto> _validator;
    private readonly IUsuarioRepository _usuarioRepository;
    public CreateUsuarioHandler(IValidator<UsuarioRequestDto> validator, IUsuarioRepository usuarioRepository)
    {
        _validator = validator;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<Result<UsuarioResponseDto>> Handle(UsuarioRequestDto request)
    {
        //validación de aplicación
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion")).ToList();
            return Result<UsuarioResponseDto>.Failure(null, validationErrors);
        }

        var usuario = request.MapToUsuario();
        _usuarioRepository.AddUsers(usuario);
        await _usuarioRepository.UnitOfWork.SaveAsync();
        var response = usuario.MapToUsuarioResponse();

        return Result<UsuarioResponseDto>.Success(response);
    }
}
