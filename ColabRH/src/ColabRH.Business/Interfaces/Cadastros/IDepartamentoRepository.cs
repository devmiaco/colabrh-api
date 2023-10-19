using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IDepartamentoRepository : IRepository<Departamento>
{
    Task<IEnumerable<Departamento>> ObterPorGrupoEconomico(Guid id);
}
