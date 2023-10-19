using ColabRH.Business.Models.Cadastros;
using FluentValidation;

namespace ColabRH.Business.Validations.Cadastros;

public class GrupoEconomicoValidation : AbstractValidator<GrupoEconomico>
{
    public GrupoEconomicoValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}
