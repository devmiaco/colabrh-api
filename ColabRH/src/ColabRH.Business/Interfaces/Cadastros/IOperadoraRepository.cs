using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IOperadoraRepository : IRepository<Operadora>
{
    Task<IEnumerable<Operadora>> ObterPorGrupoEconomico(Guid id);
}
