using ColabRH.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IFuncionarioBeneficioRepository : IRepository<FuncionarioBeneficio>
{
    Task<IEnumerable<FuncionarioBeneficio>> ObterPorFuncionario(Guid id);
}
