
using FluentValidation;
using NGsystem.Dents.Application.Common;
using NGsystem.Dents.Application.Features.Usuario.CreateUsuario;
using NGsystem.Dents.Application.QueryServices;
using NGsystem.Dents.Core;
using NGsystem.Dents.Domain.Aggregates.UsuarioAggregates;

namespace NGsystem.Dents.Application.Features.Usuario.auth;


public class LoginHandler
{
    private readonly IValidator<LoginRequestDto> _validator;
    private readonly IAuthReadRepository _authReadRepository;
    public LoginHandler(IValidator<LoginRequestDto> validator, IAuthReadRepository authReadRepository)
    {
        _validator = validator;
        _authReadRepository = authReadRepository;
    }
    public async Task<Result<LoginResponseDto>> Handle(LoginRequestDto request)
    {
        //validación de aplicación
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion")).ToList();
            return Result<LoginResponseDto>.Failure(null, validationErrors);
        }

        var response = _authReadRepository.ValidateUsuarioAsunc(request.Usuario,request.Password);
      
        return Result<LoginResponseDto>.Success(response.Result);
    }
}