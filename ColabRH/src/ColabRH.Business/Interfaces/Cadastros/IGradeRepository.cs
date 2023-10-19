using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IGradeRepository : IRepository<Grade>
{
    Task<IEnumerable<Grade>> ObterPorGrupoEconomico(Guid id);
}
