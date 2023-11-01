using ColabRH.Business.Models.Atendimento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Atendimento;

public interface ISolicitacaoRepository : IRepository<Solicitacao>
{
    Task<IEnumerable<Solicitacao>> ObterPorFuncionario(Guid id);
    Task<IEnumerable<Solicitacao>> ObterPorTipo(Guid id);
}
