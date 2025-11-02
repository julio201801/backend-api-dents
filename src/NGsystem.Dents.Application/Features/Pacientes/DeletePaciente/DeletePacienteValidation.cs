
using FluentValidation;

namespace NGsystem.Dents.Application.Features.Pacientes.DeletePaciente;

public class DeletePacienteValidation : AbstractValidator<PacienteDeleteRequestDto>
{
    public DeletePacienteValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

    }
}