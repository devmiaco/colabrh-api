using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface ISituacaoRepository : IRepository<Situacao>
{
    Task<IEnumerable<Situacao>> ObterPorGrupoEconomico(Guid id);
}
