using ColabRH.Business.Models.Atendimento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Atendimento;

public interface ICategoriaTipoSolicitacaoRepository : IRepository<CategoriaTipoSolicitacao>
{
    Task<IEnumerable<CategoriaTipoSolicitacao>> ObterPorGrupoEconomico(Guid id);
}
