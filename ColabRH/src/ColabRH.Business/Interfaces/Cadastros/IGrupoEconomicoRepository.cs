using ColabRH.Business.Models.Cadastros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IGrupoEconomicoRepository : IRepository<GrupoEconomico>
{
    Task<IEnumerable<GrupoEconomico>> ObterAtivos();
}
