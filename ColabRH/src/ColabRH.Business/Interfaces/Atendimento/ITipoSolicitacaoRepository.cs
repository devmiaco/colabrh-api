using ColabRH.Business.Models.Atendimento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Atendimento;

public interface ITipoSolicitacaoRepository : IRepository<TipoSolicitacao>
{
    Task<IEnumerable<TipoSolicitacao>> ObterPorGrupoEconomico(Guid id);
    Task<IEnumerable<TipoSolicitacao>> ObterPorCategoria(Guid id);
}
