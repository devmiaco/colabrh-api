using ColabRH.Business.Models.Cadastros;
using FluentValidation;

namespace ColabRH.Business.Validations.Cadastros;

public class SindicatoValidation : AbstractValidator<Sindicato>
{
    public SindicatoValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}
