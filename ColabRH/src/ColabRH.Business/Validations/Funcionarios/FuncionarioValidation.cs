using ColabRH.Business.Models.Funcionarios;
using FluentValidation;

namespace ColabRH.Business.Validations.Funcionarios;

public class FuncionarioValidation : AbstractValidator<Funcionario>
{
    public FuncionarioValidation()
    {
        
    }
}
