using ColabRH.Business.Models.Cadastros;
using FluentValidation;

namespace ColabRH.Business.Validations.Cadastros;

public class EmpresaValidation : AbstractValidator<Empresa>
{
    public EmpresaValidation()
    {
        RuleFor(c => c.Cnpj)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        RuleFor(c => c.RazaoSocial)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        RuleFor(c => c.NomeFantasia)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}
