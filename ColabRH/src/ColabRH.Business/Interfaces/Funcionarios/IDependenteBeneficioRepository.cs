using ColabRH.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IDependenteBeneficioRepository : IRepository<DependenteBeneficio>
{
    Task<IEnumerable<DependenteBeneficio>> ObterPorDependente(Guid id);
}
