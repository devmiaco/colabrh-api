using ColabRH.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IDependenteService : IDisposable
{
    Task Adicionar(Dependente dependente);
    Task Atualizar(Dependente dependente);
    Task Remover(Guid id);
}
