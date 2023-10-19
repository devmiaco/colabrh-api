using ColabRH.Business.Models.Cadastros;
using FluentValidation;

namespace ColabRH.Business.Validations.Cadastros;

public class GradeValidation : AbstractValidator<Grade>
{
    public GradeValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}
