
using FluentValidation;
using NGsystem.Dents.Application.Features.Usuario.CreateUsuario;

namespace NGsystem.Dents.Application.Features.Usuario.auth;

public class LoginValidation : AbstractValidator<LoginRequestDto>
{
    public LoginValidation()
    {      
        RuleFor(x => x.Usuario)
            .NotEmpty().WithMessage("El correo no puede estar vacío")
            .EmailAddress().WithMessage("El correo debe ser válido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("La clave no puede estar vacía")
            .MinimumLength(8).WithMessage("La clave debe tener al menos 8 caracteres")
            .Matches(@"[A-Z]").WithMessage("La clave debe contener al menos una letra mayúscula")
            .Matches(@"[a-z]").WithMessage("La clave debe contener al menos una letra minúscula")
            .Matches(@"\d").WithMessage("La clave debe contener al menos un número")
            .Matches(@"[\@\!\#\$\%\^\&\*\(\)]").WithMessage("La clave debe contener al menos un carácter especial (@!#$%^&*)");
    }
}