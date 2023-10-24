using ColabRH.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IDependenteRepository : IRepository<Dependente>
{
    Task<IEnumerable<Dependente>> ObterPorFuncionario(Guid id);
}
