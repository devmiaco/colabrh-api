using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IOperadoraService : IDisposable
{
    Task Adicionar(Operadora operadora);
    Task Atualizar(Operadora operadora);
    Task Remover(Guid id);
}
