using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IDependenteBeneficioService : IDisposable
{
    Task Adicionar(DependenteBeneficio dependenteBeneficio);
    Task Atualizar(DependenteBeneficio dependenteBeneficio);
    Task Remover(Guid id);
}
