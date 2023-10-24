using ColabRH.Business.Models.Funcionarios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IFuncionarioService : IDisposable
{
    Task Adicionar(Funcionario funcionario);
    Task Atualizar(Funcionario funcionario);
    Task Remover(Guid id);
}
