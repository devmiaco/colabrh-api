using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IVinculoRepository : IRepository<Vinculo>
{
    Task<IEnumerable<Vinculo>> ObterPorGrupoEconomico(Guid id);
}
