using FluentValidation;

namespace NGsystem.Dents.Application.Features.Pacientes.GetPacientes;
public class GetPacienteValidation : AbstractValidator<PacienteRequestDto>
{
    public GetPacienteValidation()
    {
        RuleFor(x => x.dni)
            .NotEmpty()
            .Length(8)
            .Matches(@"^\d{8}$");

    }
}
