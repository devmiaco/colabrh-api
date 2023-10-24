using ColabRH.Business.Models.Funcionarios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Funcionarios;

public interface IFuncionarioBeneficioService : IDisposable
{
    Task Adicionar(FuncionarioBeneficio funcionarioBeneficio);
    Task Atualizar(FuncionarioBeneficio funcionarioBeneficio);
    Task Remover(Guid id);
}
