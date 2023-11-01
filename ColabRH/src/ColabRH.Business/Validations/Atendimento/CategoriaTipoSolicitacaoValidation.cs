using ColabRH.Business.Models.Atendimento;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Validations.Atendimento;

public class CategoriaTipoSolicitacaoValidation : AbstractValidator<CategoriaTipoSolicitacao>
{
    public CategoriaTipoSolicitacaoValidation()
    {
        
    }
}
