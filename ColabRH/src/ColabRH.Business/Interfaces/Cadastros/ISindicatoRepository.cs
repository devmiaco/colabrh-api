using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface ISindicatoRepository : IRepository<Sindicato>
{
    Task<IEnumerable<Sindicato>> ObterPorGrupoEconomico(Guid id);
}
