using FluentValidation;

namespace NGsystem.Dents.Application.Features.CreatePaciente;
public class CreatePacienteValidation : AbstractValidator<PacienteCreateRequestDto>
{
    public CreatePacienteValidation()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

        RuleFor(p => p.Apellido)
            .NotEmpty().WithMessage("El apellido es obligatorio.")
            .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.");

        RuleFor(p => p.FechaNacimiento)
            .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
            .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("La fecha de nacimiento debe estar en formato YYYY-MM-DD.");

        RuleFor(p => p.Genero)
            .NotEmpty().WithMessage("El género es obligatorio.")
            .Must(g => g == "Masculino" || g == "Femenino").WithMessage("El género debe ser 'Masculino' o 'Femenino'.");

        RuleFor(p => p.Telefono)
            .NotEmpty().WithMessage("El teléfono es obligatorio.")
            .Matches(@"^\d{9}$").WithMessage("El teléfono debe tener 9 dígitos.");

        RuleFor(p => p.Direccion)
            .NotEmpty().WithMessage("La dirección es obligatoria.")
            .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");

        RuleFor(p => p.Dni)
            .NotEmpty().WithMessage("El DNI es obligatorio.")
            .Matches(@"^\d{8}$").WithMessage("El DNI debe tener 8 dígitos.");
    }
}