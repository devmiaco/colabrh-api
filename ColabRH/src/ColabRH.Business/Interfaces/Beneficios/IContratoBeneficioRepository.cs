using ColabRH.Business.Models.Beneficios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoBeneficioRepository : IRepository<ContratoBeneficio>
{
    Task<IEnumerable<ContratoBeneficio>> ObterPorGrupoEconomico(Guid id);
}
