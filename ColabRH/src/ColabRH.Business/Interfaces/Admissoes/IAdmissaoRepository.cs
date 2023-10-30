using ColabRH.Business.Models.Admissoes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoRepository : IRepository<Admissao>
{
    Task<IEnumerable<Admissao>> ObterPorGrupoEconomico(Guid id);
}
