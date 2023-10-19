using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IEmpresaRepository : IRepository<Empresa>
{
    Task<IEnumerable<Empresa>> ObterPorGrupoEconomico(Guid id);
}
