using ColabRH.Business.Models.Cadastros;
using FluentValidation;

namespace ColabRH.Business.Validations.Cadastros;

public class DepartamentoValidation : AbstractValidator<Departamento>
{
    public DepartamentoValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}
