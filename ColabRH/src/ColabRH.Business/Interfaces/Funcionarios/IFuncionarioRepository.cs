using ColabRH.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IFuncionarioRepository : IRepository<Funcionario>
{
    Task<IEnumerable<Funcionario>> ObterPorGrupoEconomico(Guid id);
}
