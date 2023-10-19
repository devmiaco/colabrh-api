using ColabRH.Business.Models.Cadastros;
using FluentValidation;

namespace ColabRH.Business.Validations.Cadastros;

public class CargoValidation : AbstractValidator<Cargo>
{
    public CargoValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}
