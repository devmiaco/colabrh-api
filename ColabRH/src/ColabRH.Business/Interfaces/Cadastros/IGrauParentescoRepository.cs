using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IGrauParentescoRepository : IRepository<GrauParentesco>
{
    Task<IEnumerable<GrauParentesco>> ObterPorGrupoEconomico(Guid id);
}
