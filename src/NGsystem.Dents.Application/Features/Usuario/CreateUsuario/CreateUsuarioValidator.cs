
using FluentValidation;
namespace NGsystem.Dents.Application.Features.Usuario.CreateUsuario;

public class CreateUsuarioValidator : AbstractValidator<UsuarioRequestDto>
{
    public CreateUsuarioValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre no puede estar vacío")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres");

        RuleFor(x => x.Correo)
            .NotEmpty().WithMessage("El correo no puede estar vacío")
            .EmailAddress().WithMessage("El correo debe ser válido");

        RuleFor(x => x.Clave)
            .NotEmpty().WithMessage("La clave no puede estar vacía")
            .MinimumLength(8).WithMessage("La clave debe tener al menos 8 caracteres")
            .Matches(@"[A-Z]").WithMessage("La clave debe contener al menos una letra mayúscula")
            .Matches(@"[a-z]").WithMessage("La clave debe contener al menos una letra minúscula")
            .Matches(@"\d").WithMessage("La clave debe contener al menos un número")
            .Matches(@"[\@\!\#\$\%\^\&\*\(\)]").WithMessage("La clave debe contener al menos un carácter especial (@!#$%^&*)");
    }
}